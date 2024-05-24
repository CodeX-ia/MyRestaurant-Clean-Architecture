using MyRestaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRestaurant.Application.Response;

public class AuthenticationResult
{
    public User User { get; }
    public string Token { get; }

    public AuthenticationResult(User user, string token)
    {
        User = user;
        Token = token;
    }
}
