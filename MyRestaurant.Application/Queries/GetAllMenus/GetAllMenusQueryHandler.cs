using Mapster;
using MediatR;
using MyRestaurant.Application.Interfaces;
using MyRestaurant.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRestaurant.Application.Queries.GetAllMenus;

public class GetAllMenusQueryHandler : IRequestHandler<GetAllMenusQuery, IEnumerable<MenuResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllMenusQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<MenuResponse>> Handle(GetAllMenusQuery request, CancellationToken cancellationToken)
    {
        var menus = await _unitOfWork.Menus.GetAllAsync();
        return menus.Adapt<IEnumerable<MenuResponse>>();
    }
}