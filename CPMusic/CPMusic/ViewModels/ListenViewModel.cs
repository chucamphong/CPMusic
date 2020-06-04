using System.Collections.Generic;

namespace CPMusic.ViewModels
{
    public class ListenViewModel
    {
        public SongViewModel Song { get; set; } = null!;

        public IEnumerable<SongViewModel> Suggestions { get; set; } = null!;
    }
}