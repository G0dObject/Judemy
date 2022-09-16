using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Judemy.Domain.Entity.Users
{
	public class User : IdentityUser<int>
	{
		public int? CartId { get; set; }
	}
}
