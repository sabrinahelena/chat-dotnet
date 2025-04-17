using MediatR;

namespace Application.UseCases.Messages.Commands.SendMessageToUser;

public record SendMessageToUserCommand(Guid SenderId, Guid ReceiverId, string Content)
    : IRequest<SendMessageToUserResponse>;
