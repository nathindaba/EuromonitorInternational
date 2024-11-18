using Euromonitor.Application.Common.Responses;
using MediatR;

namespace Euromonitor.Application.Features.Subscriptions.Commands.UnsubscribeFromBook;

public record UnsubscribeFromBookCommand(int UserId, int BookId) : IRequest<Response<string>>;
