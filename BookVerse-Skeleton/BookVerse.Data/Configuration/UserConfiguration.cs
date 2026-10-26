using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookVerse.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<IdentityUser>
    {
        // It's not good to seed Users with public password through source code
        // TODO: Use UserSecrets or any Secret Vault storage

        public static IdentityUser DefaultUser
          => new IdentityUser
          {
              Id = "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd",
              UserName = "admin@bookverse.com",
              NormalizedUserName = "ADMIN@BOOKVERSE.COM",
              Email = "admin@bookverse.com",
              NormalizedEmail = "ADMIN@BOOKVERSE.COM",
              EmailConfirmed = true,
              PasswordHash = new PasswordHasher<IdentityUser>()
                  .HashPassword(new IdentityUser { UserName = "admin@bookverse.com" }, "Admin123!")
          };

        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {
            builder.HasData(DefaultUser);
        }
    }
}
