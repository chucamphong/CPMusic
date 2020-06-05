using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CPMusic.Data.Interfaces;
using CPMusic.Models;
using CPMusic.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CPMusic.Controllers
{
    [Route("bai-hat")]
    public class SongController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ISongRepository _songRepository;

        public SongController(IMapper mapper, ISongRepository songRepository)
        {
            _mapper = mapper;
            _songRepository = songRepository;
        }

        [Route("moi-phat-hanh")]
        public IActionResult MoiPhatHanh()
        {
            return View();
        }

        /// <summary>
        /// GET: /bai-hat/nghe-nhac/18f94f44-2cb8-4dc7-bcc5-cd721ba1e2f5
        /// Trang nghe nhạc
        /// </summary>
        /// TODO: Tạo phần gợi ý bài hát
        [HttpGet]
        [Route("nghe-nhac/{id}")]
        public async Task<IActionResult> Listen(Guid? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            // Lấy thông tin bài hát
            Song? song = await _songRepository.GetByIdAsyncWithRelationShip((Guid) id);

            if (song is null)
            {
                return NotFound();
            }

            IEnumerable<Song> randomSongs = await _songRepository.Suggestions(song, 6);

            ListenViewModel listenViewModel = new ListenViewModel()
            {
                Song = _mapper.Map<SongViewModel>(song),
                Suggestions = _mapper.Map<IEnumerable<SongViewModel>>(randomSongs),
            };

            return View(listenViewModel);
        }
    }
}