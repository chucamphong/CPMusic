using System;
using CPMusic.Models.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace CPMusic.Models
{
    /// <summary>
    /// Bảng thành viên
    /// </summary>
    public class User : IdentityUser<Guid>, IEntity
    {
        /// <summary>
        /// Tên người dùng
        /// </summary>
        [ProtectedPersonalData]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Ảnh đại diện
        /// </summary>
        [ProtectedPersonalData]
        public string? Avatar { get; set; }

        /// <summary>
        /// Ngày thêm người dùng vào cơ sở dữ liệu
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}