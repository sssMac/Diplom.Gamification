using Diplom.Gamification.Application.Consts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diplom.Gamification.Persistence.Configuration.Entities
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {

        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "03476e34-e1eb-49e1-8eaf-73ec2424415e",
                    Name = Roles.Admin,
                    NormalizedName = Roles.Admin.ToUpper()
                },
                new IdentityRole
                {
                    Id = "3b87c435-a7e9-4165-9eb4-4068f652d39b",
                    Name = Roles.Moderator,
                    NormalizedName = Roles.Moderator.ToUpper()
                },
                new IdentityRole
                {
                    Id = "a10af09f-cfea-42b6-906e-5e1fec9de544",
                    Name = Roles.Creator,
                    NormalizedName = Roles.Creator.ToUpper()
                },
                new IdentityRole
                {
                    Id = "6f6c5cf9-9785-4a0b-8e87-710d5bbb44bf",
                    Name = Roles.Basic,
                    NormalizedName = Roles.Basic.ToUpper()
                }
                );
        }
    }
}
