namespace Application.UseCases.GroupChats.Dtos;

/// <summary>
/// Data Transfer Object (DTO) representing a group chat.
/// This DTO contains the basic details of a group chat, including the ID, creation date,
/// and the number of members in the chat.
/// </summary>
public record GroupChatDto
{
    /// <summary>
    /// The unique identifier of the group chat.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// The date and time when the group chat was created.
    /// </summary>
    public DateTime CreatedAt { get; init; }

    /// <summary>
    /// The number of members currently in the group chat.
    /// </summary>
    public int MemberCount { get; init; }

    /// <summary>
    /// Initializes a new instance of the <see cref="GroupChatDto"/> class.
    /// </summary>
    /// <param name="Id">The unique identifier of the group chat.</param>
    /// <param name="CreatedAt">The creation date and time of the group chat.</param>
    /// <param name="MemberCount">The number of members in the group chat.</param>
    public GroupChatDto(Guid Id, DateTime CreatedAt, int MemberCount)
    {
        this.Id = Id;
        this.CreatedAt = CreatedAt;
        this.MemberCount = MemberCount;
    }
}