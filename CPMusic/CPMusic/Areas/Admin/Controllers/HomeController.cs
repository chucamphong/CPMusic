using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CPMusic.Areas.Admin.Models;
using CPMusic.Data;
using CPMusic.Models;
using CPMusic.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CPMusic.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public HomeController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        private async Task<(int, double)> EntityGrowth(IQueryable<IEntity> entity)
        {
            double growth = 0;
            int month = DateTime.Now.Month;
            var record = await entity.Select(_ => new
            {
                prevMonth = entity.Count(col => col.CreatedAt.Month == month - 1),
                thisMonth = entity.Count(col => col.CreatedAt.Month == month),
                total = entity.Select(col => col.Id).Count(),
            }).Distinct().SingleAsync();

            if (record.prevMonth == 0)
            {
                growth = record.thisMonth;
            }

            if (record.prevMonth != 0)
            {
                growth = (record.thisMonth - record.prevMonth) / (double) record.prevMonth;
            }

            return (record.total, growth);
        }

        // GET
        public async Task<IActionResult> Index()
        {
            List<Statistical> statisticals = new List<Statistical>();

            (int totalNumberOfSongs, double songGrowth) = await EntityGrowth(_context.Songs);
            (int totalNumberOfUsers, double userGrowth) = await EntityGrowth(_userManager.Users);

            statisticals.Add(new Statistical
            {
                Name = "Bài hát",
                Total = totalNumberOfSongs,
                Percent = songGrowth,
            });

            statisticals.Add(new Statistical
            {
                Name = "Người dùng",
                Total = totalNumberOfUsers,
                Percent = userGrowth,
            });

            return View(statisticals);
        }
    }
}
