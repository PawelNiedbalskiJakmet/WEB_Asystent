using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WEB_Asystent.Models;

namespace WEB_Asystent.Controllers
{
    public class HomeController : Controller
    {
        static List<int> _list = new List<int>();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _list.Add(1);
            _list.Add(2);
            _logger = logger;

        }

        public IActionResult Index()
        {
            _list.Add(3);
            _list.Add(4);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}