using System.ComponentModel.DataAnnotations;

namespace Judemy.Application.Common.Entity
{
	public class CreateUser
	{
		[Required]
		public string UserName { get; set; } = string.Empty;
		[Required]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; } = string.Empty;
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; } = string.Empty;
	}
}
