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
                    { new Guid("09c1bfe7-d884-4484-8f66-8225536214c9"), "/img/avatars/artists/ChiPu.jpg", new DateTime(2020, 5, 31, 19, 19, 13, 578, DateTimeKind.Local).AddTicks(9897), "Chi Pu" },
                    { new Guid("a3616670-4fd8-49cf-b3fc-82dc29f7e94f"), "/img/avatars/artists/LouHoang.jpg", new DateTime(2020, 5, 31, 19, 19, 13, 579, DateTimeKind.Local).AddTicks(1418), "Lou Hoàng" },
                    { new Guid("1c9307ea-95ff-42d5-8883-2138e87b1acf"), "/img/avatars/artists/BlackPink.jpg", new DateTime(2020, 5, 31, 19, 19, 13, 579, DateTimeKind.Local).AddTicks(1463), "BLACKPINK" },
                    { new Guid("961f8b25-ae91-4b8b-940a-8caa7503e7ea"), "/img/avatars/artists/HuongTram.jpg", new DateTime(2020, 5, 31, 19, 19, 13, 579, DateTimeKind.Local).AddTicks(1469), "Hương Tràm" },
                    { new Guid("47720334-d5e6-445d-9871-3336634824c5"), "/img/avatars/artists/HoaMinzy.jpg", new DateTime(2020, 5, 31, 19, 19, 13, 579, DateTimeKind.Local).AddTicks(1473), "Hòa Minzy" },
                    { new Guid("77133a0f-eed5-47cf-b6f1-9db1c9c78009"), "/img/avatars/artists/MrSiro.jpg", new DateTime(2020, 5, 31, 19, 19, 13, 579, DateTimeKind.Local).AddTicks(1480), "Mr Siro" },
                    { new Guid("cfd5c125-09fd-4490-a237-22696d309e23"), "/img/avatars/artists/TrucNhan.jpg", new DateTime(2020, 5, 31, 19, 19, 13, 579, DateTimeKind.Local).AddTicks(1485), "Trúc Nhân" },
                    { new Guid("e0cef1be-fafd-4979-9f32-3ad2fa27ce71"), "/img/avatars/artists/MIN.jpg", new DateTime(2020, 5, 31, 19, 19, 13, 579, DateTimeKind.Local).AddTicks(1494), "MIN" },
                    { new Guid("3a17d74c-2b66-469f-a07e-e110906ed263"), "/img/avatars/artists/MrA.jpg", new DateTime(2020, 5, 31, 19, 19, 13, 579, DateTimeKind.Local).AddTicks(1499), "Mr.A" },
                    { new Guid("db28e1b6-6e88-46ee-bad6-4cb381c2e8c3"), "/img/avatars/artists/TruongThaoNhi.jpg", new DateTime(2020, 5, 31, 19, 19, 13, 579, DateTimeKind.Local).AddTicks(1505), "Trương Thảo Nhi" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { new Guid("1bb78812-0c2a-4bef-9e29-91bd45cc3311"), new DateTime(2020, 5, 31, 19, 19, 13, 577, DateTimeKind.Local).AddTicks(9437), "Nhạc trẻ" },
                    { new Guid("557a2270-276b-43eb-94cb-171cbf0cc9c5"), new DateTime(2020, 5, 31, 19, 19, 13, 578, DateTimeKind.Local).AddTicks(541), "Nhạc Hàn Quốc" },
                    { new Guid("0ebe2395-6106-4c6f-827a-29400045b39f"), new DateTime(2020, 5, 31, 19, 19, 13, 578, DateTimeKind.Local).AddTicks(579), "Nhạc Trung Quốc" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("ff6ec874-59a6-497d-a644-6fa59fb7f3ae"), "c05378d2-d920-47ac-a5f7-f211e1f860c9", "Admin", "ADMIN" },
                    { new Guid("dd56b0e4-1fcf-4e63-9b28-6afae71002f7"), "6fbb1760-c26f-4a32-a55e-4660b350f892", "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("0336da83-36b2-49d2-ae14-be954ad51370"), 0, "/img/avatars/users/ChuPhong.jpg", "ec83a0c6-2f43-4872-ba52-6f320f664506", new DateTime(2020, 5, 31, 19, 19, 13, 566, DateTimeKind.Local).AddTicks(6061), "chucamphong1999@gmail.com", false, false, null, "Chu Cẩm Phong", "CHUCAMPHONG1999@GMAIL.COM", "CHUCAMPHONG", "AQAAAAEAACcQAAAAEBTynBErjOkTzgVEjflWKhaOUJ25RNKEqJMtXNf+sDzudXUNBx/z+DJ8NHeYpAwVdQ==", null, false, "3ce00f1a-4b39-4329-8b8f-b493328301e2", false, "chucamphong" });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Name", "OtherName", "Thumbnail", "Url", "Views", "Year" },
                values: new object[,]
                {
                    { new Guid("18f94f44-2cb8-4dc7-bcc5-cd721ba1e2f5"), new Guid("1bb78812-0c2a-4bef-9e29-91bd45cc3311"), new DateTime(2020, 5, 31, 19, 19, 13, 580, DateTimeKind.Local).AddTicks(2497), "Anh ơi ở lại", "Cám Tấm", "/img/songs/AnhOiOLai.jpg", "/songs/AnhOiOLai.mp3", 3213213213m, 2019L },
                    { new Guid("b5a14be6-f859-40d5-ab01-1814f0c72b61"), new Guid("1bb78812-0c2a-4bef-9e29-91bd45cc3311"), new DateTime(2020, 7, 31, 19, 19, 13, 580, DateTimeKind.Local).AddTicks(4220), "Cảm giác lúc ấy sẽ ra sao", null, "/img/songs/CamGiacLucAySeRaSao.jpg", "/songs/CamGiacLucAySeRaSao.mp3", 4213219841m, 2018L },
                    { new Guid("4df89010-89c1-47a2-a9fb-1e0e72beb906"), new Guid("1bb78812-0c2a-4bef-9e29-91bd45cc3311"), new DateTime(2024, 12, 31, 19, 19, 13, 580, DateTimeKind.Local).AddTicks(5315), "Em gái mưa", null, "/img/songs/EmGaiMua.jpg", "/songs/EmGaiMua.mp3", 222244841m, 2017L },
                    { new Guid("9da35767-6827-420a-a104-7d4839382db8"), new Guid("1bb78812-0c2a-4bef-9e29-91bd45cc3311"), new DateTime(2024, 12, 31, 19, 19, 13, 580, DateTimeKind.Local).AddTicks(5321), "Không thể cùng nhau suốt kiếp", null, "/img/songs/KhongTheCungNhauSuotKiep.jpg", "/songs/KhongTheCungNhauSuotKiep.mp3", 255841m, 2015L },
                    { new Guid("a7d834f3-6bda-4c81-bbf5-9834edfb0cd1"), new Guid("1bb78812-0c2a-4bef-9e29-91bd45cc3311"), new DateTime(2021, 5, 31, 19, 19, 13, 580, DateTimeKind.Local).AddTicks(5327), "Muốn khóc thật to", null, "/img/songs/MuonKhocThatTo.jpg", "/songs/MuonKhocThatTo.mp3", 2321321312m, 2012L },
                    { new Guid("322b6882-f77b-44b4-93f7-5d614bec4f09"), new Guid("1bb78812-0c2a-4bef-9e29-91bd45cc3311"), new DateTime(2021, 5, 31, 19, 19, 13, 580, DateTimeKind.Local).AddTicks(5336), "Bốn chữ lắm", null, "/img/songs/BonChuLam.jpg", "/songs/BonChuLam.mp3", 2344321312m, 2013L },
                    { new Guid("70f850b5-5b05-4df6-844e-a477c4150ed5"), new Guid("1bb78812-0c2a-4bef-9e29-91bd45cc3311"), new DateTime(2021, 5, 31, 19, 19, 13, 580, DateTimeKind.Local).AddTicks(5343), "Tìm", null, "/img/songs/Tim.jpg", "/songs/Tim.mp3", 2421312m, 2011L },
                    { new Guid("df23feb6-d98f-4484-bdd2-aeef0f567213"), new Guid("557a2270-276b-43eb-94cb-171cbf0cc9c5"), new DateTime(2020, 2, 29, 19, 19, 13, 580, DateTimeKind.Local).AddTicks(5267), "Kill this love", null, "/img/songs/KillThisLove.jpg", "/songs/KillThisLove.mp3", 42841m, 2012L },
                    { new Guid("21e0d421-a233-4f6c-863c-3c99e01bf405"), new Guid("557a2270-276b-43eb-94cb-171cbf0cc9c5"), new DateTime(2020, 2, 29, 19, 19, 13, 580, DateTimeKind.Local).AddTicks(5298), "Du ddu du ddu", null, "/img/songs/DuDduDuDdu.jpg", "/songs/DuDduDuDdu.mp3", 42444841m, 2013L },
                    { new Guid("e93cc63f-062d-419e-8cb9-161298b5d532"), new Guid("557a2270-276b-43eb-94cb-171cbf0cc9c5"), new DateTime(2020, 11, 30, 19, 19, 13, 580, DateTimeKind.Local).AddTicks(5306), "Boombayah", null, "/img/songs/Boombayah.jpg", "/songs/Boombayah.mp3", 5544841m, 2023L }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("0336da83-36b2-49d2-ae14-be954ad51370"), new Guid("ff6ec874-59a6-497d-a644-6fa59fb7f3ae") });

            migrationBuilder.InsertData(
                table: "ArtistSong",
                columns: new[] { "ArtistId", "SongId" },
                values: new object[,]
                {
                    { new Guid("09c1bfe7-d884-4484-8f66-8225536214c9"), new Guid("18f94f44-2cb8-4dc7-bcc5-cd721ba1e2f5") },
                    { new Guid("a3616670-4fd8-49cf-b3fc-82dc29f7e94f"), new Guid("b5a14be6-f859-40d5-ab01-1814f0c72b61") },
                    { new Guid("961f8b25-ae91-4b8b-940a-8caa7503e7ea"), new Guid("4df89010-89c1-47a2-a9fb-1e0e72beb906") },
                    { new Guid("47720334-d5e6-445d-9871-3336634824c5"), new Guid("9da35767-6827-420a-a104-7d4839382db8") },
                    { new Guid("77133a0f-eed5-47cf-b6f1-9db1c9c78009"), new Guid("9da35767-6827-420a-a104-7d4839382db8") },
                    { new Guid("cfd5c125-09fd-4490-a237-22696d309e23"), new Guid("a7d834f3-6bda-4c81-bbf5-9834edfb0cd1") },
                    { new Guid("cfd5c125-09fd-4490-a237-22696d309e23"), new Guid("322b6882-f77b-44b4-93f7-5d614bec4f09") },
                    { new Guid("db28e1b6-6e88-46ee-bad6-4cb381c2e8c3"), new Guid("322b6882-f77b-44b4-93f7-5d614bec4f09") },
                    { new Guid("e0cef1be-fafd-4979-9f32-3ad2fa27ce71"), new Guid("70f850b5-5b05-4df6-844e-a477c4150ed5") },
                    { new Guid("3a17d74c-2b66-469f-a07e-e110906ed263"), new Guid("70f850b5-5b05-4df6-844e-a477c4150ed5") },
                    { new Guid("1c9307ea-95ff-42d5-8883-2138e87b1acf"), new Guid("df23feb6-d98f-4484-bdd2-aeef0f567213") },
                    { new Guid("1c9307ea-95ff-42d5-8883-2138e87b1acf"), new Guid("21e0d421-a233-4f6c-863c-3c99e01bf405") },
                    { new Guid("1c9307ea-95ff-42d5-8883-2138e87b1acf"), new Guid("e93cc63f-062d-419e-8cb9-161298b5d532") }
                });

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
