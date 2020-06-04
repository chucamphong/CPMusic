using System;
using System.Collections.Generic;
using CPMusic.Models;

namespace CPMusic.ViewModels
{
    public class CategoryViewModel
    {
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Thumbnail { get; set; } = null!;
        
        public DateTime CreatedAt { get; set; }

        public IEnumerable<Song> Songs { get; set; } = null!;
    }
}