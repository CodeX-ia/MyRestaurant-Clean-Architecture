using Mapster;
using MediatR;
using MyRestaurant.Application.Interfaces;
using MyRestaurant.Application.Response;

namespace MyRestaurant.Application.Queries.GetMenuById;

public class GetMenuByIdQueryHandler : IRequestHandler<GetMenuByIdQuery, MenuResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetMenuByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<MenuResponse> Handle(GetMenuByIdQuery request, CancellationToken cancellationToken)
    {
        var menu = await _unitOfWork.Menus.GetByIdAsync(request.Id);
        return menu.Adapt<MenuResponse>();
    }
}