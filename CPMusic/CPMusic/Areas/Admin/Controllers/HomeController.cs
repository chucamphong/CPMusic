using System;
using System.Collections.Generic;
using System.Linq;
using CPMusic.Data;
using CPMusic.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CPMusic.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public class StaticialStats
        {
            public string Name { get; set; }
            public int Total { get; set; }
            public double Percent { get; set; }
        }

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        private (int, double) EntityGrowth(IQueryable<IEntity> entity)
        {
            double growth = 0;
            int month = DateTime.Now.Month;
            int totalNumberOfEntityPrevMonth = entity.Count(col => col.CreatedAt.Month == month - 1);
            int totalNumberOfEntityThisMonth = entity.Count(col => col.CreatedAt.Month == month);
            int totalNumberOfEntity = entity.Count();

            if (totalNumberOfEntityThisMonth != 0 || totalNumberOfEntityPrevMonth != 0)
            {
                growth = (totalNumberOfEntityThisMonth - totalNumberOfEntityPrevMonth) /
                         (double) totalNumberOfEntityPrevMonth;
            }

            return (totalNumberOfEntity, growth);
        }

        // GET
        public IActionResult Index()
        {
            List<StaticialStats> staticialStatses = new List<StaticialStats>();
            
            var (totalNumberOfSongsThisMonth, songGrowth) = EntityGrowth(_context.Songs);

            staticialStatses.Add(new StaticialStats
            {
                Name = "Bài hát",
                Total = totalNumberOfSongsThisMonth,
                Percent = songGrowth
            });

            return View(staticialStatses);
        }
    }
}