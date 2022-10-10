using Judemy.Application.Interfaces;
using Judemy.Persistent.EntityTypeContext;
using Judemy.Persistent.Repositories;

namespace Judemy.Persistent
{
	public class UnitOfWork : IUnitOfWork, IDisposable
	{
		private bool _disposed = false;
		private readonly Context _context;

		public UnitOfWork(Context context)
		{
			_context = context;
			Authorization = new AuthorizationRepository(context);
		}
		~UnitOfWork() => Dispose();

		public IAuthorizationRepository Authorization { get; set; }

		public async Task Save()=> _ = await _context.SaveChangesAsync();
		public void Dispose()
		{
			if (!_disposed)
			{
				_context.Dispose();
				_disposed = true;
				GC.SuppressFinalize(this);
			}
		}
	}
}
