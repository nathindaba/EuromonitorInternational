using Euromonitor.Application.Common.Responses;
using Euromonitor.Application.DTOs;
using MediatR;

namespace Euromonitor.Application.Features.Users.Queries.GetUser;

public record GetUserQuery(int UserId) : IRequest<Response<UserDto>>;
