using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CPMusic.Data;
using CPMusic.Data.Interfaces;
using CPMusic.InputModels;
using CPMusic.Models;
using CPMusic.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CPMusic.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SongController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ISongRepository _songRepository;

        public SongController(ApplicationDbContext context, IMapper mapper, ISongRepository songRepository)
        {
            _context = context;
            _mapper = mapper;
            _songRepository = songRepository;
        }

        /// <summary>
        /// GET: /Admin/Song
        /// Trang xem tất cả bài hát
        /// </summary>
        public async Task<IActionResult> Index()
        {
            IEnumerable<Song> songs = await _songRepository.All(
                song => song,
                includes: song => song.Include(song => song.Category)
                                      .Include(song => song.ArtistSongs)
                                      .ThenInclude(artistSong => artistSong.Artist));

            IEnumerable<SongViewModel> songViewModel = _mapper.Map<IEnumerable<SongViewModel>>(songs);

            return View(songViewModel);
        }

        /// <summary>
        /// GET: Admin/Song/Details/18f94f44-2cb8-4dc7-bcc5-cd721ba1e2f2
        /// Trang xem thông tin của bài hát
        /// </summary>
        [HttpGet]
        [Route("{area}/{controller}/{action}/{id}")]
        public async Task<IActionResult> Details(Guid id)
        {
            Song? song = await _songRepository.GetByIdAsync(id);
            
            if (song is null)
            {
                return NotFound();
            }

            return View(song);
        }

        /// <summary>
        /// GET: Admin/Song/Create
        /// Trạng tạo bài hát
        /// </summary>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// POST: Admin/Song/Create
        /// Xử lý dữ liệu của bài hát, nếu hợp lệ thì sẽ tạo bài hát và ngược lại thì trả về lỗi
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,OtherName,Thumbnail,Url,Year,Views,CreatedAt")]
            Song song)
        {
            if (ModelState.IsValid)
            {
                song.Id = Guid.NewGuid();
                _context.Add(song);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(song);
        }

        /// <summary>
        /// GET: Admin/Song/Edit/18f94f44-2cb8-4dc7-bcc5-cd721ba1e2f2
        /// Trang sửa bài hát
        /// </summary>
        [HttpGet]
        [Route("{area}/{controller}/{action}/{id}")]
        public async Task<IActionResult> Edit(Guid id,
            [FromServices] IArtistRepository artistRepository,
            [FromServices] ICategoryRepository categoryRepository)
        {
            Song? song = await _songRepository.GetByIdAsync(id,
                song => song.Include(song => song.Category)
                            .Include(song => song.ArtistSongs)
                            .ThenInclude(artistSong => artistSong.Artist)
            );

            if (song is null)
            {
                return NotFound();
            }

            ViewBag.Artists = await artistRepository.All();
            ViewBag.Categories = await categoryRepository.All();

            return View(_mapper.Map<SongInputModel>(song));
        }

        /// <summary>
        /// POST: Admin/Song/Edit/18f94f44-2cb8-4dc7-bcc5-cd721ba1e2f2
        /// Xử lý dữ liệu của việc chỉnh sửa bài hát, nếu hợp lệ thì chỉnh sửa không thì báo lỗi
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, SongInputModel song)
        {
            if (id != song.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(song);
            }

            try
            {
                Song entity = _mapper.Map<Song>(song);

                await _songRepository.Update(entity);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _songRepository.GetByIdAsync(song.Id) is null)
                {
                    return NotFound();
                }

                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// GET: Admin/Song/Delete/5
        /// Trang xóa bài hát
        /// </summary>
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await _context.Songs
                                     .FirstOrDefaultAsync(m => m.Id == id);
            if (song == null)
            {
                return NotFound();
            }

            return View(song);
        }

        /// <summary>
        /// POST: Admin/Song/Delete/5
        /// Xử lý xóa bài hát
        /// </summary>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var song = await _context.Songs.FindAsync(id);
            _context.Songs.Remove(song);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
