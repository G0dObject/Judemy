namespace Judemy.Domain.Entity
{
	public class Course : Entity
	{
		public int Id { get; set; } = 0;
		public string Category { get; set; } = string.Empty;
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public decimal Price { get; set; } = decimal.Zero;
		public string Uploader { get; set; } = string.Empty;
		public string Adress { get; set; } = "/";
		public string ImageUrl { get; set; } = "/";
	}
}
