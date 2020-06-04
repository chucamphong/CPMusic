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

        /// <summary>
        /// Lấy N bài hát có lượt nghe cao nhất
        /// </summary>
        /// <param name="take">Số bài hát cần lấy (tối thiểu 1)</param>
        IAsyncEnumerable<Song> Ranking(int take = 0);
        
        /// <summary>
        /// Lấy N bài hát mới phát hành
        /// </summary>
        /// <param name="take">Số bài hát cần lấy (tối thiểu 1)</param>
        IAsyncEnumerable<Song> NewSongsReleased(int take = 0);
    }
}