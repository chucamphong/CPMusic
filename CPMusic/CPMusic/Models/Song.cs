using System;
using System.Collections.Generic;
using CPMusic.Models.Interfaces;

namespace CPMusic.Models
{
    public class Song : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? OtherName { get; set; }

        public string Thumbnail { get; set; } = null!;

        public string Url { get; set; } = null!;

        public ushort Year { get; set; } = Convert.ToUInt16(DateTime.Now.Year);

        public ulong Views { get; set; } = 0;

        public Category Category { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<ArtistSong> ArtistSongs { get; set; } = null!;
    }
}