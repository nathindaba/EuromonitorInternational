using Euromonitor.Application.Common.Responses;
using Euromonitor.Application.Interfaces.Repositories;
using Euromonitor.Domain.Entities;
using MediatR;
using System.Net;

namespace Euromonitor.Application.Features.Users.Commands.RegisterUser;

public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, Response<int>>
{
    private readonly IUserRepository _userRepository;

    public RegisterUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Response<int>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email
        };

        await _userRepository.AddAsync(user);
        return new Response<int>(user.Id, HttpStatusCode.Created, "User registered successfully");
    }
}

