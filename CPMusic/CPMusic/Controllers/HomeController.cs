using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
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

        /// <summary>
        /// GET: /
        /// Trang chủ
        /// </summary>
        public async Task<ViewResult> Index()
        {
            IEnumerable<Song> randomSongs = await _songRepository.RandomSongs(6);
            IEnumerable<Song> newSongsReleased = await _songRepository.NewSongsReleased(6);
            IEnumerable<Category> categories = await _categoryRepository.All(col => col, take: 6);

            HomeViewModel homeViewModel = new HomeViewModel()
            {
                RandomSongs = _mapper.Map<IEnumerable<SongViewModel>>(randomSongs),
                NewSongsReleased = _mapper.Map<IEnumerable<SongViewModel>>(newSongsReleased),
                Categories = _mapper.Map<IEnumerable<CategoryViewModel>>(categories),
            };

            return View(homeViewModel);
        }
    }
}