using System.Collections;
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
        private readonly IMapper _mapper;
        private readonly ISongRepository _songRepository;
        private readonly ICategoryRepository _categoryRepository;

        public HomeController(IMapper mapper, ISongRepository songRepository, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _songRepository = songRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<ViewResult> Index()
        {
            Dictionary<string, IEnumerable> songViewModels = new Dictionary<string, IEnumerable>
            {
                { "randomSongs", _mapper.Map<IEnumerable<SongViewModel>>(await _songRepository.RandomSongs(6)) },
                { "newSongsReleased", _mapper.Map<IEnumerable<SongViewModel>>(await _songRepository.NewSongsReleased(6)) },
                { "categories", _mapper.Map<IEnumerable<CategoryViewModel>>(await _categoryRepository.All(col => col, take: 6)) },
            };

            return View(songViewModels);
        }
    }
}