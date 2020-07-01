using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CPMusic.Data.Interfaces;
using CPMusic.Helpers;
using CPMusic.InputModels;
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
        private readonly IMapper _mapper;
        private readonly IArtistRepository _artistRepository;

        public ArtistController(IMapper mapper, IArtistRepository artistRepository)
        {
            _mapper = mapper;
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
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id is null) return NotFound();

            var artist = await _artistRepository.GetByIdAsyncWithRelationShip((Guid) id);

            if (artist is null) return NotFound();

            return View(artist);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id is null) return NotFound();

            var artist = await _artistRepository.GetByIdAsync((Guid) id);

            if (artist is null) return NotFound();

            return View(_mapper.Map<ArtistUpdateInputModel>(artist));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, ArtistUpdateInputModel request,
                                              [FromServices] IFileUpload fileUpload)
        {
            // Nếu ID bị null
            if (id is null) return NotFound();

            // Lấy thông tin nghệ sĩ
            var artist = await _artistRepository.GetByIdAsync((Guid) id);

            // Kiểm tra nghệ sĩ có tồn tại hay không và kiểm tra ID nghệ sĩ cần chỉnh sửa có khớp hay không
            if (artist is null || artist.Id != id) return NotFound();

            // Kiểm tra tính hợp lệ của dữ liệu
            if (!ModelState.IsValid) return View(request);

            // Xử lý tải lên ảnh đại diện của nghệ sĩ
            request.Avatar = request.UploadAvatar is null
                ? artist.Avatar
                : await fileUpload.Save(request.UploadAvatar, "img/avatars/artists");

            // Thực hiện cập nhật vào cơ sở dữ liệu
            try
            {
                Artist entity = _mapper.Map<Artist>(request);

                await _artistRepository.Update(entity);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _artistRepository.GetByIdAsync(request.Id) is null) return NotFound();

                throw;
            }

            return RedirectToAction(nameof(Index));
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