using System;
using System.Runtime.InteropServices;
using CPMusic.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CPMusic.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public DbSet<Song> Songs { get; set; } = null!;
        public DbSet<Artist> Artists { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Các bảng thuộc thư viện Identity

            builder.Entity<User>().ToTable("Users");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            builder.Entity<IdentityRole>().ToTable("Roles");

            #endregion
            
            #region Bảng Roles
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN"
            });
            
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "Member",
                NormalizedName = "MEMBER"
            });
            #endregion

            #region Bảng nghệ sĩ

            builder.Entity<Artist>().HasIndex(col => col.Name).IsUnique();

            #endregion

            #region Bảng thể loại

            builder.Entity<Category>().HasIndex(col => col.Name).IsUnique();
            builder.Entity<Category>().HasData(new Category
            {
                Id = 1,
                Name = "Nhạc trẻ"
            });
            builder.Entity<Category>().HasData(new Category
            {
                Id = 2,
                Name = "Nhạc Hàn Quốc"
            });
            builder.Entity<Category>().HasData(new Category
            {
                Id = 3,
                Name = "Nhạc Trung Quốc"
            });

            #endregion

            #region Bảng bài hát

            builder.Entity<Song>().HasIndex(col => col.Thumbnail).IsUnique();
            builder.Entity<Song>().HasIndex(col => col.Url).IsUnique();

            #endregion

            #region Tạo quan hệ n - n giữa bảng Nghệ sĩ - Thể loại

            builder.Entity<ArtistSong>().HasKey(col => new {col.ArtistId, col.SongId});

            builder.Entity<ArtistSong>()
                .HasOne(col => col.Artist)
                .WithMany(col => col.ArtistSongs)
                .HasForeignKey(col => col.ArtistId);

            builder.Entity<ArtistSong>()
                .HasOne(col => col.Song)
                .WithMany(col => col.ArtistSongs)
                .HasForeignKey(col => col.SongId);

            #endregion
        }
    }
}