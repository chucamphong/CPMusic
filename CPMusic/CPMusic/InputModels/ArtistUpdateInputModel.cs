using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace CPMusic.InputModels
{
    public class ArtistUpdateInputModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Tên nghệ sĩ")]
        public string Name { get; set; } = null!;

        public string? Avatar { get; set; }

        [Display(Name = "Ảnh đại diện")]
        [DataType(DataType.Upload)]
        public IFormFile? UploadAvatar { get; set; }
    }
}