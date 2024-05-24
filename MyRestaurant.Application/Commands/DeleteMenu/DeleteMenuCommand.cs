using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRestaurant.Application.Commands.DeleteMenu;

public class DeleteMenuCommand : IRequest
{
    public Guid Id { get; set; }
}
