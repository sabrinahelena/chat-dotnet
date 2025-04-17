using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.UseCases.Messages.Commands.SendMessageToGroupChat;

public class SendMessageToGroupChatHandler(IMessageRepository repository) : IRequestHandler<SendMessageToGroupChatCommand, SendMessageToGroupChatResponse>
{
    public async Task<SendMessageToGroupChatResponse> Handle(
        SendMessageToGroupChatCommand cmd,
        CancellationToken cancellationToken)
    {
        var message = new MessageEntity
        {
            Content = cmd.Content,
            SentAt = DateTime.UtcNow,
            SenderId = cmd.SenderId,
            ReceiverId = null,
            GroupChatId = cmd.RoomId
        };

        await repository.AddAsync(message, cancellationToken);
        await repository.UnitOfWork.CommitAsync(cancellationToken);

        return new SendMessageToGroupChatResponse(true, message.Id);
    }
}