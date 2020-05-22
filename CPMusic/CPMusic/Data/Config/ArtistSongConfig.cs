using System;
using CPMusic.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CPMusic.Data.Config
{
    public class ArtistSongConfig : IEntityTypeConfiguration<ArtistSong>
    {
        public void Configure(EntityTypeBuilder<ArtistSong> builder)
        {
            builder.HasKey(col => new { col.ArtistId, col.SongId });

            // Tạo quan hệ n - n giữa bảng Nghệ sĩ - Thể loại
            builder.HasOne(col => col.Artist)
                   .WithMany(col => col.ArtistSongs)
                   .HasForeignKey(col => col.ArtistId);
            
            builder
                .HasOne(col => col.Song)
                .WithMany(col => col.ArtistSongs)
                .HasForeignKey(col => col.SongId);
            
            builder.HasData(new ArtistSong
            {
                ArtistId = Guid.Parse("09C1BFE7-D884-4484-8F66-8225536214C9"),
                SongId = Guid.Parse("18F94F44-2CB8-4DC7-BCC5-CD721BA1E2F5"),
            });
        }
    }
}
