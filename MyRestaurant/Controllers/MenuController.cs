using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyRestaurant.Application.Commands.CreateMenu;
using MyRestaurant.Application.Commands.CreateMenuItem;
using MyRestaurant.Application.Commands.DeleteMenuItem;
using MyRestaurant.Application.Commands.UpdateMenuItem;
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

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MenuResponse>>> GetAllMenus()
    {
        var query = new GetAllMenusQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MenuResponse>> GetMenuById(Guid id)
    {
        var query = new GetMenuByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateMenu(CreateMenuCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPost("{menuId}/items")]
    public async Task<ActionResult<Guid>> CreateMenuItem(Guid menuId, CreateMenuItemCommand command)
    {
        command.MenuId = menuId;
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{menuId}/items/{itemId}")]
    public async Task<IActionResult> UpdateMenuItem(Guid menuId, Guid itemId, UpdateMenuItemCommand command)
    {
        command.MenuId = menuId;
        command.Id = itemId;
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{menuId}/items/{itemId}")]
    public async Task<IActionResult> DeleteMenuItem(Guid menuId, Guid itemId)
    {
        var command = new DeleteMenuItemCommand { MenuId = menuId, Id = itemId };
        await _mediator.Send(command);
        return NoContent();
    }
}