using Microsoft.AspNetCore.Identity;

namespace Judemy.Domain.Entity.Users
{
	public class User : IdentityUser<int>, Entity
	{
		public int CartId { get; set; }
	}
}
