﻿using System.Collections.Generic;
using System.Threading.Tasks;
using CPMusic.Data.Interfaces;
using CPMusic.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CPMusic.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        /// <summary>
        /// Trang chủ
        /// </summary>
        public async Task<IActionResult> Index(
            [FromServices] ISongRepository songRepository,
            [FromServices] IArtistRepository artistRepository,
            [FromServices] ICategoryRepository categoryRepository,
            [FromServices] IUserRepository userRepository
        )
        {
            var (totalNumberOfSongs, songGrowth) = await songRepository.GrowthRate();
            var (totalNumberOfArtists, artistGrowth) = await artistRepository.GrowthRate();
            var (totalNumberOfCategories, categoryGrowth) = await categoryRepository.GrowthRate();
            var (totalNumberOfUsers, userGrowth) = await userRepository.GrowthRate();

            ViewData["SongStatisticsPerMonth"] = songRepository.StatisticsPerMonth();
            ViewData["AccountStatisticsPerMonth"] = userRepository.StatisticsPerMonth();

            List<StatisticalViewModel> statisticals = new List<StatisticalViewModel>
            {
                new StatisticalViewModel
                {
                    Name = "Tài khoản",
                    Icon = "user-run",
                    BackgroundIcon = "bg-gradient-red",
                    Total = totalNumberOfUsers,
                    Percent = userGrowth,
                },
                new StatisticalViewModel
                {
                    Name = "Bài hát",
                    Icon = "note-03",
                    BackgroundIcon = "bg-gradient-orange",
                    Total = totalNumberOfSongs,
                    Percent = songGrowth,
                },
                new StatisticalViewModel
                {
                    Name = "Nghệ sĩ",
                    Icon = "air-baloon",
                    BackgroundIcon = "bg-gradient-green",
                    Total = totalNumberOfArtists,
                    Percent = artistGrowth,
                },
                new StatisticalViewModel
                {
                    Name = "Thể loại",
                    Icon = "books",
                    BackgroundIcon = "bg-gradient-info",
                    Total = totalNumberOfCategories,
                    Percent = categoryGrowth,
                },
            };

            return View(statisticals);
        }
    }
}
