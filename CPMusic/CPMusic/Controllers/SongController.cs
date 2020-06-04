using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CPMusic.Data;
using CPMusic.Data.Interfaces;
using CPMusic.Models;
using CPMusic.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

            Song? song = await _songRepository.GetByIdAsync((Guid) id, query =>
            {
                return query.Include(song => song.ArtistSongs)
                            .ThenInclude(artistSong => artistSong.Artist)
                            .Include(song => song.Category);
            });
            
            if (song is null)
            {
                return NotFound();
            }

            return View(_mapper.Map<SongViewModel>(song));
        }
    }
}