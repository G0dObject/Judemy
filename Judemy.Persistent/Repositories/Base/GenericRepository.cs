using Judemy.Application.Interfaces.Base;
using Judemy.Persistent.EntityTypeContext;
using Microsoft.EntityFrameworkCore;

namespace Judemy.Persistent.Repositories.Base
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		internal readonly Context _context;
		public GenericRepository(Context context)
		{
			_context = context;
		}
		public async Task<T> CreateAsync(T entity)
		{
			_ = await _context.Set<T>().AddAsync(entity);
			_ = await _context.SaveChangesAsync();
			return entity;
		}

		public Task Delete(T entity)
		{
			_context.Remove(entity);
			return Task.CompletedTask;
		}

		public async Task<T?> FirstAsync()
		{
			return await _context.Set<T>().FirstOrDefaultAsync();
		}

		public Task<List<T>> GetAllAsync()
		{
			return _context.Set<T>().ToListAsync();
		}

		public async Task<T?> GetByIdAsync(int id)
		{
			return await _context.Set<T>().FindAsync(id);
		}

		public Task<T?> LastAsync()
		{
			throw new NotImplementedException();
		}

		public Task UpdateAsync(T entity)
		{
			return Task.FromResult(entity);
		}
	}
}
