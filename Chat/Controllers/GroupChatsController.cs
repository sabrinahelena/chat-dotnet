using Application.UseCases.GroupChats.Commands.CreateGroupChat;
using Application.UseCases.GroupChats.Commands.DeleteGroupChat;
using Application.UseCases.GroupChats.Commands.JoinGroupChat;
using Application.UseCases.GroupChats.Commands.LeaveGroupChat;
using Application.UseCases.GroupChats.Commands.RemoveUserFromGroupChat;
using Application.UseCases.GroupChats.Dtos;
using Application.UseCases.GroupChats.Queries.GetGroupChats;
using Application.UseCases.Messages.Commands.SendMessageToGroupChat;
using Application.UseCases.Messages.Queries.DTOs;
using Application.UseCases.Messages.Queries.ReceiveMessagesFromGroupChat;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Controllers;

[ApiController]
[Route("rooms")]
public class GroupChatsController(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// Create a new chat room.
    /// </summary>
    /// <returns>Returns the details of the newly created room.</returns>
    [HttpPost]
    public async Task<ActionResult<CreateGroupChatResponse>> CreateRoom(CancellationToken cancellationToken)
        => Ok(await mediator.Send(new CreateGroupChatCommand(), cancellationToken));


    /// <summary>
    /// Delete a specific chat room by ID.
    /// </summary>
    /// <param name="roomId">The ID of the room to delete.</param>
    /// <returns>No content if the room is deleted.</returns>
    [HttpDelete("{roomId:guid}")]
    public async Task<ActionResult> DeleteRoom(Guid roomId, CancellationToken cancellationToken)
    {
        var res = await mediator.Send(new DeleteGroupChatCommand(roomId), cancellationToken);
        return res.Success ? NoContent() : NotFound();
    }

    /// <summary>
    /// Endpoint to retrieve a list of all group chat rooms.
    /// This method processes a GET request to retrieve all the available group chat rooms.
    /// It triggers the <see cref="ListGroupChatsQuery"/> to fetch the data and return a list of group chat details.
    /// </summary>
    /// <param name="ct">The cancellation token to monitor for request cancellation.</param>
    /// <returns>An <see cref="IEnumerable{GroupChatDto}"/> containing a list of group chat rooms as <see cref="GroupChatDto"/> objects.</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GroupChatDto>>> ListRooms(CancellationToken ct)
        => Ok(await mediator.Send(new ListGroupChatsQuery(), ct));

    /// <summary>
    /// Join a chat room by room ID.
    /// </summary>
    /// <param name="roomId">The ID of the room to join.</param>
    /// <returns>Returns confirmation of join action.</returns>
    [HttpPost("{roomId:guid}/enter")]
    public async Task<IActionResult> JoinRoom(
        Guid roomId,
        [FromBody] UserInRoomDto dto,
        CancellationToken ct)
    {
        var res = await mediator.Send(new JoinGroupChatCommand(roomId, dto.UserId), ct);
        return res.Success ? Ok() : BadRequest();
    }

    /// <summary>
    /// Leave a chat room by room ID.
    /// </summary>
    /// <param name="roomId">The ID of the room to leave.</param>
    /// <returns>Returns confirmation of leave action.</returns>
    [HttpPost("{roomId:guid}/leave")]
    public async Task<IActionResult> LeaveRoom(
        Guid roomId,
        [FromBody] UserInRoomDto dto,
        CancellationToken ct)
    {
        var res = await mediator.Send(new LeaveGroupChatCommand(roomId, dto.UserId), ct);
        return res.Success ? Ok() : BadRequest();
    }

    /// <summary>
    /// Remove a user from a specific chat room.
    /// </summary>
    /// <param name="roomId">The ID of the room.</param>
    /// <param name="userId">The ID of the user to remove.</param>
    /// <returns>No content if user is removed successfully.</returns>
    [HttpDelete("{roomId:guid}/users/{userId:guid}")]
    public async Task<IActionResult> RemoveUserFromRoom(
        Guid roomId, Guid userId, CancellationToken ct)
    {
        var res = await mediator.Send(
            new RemoveUserFromGroupChatCommand(roomId, userId), ct);
        return res.Success ? NoContent() : BadRequest();
    }

    /// <summary>
    /// Send a message to a chat room.
    /// </summary>
    /// <param name="roomId">The ID of the chat room.</param>
    /// <returns>Returns the result of sending the message to the room.</returns>
    [HttpPost("{roomId:guid}/messages")]
    public async Task<ActionResult<SendMessageToGroupChatResponse>> SendMessageToRoom(
        Guid roomId,
        [FromBody] SendMessageDto dto,
        CancellationToken cancellationToken)
    {
        var cmd = new SendMessageToGroupChatCommand(dto.SenderId, roomId, dto.Content);
        var result = await mediator.Send(cmd, cancellationToken);

        if (!result.Success)
            return BadRequest(new { Message = "Não foi possível enviar a mensagem." });

        return Ok(result);
    }

    /// <summary>
    /// Get all messages from a chat room.
    /// </summary>
    /// <param name="roomId">The ID of the chat room.</param>
    /// <returns>Returns the list of messages from the room.</returns>
    [HttpGet("{roomId:guid}/messages")]
    public async Task<ActionResult<IEnumerable<MessageDto>>> GetMessagesFromRoom(
        Guid roomId,
        CancellationToken cancellationToken)
    {
        var query = new ReceiveMessagesFromGroupChatQuery(roomId);
        var messages = await mediator.Send(query, cancellationToken);
        return Ok(messages);
    }
}