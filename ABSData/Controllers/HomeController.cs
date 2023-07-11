using ABSData.Models;
using ABSDataFramework;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ABSData.Controllers {

    public class HomeController : Controller {
        private ApplicationDbContext context;

        public HomeController(ApplicationDbContext ctx) {
            context = ctx;
        }

        public IActionResult Index() {
            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, 
            NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id 
                ?? HttpContext.TraceIdentifier });
        }
    }
}
