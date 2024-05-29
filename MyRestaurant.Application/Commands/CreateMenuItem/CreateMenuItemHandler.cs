using Mapster;
using MediatR;
using MyRestaurant.Application.Interfaces;
using MyRestaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRestaurant.Application.Commands.CreateMenuItem;

public class CreateMenuItemCommandHandler : IRequestHandler<CreateMenuItemCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateMenuItemCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateMenuItemCommand request, CancellationToken cancellationToken)
    {
        var menu = await _unitOfWork.Menus.GetByIdAsync(request.MenuId);
        if (menu == null) throw new Exception("Menu not found");

        var menuItem = request.Adapt<MenuItem>();
        menu.Items.Add(menuItem);

        await _unitOfWork.Menus.UpdateAsync(menu);
        await _unitOfWork.CommitAsync();

        return menuItem.Id;
    }
}