using System;
using CPMusic.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CPMusic.Data.Config
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasIndex(col => col.Name).IsUnique();

            builder.HasData(new Category
            {
                Id = Guid.Parse("1BB78812-0C2A-4BEF-9E29-91BD45CC3311"),
                Name = "Nhạc trẻ",
                Thumbnail = "/img/categories/NhacTre.jpg",
            });

            builder.HasData(new Category
            {
                Id = Guid.Parse("557A2270-276B-43EB-94CB-171CBF0CC9C5"),
                Name = "Nhạc Hàn Quốc",
                Thumbnail = "/img/categories/NhacHanQuoc.jpg",
            });

            builder.HasData(new Category
            {
                Id = Guid.Parse("0EBE2395-6106-4C6F-827A-29400045B39F"),
                Name = "Nhạc Trung Quốc",
                Thumbnail = "/img/categories/NhacTrungQuoc.jpg",
            });
            
            builder.HasData(new Category
            {
                Id = Guid.Parse("BCC390F6-F78E-468C-A158-6DD23E6A28BC"),
                Name = "Nhạc EDM",
                Thumbnail = "/img/categories/NhacEDM.jpg",
            });
            
            builder.HasData(new Category
            {
                Id = Guid.Parse("917DA125-164F-4D97-BA01-59AC6E93F5C3"),
                Name = "Nhạc Âu Mỹ",
                Thumbnail = "/img/categories/NhacAuMy.jpg",
            });
            
            builder.HasData(new Category
            {
                Id = Guid.Parse("57EC071D-9986-424F-9DAE-ED54E2316214"),
                Name = "Nhạc Latin",
                Thumbnail = "/img/categories/NhacLatin.jpg",
            });
            
            builder.HasData(new Category
            {
                Id = Guid.Parse("9426B9B8-4B85-459C-9F82-79BDDEE93E56"),
                Name = "Nhạc Nhật Bản",
                Thumbnail = "/img/categories/NhacNhatBan.jpg",
            });
            
            builder.HasData(new Category
            {
                Id = Guid.Parse("D599DF0E-A82E-49FD-84E4-DFAF4B40A070"),
                Name = "Nhạc Trữ Tình",
                Thumbnail = "/img/categories/NhacTruTinh.jpg",
            });
        }
    }
}