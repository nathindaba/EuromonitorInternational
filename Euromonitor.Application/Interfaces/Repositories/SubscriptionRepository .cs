using Euromonitor.Application.Infrastructure.Persistence;
using Euromonitor.Application.Infrastructure.Repositories;
using Euromonitor.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Euromonitor.Application.Interfaces.Repositories;

public class SubscriptionRepository : ISubscriptionRepository
{
    private readonly AppDbContext _context;

    public SubscriptionRepository(AppDbContext context)
    {
        _context = context;
    }

    // Subscribe a user to a book
    public async Task SubscribeAsync(int userId, int bookId)
    {
        var subscription = new Subscription
        {
            UserId = userId,
            BookId = bookId,
            SubscribedOn = DateTime.UtcNow
        };

        _context.Subscriptions.Add(subscription);
        await _context.SaveChangesAsync();
    }

    // Unsubscribe a user from a book
    public async Task UnsubscribeAsync(int userId, int bookId)
    {
        var subscription = await _context.Subscriptions
            .FirstOrDefaultAsync(s => s.UserId == userId && s.BookId == bookId);

        if (subscription != null)
        {
            _context.Subscriptions.Remove(subscription);
            await _context.SaveChangesAsync();
        }
    }

    // Get all subscriptions for a user
    public async Task<IEnumerable<Book>> GetUserSubscriptionsAsync(int userId)
    {
        return await _context.Subscriptions
            .Where(s => s.UserId == userId)
            .Include(s => s.Book)
            .Select(s => s.Book)
            .ToListAsync();
    }

    // Get all subscribers for a book
    public async Task<IEnumerable<User>> GetBookSubscribersAsync(int bookId)
    {
        return await _context.Subscriptions
            .Where(s => s.BookId == bookId)
            .Include(s => s.User)
            .Select(s => s.User)
            .ToListAsync();
    }
}
