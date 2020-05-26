using System;
using CPMusic.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CPMusic.Data.Config
{
    public class SongConfig : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.HasIndex(col => col.Thumbnail).IsUnique();
            builder.HasIndex(col => col.Url).IsUnique();

            builder.HasData(new
            {
                Id = Guid.Parse("18F94F44-2CB8-4DC7-BCC5-CD721BA1E2F5"),
                Name = "Anh ơi ở lại",
                OtherName = "Cám Tấm",
                Thumbnail = "/img/songs/thumbnails/AnhOiOLai.png",
                Url = "Url/AnhOiOLai.mp3",
                Year = 2019u,
                Views = 3213213213ul,
                CategoryId = Guid.Parse("1BB78812-0C2A-4BEF-9E29-91BD45CC3311"),
                CreatedAt = DateTime.Now,
            });
        }
    }
}
