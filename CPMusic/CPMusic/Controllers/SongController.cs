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

        /// <summary>
        /// GET: /bai-hat/moi-phat-hanh
        /// Trang chi tiết hiển thị các bài hát mới phát hành
        /// Hiển thị tối đa 25 bài hát
        /// </summary>
        [Route("moi-phat-hanh")]
        public async Task<ViewResult> NewRelease()
        {
            IEnumerable<SongViewModel> songs = _mapper.Map<IEnumerable<SongViewModel>>(
                await _songRepository.NewSongsReleased(25)
            );

            return View(songs);
        }

        /// <summary>
        /// GET: /bai-hat/nghe-nhac/18f94f44-2cb8-4dc7-bcc5-cd721ba1e2f5
        /// Trang nghe nhạc
        /// </summary>
        /// TODO: Tạo phần gợi ý bài hát
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

        /// <summary>
        /// GET: /bai-hat/bang-xep-hang[?country=(Việt Nam, Âu Mỹ, Hàn Quốc)]
        /// Trang chi tiết bảng xếp hạng bài hát
        /// Hiển thị tối đa 25 bài hát
        /// </summary>
        [Route("bang-xep-hang")]
        public async Task<IActionResult> Ranking(string? country)
        {
            IEnumerable<Song> songs = country switch
            {
                "Việt Nam" => await _songRepository.Ranking("Việt Nam", 25),
                "Âu Mỹ" => await _songRepository.Ranking("Âu Mỹ", 25),
                "Hàn Quốc" => await _songRepository.Ranking("Hàn Quốc", 25),
                _ => await _songRepository.Ranking(25),
            };

            var ranking = _mapper.Map<IEnumerable<SongViewModel>>(songs);

            return View(ranking);
        }
    }
}