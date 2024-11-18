using Euromonitor.Domain.Entities;

namespace Euromonitor.Application.Infrastructure.Repositories;
public interface ISubscriptionRepository
{
    Task SubscribeAsync(int userId, int bookId);
    Task UnsubscribeAsync(int userId, int bookId);
    Task<IEnumerable<Book>> GetUserSubscriptionsAsync(int userId);
    Task<IEnumerable<User>> GetBookSubscribersAsync(int bookId);
}
