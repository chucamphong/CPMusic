using System.Collections.Generic;

namespace CPMusic.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public ICollection<Song> Songs { get; set; } = null!;
    }
}