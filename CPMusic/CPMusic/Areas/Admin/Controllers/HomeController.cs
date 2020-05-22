using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CPMusic.Areas.Admin.Models;
using CPMusic.Data;
using CPMusic.Models;
using CPMusic.Data.Interfaces;
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

        /// <summary>
        /// Lấy số lượng bài hát của từng tháng, tính từ tháng 1 đến tháng hiện tại, năm hiện tại
        /// </summary>
        /// <example>
        /// Tháng hiện tại: 5
        /// Kết quả [0, 1, 2, 3, 4]
        /// Nghĩa là tháng 1 có 0 bài hát, tháng 2 có 1 bài hát, tháng 3 có 2 bài hát và tháng 4 có 4 bài hát
        /// </example>
        /// <returns>Một mảng số nguyên có độ dài là n (n là tháng hiện tại)</returns>
        private IEnumerable<int> SongStatistics()
        {
            return Enumerable.Range(1, DateTime.Now.Month)
                             .GroupJoin(
                                 _context.Songs.Where(song => song.CreatedAt.Year == DateTime.Now.Year)
                                         .Select(song => song.CreatedAt.Month),
                                 month => month,
                                 createdAtMonth => createdAtMonth,
                                 (month, monthGroup) => monthGroup.Count())
                             .ToArray();
        }

        /// <summary>
        /// Trang chủ
        /// </summary>
        public async Task<IActionResult> Index()
        {
            List<Statistical> statisticals = new List<Statistical>();
            
            var (totalNumberOfSongs, songGrowth) = await EntityGrowth(_context.Songs);
            var (totalNumberOfArtists, artistGrowth) = await EntityGrowth(_context.Artists);
            var (totalNumberOfCategories, categoryGrowth) = await EntityGrowth(_context.Categories);
            var (totalNumberOfUsers, userGrowth) = await EntityGrowth(_userManager.Users);

            ViewData["SongStatistics"] = SongStatistics();

            statisticals.Add(new Statistical
            {
                Name = "Tài khoản",
                Icon = "user-run",
                BackgroundIcon = "bg-gradient-red",
                Total = totalNumberOfUsers,
                Percent = userGrowth,
            });

            statisticals.Add(new Statistical
            {
                Name = "Bài hát",
                Icon = "note-03",
                BackgroundIcon = "bg-gradient-orange",
                Total = totalNumberOfSongs,
                Percent = songGrowth,
            });
            
            statisticals.Add(new Statistical
            {
                Name = "Nghệ sĩ",
                Icon = "air-baloon",
                BackgroundIcon = "bg-gradient-green",
                Total = totalNumberOfArtists,
                Percent = artistGrowth,
            });
            
            statisticals.Add(new Statistical
            {
                Name = "Thể loại",
                Icon = "books",
                BackgroundIcon = "bg-gradient-info",
                Total = totalNumberOfCategories,
                Percent = categoryGrowth,
            });

            return View(statisticals);
        }
    }
}
