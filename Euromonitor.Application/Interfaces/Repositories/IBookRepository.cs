using Euromonitor.Domain.Entities;

namespace Euromonitor.Application.Interfaces.Repositories;

public interface IBookRepository
{
    Task<Book?> GetByIdAsync(int id);
    Task AddAsync(Book book);
    Task UpdateAsync(Book book);
    Task DeleteAsync(int id);
    Task<IEnumerable<Book>> GetAllAsync();
}