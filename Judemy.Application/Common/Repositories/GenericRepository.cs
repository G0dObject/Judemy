using Judemy.Application.Interfaces;

namespace Judemy.Application.Common.Repositories
{
    public abstract class GenericRepository<T> where T : class
    {
        IContext _context;

        public GenericRepository(IContext context)
        {
            _context = context;
        }
        public abstract Task<T> GetById(int id);
        public abstract Task Add(T entity);
        public abstract Task Remove(T entity);
        public abstract Task<IEnumerable<T>> GetAll();

        public virtual async Task Save() => _ = await _context.SaveChangesAsync(new CancellationToken());
    }
}
