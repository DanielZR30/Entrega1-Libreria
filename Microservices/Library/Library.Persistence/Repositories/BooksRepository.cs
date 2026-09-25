using Library.Application.Contracts.Repositories;
using Library.Domain.Entities.Books;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistence.Repositories
{
    public class BooksRepository : Repository<Book>, IBooksRepository
    {
        public BooksRepository(DataContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<Book>> GetAllWithDetailsAsync(CancellationToken cancellationToken = default)
        {
            return await Context.Books
                                .AsNoTracking()
                                .Include(b => b.Author)
                                .Include(b => b.Category)
                                .OrderBy(b => b.Title)
                                .ToListAsync(cancellationToken);
        }

        public async Task<Book?> GetByIdWithDetailsAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await Context.Books
                                .AsNoTracking()
                                .Include(b => b.Author)
                                .Include(b => b.Category)
                                .FirstOrDefaultAsync(b => b.Id == id, cancellationToken);
        }

        public async Task<IReadOnlyList<Book>> GetByCategoryIdWithDetailsAsync(Guid categoryId, CancellationToken cancellationToken = default)
        {
            return await Context.Books
                                .AsNoTracking()
                                .Include(b => b.Author)
                                .Include(b => b.Category)
                                .Where(b => b.CategoryId == categoryId)
                                .OrderBy(b => b.Title)
                                .ToListAsync(cancellationToken);
        }
    }
}
