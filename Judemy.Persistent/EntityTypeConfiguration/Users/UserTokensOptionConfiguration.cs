using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Judemy.Persistent.EntityTypeConfiguration.Users
{
	public class UserTokensOptionConfiguration : IEntityTypeConfiguration<IdentityUserToken<int>>
	{
		public void Configure(EntityTypeBuilder<IdentityUserToken<int>> builder)
		{
			_ = builder.HasKey(i => i.UserId);
			_ = builder.Property(i => i.LoginProvider);
			_ = builder.Property(i => i.Name);
			_ = builder.Property(i => i.Value);
		}
	}
}
