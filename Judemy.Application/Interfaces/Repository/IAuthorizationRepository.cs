using Judemy.Application.Interfaces.Base;
using Judemy.Domain.Entity.Users;
using Microsoft.AspNetCore.Identity;

namespace Judemy.Persistent.Repositories
{
	public interface IAuthorizationRepository : IGenericRepository<User>
	{
		public UserManager<User> UserManager { get; set; }
	}
}
