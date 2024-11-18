using Euromonitor.Domain.Entities;

namespace Euromonitor.Application.Infrastructure.Persistence;

public static class DbInitializer
{
    public static void Seed(AppDbContext context)
    {
        // Ensure database is created
        context.Database.EnsureCreated();

        // Seed Users
        if (!context.Users.Any())
        {
            var users = new List<User>
            {
                new() {
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@example.com",
                    Subscriptions = []
                },
                new() {
                    FirstName = "Jane",
                    LastName = "Smith",
                    Email = "jane.smith@example.com",
                    Subscriptions = []
                }
            };

            context.Users.AddRange(users);
        }

        // Seed Books
        if (!context.Books.Any())
        {
            var books = new List<Book>
            {
                new Book { Name = "Book A", PurchasePrice = 19.99M },
                new Book { Name = "Book B", PurchasePrice = 29.99M }
            };

            context.Books.AddRange(books);
        }

        context.SaveChanges();
    }
}
