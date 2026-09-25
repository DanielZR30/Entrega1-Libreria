using Library.Application.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DataContext Context;

        public Repository(DataContext context)
        {
            Context = context;
        }

        public async Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default)
        {
            await Context.Set<T>().AddAsync(entity, cancellationToken);
            return entity;
        }

        public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            T? entity = Context.Set<T>().Find(id);
            if (entity != null)
            {
                Context.Set<T>().Remove(entity);
            }
            return Task.CompletedTask;
        }

        public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await Context.Set<T>().FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task<IEnumerable<T>> GetListAsync(CancellationToken cancellationToken = default)
        {
            return await Context.Set<T>().ToListAsync(cancellationToken);
        }

        public Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            Context.Set<T>().Update(entity);
            return Task.FromResult(entity);
        }
    }
}
