using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyLibrary.Models;

namespace MyLibrary.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var loggedInUser = await _userManager.GetUserAsync(User);
            OverviewViewModel? model = null;
            ViewData["Warning"] = "";

            if (loggedInUser != null)
            {
                model = new OverviewViewModel(_context, loggedInUser, 7);

                if (model.TimeSpentOnFilmsInMinutes >= 1320)
                {
                    ViewData["Warning"] = "You REALLY should spent less time on this";
                }
                else if (model.TimeSpentOnFilmsInMinutes >= 850)
                {
                    ViewData["Warning"] = "You should spent less time on this";
                }
            }

            return View(model);
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


