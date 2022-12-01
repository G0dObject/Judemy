using Judemy.Application.Interfaces.Repository;
using Judemy.Persistent.Repositories;

namespace Judemy.Application.Interfaces
{
	public interface IUnitOfWork
	{

		public IAuthorizationRepository Authorization { get; set; }
		public ICourseRepository Course { get; set; }
		public void Dispose();

		Task Save();
	}
}
