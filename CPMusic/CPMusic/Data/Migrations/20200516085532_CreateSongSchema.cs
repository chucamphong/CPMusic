using Microsoft.EntityFrameworkCore.Migrations;

namespace CPMusic.Data.Migrations
{
    public partial class CreateSongSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Songs",
                builder => new {
                    Id = builder.Column<int>(),
                    Name = builder.Column<string>()
                },
                constraints: builder =>
                {
                    builder.PrimaryKey("PK_SongId", col => col.Id);
                }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Songs");
        }
    }
}
