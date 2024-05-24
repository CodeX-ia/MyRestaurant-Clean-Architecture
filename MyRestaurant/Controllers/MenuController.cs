using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyRestaurant.Application.Commands.CreateMenu;
using MyRestaurant.Application.Commands.DeleteMenu;
using MyRestaurant.Application.Commands.UpdateMenu;
using MyRestaurant.Application.Queries.GetAllMenus;
using MyRestaurant.Application.Queries.GetMenuById;
using MyRestaurant.Application.Response;

namespace MyRestaurant.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MenuController : ControllerBase
{
    private readonly IMediator _mediator;

    public MenuController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MenuResponse>> GetById(Guid id)
    {
        var query = new GetMenuByIdQuery { Id = id };
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MenuResponse>>> GetAll()
    {
        var query = new GetAllMenusQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateMenuCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] UpdateMenuCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest("Id mismatch");
        }

        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var command = new DeleteMenuCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}