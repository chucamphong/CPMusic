using System;
using CPMusic.Data.Config;
using CPMusic.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CPMusic.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, Guid>
    {
        public DbSet<Song> Songs { get; set; } = null!;
        public DbSet<Artist> Artists { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new UserConfig());
            builder.ApplyConfiguration(new IdentityUserLoginConfig());
            builder.ApplyConfiguration(new IdentityUserTokenConfig());
            builder.ApplyConfiguration(new IdentityUserClaimConfig());
            builder.ApplyConfiguration(new IdentityUserRoleConfig());
            builder.ApplyConfiguration(new IdentityRoleClaimConfig());
            builder.ApplyConfiguration(new RoleConfig());

            builder.ApplyConfiguration(new CategoryConfig());
            builder.ApplyConfiguration(new ArtistConfig());
            builder.ApplyConfiguration(new SongConfig());
            builder.ApplyConfiguration(new ArtistSongConfig());
        }
    }
}
