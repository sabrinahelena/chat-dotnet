using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.UseCases.Messages.Commands.SendMessageToUser;

public class SendMessageToUserHandler(IMessageRepository repository) : IRequestHandler<SendMessageToUserCommand, SendMessageToUserResponse>
{
    public async Task<SendMessageToUserResponse> Handle(
        SendMessageToUserCommand cmd,
        CancellationToken cancellationToken)
    {
        var message = new MessageEntity
        {
            Content = cmd.Content,
            SentAt = DateTime.UtcNow,
            SenderId = cmd.SenderId,
            ReceiverId = cmd.ReceiverId,
            GroupChatId = null
        };

        await repository.AddAsync(message, cancellationToken);
        await repository.UnitOfWork.CommitAsync(cancellationToken);

        return new SendMessageToUserResponse(true, message.Id);
    }
}