using MediatR;
using MyRestaurant.Application.Commands.UpdateMenuItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRestaurant.Application.Commands.UpdateMenu;
public class UpdateMenuCommand : IRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<UpdateMenuItemCommand> Items { get; set; }
}
