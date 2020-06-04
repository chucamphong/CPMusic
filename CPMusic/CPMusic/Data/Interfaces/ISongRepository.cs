using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CPMusic.Models;

namespace CPMusic.Data.Interfaces
{
    public interface ISongRepository : IRepository<Song>
    {
        /// <summary>
        /// Lấy ngẫu nhiên N bài hát
        /// </summary>
        /// <param name="take">Số bài hát cần lấy (tối thiểu 1)</param>
        IAsyncEnumerable<Song> RandomSongs(int take = 0);
    }
}
