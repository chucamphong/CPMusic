using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace CPMusic.InputModels
{
    public class SongInputModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Tên bài hát")]
        public string Name { get; set; } = null!;

        [Display(Name = "Tên khác")]
        public string? OtherName { get; set; }

        /// <summary>
        /// Dùng để tải hình ảnh lên máy chủ, sau khi xử lý xong mới đặt nơi lưu vào Thumbnail
        /// </summary>
        [Display(Name = "Ảnh đại diện")]
        [DataType(DataType.Upload)]
        public IFormFile UploadThumbnail { get; set; } = null!;

        /// <summary>
        /// Lưu đường dẫn của bài hát để cập nhật vào cơ sở dữ liệu
        /// </summary>
        public string? Thumbnail { get; set; }

        [Display(Name = "Đường dẫn bài hát")]
        public string Url { get; set; } = null!;

        [Display(Name = "Năm phát hành")]
        public uint Year { get; set; }

        [Display(Name = "Thể loại")]
        public Guid CategoryId { get; set; }

        [Display(Name = "Nghệ sĩ")]
        public Guid[]? ArtistsId { get; set; }
    }
}