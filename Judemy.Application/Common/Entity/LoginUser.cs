using System.ComponentModel.DataAnnotations;

namespace Judemy.Application.Common.Entity
{
	public class LoginUser
	{
		[Required]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; } = string.Empty;
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; } = string.Empty;
	}
}
