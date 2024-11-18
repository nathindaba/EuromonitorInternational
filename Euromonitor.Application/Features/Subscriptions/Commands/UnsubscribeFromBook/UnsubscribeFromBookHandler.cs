using Euromonitor.Application.Common.Responses;
using Euromonitor.Application.Interfaces.Repositories;
using MediatR;
using System.Net;

namespace Euromonitor.Application.Features.Subscriptions.Commands.UnsubscribeFromBook;

public class UnsubscribeFromBookHandler : IRequestHandler<UnsubscribeFromBookCommand, Response<string>>
{
    private readonly IUserRepository _userRepository;
    private readonly IBookRepository _bookRepository;

    public UnsubscribeFromBookHandler(IUserRepository userRepository, IBookRepository bookRepository)
    {
        _userRepository = userRepository;
        _bookRepository = bookRepository;
    }

    public async Task<Response<string>> Handle(UnsubscribeFromBookCommand request, CancellationToken cancellationToken)
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

        // Step 3: Check if the user is subscribed to the book
        var subscription = user.Subscriptions.FirstOrDefault(b => b.Id == book.Id);
        if (subscription == null)
        {
            return new Response<string>(null, HttpStatusCode.BadRequest, "User is not subscribed to this book.");
        }

        // Step 4: Remove the subscription
        user.Subscriptions.Remove(subscription);

        // Step 5: Update the user in the repository
        await _userRepository.UpdateAsync(user);

        // Step 6: Return success response
        return new Response<string>("Unsubscription successful.", HttpStatusCode.OK);
    }
}
