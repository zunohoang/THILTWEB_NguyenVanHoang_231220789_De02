using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NguyenVanHoang_231220789_De02.Models;

namespace NguyenVanHoang_231220789_De02.Controllers
{
    public class NvhHomeController : Controller
    {
        private readonly ILogger<NvhHomeController> _logger;

        public NvhHomeController(ILogger<NvhHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult NvhIndex()
        {
            return View();
        }

        public IActionResult NvhAbout()
        {
            return View();
        }

        public IActionResult NvhPrivacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult NvhError()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
