namespace Application.UseCases.Messages.Queries.DTOs;

/// <summary>
/// Data Transfer Object (DTO) representing a message.
/// This DTO contains the details of a message, including the message ID, sender's ID, content, and the timestamp of when the message was sent.
/// </summary>
public record MessageDto(Guid Id, Guid SenderId, string Content, DateTime SentAt);