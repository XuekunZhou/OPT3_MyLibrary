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
                    case 1: model = OverviewFactory.GetTwoWeekOverview(_context, loggedInUser); break;
                    case 2: model = OverviewFactory.GetMonthOverview(_context, loggedInUser); break;
                    default: model = OverviewFactory.GetWeekOverview(_context, loggedInUser); break;
                }

                ViewData["Warning"] = Warning.GetWarning(OverviewFactory.GetWeekOverview(_context, loggedInUser));
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


