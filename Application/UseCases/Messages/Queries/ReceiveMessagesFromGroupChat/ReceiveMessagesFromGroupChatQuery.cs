using MediatR;

namespace Application.UseCases.Messages.Queries.ReceiveMessagesFromGroupChat;

public record ReceiveMessagesFromGroupChatQuery(Guid RoomId)
    : IRequest<ReceiveMessagesFromGroupChatResponse>;