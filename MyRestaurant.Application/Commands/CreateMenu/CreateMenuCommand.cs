﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRestaurant.Application.Commands.CreateMenu;

public class CreateMenuCommand : IRequest<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }
}
