namespace Euromonitor.Application.API.Controllers;

using Microsoft.AspNetCore.Mvc;
using Application.Features.Users.Commands.RegisterUser;
using Euromonitor.Application.Features.Users.Queries.GetUser;
using MediatR;
using System.Runtime.InteropServices;


[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterUserCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(int id)
    {
        // Logic for fetching user by ID
        return Ok(await _mediator.Send(new GetUserQuery(id)));
    }
}