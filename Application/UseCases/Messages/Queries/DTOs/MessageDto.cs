namespace Application.UseCases.Messages.Queries.DTOs;

public record MessageDto(Guid Id, Guid SenderId, string Content, DateTime SentAt);
