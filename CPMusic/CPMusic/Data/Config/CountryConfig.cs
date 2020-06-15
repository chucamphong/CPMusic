using System;
using CPMusic.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CPMusic.Data.Config
{
    public class CountryConfig : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasIndex(col => col.Name).IsUnique();

            builder.HasData(new Country { Id = Guid.Parse("4B73A5C7-0623-46A5-B658-B5F8DB232498"), Name = "Việt Nam" });
            
            builder.HasData(new Country { Id = Guid.Parse("109C4273-8602-430E-8F18-63766AEE423B"), Name = "Âu Mỹ" });
            
            builder.HasData(new Country { Id = Guid.Parse("1E2831A8-1A04-4CF4-B301-DBB25AC05856"), Name = "Hàn Quốc" });
        }
    }
}