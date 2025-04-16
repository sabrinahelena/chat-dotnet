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
    public async Task<ActionResult> CreateRoom()
    {
        // Logic to create room
        return Ok();
    }

    /// <summary>
    /// Delete a specific chat room by ID.
    /// </summary>
    /// <param name="roomId">The ID of the room to delete.</param>
    /// <returns>No content if the room is deleted.</returns>
    [HttpDelete("{roomId:guid}")]
    public async Task<ActionResult> DeleteRoom(Guid roomId)
    {
        // Logic to delete room
        return NoContent();
    }

    /// <summary>
    /// Join a chat room by room ID.
    /// </summary>
    /// <param name="roomId">The ID of the room to join.</param>
    /// <returns>Returns confirmation of join action.</returns>
    [HttpPost("{roomId:guid}/enter")]
    public async Task<ActionResult> JoinRoom(Guid roomId)
    {
        // Logic to join room
        return Ok();
    }

    /// <summary>
    /// Leave a chat room by room ID.
    /// </summary>
    /// <param name="roomId">The ID of the room to leave.</param>
    /// <returns>Returns confirmation of leave action.</returns>
    [HttpPost("{roomId:guid}/leave")]
    public async Task<ActionResult> LeaveRoom(Guid roomId)
    {
        // Logic to leave room
        return Ok();
    }

    /// <summary>
    /// Remove a user from a specific chat room.
    /// </summary>
    /// <param name="roomId">The ID of the room.</param>
    /// <param name="userId">The ID of the user to remove.</param>
    /// <returns>No content if user is removed successfully.</returns>
    [HttpDelete("{roomId:guid}/users/{userId:guid}")]
    public async Task<ActionResult> RemoveUserFromRoom(Guid roomId, Guid userId)
    {
        // Logic to remove user from room
        return NoContent();
    }

    /// <summary>
    /// Send a message to a chat room.
    /// </summary>
    /// <param name="roomId">The ID of the chat room.</param>
    /// <returns>Returns the result of sending the message to the room.</returns>
    [HttpPost("{roomId:guid}/messages")]
    public Task<ActionResult> SendMessageToRoom(Guid roomId)
    {
        // Logic to send message to room
        throw new NotImplementedException();
    }

    /// <summary>
    /// Get all messages from a chat room.
    /// </summary>
    /// <param name="roomId">The ID of the chat room.</param>
    /// <returns>Returns the list of messages from the room.</returns>
    [HttpGet("{roomId:guid}/messages")]
    public Task<ActionResult> GetMessagesFromRoom(Guid roomId)
    {
        // Logic to retrieve message history from room
        throw new NotImplementedException();
    }
}