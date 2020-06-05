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
        Task<IEnumerable<Song>> RandomSongs(int take = 0);

        /// <summary>
        /// Lấy N bài hát có lượt nghe cao nhất
        /// </summary>
        /// <param name="take">Số bài hát cần lấy (tối thiểu 1)</param>
        Task<IEnumerable<Song>> Ranking(int take = 0);
        
        /// <summary>
        /// Lấy N bài hát mới phát hành
        /// </summary>
        /// <param name="take">Số bài hát cần lấy (tối thiểu 1)</param>
        Task<IEnumerable<Song>> NewSongsReleased(int take = 0);
        
        /// <summary>
        /// Lấy bản ghi có <paramref name="id"/> và tất cả mối quan hệ liên quan
        /// </summary>
        Task<Song?> GetByIdAsyncWithRelationShip(Guid id);

        /// <summary>
        /// Tìm những bài hát có điểm tương tự với <paramref name="song"/>
        /// Lấy ra <paramref name="take"/> bài hát
        /// </summary>
        /// <example>
        /// Ví dụ có bài hát là Anh Ơi ở lại - Chi Pu - Nhạc trẻ
        /// Thì sẽ tìm những bài hát có tên gần giống với Anh ơi ở lại hoặc
        /// các bài hát có ca sĩ Chi Pu hoặc
        /// có cùng thể loại nhạc trẻ
        /// </example>
        Task<IEnumerable<Song>> Suggestions(Song song, int take);
    }
}