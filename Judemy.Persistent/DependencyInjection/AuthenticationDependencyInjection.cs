using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Judemy.Persistent.DependencyInjection
{
	public static class AuthenticationDependencyInjection
	{
		public static IServiceCollection AddAuthenticationDependency(this IServiceCollection services, IConfiguration configuration)
		{
			_ = services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(options =>
			{

				options.SaveToken = true;
				options.RequireHttpsMetadata = false;
				options.TokenValidationParameters = new TokenValidationParameters()
				{					
					ValidateIssuer = false,
					ValidateAudience = false,
					ValidAudience = configuration["Jwt:Audience"],
					ValidIssuer = configuration["Jwt:Issuer"],
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
					ValidateLifetime = false
				};
			});
			return services;
		}
	}
}
