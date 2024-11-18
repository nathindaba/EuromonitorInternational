namespace Euromonitor.Application.API.Controllers;

using Microsoft.AspNetCore.Mvc;
using Application.Features.Subscriptions.Commands.SubscribeToBook;
using Application.Features.Subscriptions.Commands.UnsubscribeFromBook;
using MediatR;

[ApiController]
[Route("api/[controller]")]
public class SubscriptionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public SubscriptionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("subscribe")]
    public async Task<IActionResult> SubscribeToBook([FromBody] SubscribeToBookCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPost("unsubscribe")]
    public async Task<IActionResult> UnsubscribeFromBook([FromBody] UnsubscribeFromBookCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}
