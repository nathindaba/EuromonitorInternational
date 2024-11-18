using AutoMapper;
using Euromonitor.Application.Common.Responses;
using Euromonitor.Application.DTOs;
using Euromonitor.Application.Features.Users.Queries.GetUser;
using Euromonitor.Application.Interfaces.Repositories;
using MediatR;
using System.Net;

public class GetUserHandler : IRequestHandler<GetUserQuery, Response<UserDto>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetUserHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<Response<UserDto>> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId);
        if (user == null)
            return new Response<UserDto>(null, HttpStatusCode.NotFound, "User not found");

        var userDto = _mapper.Map<UserDto>(user);
        return new Response<UserDto>(userDto);
    }
}
