using Judemy.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Judemy.Persistent.EntityTypeConfiguration.Users
{
	internal class CourseOptionConfiguration : IEntityTypeConfiguration<Course>
	{
		public void Configure(EntityTypeBuilder<Course> builder)
		{
			builder.HasKey(e => e.Id);
			builder.Property(e => e.Adress);
			builder.Property(e => e.Price);
			builder.Property(e => e.Description);
			builder.Property(e => e.Category);
		}
	}
}
