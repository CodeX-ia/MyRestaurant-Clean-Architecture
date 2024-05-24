using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyRestaurant.Api.Models;
using MyRestaurant.Application.Commands.LoginUser;
using MyRestaurant.Application.Commands.RegisterUser;

namespace MyRestaurant.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IMediator _mediator;

    public AccountController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var command = new RegisterUserCommand
        {
            Username = request.Username,
            Email = request.Email,
            Password = request.Password
        };

        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var command = new LoginUserCommand
        {
            Username = request.Username,
            Password = request.Password
        };

        var result = await _mediator.Send(command);

        return Ok(result);
    }
}