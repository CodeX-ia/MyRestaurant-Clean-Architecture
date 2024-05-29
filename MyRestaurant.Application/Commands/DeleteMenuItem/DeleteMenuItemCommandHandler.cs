using MediatR;
using MyRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRestaurant.Application.Commands.DeleteMenuItem;

public class DeleteMenuItemCommandHandler : IRequestHandler<DeleteMenuItemCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteMenuItemCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteMenuItemCommand request, CancellationToken cancellationToken)
    {
        var menu = await _unitOfWork.Menus.GetByIdAsync(request.MenuId);
        if (menu == null) throw new Exception("Menu not found");

        var menuItem = menu.Items.FirstOrDefault(item => item.Id == request.Id);
        if (menuItem == null) throw new Exception("Menu item not found");

        menu.Items.Remove(menuItem);

        await _unitOfWork.Menus.UpdateAsync(menu);
        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}