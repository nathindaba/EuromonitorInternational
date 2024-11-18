using Euromonitor.Application.Common.Responses;
using Euromonitor.Application.Interfaces.Repositories;
using MediatR;
using System.Net;

namespace Euromonitor.Application.Features.Subscriptions.Commands.SubscribeToBook;
public class SubscribeToBookHandler : IRequestHandler<SubscribeToBookCommand, Response<string>>
{
    private readonly IUserRepository _userRepository;
    private readonly IBookRepository _bookRepository;

    public SubscribeToBookHandler(IUserRepository userRepository, IBookRepository bookRepository)
    {
        _userRepository = userRepository;
        _bookRepository = bookRepository;
    }

    public async Task<Response<string>> Handle(SubscribeToBookCommand request, CancellationToken cancellationToken)
    {
        // Step 1: Fetch the user
        var user = await _userRepository.GetByIdAsync(request.UserId);
        if (user == null)
        {
            return new Response<string>(null, HttpStatusCode.NotFound, "User not found.");
        }

        // Step 2: Fetch the book
        var book = await _bookRepository.GetByIdAsync(request.BookId);
        if (book == null)
        {
            return new Response<string>(null, HttpStatusCode.NotFound, "Book not found.");
        }

        // Step 3: Check if the user is already subscribed
        if (user.Subscriptions.Any(b => b.Id == book.Id))
        {
            return new Response<string>(null, HttpStatusCode.Conflict, "User is already subscribed to this book.");
        }

        // Step 4: Add the book to the user's subscriptions
        user.Subscriptions.Add(book);

        // Step 5: Update the user in the repository
        await _userRepository.UpdateAsync(user);

        // Step 6: Return success response
        return new Response<string>("Subscription successful.", HttpStatusCode.OK);
    }
}

