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

            #region Tạo quan hệ n - n giữa bảng Nghệ sĩ - Thể loại

            builder.HasOne(col => col.Artist)
                   .WithMany(col => col.ArtistSongs)
                   .HasForeignKey(col => col.ArtistId);

            builder
                .HasOne(col => col.Song)
                .WithMany(col => col.ArtistSongs)
                .HasForeignKey(col => col.SongId);

            #endregion

            // Anh ơi ở lại - Chi Pu
            builder.HasData(new ArtistSong
            {
                ArtistId = Guid.Parse("09C1BFE7-D884-4484-8F66-8225536214C9"),
                SongId = Guid.Parse("18F94F44-2CB8-4DC7-BCC5-CD721BA1E2F5"),
            });

            // Cảm giác lúc ấy sẽ ra sao - Lou Hoàng
            builder.HasData(new ArtistSong
            {
                ArtistId = Guid.Parse("A3616670-4FD8-49CF-B3FC-82DC29F7E94F"),
                SongId = Guid.Parse("B5A14BE6-F859-40D5-AB01-1814F0C72B61"),
            });

            // Kill this love - BlackPink
            builder.HasData(new ArtistSong
            {
                ArtistId = Guid.Parse("1C9307EA-95FF-42D5-8883-2138E87B1ACF"),
                SongId = Guid.Parse("DF23FEB6-D98F-4484-BDD2-AEEF0F567213"),
            });

            // Du ddu du ddu - BlackPink
            builder.HasData(new ArtistSong
            {
                ArtistId = Guid.Parse("1C9307EA-95FF-42D5-8883-2138E87B1ACF"),
                SongId = Guid.Parse("21E0D421-A233-4F6C-863C-3C99E01BF405"),
            });

            // Boombayah - BlackPink
            builder.HasData(new ArtistSong
            {
                ArtistId = Guid.Parse("1C9307EA-95FF-42D5-8883-2138E87B1ACF"),
                SongId = Guid.Parse("E93CC63F-062D-419E-8CB9-161298B5D532"),
            });

            // Em gái mưa - Hương Tràm
            builder.HasData(new ArtistSong
            {
                ArtistId = Guid.Parse("961F8B25-AE91-4B8B-940A-8CAA7503E7EA"),
                SongId = Guid.Parse("4DF89010-89C1-47A2-A9FB-1E0E72BEB906"),
            });

            // Không thể cùng nhau suốt kiếp - Hương Tràm, Mr Siro
            builder.HasData(new ArtistSong
            {
                ArtistId = Guid.Parse("47720334-D5E6-445D-9871-3336634824C5"),
                SongId = Guid.Parse("9DA35767-6827-420A-A104-7D4839382DB8"),
            });

            builder.HasData(new ArtistSong
            {
                ArtistId = Guid.Parse("77133A0F-EED5-47CF-B6F1-9DB1C9C78009"),
                SongId = Guid.Parse("9DA35767-6827-420A-A104-7D4839382DB8"),
            });

            // Muốn khóc thật to - Trúc Nhân
            builder.HasData(new ArtistSong
            {
                ArtistId = Guid.Parse("CFD5C125-09FD-4490-A237-22696D309E23"),
                SongId = Guid.Parse("A7D834F3-6BDA-4C81-BBF5-9834EDFB0CD1"),
            });

            // Bốn chữ lắm - Trúc Nhân, Trương Thảo nhi
            builder.HasData(new ArtistSong
            {
                ArtistId = Guid.Parse("CFD5C125-09FD-4490-A237-22696D309E23"),
                SongId = Guid.Parse("322B6882-F77B-44B4-93F7-5D614BEC4F09"),
            });
            
            builder.HasData(new ArtistSong
            {
                ArtistId = Guid.Parse("DB28E1B6-6E88-46EE-BAD6-4CB381C2E8C3"),
                SongId = Guid.Parse("322B6882-F77B-44B4-93F7-5D614BEC4F09"),
            });

            // Tìm - MIN, Mr.A
            builder.HasData(new ArtistSong
            {
                ArtistId = Guid.Parse("E0CEF1BE-FAFD-4979-9F32-3AD2FA27CE71"),
                SongId = Guid.Parse("70F850B5-5B05-4DF6-844E-A477C4150ED5"),
            });
            
            // Tìm - MIN, Mr.A
            builder.HasData(new ArtistSong
            {
                ArtistId = Guid.Parse("3A17D74C-2B66-469F-A07E-E110906ED263"),
                SongId = Guid.Parse("70F850B5-5B05-4DF6-844E-A477C4150ED5"),
            });
        }
    }
}