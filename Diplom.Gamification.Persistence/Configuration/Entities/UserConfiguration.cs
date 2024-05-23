using Diplom.Gamification.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diplom.Gamification.Persistence.Configuration.Entities
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {

        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var admin = new ApplicationUser
            {
                Id = "8a8670b4-afb9-4734-a596-ffc3d2156e50",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                Rating = 99
            };

            var passwordHasher = new PasswordHasher<ApplicationUser>();
            admin.PasswordHash = passwordHasher.HashPassword(admin, "admin");

            builder.HasData(admin);
        }

    }

    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {

        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    UserId = "8a8670b4-afb9-4734-a596-ffc3d2156e50",
                    RoleId = "03476e34-e1eb-49e1-8eaf-73ec2424415e",
                });
        }

    }
}
