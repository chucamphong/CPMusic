using System;
using System.Linq;
using System.Threading.Tasks;
using CPMusic.Data.Interfaces;
using CPMusic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace CPMusic.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ArtistController : Controller
    {
        private readonly IArtistRepository _artistRepository;

        public ArtistController(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        /// <summary>
        /// GET: /Admin/Artist
        /// Trang xem tất cả nghệ sĩ
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Index(int page = 1)
        {
            // Truy vấn lấy tất cả các cột trong bảng cùng với quan hệ
            IQueryable<Artist> songs = _artistRepository.Query(
                col => col,
                include: query =>
                    query.Include(col => col.ArtistSongs)
                         .ThenInclude(artistSong => artistSong.Song),
                orderBy: query => query.OrderByDescending(song => song.CreatedAt));

            IPagedList<Artist> paginated = await songs.ToPagedListAsync(page, 5);

            return View(paginated);
        }

        /// <summary>
        /// GET: Admin/Artist/Details/db28e1b6-6e88-46ee-bad6-4cb381c2e8c3
        /// Trang xem thông tin của nghệ sĩ
        /// </summary>
        [HttpGet]
        [Route("{area}/{controller}/{action}/{id}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var artist = await _artistRepository.GetByIdAsyncWithRelationShip(id);

            if (artist is null) return NotFound();

            return View(artist);
        }

        /// <summary>
        /// GET: Admin/Artist/Delete/db28e1b6-6e88-46ee-bad6-4cb381c2e8c3
        /// Trang xóa nghệ sĩ
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id is null) return NotFound();

            var artist = await _artistRepository.GetByIdAsyncWithRelationShip((Guid) id);

            if (artist == null) return NotFound();

            return View(artist);
        }

        /// <summary>
        /// POST: Admin/Artist/Delete/db28e1b6-6e88-46ee-bad6-4cb381c2e8c3
        /// Xử lý xóa nghệ sĩ
        /// </summary>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _artistRepository.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}