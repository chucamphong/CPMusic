using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CPMusic.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Avatar = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Avatar = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    OtherName = table.Column<string>(nullable: true),
                    Thumbnail = table.Column<string>(nullable: false),
                    Url = table.Column<string>(nullable: false),
                    Year = table.Column<long>(nullable: false),
                    Views = table.Column<decimal>(nullable: false),
                    CategoryId = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Songs_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArtistSong",
                columns: table => new
                {
                    ArtistId = table.Column<Guid>(nullable: false),
                    SongId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistSong", x => new { x.ArtistId, x.SongId });
                    table.ForeignKey(
                        name: "FK_ArtistSong_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistSong_Songs_SongId",
                        column: x => x.SongId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "Avatar", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { new Guid("09c1bfe7-d884-4484-8f66-8225536214c9"), "Image/ChiPu.png", new DateTime(2020, 5, 22, 15, 32, 36, 192, DateTimeKind.Local).AddTicks(5125), "Chi Pu" },
                    { new Guid("de704ce1-72de-48a2-bd9a-71e2d57bfab0"), "Image/BlackPink.png", new DateTime(2020, 5, 22, 15, 32, 36, 192, DateTimeKind.Local).AddTicks(6726), "BlackPink" },
                    { new Guid("7b6409e9-50c7-44a6-9c9d-c3b576d966b9"), "Image/VoHoangYen.png", new DateTime(2020, 5, 22, 15, 32, 36, 192, DateTimeKind.Local).AddTicks(6752), "Võ Hoàng Yến" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { new Guid("1bb78812-0c2a-4bef-9e29-91bd45cc3311"), new DateTime(2020, 5, 22, 15, 32, 36, 191, DateTimeKind.Local).AddTicks(6412), "Nhạc trẻ" },
                    { new Guid("557a2270-276b-43eb-94cb-171cbf0cc9c5"), new DateTime(2020, 5, 22, 15, 32, 36, 191, DateTimeKind.Local).AddTicks(7705), "Nhạc Hàn Quốc" },
                    { new Guid("0ebe2395-6106-4c6f-827a-29400045b39f"), new DateTime(2020, 5, 22, 15, 32, 36, 191, DateTimeKind.Local).AddTicks(7736), "Nhạc Trung Quốc" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("ff6ec874-59a6-497d-a644-6fa59fb7f3ae"), "7a98b3b4-2283-43fc-a89b-de4a527f907a", "Admin", "ADMIN" },
                    { new Guid("dd56b0e4-1fcf-4e63-9b28-6afae71002f7"), "64a2fc61-f20a-4482-982c-e6b2a97177a9", "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("0336da83-36b2-49d2-ae14-be954ad51370"), 0, null, "5e67d59c-9058-4d72-b7b0-d53da9ba7842", new DateTime(2020, 5, 22, 15, 32, 36, 179, DateTimeKind.Local).AddTicks(5846), "chucamphong1999@gmail.com", false, false, null, "Chu Cẩm Phong", "CHUCAMPHONG1999@GMAIL.COM", "CHUCAMPHONG", "AQAAAAEAACcQAAAAEInAYIelkRl1jSqhM7wJSpjpMw/8a8JKjiHFvLPbdSFItlX57xsrOc5g316q8Y5nxQ==", null, false, "1551209c-0ad7-45e3-8b87-51642dc88d0b", false, "chucamphong" });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Name", "OtherName", "Thumbnail", "Url", "Views", "Year" },
                values: new object[] { new Guid("18f94f44-2cb8-4dc7-bcc5-cd721ba1e2f5"), new Guid("1bb78812-0c2a-4bef-9e29-91bd45cc3311"), new DateTime(2020, 5, 22, 15, 32, 36, 193, DateTimeKind.Local).AddTicks(2936), "Anh ơi ở lại", "Cám Tấm", "Images/AnhOiOLai.png", "Url/AnhOiOLai.mp3", 3213213213m, 2019L });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("0336da83-36b2-49d2-ae14-be954ad51370"), new Guid("ff6ec874-59a6-497d-a644-6fa59fb7f3ae") });

            migrationBuilder.InsertData(
                table: "ArtistSong",
                columns: new[] { "ArtistId", "SongId" },
                values: new object[] { new Guid("09c1bfe7-d884-4484-8f66-8225536214c9"), new Guid("18f94f44-2cb8-4dc7-bcc5-cd721ba1e2f5") });

            migrationBuilder.CreateIndex(
                name: "IX_Artists_Avatar",
                table: "Artists",
                column: "Avatar",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Artists_Name",
                table: "Artists",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArtistSong_SongId",
                table: "ArtistSong",
                column: "SongId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_CategoryId",
                table: "Songs",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_Thumbnail",
                table: "Songs",
                column: "Thumbnail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Songs_Url",
                table: "Songs",
                column: "Url",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistSong");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
