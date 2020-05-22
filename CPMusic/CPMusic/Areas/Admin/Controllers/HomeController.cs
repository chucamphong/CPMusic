using System;
using System.Collections.Generic;
using System.Linq;
using CPMusic.Data;
using CPMusic.Models;
using CPMusic.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CPMusic.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public class StaticialStats
        {
            public string Name { get; set; } = null!;
            public int Total { get; set; }
            public double Percent { get; set; }
        }

        public HomeController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        private (int, double) EntityGrowth(IQueryable<IEntity> entity)
        {
            double growth = 0;
            int month = DateTime.Now.Month;
            int totalNumberOfEntityPrevMonth = entity.Count(col => col.CreatedAt.Month == month - 1);
            int totalNumberOfEntityThisMonth = entity.Count(col => col.CreatedAt.Month == month);
            int totalNumberOfEntity = entity.Count();

            if (totalNumberOfEntityPrevMonth == 0)
            {
                growth = totalNumberOfEntityThisMonth;
            }

            if (totalNumberOfEntityPrevMonth != 0)
            {
                growth = (totalNumberOfEntityThisMonth - totalNumberOfEntityPrevMonth) /
                         (double)totalNumberOfEntityPrevMonth;
            }

            return (totalNumberOfEntity, growth);
        }

        // GET
        public IActionResult Index()
        {
            List<StaticialStats> staticialStatses = new List<StaticialStats>();

            var (totalNumberOfSongsThisMonth, songGrowth) = EntityGrowth(_context.Songs);
            var (totalNumberOfUsersThisMonth, userGrowth) = EntityGrowth(_userManager.Users);

            staticialStatses.Add(new StaticialStats
            {
                Name = "Bài hát",
                Total = totalNumberOfSongsThisMonth,
                Percent = songGrowth
            });

            staticialStatses.Add(new StaticialStats
            {
                Name = "Người dùng",
                Total = totalNumberOfUsersThisMonth,
                Percent = userGrowth
            });

            return View(staticialStatses);
        }
    }
}