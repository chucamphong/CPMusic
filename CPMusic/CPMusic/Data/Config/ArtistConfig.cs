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

            builder.HasData(new Artist
            {
                Id = Guid.Parse("09C1BFE7-D884-4484-8F66-8225536214C9"),
                Name = "Chi Pu",
                Avatar = "/img/avatars/artists/ChiPu.jpg",
            });
            
            builder.HasData(new Artist
            {
                Id = Guid.Parse("A3616670-4FD8-49CF-B3FC-82DC29F7E94F"),
                Name = "Lou Hoàng",
                Avatar = "/img/avatars/artists/LouHoang.jpg",
            });
            
            builder.HasData(new Artist
            {
                Id = Guid.Parse("1C9307EA-95FF-42D5-8883-2138E87B1ACF"),
                Name = "BLACKPINK",
                Avatar = "/img/avatars/artists/BlackPink.jpg",
            });
            
            builder.HasData(new Artist
            {
                Id = Guid.Parse("961F8B25-AE91-4B8B-940A-8CAA7503E7EA"),
                Name = "Hương Tràm",
                Avatar = "/img/avatars/artists/HuongTram.jpg",
            });
            
            builder.HasData(new Artist
            {
                Id = Guid.Parse("47720334-D5E6-445D-9871-3336634824C5"),
                Name = "Hòa Minzy",
                Avatar = "/img/avatars/artists/HoaMinzy.jpg",
            });
            
            builder.HasData(new Artist
            {
                Id = Guid.Parse("77133A0F-EED5-47CF-B6F1-9DB1C9C78009"),
                Name = "Mr Siro",
                Avatar = "/img/avatars/artists/MrSiro.jpg",
            });
            
            builder.HasData(new Artist
            {
                Id = Guid.Parse("CFD5C125-09FD-4490-A237-22696D309E23"),
                Name = "Trúc Nhân",
                Avatar = "/img/avatars/artists/TrucNhan.jpg",
            });
            
            builder.HasData(new Artist
            {
                Id = Guid.Parse("E0CEF1BE-FAFD-4979-9F32-3AD2FA27CE71"),
                Name = "MIN",
                Avatar = "/img/avatars/artists/MIN.jpg",
            });
            
            builder.HasData(new Artist
            {
                Id = Guid.Parse("3A17D74C-2B66-469F-A07E-E110906ED263"),
                Name = "Mr.A",
                Avatar = "/img/avatars/artists/MrA.jpg",
            });
            
            builder.HasData(new Artist
            {
                Id = Guid.Parse("DB28E1B6-6E88-46EE-BAD6-4CB381C2E8C3"),
                Name = "Trương Thảo Nhi",
                Avatar = "/img/avatars/artists/TruongThaoNhi.jpg",
            });
        }
    }
}