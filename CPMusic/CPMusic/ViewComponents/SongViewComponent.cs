using CPMusic.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CPMusic.ViewComponents
{
    public class SongViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(SongViewModel song)
        {
            return View("Default", song);
        }
    }
}