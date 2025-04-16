using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Controllers;

[ApiController]
[Route("messages")]
public class MessagesController(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// Send a direct message to a specific user.
    /// </summary>
    /// <param name="receiverId">The ID of the user receiving the message.</param>
    /// <returns>Returns the result of sending the direct message.</returns>
    [HttpPost("direct/{receiverId:guid}")]
    public Task<ActionResult> SendDirectMessage(Guid receiverId)
    {
        // Logic to send direct message
        throw new NotImplementedException();
    }
}