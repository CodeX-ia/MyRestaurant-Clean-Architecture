using Mapster;
using MediatR;
using MyRestaurant.Application.Interfaces;
using MyRestaurant.Domain.Entities;

namespace MyRestaurant.Application.Commands.CreateMenu;

public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateMenuCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        var menu = request.Adapt<Menu>();
        await _unitOfWork.Menus.AddAsync(menu);
        await _unitOfWork.CommitAsync();
        return menu.Id;
    }
}