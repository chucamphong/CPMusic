using System;
using CPMusic.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CPMusic.Data.Config
{
    public class IdentityUserRoleConfig : IEntityTypeConfiguration<IdentityUserRole<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
        {
            builder.ToTable("UserRoles");

            builder.HasData(new IdentityUserRole<Guid>
            {
                RoleId = Guid.Parse("FF6EC874-59A6-497D-A644-6FA59FB7F3AE"), UserId = Guid.Parse("0336DA83-36B2-49D2-AE14-BE954AD51370")
            });
        }
    }
}
