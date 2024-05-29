using Mapster;
using MediatR;
using MyRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRestaurant.Application.Commands.UpdateMenuItem;

public class UpdateMenuItemCommandHandler : IRequestHandler<UpdateMenuItemCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateMenuItemCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateMenuItemCommand request, CancellationToken cancellationToken)
    {
        var menu = await _unitOfWork.Menus.GetByIdAsync(request.MenuId);
        //if (menu == null) throw new Exception("Menu not found");


        if (menu == null)
        {
            throw new Exception("Menu not found");
        }

        var menuItem = menu.Items.FirstOrDefault(item => item.Id == request.Id);


        if (menuItem == null)
        {
            throw new Exception("Menu item not found");
        }


        //if (menuItem == null) throw new Exception("Menu item not found");

        //request.Adapt(menuItem);

        //await _unitOfWork.Menus.UpdateAsync(menu);
        menuItem.Name = request.Name;
        menuItem.Description = request.Description;
        menuItem.Price = request.Price;

        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}