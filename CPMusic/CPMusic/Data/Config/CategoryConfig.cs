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
            
            builder.HasData(new Category { Id = Guid.Parse("1BB78812-0C2A-4BEF-9E29-91BD45CC3311"), Name = "Nhạc trẻ" });
            builder.HasData(new Category { Id = Guid.Parse("557A2270-276B-43EB-94CB-171CBF0CC9C5"), Name = "Nhạc Hàn Quốc" });
            builder.HasData(new Category { Id = Guid.Parse("0EBE2395-6106-4C6F-827A-29400045B39F"), Name = "Nhạc Trung Quốc" });
        }
    }
}
