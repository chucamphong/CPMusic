using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CPMusic.Data;
using CPMusic.Data.Interfaces;
using CPMusic.Helpers;
using CPMusic.InputModels;
using CPMusic.Models;
using CPMusic.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

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
        public async Task<ViewResult> Index(int page = 1)
        {
            // Truy vấn lấy tất cả các cột trong bảng cùng với quan hệ
            IQueryable<Song> songs = _songRepository.Query(
                col => col,
                include: query =>
                    query.Include(col => col.Category)
                         .Include(col => col.Country)
                         .Include(col => col.ArtistSongs)
                         .ThenInclude(artistSong => artistSong.Artist),
                orderBy: query => query.OrderByDescending(song => song.CreatedAt));

            IPagedList<Song> paginated = await songs.ToPagedListAsync(page, 5);

            return View(paginated);
        }

        /// <summary>
        /// GET: Admin/Song/Details/18f94f44-2cb8-4dc7-bcc5-cd721ba1e2f2
        /// Trang xem thông tin của bài hát
        /// </summary>
        [HttpGet]
        [Route("{area}/{controller}/{action}/{id}")]
        public async Task<IActionResult> Details(Guid id, [FromServices] IArtistRepository artistRepository,
                                                 [FromServices] ICategoryRepository categoryRepository,
                                                 [FromServices] ICountryRepository countryRepository)
        {
            Song? song = await _songRepository.GetByIdAsyncWithRelationShip(id);

            if (song is null)
            {
                return NotFound();
            }

            return View(_mapper.Map<SongViewModel>(song));
        }

        /// <summary>
        /// GET: Admin/Song/Create
        /// Trạng tạo bài hát
        /// </summary>
        public async Task<ViewResult> Create([FromServices] IArtistRepository artistRepository,
                                             [FromServices] ICategoryRepository categoryRepository,
                                             [FromServices] ICountryRepository countryRepository)
        {
            ViewBag.Artists = await artistRepository.All();
            ViewBag.Categories = await categoryRepository.All();
            ViewBag.Countries = await countryRepository.All();

            return View();
        }

        /// <summary>
        /// POST: Admin/Song/Create
        /// Xử lý dữ liệu của bài hát, nếu hợp lệ thì sẽ tạo bài hát và ngược lại thì trả về lỗi
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SongCreateInputModel request, [FromServices] IFileUpload fileUpload)
        {
            if (!ModelState.IsValid) return View(request);

            // Xử lý tải lên ảnh đại diện bài hát
            request.Thumbnail = await fileUpload.Save(request.UploadThumbnail, "img/songs");

            // Xử lý tải lên bài hát
            request.Url = await fileUpload.Save(request.UploadSong, "songs");

            await _songRepository.Add(_mapper.Map<Song>(request));

            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// GET: Admin/Song/Edit/18f94f44-2cb8-4dc7-bcc5-cd721ba1e2f2
        /// Trang sửa bài hát
        /// </summary>
        [HttpGet]
        [Route("{area}/{controller}/{action}/{id}")]
        public async Task<IActionResult> Edit(Guid id,
                                              [FromServices] IArtistRepository artistRepository,
                                              [FromServices] ICategoryRepository categoryRepository,
                                              [FromServices] ICountryRepository countryRepository)
        {
            Song? song = await _songRepository.GetByIdAsync(id,
                query => query.Include(column => column.Category)
                              .Include(column => column.ArtistSongs)
                              .ThenInclude(artistSong => artistSong.Artist)
            );

            if (song is null)
            {
                return NotFound();
            }

            ViewBag.Artists = await artistRepository.All();
            ViewBag.Categories = await categoryRepository.All();
            ViewBag.Countries = await countryRepository.All();

            return View(_mapper.Map<SongUpdateInputModel>(song));
        }

        /// <summary>
        /// POST: Admin/Song/Edit/18f94f44-2cb8-4dc7-bcc5-cd721ba1e2f2
        /// Xử lý dữ liệu của việc chỉnh sửa bài hát, nếu hợp lệ thì chỉnh sửa không thì báo lỗi
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, SongUpdateInputModel request,
                                              [FromServices] IFileUpload fileUpload)
        {
            Song? song = await _songRepository.GetByIdAsync(id);

            if (song is null || song.Id != request.Id) return NotFound();

            if (!ModelState.IsValid) return View(request);

            // Xử lý tải lên ảnh đại diện bài hát
            request.Thumbnail = request.UploadThumbnail is null
                ? song.Thumbnail
                : await fileUpload.Save(request.UploadThumbnail, "img/songs");

            // Xử lý tải lên bài hát
            request.Url = request.UploadSong is null
                ? song.Url
                : await fileUpload.Save(request.UploadSong, "songs");

            // Thực hiện cập nhật vào cơ sở dữ liệu
            try
            {
                Song entity = _mapper.Map<Song>(request);

                await _songRepository.Update(entity);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _songRepository.GetByIdAsync(request.Id) is null) return NotFound();

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

            var song = await _songRepository.GetByIdAsyncWithRelationShip((Guid) id);
            
            if (song == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<SongViewModel>(song));
        }

        /// <summary>
        /// POST: Admin/Song/Delete/5
        /// Xử lý xóa bài hát
        /// </summary>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _songRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}