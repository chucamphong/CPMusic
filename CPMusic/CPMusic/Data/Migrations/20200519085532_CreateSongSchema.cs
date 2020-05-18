using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CPMusic.Data.Migrations
{
    /// <summary>
    /// Tạo bảng bài hát
    /// </summary>
    /// ReSharper disable once UnusedType.Global
    public partial class CreateSongSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Songs",
                builder => new {
                    Id = builder.Column<int>(),
                    Name = builder.Column<string>(maxLength: 255),
                    OtherName = builder.Column<string>(maxLength: 255, nullable: true),
                    Thumbnail = builder.Column<string>(maxLength: 255),
                    Url = builder.Column<string>(maxLength: 255),
                    Year = builder.Column<ushort>(),
                    Views = builder.Column<ulong>(defaultValue: 0),
                    CategoryId = builder.Column<int>()
                },
                constraints: builder =>
                {
                    builder.PrimaryKey("PK_SongId", col => col.Id);
                    builder.ForeignKey("FK_Song_CategoryId", col => col.CategoryId, "Categories", "Id");
                }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Songs");
        }
    }
}
