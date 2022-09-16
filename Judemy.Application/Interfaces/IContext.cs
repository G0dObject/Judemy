using Judemy.Domain.Entity.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Judemy.Application.Interfaces
{
	public interface IContext
	{
		public DbSet<User>? Users { get; set; }
		public DbSet<IdentityUserRole<int>>? UserRoles { get; set; }
		public DbSet<IdentityUserToken<int>>? UserTokens { get; set; }

		Task<int> SaveChangesAsync(CancellationToken cancellationToken);
	}
}
