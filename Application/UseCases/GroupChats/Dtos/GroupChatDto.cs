namespace Application.UseCases.GroupChats.Dtos;
public record GroupChatDto(Guid Id, DateTime CreatedAt, int MemberCount);