using MediatR;
using MyRestaurant.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRestaurant.Application.Queries.GetAllMenus;

public class GetAllMenusQuery : IRequest<IEnumerable<MenuResponse>>
{
}