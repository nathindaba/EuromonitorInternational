using Euromonitor.Application.Common.Responses;
using MediatR;

namespace Euromonitor.Application.Features.Users.Commands.RegisterUser;

public record RegisterUserCommand(string FirstName, string LastName, string Email) : IRequest<Response<int>>;