using Judemy.Domain.Entity.Users;
using Judemy.Persistent.EntityTypeContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Judemy.Persistent.DependencyInjection
{
	public static class IdentityDependencyInjection
	{
		public static IServiceCollection AddIdentityDependency(this IServiceCollection services)
		{
			IdentityBuilder? builder = services.AddIdentity<User, Role>(option =>
			{
				option.User.RequireUniqueEmail = false;

				option.Stores.MaxLengthForKeys = 128;

				option.Password.RequireUppercase = false;
				option.Password.RequireNonAlphanumeric = false;
				option.Password.RequireDigit = false;

				option.SignIn.RequireConfirmedPhoneNumber = false;
				option.SignIn.RequireConfirmedEmail = false;
				option.SignIn.RequireConfirmedAccount = false;
			}).AddEntityFrameworkStores<Context>().AddDefaultTokenProviders();

			return services;
		}
	}
}
