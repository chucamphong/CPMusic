using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CPMusic.Models
{
    public class Song
    {
        public int Id { get; set; }
        
        public string Name { get; set; } = null!;

        public string? OtherName { get; set; }
        
        public string Thumbnail { get; set; } = null!;

        public string Url { get; set; } = null!;

        public ushort Year { get; set; }
        
        public ulong Views { get; set; }

        public Category Category { get; set; } = null!;
        
        public ICollection<ArtistSong> ArtistSongs { get; set; } = null!;
    }
}