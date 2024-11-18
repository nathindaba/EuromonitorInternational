using Euromonitor.Application.Common.Responses;
using MediatR;

namespace Euromonitor.Application.Features.Subscriptions.Commands.SubscribeToBook;
public record SubscribeToBookCommand(int UserId, int BookId) : IRequest<Response<string>>;
