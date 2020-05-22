using System;
using System.Collections.Generic;
using CPMusic.Data.Interfaces;

namespace CPMusic.Models
{
    /// <summary>
    /// Bảng thể loại
    /// </summary>
    public class Category : IEntity
    {
        /// <summary>
        /// ID thể loại
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Tên thể loại
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Ngày thêm thể loại vào trong cơ sở dữ liệu
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// Danh sách bài hát thuộc thể loại này
        /// </summary>
        public virtual ICollection<Song> Songs { get; set; } = new LinkedList<Song>();
    }
}