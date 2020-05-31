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
                Thumbnail = "/img/songs/AnhOiOLai.jpg",
                Url = "/songs/AnhOiOLai.mp3",
                Year = 2019u,
                Views = 3213213213ul,
                CategoryId = Guid.Parse("1BB78812-0C2A-4BEF-9E29-91BD45CC3311"),
                CreatedAt = DateTime.Now,
            });
            
            builder.HasData(new
            {
                Id = Guid.Parse("B5A14BE6-F859-40D5-AB01-1814F0C72B61"),
                Name = "Cảm giác lúc ấy sẽ ra sao",
                Thumbnail = "/img/songs/CamGiacLucAySeRaSao.jpg",
                Url = "/songs/CamGiacLucAySeRaSao.mp3",
                Year = 2018u,
                Views = 4213219841ul,
                CategoryId = Guid.Parse("1BB78812-0C2A-4BEF-9E29-91BD45CC3311"),
                CreatedAt = DateTime.Now.AddMonths(2),
            });
            
            builder.HasData(new
            {
                Id = Guid.Parse("DF23FEB6-D98F-4484-BDD2-AEEF0F567213"),
                Name = "Kill this love",
                Thumbnail = "/img/songs/KillThisLove.jpg",
                Url = "/songs/KillThisLove.mp3",
                Year = 2012u,
                Views = 42841ul,
                CategoryId = Guid.Parse("557A2270-276B-43EB-94CB-171CBF0CC9C5"),
                CreatedAt = DateTime.Now.AddMonths(-3),
            });
            
            builder.HasData(new
            {
                Id = Guid.Parse("21E0D421-A233-4F6C-863C-3C99E01BF405"),
                Name = "Du ddu du ddu",
                Thumbnail = "/img/songs/DuDduDuDdu.jpg",
                Url = "/songs/DuDduDuDdu.mp3",
                Year = 2013u,
                Views = 42444841ul,
                CategoryId = Guid.Parse("557A2270-276B-43EB-94CB-171CBF0CC9C5"),
                CreatedAt = DateTime.Now.AddMonths(-3),
            });
            
            builder.HasData(new
            {
                Id = Guid.Parse("E93CC63F-062D-419E-8CB9-161298B5D532"),
                Name = "Boombayah",
                Thumbnail = "/img/songs/Boombayah.jpg",
                Url = "/songs/Boombayah.mp3",
                Year = 2023u,
                Views = 5544841ul,
                CategoryId = Guid.Parse("557A2270-276B-43EB-94CB-171CBF0CC9C5"),
                CreatedAt = DateTime.Now.AddMonths(6),
            });
            
            builder.HasData(new
            {
                Id = Guid.Parse("4DF89010-89C1-47A2-A9FB-1E0E72BEB906"),
                Name = "Em gái mưa",
                Thumbnail = "/img/songs/EmGaiMua.jpg",
                Url = "/songs/EmGaiMua.mp3",
                Year = 2017u,
                Views = 222244841ul,
                CategoryId = Guid.Parse("1BB78812-0C2A-4BEF-9E29-91BD45CC3311"),
                CreatedAt = DateTime.Now.AddMonths(55),
            });
            
            builder.HasData(new
            {
                Id = Guid.Parse("9DA35767-6827-420A-A104-7D4839382DB8"),
                Name = "Không thể cùng nhau suốt kiếp",
                Thumbnail = "/img/songs/KhongTheCungNhauSuotKiep.jpg",
                Url = "/songs/KhongTheCungNhauSuotKiep.mp3",
                Year = 2015u,
                Views = 255841ul,
                CategoryId = Guid.Parse("1BB78812-0C2A-4BEF-9E29-91BD45CC3311"),
                CreatedAt = DateTime.Now.AddMonths(55),
            });
            
            builder.HasData(new
            {
                Id = Guid.Parse("A7D834F3-6BDA-4C81-BBF5-9834EDFB0CD1"),
                Name = "Muốn khóc thật to",
                Thumbnail = "/img/songs/MuonKhocThatTo.jpg",
                Url = "/songs/MuonKhocThatTo.mp3",
                Year = 2012u,
                Views = 2321321312ul,
                CategoryId = Guid.Parse("1BB78812-0C2A-4BEF-9E29-91BD45CC3311"),
                CreatedAt = DateTime.Now.AddMonths(12),
            });
            
            builder.HasData(new
            {
                Id = Guid.Parse("322B6882-F77B-44B4-93F7-5D614BEC4F09"),
                Name = "Bốn chữ lắm",
                Thumbnail = "/img/songs/BonChuLam.jpg",
                Url = "/songs/BonChuLam.mp3",
                Year = 2013u,
                Views = 2344321312ul,
                CategoryId = Guid.Parse("1BB78812-0C2A-4BEF-9E29-91BD45CC3311"),
                CreatedAt = DateTime.Now.AddMonths(12),
            });
            
            builder.HasData(new
            {
                Id = Guid.Parse("70F850B5-5B05-4DF6-844E-A477C4150ED5"),
                Name = "Tìm",
                Thumbnail = "/img/songs/Tim.jpg",
                Url = "/songs/Tim.mp3",
                Year = 2011u,
                Views = 2421312ul,
                CategoryId = Guid.Parse("1BB78812-0C2A-4BEF-9E29-91BD45CC3311"),
                CreatedAt = DateTime.Now.AddMonths(12),
            });
        }
    }
}
