using Application.UseCases.GroupChats.Dtos;
using Application.UseCases.Messages.Commands.SendMessageToGroupChat;
using Application.UseCases.Messages.Commands.SendMessageToUser;
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
    public async Task<ActionResult<SendMessageToUserResponse>> SendDirectMessage(Guid receiverId,
        [FromBody] SendMessageToUserCommand command, CancellationToken cancellationToken)
    {
        var cmd = new SendMessageToUserCommand(command.SenderId, receiverId, command.Content);
        var result = await mediator.Send(cmd, cancellationToken);

        if (!result.Success)
            return BadRequest(new { Message = "Não foi possível enviar a mensagem." });

        return Ok(result);
    }
}