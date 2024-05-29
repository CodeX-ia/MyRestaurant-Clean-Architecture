using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRestaurant.Application.Commands.DeleteMenuItem;

public class DeleteMenuItemCommand : IRequest
{
    public Guid MenuId { get; set; }
    public Guid Id { get; set; }
}
