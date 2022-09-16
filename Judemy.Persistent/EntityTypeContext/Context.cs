using Judemy.Application.Interfaces;
using Judemy.Domain.Entity.Users;
using Judemy.Persistent.EntityTypeConfiguration.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Judemy.Persistent.EntityTypeContext
{
	public class Context : IdentityDbContext<User, Role, int>, IContext
	{
		public Context(DbContextOptions<Context> contextOptions) : base(contextOptions) { }
		public override DbSet<User>? Users { get; set; }

		protected override void OnModelCreating(ModelBuilder option)
		{
			_ = option.ApplyConfiguration(new UserOptionConfiguration());
			_ = option.ApplyConfiguration(new UserRoleOptionConfiguration());
			_ = option.ApplyConfiguration(new UserTokensOptionConfiguration());
			base.OnModelCreating(option);

		}
	}
}