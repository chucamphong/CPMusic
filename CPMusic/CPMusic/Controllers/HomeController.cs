using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CPMusic.Data;
using CPMusic.Data.Interfaces;
using CPMusic.Models;
using CPMusic.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CPMusic.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISongRepository _songRepository;
        private readonly IMapper _mapper;

        public HomeController(ISongRepository songRepository, IMapper mapper)
        {
            _songRepository = songRepository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var songViewModels = new Dictionary<string, IEnumerable<SongViewModel>>
            {
                { "randomSongs", _mapper.Map<IEnumerable<SongViewModel>>(_songRepository.RandomSongs(6)) },
                { "newSongsReleased", _mapper.Map<IEnumerable<SongViewModel>>(_songRepository.NewSongsReleased(6)) },
            };

            return View(songViewModels);
        }
    }
}