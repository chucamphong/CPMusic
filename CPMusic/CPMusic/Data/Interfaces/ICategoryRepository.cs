using System;
using System.Threading.Tasks;
using CPMusic.Models;

namespace CPMusic.Data.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        /// <summary>
        /// Lấy thể loại có <paramref name="id"/> và tất cả mối quan hệ liên quan
        /// </summary>
        Task<Category?> GetByIdAsyncWithRelationShip(Guid id);
    }
}
