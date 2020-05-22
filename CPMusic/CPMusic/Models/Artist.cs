using System;
using System.Collections.Generic;
using CPMusic.Models.Interfaces;

namespace CPMusic.Models
{
    /// <summary>
    /// Bảng nghệ sĩ
    /// </summary>
    public class Artist : IEntity
    {
        /// <summary>
        /// ID nghệ sĩ
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Tên nghệ sĩ
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Ảnh đại diện của nghệ sĩ
        /// </summary>
        public string Avatar { get; set; } = null!;

        /// <summary>
        /// Ngày thêm nghệ sĩ vào cơ sở dữ liệu
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// Danh sách bài hát mà nghệ sĩ này hát
        /// </summary>
        public virtual ICollection<ArtistSong> ArtistSongs { get; set; } = new LinkedList<ArtistSong>();
    }
}