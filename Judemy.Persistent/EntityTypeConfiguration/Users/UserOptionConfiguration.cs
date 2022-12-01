using Judemy.Domain.Entity.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Judemy.Persistent.EntityTypeConfiguration.Users
{
	internal class UserOptionConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			_ = builder.HasKey(u => u.Id);
			_ = builder.Property(u => u.UserName).HasMaxLength(30);
			_ = builder.Property(u => u.Email);
			_ = builder.Property(u => u.PasswordHash);
		}
	}
}
