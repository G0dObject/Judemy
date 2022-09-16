using System.ComponentModel.DataAnnotations;

namespace Judemy.Application.Common.Entity.Product
{
	public class GetProductMenu
	{
		[Required]
		public int Id { get; set; }
		[Required]
		public string? Title { get; set; }
		[Required]
		public string? Type { get; set; }
		[Required]
		public string? Category { get; set; }

		[Required]
		[DataType(DataType.ImageUrl)]
		public string? ImageUrl { get; set; }
		public decimal? Rating { get; set; }

		[Required]
		[DataType(DataType.Currency)]
		public virtual decimal? Price { get; set; }

		public List<string>? Size { get; set; }
	}
}
