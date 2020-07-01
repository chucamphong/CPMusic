using System;
using System.Threading.Tasks;
using CPMusic.Models;

namespace CPMusic.Data.Interfaces
{
    public interface IArtistRepository : IRepository<Artist>
    {
        /// <summary>
        /// Lấy nghệ sĩ có <paramref name="id"/> và tất cả mối quan hệ liên quan
        /// </summary>
        Task<Artist?> GetByIdAsyncWithRelationShip(Guid id);
    }
}
