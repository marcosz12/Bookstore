<<<<<<< HEAD
using BookStore.Models.ViewModels;
=======
using BookStore.Models;
>>>>>>> 17d4e652e56e5cbaae58e670a45efb8c7a06d8e3
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
<<<<<<< HEAD
=======
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

>>>>>>> 17d4e652e56e5cbaae58e670a45efb8c7a06d8e3
        public IActionResult Index()
        {
            return View();
        }
<<<<<<< HEAD
=======

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
>>>>>>> 17d4e652e56e5cbaae58e670a45efb8c7a06d8e3
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
