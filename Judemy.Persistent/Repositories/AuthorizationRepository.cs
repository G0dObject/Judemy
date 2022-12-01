using Judemy.Domain.Entity.Users;
using Judemy.Persistent.EntityTypeContext;
using Judemy.Persistent.Repositories.Base;

namespace Judemy.Persistent.Repositories
{
	public class AuthorizationRepository : GenericRepository<User>, IAuthorizationRepository
	{
		private new readonly Context _context;
		public AuthorizationRepository(Context context) : base(context)
		{
			_context = context;
		}
	}
}
