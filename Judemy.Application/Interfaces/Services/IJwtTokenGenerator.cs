using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Judemy.Application.Interfaces.Services
{
	public interface IJwtTokenGenerator
	{
		public JwtSecurityToken GenerateJwtToken(List<Claim> authClaims);
	}
}
