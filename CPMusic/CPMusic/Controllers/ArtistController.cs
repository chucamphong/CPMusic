using System;
using System.Threading.Tasks;
using CPMusic.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CPMusic.Controllers
{
    public class ArtistController : Controller
    {
        private readonly IArtistRepository _artistRepository;

        public ArtistController(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }
        
        /// <summary>
        /// GET: /nghe-si/{id}
        /// Trang nghệ sĩ
        /// </summary>
        /// TODO: Làm trang nghệ sĩ
        [Route("nghe-si/{id}")]
        public async Task<IActionResult> Profile(Guid? id)
        {
            if (id is null) return NotFound();

            var artist = await _artistRepository.GetByIdAsync((Guid) id);

            if (artist is null) return NotFound();

            return View(artist);
        }
    }
}