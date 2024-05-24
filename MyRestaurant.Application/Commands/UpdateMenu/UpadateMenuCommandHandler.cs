using Mapster;
using MediatR;
using MyRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRestaurant.Application.Commands.UpdateMenu;

public class UpdateMenuCommandHandler : IRequestHandler<UpdateMenuCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateMenuCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateMenuCommand request, CancellationToken cancellationToken)
    {
        var menu = await _unitOfWork.Menus.GetByIdAsync(request.Id);

        if (menu == null)
        {
            throw new Exception("Menu not found");
        }

        request.Adapt(menu);

        _unitOfWork.Menus.Update(menu);
        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}