using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CPMusic.Controllers
{
    [Route("bai-hat")]
    public class SongController : Controller
    {
        [Route("moi-phat-hanh")]
        public IActionResult NewSongsReleased()
        {
            return View();
        }
    }
}
