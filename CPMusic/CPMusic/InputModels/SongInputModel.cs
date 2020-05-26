using System;
using System.ComponentModel.DataAnnotations;
using CPMusic.Models;

namespace CPMusic.InputModels
{
    public class SongInputModel
    {
        public Guid Id { get; set; }
        
        [Display(Name = "Tên bài hát")]
        public string Name { get; set; } = null!;
        
        [Display(Name = "Tên khác")]
        public string? OtherName { get; set; }
            
        [Display(Name = "Ảnh đại diện")]
        [DataType(DataType.Upload)]
        public string Thumbnail { get; set; } = null!;
        
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
