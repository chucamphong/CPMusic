using System.Collections.Generic;

namespace CPMusic.Models
{
    public class Artist
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Avatar { get; set; } = null!;

        public ICollection<ArtistSong> ArtistSongs { get; set; } = null!;
    }
}