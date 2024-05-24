using MediatR;
using MyRestaurant.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRestaurant.Application.Commands.LoginUser;

public class LoginUserCommand : IRequest<AuthenticationResult>
{
    public string Username { get; set; }
    public string Password { get; set; }
}
