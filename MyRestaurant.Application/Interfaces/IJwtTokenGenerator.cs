﻿using MyRestaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRestaurant.Application.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
