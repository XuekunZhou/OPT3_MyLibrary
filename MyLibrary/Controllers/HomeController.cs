using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyLibrary.Models;

namespace MyLibrary.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [AllowAnonymous]
        public async Task<IActionResult> IndexAsync()
        {
            var loggedInUser = await _userManager.GetUserAsync(User);
            OverviewModel? model = null;
            ViewData["Warning"] = "";

            if (loggedInUser != null)
            {
                
                switch(loggedInUser.defaultOverview)
                {
                    case 1: model = new TwoWeekOverviewModel(_context, loggedInUser); break;
                    case 2: model = new MonthOverviewModel(_context, loggedInUser); break;
                    default: model = new WeekOverviewModel(_context, loggedInUser); break;
                }

                if (model.TimeSpentOnFilmsInMinutes >= 1320)
                {
                    ViewData["Warning"] = "You REALLY should spent less time on this";
                }
                else if (model.TimeSpentOnFilmsInMinutes >= 850)
                {
                    ViewData["Warning"] = "You should spent less time on this";
                }

                return View(model);
            }

            return View();
        }

        public async Task<IActionResult> SetOverviewAsync(int id)
        {
            var loggedInUser = await _userManager.GetUserAsync(User);
            
            loggedInUser.SetDefaultOverview(id);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [AllowAnonymous]
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


