using Judemy.Application.Interfaces.Base;
using Judemy.Domain.Entity;

namespace Judemy.Application.Interfaces.Repository
{
	public interface ICourseRepository : IGenericRepository<Course>
	{
		public Task<List<Course>> GetCourseByCategoryAsync(string category);
	}
}
