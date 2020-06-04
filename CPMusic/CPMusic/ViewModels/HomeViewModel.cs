using System.Collections.Generic;

namespace CPMusic.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<SongViewModel> RandomSongs { get; set; } = null!;
        
        public IEnumerable<SongViewModel> NewSongsReleased { get; set; } = null!;

        public IEnumerable<CategoryViewModel> Categories { get; set; } = null!;
    }
}