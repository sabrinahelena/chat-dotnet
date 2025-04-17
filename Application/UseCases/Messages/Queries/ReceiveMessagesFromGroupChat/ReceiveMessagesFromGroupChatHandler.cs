using Application.UseCases.Messages.Queries.DTOs;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.UseCases.Messages.Queries.ReceiveMessagesFromGroupChat;

public class ReceiveMessagesFromGroupChatHandler(IMessageRepository repository) : IRequestHandler<ReceiveMessagesFromGroupChatQuery, ReceiveMessagesFromGroupChatResponse>
{
    public async Task<ReceiveMessagesFromGroupChatResponse> Handle(
        ReceiveMessagesFromGroupChatQuery query,
        CancellationToken cancellationToken)
    {
        var msgs = await repository.GetMessagesByGroupChatAsync(query.RoomId, cancellationToken);
        return new ReceiveMessagesFromGroupChatResponse(msgs.Select(m =>
            new MessageDto(m.Id.GetValueOrDefault(), m.SenderId, m.Content, m.SentAt)));
    }
}