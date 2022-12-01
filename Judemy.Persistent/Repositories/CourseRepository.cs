using Judemy.Application.Interfaces.Repository;
using Judemy.Domain.Entity;
using Judemy.Persistent.EntityTypeContext;
using Judemy.Persistent.Repositories.Base;


namespace Judemy.Persistent.Repositories
{
	public class CourseRepository : GenericRepository<Course>, ICourseRepository
	{
		public CourseRepository(Context context) : base(context)
		{
			base._context = context;
		}

		public async Task<List<Course>> GetCourseByCategoryAsync(string category)
		{
			return await _context.Set<Course>().ToAsyncEnumerable().WhereAwait(x => new ValueTask<bool>(x.Category == category)).ToListAsync();
		}
	}
}
