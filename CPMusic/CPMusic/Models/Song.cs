using System;
using System.Collections.Generic;
using CPMusic.Models.Interfaces;

namespace CPMusic.Models
{
    /// <summary>
    /// Bảng bài hát
    /// </summary>
    public class Song : IEntity
    {
        /// <summary>
        /// ID bài hát
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Tên bài hát
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Tên khác của bài hát
        /// </summary>
        public string? OtherName { get; set; }

        /// <summary>
        /// Ảnh đại diện của bài hát
        /// </summary>
        public string Thumbnail { get; set; } = null!;

        /// <summary>
        /// Đường dẫn bài hát
        /// </summary>
        public string Url { get; set; } = null!;

        /// <summary>
        /// Năm phát hành bài hát
        /// </summary>
        public uint Year { get; set; } = Convert.ToUInt32(DateTime.Now.Year);

        /// <summary>
        /// Lượt xem bài hát
        /// </summary>
        public ulong Views { get; set; }

        /// <summary>
        /// Thể loại của bài hát
        /// </summary>
        public Category Category { get; set; } = null!;

        /// <summary>
        /// Ngày mà bài hát được tạo trong cơ sở dữ liệu
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// Danh sách nghệ sĩ hát bài hát này
        /// Có thể là 1 nghệ sĩ hoặc nhiều nghệ sĩ
        /// </summary>
        public ICollection<ArtistSong> ArtistSongs { get; set; } = new LinkedList<ArtistSong>();
    }
}