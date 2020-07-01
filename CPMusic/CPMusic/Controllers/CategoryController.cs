using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CPMusic.Data.Interfaces;
using CPMusic.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CPMusic.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<CategoryViewModel> categories = _mapper.Map<IEnumerable<CategoryViewModel>>(
                await _categoryRepository.All()
            );

            return View(categories);
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id is null) return NotFound();

            CategoryViewModel category = _mapper.Map<CategoryViewModel>(
                source: await _categoryRepository.GetByIdAsyncWithRelationShip((Guid) id)
            );

            return View(category);
        }
    }
}