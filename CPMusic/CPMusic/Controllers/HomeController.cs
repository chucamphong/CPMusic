using System.Diagnostics;
using CPMusic.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CPMusic.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
