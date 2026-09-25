using Library.Domain.Entities.Books;

namespace Library.Application.Contracts.Repositories
{
    public interface IBooksRepository : IRepository<Book>
    {
        Task<IReadOnlyList<Book>> GetAllWithDetailsAsync(CancellationToken cancellationToken = default);
        Task<Book?> GetByIdWithDetailsAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<Book>> GetByCategoryIdWithDetailsAsync(Guid categoryId, CancellationToken cancellationToken = default);
    }
}
