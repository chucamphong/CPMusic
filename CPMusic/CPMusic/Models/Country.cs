using System;
using System.Collections.Generic;
using CPMusic.Data.Interfaces;

namespace CPMusic.Models
{
    public class Country : IEntity
    {
        /// <summary>
        /// Mã quốc gia trong cơ sở dữ liệu
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Tên quốc gia
        /// </summary>
        public string Name { get; set; } = null!;
        
        /// <summary>
        /// Thời gian tạo trong cơ sở dữ liệu
        /// </summary>
        public DateTime CreatedAt { get; set; }
        
        /// <summary>
        /// Danh sách bài hát thuộc quốc gia này
        /// </summary>
        public virtual ICollection<Song> Songs { get; set; } = new LinkedList<Song>();
    }
}