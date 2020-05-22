using System;
using CPMusic.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CPMusic.Data.Config
{
    public class ArtistConfig : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.HasIndex(col => col.Name).IsUnique();
            builder.HasIndex(col => col.Avatar).IsUnique();
            
            builder.HasData(new Artist { Id = Guid.Parse("09C1BFE7-D884-4484-8F66-8225536214C9"), Name = "Chi Pu", Avatar = "Image/ChiPu.png" });
            builder.HasData(new Artist { Name = "BlackPink", Avatar = "Image/BlackPink.png" });
            builder.HasData(new Artist { Name = "Võ Hoàng Yến", Avatar = "Image/VoHoangYen.png" });
        }
    }
}
