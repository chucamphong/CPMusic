﻿// <auto-generated />
using System;
using CPMusic.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CPMusic.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CPMusic.Models.Artist", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Avatar")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Avatar")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Artists");

                    b.HasData(
                        new
                        {
                            Id = new Guid("09c1bfe7-d884-4484-8f66-8225536214c9"),
                            Avatar = "/img/avatars/artists/ChiPu.jpg",
                            CreatedAt = new DateTime(2020, 6, 15, 12, 42, 41, 923, DateTimeKind.Local).AddTicks(768),
                            Name = "Chi Pu"
                        },
                        new
                        {
                            Id = new Guid("a3616670-4fd8-49cf-b3fc-82dc29f7e94f"),
                            Avatar = "/img/avatars/artists/LouHoang.jpg",
                            CreatedAt = new DateTime(2020, 6, 15, 12, 42, 41, 923, DateTimeKind.Local).AddTicks(2188),
                            Name = "Lou Hoàng"
                        },
                        new
                        {
                            Id = new Guid("1c9307ea-95ff-42d5-8883-2138e87b1acf"),
                            Avatar = "/img/avatars/artists/BlackPink.jpg",
                            CreatedAt = new DateTime(2020, 6, 15, 12, 42, 41, 923, DateTimeKind.Local).AddTicks(2232),
                            Name = "BLACKPINK"
                        },
                        new
                        {
                            Id = new Guid("961f8b25-ae91-4b8b-940a-8caa7503e7ea"),
                            Avatar = "/img/avatars/artists/HuongTram.jpg",
                            CreatedAt = new DateTime(2020, 6, 15, 12, 42, 41, 923, DateTimeKind.Local).AddTicks(2237),
                            Name = "Hương Tràm"
                        },
                        new
                        {
                            Id = new Guid("47720334-d5e6-445d-9871-3336634824c5"),
                            Avatar = "/img/avatars/artists/HoaMinzy.jpg",
                            CreatedAt = new DateTime(2020, 6, 15, 12, 42, 41, 923, DateTimeKind.Local).AddTicks(2242),
                            Name = "Hòa Minzy"
                        },
                        new
                        {
                            Id = new Guid("77133a0f-eed5-47cf-b6f1-9db1c9c78009"),
                            Avatar = "/img/avatars/artists/MrSiro.jpg",
                            CreatedAt = new DateTime(2020, 6, 15, 12, 42, 41, 923, DateTimeKind.Local).AddTicks(2248),
                            Name = "Mr Siro"
                        },
                        new
                        {
                            Id = new Guid("cfd5c125-09fd-4490-a237-22696d309e23"),
                            Avatar = "/img/avatars/artists/TrucNhan.jpg",
                            CreatedAt = new DateTime(2020, 6, 15, 12, 42, 41, 923, DateTimeKind.Local).AddTicks(2258),
                            Name = "Trúc Nhân"
                        },
                        new
                        {
                            Id = new Guid("e0cef1be-fafd-4979-9f32-3ad2fa27ce71"),
                            Avatar = "/img/avatars/artists/MIN.jpg",
                            CreatedAt = new DateTime(2020, 6, 15, 12, 42, 41, 923, DateTimeKind.Local).AddTicks(2264),
                            Name = "MIN"
                        },
                        new
                        {
                            Id = new Guid("3a17d74c-2b66-469f-a07e-e110906ed263"),
                            Avatar = "/img/avatars/artists/MrA.jpg",
                            CreatedAt = new DateTime(2020, 6, 15, 12, 42, 41, 923, DateTimeKind.Local).AddTicks(2268),
                            Name = "Mr.A"
                        },
                        new
                        {
                            Id = new Guid("db28e1b6-6e88-46ee-bad6-4cb381c2e8c3"),
                            Avatar = "/img/avatars/artists/TruongThaoNhi.jpg",
                            CreatedAt = new DateTime(2020, 6, 15, 12, 42, 41, 923, DateTimeKind.Local).AddTicks(2273),
                            Name = "Trương Thảo Nhi"
                        });
                });

            modelBuilder.Entity("CPMusic.Models.ArtistSong", b =>
                {
                    b.Property<Guid>("ArtistId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SongId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ArtistId", "SongId");

                    b.HasIndex("SongId");

                    b.ToTable("ArtistSong");

                    b.HasData(
                        new
                        {
                            ArtistId = new Guid("09c1bfe7-d884-4484-8f66-8225536214c9"),
                            SongId = new Guid("18f94f44-2cb8-4dc7-bcc5-cd721ba1e2f5")
                        },
                        new
                        {
                            ArtistId = new Guid("a3616670-4fd8-49cf-b3fc-82dc29f7e94f"),
                            SongId = new Guid("b5a14be6-f859-40d5-ab01-1814f0c72b61")
                        },
                        new
                        {
                            ArtistId = new Guid("1c9307ea-95ff-42d5-8883-2138e87b1acf"),
                            SongId = new Guid("df23feb6-d98f-4484-bdd2-aeef0f567213")
                        },
                        new
                        {
                            ArtistId = new Guid("1c9307ea-95ff-42d5-8883-2138e87b1acf"),
                            SongId = new Guid("21e0d421-a233-4f6c-863c-3c99e01bf405")
                        },
                        new
                        {
                            ArtistId = new Guid("1c9307ea-95ff-42d5-8883-2138e87b1acf"),
                            SongId = new Guid("e93cc63f-062d-419e-8cb9-161298b5d532")
                        },
                        new
                        {
                            ArtistId = new Guid("961f8b25-ae91-4b8b-940a-8caa7503e7ea"),
                            SongId = new Guid("4df89010-89c1-47a2-a9fb-1e0e72beb906")
                        },
                        new
                        {
                            ArtistId = new Guid("47720334-d5e6-445d-9871-3336634824c5"),
                            SongId = new Guid("9da35767-6827-420a-a104-7d4839382db8")
                        },
                        new
                        {
                            ArtistId = new Guid("77133a0f-eed5-47cf-b6f1-9db1c9c78009"),
                            SongId = new Guid("9da35767-6827-420a-a104-7d4839382db8")
                        },
                        new
                        {
                            ArtistId = new Guid("cfd5c125-09fd-4490-a237-22696d309e23"),
                            SongId = new Guid("a7d834f3-6bda-4c81-bbf5-9834edfb0cd1")
                        },
                        new
                        {
                            ArtistId = new Guid("cfd5c125-09fd-4490-a237-22696d309e23"),
                            SongId = new Guid("322b6882-f77b-44b4-93f7-5d614bec4f09")
                        },
                        new
                        {
                            ArtistId = new Guid("db28e1b6-6e88-46ee-bad6-4cb381c2e8c3"),
                            SongId = new Guid("322b6882-f77b-44b4-93f7-5d614bec4f09")
                        },
                        new
                        {
                            ArtistId = new Guid("e0cef1be-fafd-4979-9f32-3ad2fa27ce71"),
                            SongId = new Guid("70f850b5-5b05-4df6-844e-a477c4150ed5")
                        },
                        new
                        {
                            ArtistId = new Guid("3a17d74c-2b66-469f-a07e-e110906ed263"),
                            SongId = new Guid("70f850b5-5b05-4df6-844e-a477c4150ed5")
                        });
                });

            modelBuilder.Entity("CPMusic.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Thumbnail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1bb78812-0c2a-4bef-9e29-91bd45cc3311"),
                            CreatedAt = new DateTime(2020, 6, 15, 12, 42, 41, 921, DateTimeKind.Local).AddTicks(3093),
                            Name = "Nhạc trẻ",
                            Thumbnail = "/img/categories/NhacTre.jpg"
                        },
                        new
                        {
                            Id = new Guid("557a2270-276b-43eb-94cb-171cbf0cc9c5"),
                            CreatedAt = new DateTime(2020, 6, 15, 12, 42, 41, 921, DateTimeKind.Local).AddTicks(4599),
                            Name = "Nhạc Hàn Quốc",
                            Thumbnail = "/img/categories/NhacHanQuoc.jpg"
                        },
                        new
                        {
                            Id = new Guid("0ebe2395-6106-4c6f-827a-29400045b39f"),
                            CreatedAt = new DateTime(2020, 6, 15, 12, 42, 41, 921, DateTimeKind.Local).AddTicks(4638),
                            Name = "Nhạc Trung Quốc",
                            Thumbnail = "/img/categories/NhacTrungQuoc.jpg"
                        },
                        new
                        {
                            Id = new Guid("bcc390f6-f78e-468c-a158-6dd23e6a28bc"),
                            CreatedAt = new DateTime(2020, 6, 15, 12, 42, 41, 921, DateTimeKind.Local).AddTicks(4645),
                            Name = "Nhạc EDM",
                            Thumbnail = "/img/categories/NhacEDM.jpg"
                        },
                        new
                        {
                            Id = new Guid("917da125-164f-4d97-ba01-59ac6e93f5c3"),
                            CreatedAt = new DateTime(2020, 6, 15, 12, 42, 41, 921, DateTimeKind.Local).AddTicks(4650),
                            Name = "Nhạc Âu Mỹ",
                            Thumbnail = "/img/categories/NhacAuMy.jpg"
                        },
                        new
                        {
                            Id = new Guid("57ec071d-9986-424f-9dae-ed54e2316214"),
                            CreatedAt = new DateTime(2020, 6, 15, 12, 42, 41, 921, DateTimeKind.Local).AddTicks(4656),
                            Name = "Nhạc Latin",
                            Thumbnail = "/img/categories/NhacLatin.jpg"
                        },
                        new
                        {
                            Id = new Guid("9426b9b8-4b85-459c-9f82-79bddee93e56"),
                            CreatedAt = new DateTime(2020, 6, 15, 12, 42, 41, 921, DateTimeKind.Local).AddTicks(4661),
                            Name = "Nhạc Nhật Bản",
                            Thumbnail = "/img/categories/NhacNhatBan.jpg"
                        },
                        new
                        {
                            Id = new Guid("d599df0e-a82e-49fd-84e4-dfaf4b40a070"),
                            CreatedAt = new DateTime(2020, 6, 15, 12, 42, 41, 921, DateTimeKind.Local).AddTicks(4666),
                            Name = "Nhạc Trữ Tình",
                            Thumbnail = "/img/categories/NhacTruTinh.jpg"
                        });
                });

            modelBuilder.Entity("CPMusic.Models.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Country");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4b73a5c7-0623-46a5-b658-b5f8db232498"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Việt Nam"
                        },
                        new
                        {
                            Id = new Guid("109c4273-8602-430e-8f18-63766aee423b"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Âu Mỹ"
                        },
                        new
                        {
                            Id = new Guid("1e2831a8-1a04-4cf4-b301-dbb25ac05856"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Hàn Quốc"
                        });
                });

            modelBuilder.Entity("CPMusic.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ff6ec874-59a6-497d-a644-6fa59fb7f3ae"),
                            ConcurrencyStamp = "241d2c23-ceeb-4b0c-8e79-cf7c034b4f38",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = new Guid("dd56b0e4-1fcf-4e63-9b28-6afae71002f7"),
                            ConcurrencyStamp = "070a7fc3-2fdc-491a-ba43-63538e7a100e",
                            Name = "Member",
                            NormalizedName = "MEMBER"
                        });
                });

            modelBuilder.Entity("CPMusic.Models.Song", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OtherName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Thumbnail")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Views")
                        .HasColumnType("decimal(20,0)");

                    b.Property<long>("Year")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CountryId");

                    b.HasIndex("Thumbnail")
                        .IsUnique();

                    b.HasIndex("Url")
                        .IsUnique();

                    b.ToTable("Songs");

                    b.HasData(
                        new
                        {
                            Id = new Guid("18f94f44-2cb8-4dc7-bcc5-cd721ba1e2f5"),
                            CategoryId = new Guid("1bb78812-0c2a-4bef-9e29-91bd45cc3311"),
                            CountryId = new Guid("4b73a5c7-0623-46a5-b658-b5f8db232498"),
                            CreatedAt = new DateTime(2020, 6, 15, 12, 42, 41, 924, DateTimeKind.Local).AddTicks(4198),
                            Name = "Anh ơi ở lại",
                            OtherName = "Cám Tấm",
                            Thumbnail = "/img/songs/AnhOiOLai.jpg",
                            Url = "/songs/AnhOiOLai.mp3",
                            Views = 3213213213m,
                            Year = 2019L
                        },
                        new
                        {
                            Id = new Guid("b5a14be6-f859-40d5-ab01-1814f0c72b61"),
                            CategoryId = new Guid("1bb78812-0c2a-4bef-9e29-91bd45cc3311"),
                            CountryId = new Guid("4b73a5c7-0623-46a5-b658-b5f8db232498"),
                            CreatedAt = new DateTime(2020, 8, 15, 12, 42, 41, 924, DateTimeKind.Local).AddTicks(6026),
                            Name = "Cảm giác lúc ấy sẽ ra sao",
                            Thumbnail = "/img/songs/CamGiacLucAySeRaSao.jpg",
                            Url = "/songs/CamGiacLucAySeRaSao.mp3",
                            Views = 4213219841m,
                            Year = 2018L
                        },
                        new
                        {
                            Id = new Guid("df23feb6-d98f-4484-bdd2-aeef0f567213"),
                            CategoryId = new Guid("557a2270-276b-43eb-94cb-171cbf0cc9c5"),
                            CountryId = new Guid("1e2831a8-1a04-4cf4-b301-dbb25ac05856"),
                            CreatedAt = new DateTime(2020, 3, 15, 12, 42, 41, 924, DateTimeKind.Local).AddTicks(7127),
                            Name = "Kill this love",
                            Thumbnail = "/img/songs/KillThisLove.jpg",
                            Url = "/songs/KillThisLove.mp3",
                            Views = 42841m,
                            Year = 2012L
                        },
                        new
                        {
                            Id = new Guid("21e0d421-a233-4f6c-863c-3c99e01bf405"),
                            CategoryId = new Guid("557a2270-276b-43eb-94cb-171cbf0cc9c5"),
                            CountryId = new Guid("1e2831a8-1a04-4cf4-b301-dbb25ac05856"),
                            CreatedAt = new DateTime(2020, 3, 15, 12, 42, 41, 924, DateTimeKind.Local).AddTicks(7160),
                            Name = "Du ddu du ddu",
                            Thumbnail = "/img/songs/DuDduDuDdu.jpg",
                            Url = "/songs/DuDduDuDdu.mp3",
                            Views = 42444841m,
                            Year = 2013L
                        },
                        new
                        {
                            Id = new Guid("e93cc63f-062d-419e-8cb9-161298b5d532"),
                            CategoryId = new Guid("557a2270-276b-43eb-94cb-171cbf0cc9c5"),
                            CountryId = new Guid("1e2831a8-1a04-4cf4-b301-dbb25ac05856"),
                            CreatedAt = new DateTime(2020, 12, 15, 12, 42, 41, 924, DateTimeKind.Local).AddTicks(7168),
                            Name = "Boombayah",
                            Thumbnail = "/img/songs/Boombayah.jpg",
                            Url = "/songs/Boombayah.mp3",
                            Views = 5544841m,
                            Year = 2023L
                        },
                        new
                        {
                            Id = new Guid("4df89010-89c1-47a2-a9fb-1e0e72beb906"),
                            CategoryId = new Guid("1bb78812-0c2a-4bef-9e29-91bd45cc3311"),
                            CountryId = new Guid("4b73a5c7-0623-46a5-b658-b5f8db232498"),
                            CreatedAt = new DateTime(2025, 1, 15, 12, 42, 41, 924, DateTimeKind.Local).AddTicks(7180),
                            Name = "Em gái mưa",
                            Thumbnail = "/img/songs/EmGaiMua.jpg",
                            Url = "/songs/EmGaiMua.mp3",
                            Views = 222244841m,
                            Year = 2017L
                        },
                        new
                        {
                            Id = new Guid("9da35767-6827-420a-a104-7d4839382db8"),
                            CategoryId = new Guid("1bb78812-0c2a-4bef-9e29-91bd45cc3311"),
                            CountryId = new Guid("4b73a5c7-0623-46a5-b658-b5f8db232498"),
                            CreatedAt = new DateTime(2025, 1, 15, 12, 42, 41, 924, DateTimeKind.Local).AddTicks(7187),
                            Name = "Không thể cùng nhau suốt kiếp",
                            Thumbnail = "/img/songs/KhongTheCungNhauSuotKiep.jpg",
                            Url = "/songs/KhongTheCungNhauSuotKiep.mp3",
                            Views = 255841m,
                            Year = 2015L
                        },
                        new
                        {
                            Id = new Guid("a7d834f3-6bda-4c81-bbf5-9834edfb0cd1"),
                            CategoryId = new Guid("1bb78812-0c2a-4bef-9e29-91bd45cc3311"),
                            CountryId = new Guid("4b73a5c7-0623-46a5-b658-b5f8db232498"),
                            CreatedAt = new DateTime(2021, 6, 15, 12, 42, 41, 924, DateTimeKind.Local).AddTicks(7193),
                            Name = "Muốn khóc thật to",
                            Thumbnail = "/img/songs/MuonKhocThatTo.jpg",
                            Url = "/songs/MuonKhocThatTo.mp3",
                            Views = 2321321312m,
                            Year = 2012L
                        },
                        new
                        {
                            Id = new Guid("322b6882-f77b-44b4-93f7-5d614bec4f09"),
                            CategoryId = new Guid("1bb78812-0c2a-4bef-9e29-91bd45cc3311"),
                            CountryId = new Guid("4b73a5c7-0623-46a5-b658-b5f8db232498"),
                            CreatedAt = new DateTime(2021, 6, 15, 12, 42, 41, 924, DateTimeKind.Local).AddTicks(7200),
                            Name = "Bốn chữ lắm",
                            Thumbnail = "/img/songs/BonChuLam.jpg",
                            Url = "/songs/BonChuLam.mp3",
                            Views = 2344321312m,
                            Year = 2013L
                        },
                        new
                        {
                            Id = new Guid("70f850b5-5b05-4df6-844e-a477c4150ed5"),
                            CategoryId = new Guid("1bb78812-0c2a-4bef-9e29-91bd45cc3311"),
                            CountryId = new Guid("4b73a5c7-0623-46a5-b658-b5f8db232498"),
                            CreatedAt = new DateTime(2021, 6, 15, 12, 42, 41, 924, DateTimeKind.Local).AddTicks(7207),
                            Name = "Tìm",
                            Thumbnail = "/img/songs/Tim.jpg",
                            Url = "/songs/Tim.mp3",
                            Views = 2421312m,
                            Year = 2011L
                        });
                });

            modelBuilder.Entity("CPMusic.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0336da83-36b2-49d2-ae14-be954ad51370"),
                            AccessFailedCount = 0,
                            Avatar = "/img/avatars/users/ChuPhong.jpg",
                            ConcurrencyStamp = "ffcd79a9-10d6-40a9-ba69-4b6df83b3273",
                            CreatedAt = new DateTime(2020, 6, 15, 12, 42, 41, 909, DateTimeKind.Local).AddTicks(8574),
                            Email = "chucamphong1999@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            Name = "Chu Cẩm Phong",
                            NormalizedEmail = "CHUCAMPHONG1999@GMAIL.COM",
                            NormalizedUserName = "CHUCAMPHONG",
                            PasswordHash = "AQAAAAEAACcQAAAAEGcvVLCGxjgvdx9VWIrk5ntHJKb05w3D3A7I943bzG1oFhEzaqlQhE+5/LDTkGTT5A==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "94e5e26b-1004-4306-983d-6442d3799a54",
                            TwoFactorEnabled = false,
                            UserName = "chucamphong"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("0336da83-36b2-49d2-ae14-be954ad51370"),
                            RoleId = new Guid("ff6ec874-59a6-497d-a644-6fa59fb7f3ae")
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("CPMusic.Models.ArtistSong", b =>
                {
                    b.HasOne("CPMusic.Models.Artist", "Artist")
                        .WithMany("ArtistSongs")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CPMusic.Models.Song", "Song")
                        .WithMany("ArtistSongs")
                        .HasForeignKey("SongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CPMusic.Models.Song", b =>
                {
                    b.HasOne("CPMusic.Models.Category", "Category")
                        .WithMany("Songs")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CPMusic.Models.Country", "Country")
                        .WithMany("Songs")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("CPMusic.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("CPMusic.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("CPMusic.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("CPMusic.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CPMusic.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("CPMusic.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
