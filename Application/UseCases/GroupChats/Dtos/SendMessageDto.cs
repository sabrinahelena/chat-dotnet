namespace Application.UseCases.GroupChats.Dtos;

/// <summary>
/// Data Transfer Object (DTO) representing a message to be sent in a group chat.
/// This DTO contains the sender's unique identifier and the content of the message.
/// </summary>
public record SendMessageDto
{
    /// <summary>
    /// The unique identifier of the sender of the message.
    /// </summary>
    public Guid SenderId { get; init; }

    /// <summary>
    /// The content (text) of the message to be sent.
    /// </summary>
    public string Content { get; init; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SendMessageDto"/> class.
    /// </summary>
    /// <param name="SenderId">The unique identifier of the sender.</param>
    /// <param name="Content">The content of the message to be sent.</param>
    public SendMessageDto(Guid SenderId, string Content)
    {
        this.SenderId = SenderId;
        this.Content = Content;
    }
}