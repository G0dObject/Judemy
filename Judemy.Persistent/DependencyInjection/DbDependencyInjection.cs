using Judemy.Application.Interfaces;
using Judemy.Persistent.EntityTypeContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Judemy.Persistent.DependencyInjection
{
	public static class DbDependencyInjection
	{
		public static IServiceCollection AddDbDependency(this IServiceCollection services, IConfiguration configuration, bool IsDevelopment = false)

		{
			if (IsDevelopment)
			{
				string? connectionString = configuration.GetConnectionString("MySql");
				_ = services.AddDbContext<Context>(option =>
				{
					_ = option.UseMySQL(connectionString);
				});
			}
			else
			{
				string? connectionString = configuration.GetConnectionString("SqLite");
				_ = services.AddDbContext<Context>(option =>
				{
					_ = option.UseSqlite(connectionString);
				});
			}

			IServiceCollection? g = services.AddScoped<IContext>(provider =>
			   provider.GetService<Context>() ?? new Context(new DbContextOptions<Context>()));

			return services;
		}
	}

}
