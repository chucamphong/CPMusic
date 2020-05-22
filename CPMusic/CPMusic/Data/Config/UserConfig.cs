using System;
using CPMusic.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CPMusic.Data.Config
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            
            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            User user = new User
            {
                Id = Guid.Parse("0336DA83-36B2-49D2-AE14-BE954AD51370"),
                Name = "Chu Cẩm Phong",
                UserName = "chucamphong",
                NormalizedUserName = "CHUCAMPHONG",
                Email = "chucamphong1999@gmail.com",
                NormalizedEmail = "CHUCAMPHONG1999@GMAIL.COM",
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            user.PasswordHash = passwordHasher.HashPassword(user, "123456789aS");
            
            builder.HasData(user);
        }
    }
}
