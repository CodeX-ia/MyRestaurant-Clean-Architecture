using MediatR;
using MyRestaurant.Application.Interfaces;
using MyRestaurant.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRestaurant.Application.Queries.GetMenuById;

public class GetMenuByIdQuery : IRequest<MenuResponse>
{
    public Guid Id { get; set; }

    public GetMenuByIdQuery(Guid id)
    {
        Id = id;
    }
}