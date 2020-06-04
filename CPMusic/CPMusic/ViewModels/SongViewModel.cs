using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using CPMusic.Models;

namespace CPMusic.ViewModels
{
    public class SongViewModel
    {
        public string Id { get; set; } = null!;

        [Display(Name = "Tên bài hát")]
        public string Name { get; set; } = null!;

        [Display(Name = "Tên khác")]
        public string? OtherName { get; set; }

        [Display(Name = "Ảnh đại diện")]
        public string Thumbnail { get; set; } = null!;

        [Display(Name = "Nơi lưu bài hát")]
        public string Url { get; set; } = null!;

        [Display(Name = "Năm phát hành")]
        public uint Year { get; set; }

        [Display(Name = "Lượt nghe")]
        public uint Views { get; set; }

        [Display(Name = "Thể loại")]
        public string Category { get; set; } = null!;

        [Display(Name = "Nghệ sĩ")]
        public IEnumerable<Artist?> Artists { get; set; } = null!;

        [Display(Name = "Ngày tạo")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy - HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime CreatedAt { get; set; }

        public string CapitalizeName => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Name);

        public string? ArtistsToString => string.Join(", ", Artists.Select(artist => artist?.Name));
    }
}