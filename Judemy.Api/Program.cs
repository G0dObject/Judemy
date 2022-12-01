using Judemy.Api.Services;
using Judemy.Application.Common.Mapping.Profiles;
using Judemy.Application.Interfaces;
using Judemy.Application.Interfaces.Repository;
using Judemy.Application.Interfaces.Services;
using Judemy.Persistent;
using Judemy.Persistent.DependencyInjection;
using Judemy.Persistent.EntityTypeConfiguration;
using Judemy.Persistent.EntityTypeContext;
using Judemy.Persistent.Repositories;
using Microsoft.AspNetCore.Authentication.Certificate;
using NuGet.Protocol.Core.Types;

namespace Judemy.Api
{
	public class Program
	{
		public static void Main(string[] args)
		{
			WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);
			string _cors = "http://localhost:3000";

			_ = builder.Services.AddControllers();
			_ = builder.Services.AddEndpointsApiExplorer();
			_ = builder.Services.AddSwaggerGen();
			_ = builder.Services.AddAutoMapper(typeof(AppMappingProfile));
			_ = builder.Services.AddCors(options =>
			{
				options.AddPolicy(name: _cors,
								  policy =>
								  {
									  _ = policy.WithOrigins("http://localhost:3000",
														  "http://localhost");
								  });
			});

			_ = builder.Services.AddDbDependency(builder.Configuration, builder.Environment.IsDevelopment());
			_ = builder.Services.AddIdentityDependency();
			_ = builder.Services.AddAuthenticationDependency(builder.Configuration);

			_ = builder.Services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
			_ = builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

			_ = builder.Services.AddAuthentication(CertificateAuthenticationDefaults.AuthenticationScheme).AddCertificate();

			builder.WebHost.ConfigureKestrel(serverOptions =>
			{
				serverOptions.ListenAnyIP(5001, listenOptions =>
				{
					listenOptions.UseHttps();
				});
			});
			builder.WebHost.UseKestrel();

			WebApplication? app = builder.Build();

			using Context? db = app.Services.CreateScope().ServiceProvider.GetRequiredService<Context>();
			_ = Task.Run(async () => await Initializer.Initialize(db));

			_ = app.UseSwagger();
			_ = app.UseSwaggerUI();

			if (app.Environment.IsDevelopment())
			{
				_ = app.UseSwagger();
				_ = app.UseSwaggerUI();
			}

			_ = app.UseCors(_cors);
			_ = app.UseHttpsRedirection();

			_ = app.UseRouting();
			_ = app.UseAuthentication();
			_ = app.UseAuthorization();
			_ = app.MapControllers();

			_ = app.Map("/", () => "Ok");

			app.Run();
		}
	}
}