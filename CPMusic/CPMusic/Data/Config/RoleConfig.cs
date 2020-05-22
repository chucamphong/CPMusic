using System;
using CPMusic.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CPMusic.Data.Config
{
    public class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");

            builder.HasData(new Role
            {
                Id = Guid.Parse("FF6EC874-59A6-497D-A644-6FA59FB7F3AE"), Name = "Admin", NormalizedName = "ADMIN"
            });
            builder.HasData(new Role {
                Id = Guid.Parse("DD56B0E4-1FCF-4E63-9B28-6AFAE71002F7"), Name = "Member", NormalizedName = "MEMBER"
            });
        }
    }
}
