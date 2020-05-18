using Microsoft.EntityFrameworkCore.Migrations;

namespace CPMusic.Data.Migrations
{
    /// <summary>
    /// Tạo bảng phụ Artist_Song để tạo mối quan hệ n - n giữa bảng nghệ sĩ và bảng bài hát
    /// </summary>
    /// ReSharper disable once UnusedType.Global
    public partial class CreateArtistSongSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Artist_Song",
                builder => new
                {
                    ArtistId = builder.Column<int>(),
                    SongId = builder.Column<int>()
                },
                constraints: builder =>
                {
                    builder.ForeignKey(
                        "FK_ArtistSong_Artist_ArtistId",
                        col => col.ArtistId,
                        "Artists",
                        "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    
                    builder.ForeignKey(
                        "FK_ArtistSong_Song_SongId",
                        col => col.SongId,
                        "Songs",
                        "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}