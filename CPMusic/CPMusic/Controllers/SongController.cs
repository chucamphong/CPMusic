using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CPMusic.Data;
using CPMusic.Models;
using CPMusic.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CPMusic.Controllers
{
    [Route("bai-hat")]
    public class SongController : Controller
    {
        private readonly ApplicationDbContext _context;
        
        public SongController(ApplicationDbContext context)
        {
            _context = context;
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
        /// TODO: Tạo view cho trang nghe nhạc
        [HttpGet]
        [Route("nghe-nhac/{id?}")]
        public async Task<IActionResult> NgheNhac(Guid? id)
        {
            if (id is null)
            {
                return NotFound();
            }
            
            Song song = await _context.Songs.FindAsync(id as object);
            
            return Content($"Bạn đang nghe bài hát {song.Name}");
        }
    }
}
