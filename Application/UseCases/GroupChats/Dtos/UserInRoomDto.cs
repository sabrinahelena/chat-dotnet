namespace Application.UseCases.GroupChats.Dtos;

/// <summary>
/// Data Transfer Object (DTO) representing a user in a group chat room.
/// This DTO contains the user's unique identifier.
/// </summary>
public record UserInRoomDto
{
    /// <summary>
    /// The unique identifier of the user in the group chat room.
    /// </summary>
    public Guid UserId { get; init; }

    /// <summary>
    /// Initializes a new instance of the <see cref="UserInRoomDto"/> class.
    /// </summary>
    /// <param name="UserId">The unique identifier of the user in the group chat room.</param>
    public UserInRoomDto(Guid UserId)
    {
        this.UserId = UserId;
    }
}