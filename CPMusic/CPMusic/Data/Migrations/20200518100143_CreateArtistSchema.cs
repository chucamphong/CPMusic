using Microsoft.EntityFrameworkCore.Migrations;

namespace CPMusic.Data.Migrations
{
    /// <summary>
    /// Tạo bảng nghệ sĩ
    /// </summary>
    /// ReSharper disable once UnusedType.Global
    public partial class CreateArtistSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Artists",
                builder => new
                {
                    Id = builder.Column<int>(),
                    Name = builder.Column<string>(maxLength: 50)
                },
                constraints: builder =>
                {
                    builder.PrimaryKey("PK_Artist_Id", col => col.Id);
                    builder.UniqueConstraint("UQ_Artist_Name", col => col.Name);
                }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Artists");
        }
    }
}