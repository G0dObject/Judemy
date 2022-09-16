using System.ComponentModel.DataAnnotations;

namespace Judemy.Application.Common.Entity.Product
{
	public class CreateProduct
	{
		[Required]
		public string? Title { get; set; }

		[Required]
		public List<string>? Size { get; set; }


		public string? Type { get; set; }

		[Required]
		public string? Category { get; set; }

		[Required]
		public string? ImageUrl { get; set; }

		[Required]
		public virtual decimal? Price { get; set; }

		public decimal? Rating { get; set; }
	}
}
