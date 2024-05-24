using MediatR;
using MyRestaurant.Application.Interfaces;

namespace MyRestaurant.Application.Commands.DeleteMenu;

public class DeleteMenuCommandHandler : IRequestHandler<DeleteMenuCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteMenuCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteMenuCommand request, CancellationToken cancellationToken)
    {
        var menu = await _unitOfWork.Menus.GetByIdAsync(request.Id);

        if (menu == null)
        {
            throw new Exception("Menu not found");
        }

        _unitOfWork.Menus.Delete(menu);
        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}