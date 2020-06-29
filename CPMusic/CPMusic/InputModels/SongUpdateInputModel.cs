using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace CPMusic.InputModels
{
    /// <summary>
    /// Dùng để chứa dữ liệu khi người dùng cập nhật form lên máy chủ
    /// </summary>
    public class SongUpdateInputModel
    {
        // ID bài hát
        public Guid Id { get; set; }

        // Tên bài hát
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Tên bài hát")]
        public string Name { get; set; } = null!;

        // Tên khác của bài hát
        [Display(Name = "Tên khác")]
        public string? OtherName { get; set; }

        // Dùng để tải hình ảnh lên máy chủ, sau khi xử lý xong mới đặt nơi lưu vào Thumbnail
        [Display(Name = "Ảnh đại diện")]
        [DataType(DataType.Upload)]
        public IFormFile? UploadThumbnail { get; set; }

        // Dùng để tải bài hát lên máy chủ, sau khi xử lý xong mới đặt nơi lưu vào Url
        [Display(Name = "Bài hát")]
        [DataType(DataType.Upload)]
        public IFormFile? UploadSong { get; set; }

        // Lưu đường dẫn hình ảnh bài hát để cập nhật vào cơ sở dữ liệu
        public string? Thumbnail { get; set; }

        // Lưu đường dẫn của bài hát để cập nhật vào cơ sở dữ liệu
        public string? Url { get; set; }

        // Năm phát hành của bài hát
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Năm phát hành")]
        public uint Year { get; set; }
        
        // Quốc gia của bài hát
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Quốc gia")]
        public Guid CountryId { get; set; }

        // Thể loại của bài hát
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Thể loại")]
        public Guid CategoryId { get; set; }

        // Nghệ sĩ của bài hát
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Nghệ sĩ")]
        public Guid[]? ArtistsId { get; set; }
    }
}