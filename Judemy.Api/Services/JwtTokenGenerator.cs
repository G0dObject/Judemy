using Judemy.Application.Interfaces.Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Judemy.Api.Services
{
	public class JwtTokenGenerator : IJwtTokenGenerator
	{
		private readonly IConfiguration _configuration;
		public JwtTokenGenerator(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public JwtSecurityToken GenerateJwtToken(List<Claim> authClaims)
		{
			SymmetricSecurityKey? authSigningKey = new(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
			JwtSecurityToken? token = new(
				issuer: _configuration["Jwt:Issuer"],
				audience: _configuration["Jwt:Audience"],
				expires: DateTime.Now.AddSeconds(double.Parse(_configuration["Jwt:TokenLifeTime"])),
				claims: authClaims,
				signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
				);
			return token;
		}
	}
}
