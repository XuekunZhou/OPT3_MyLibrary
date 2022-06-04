using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyLibrary.Models;

namespace MyLibrary.Controllers
{
    [Authorize]
    public class SeriesSessionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public SeriesSessionsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> AddEpisode(int id)
        {
            var series = _context.SeriesEntries.Where(s => s.Id == id).FirstOrDefault();

            if (series != null)
            {
                var episode = new SeriesSessionModel
                {
                    DateOfSession = DateTime.UtcNow,
                    NumberOfEpisodesWatches = 1,
                    Entry = series,
                    User = await _userManager.GetUserAsync(User)
                };

                _context.Add(episode);
                series.TotalEpisodesWatched ++;;
                _context.SaveChanges();
            }

            return RedirectToAction("List", "Series");
        }

        public async Task<IActionResult> RemoveEpisode(int id)
        {
            var series = _context.SeriesEntries.Where(s => s.Id == id).FirstOrDefault();

            if (series != null)
            {
                if (series.TotalEpisodesWatched < 1)
                {
                    series.TotalEpisodesWatched = 0;;
                    _context.SaveChanges();
                    return RedirectToAction("List", "Series");
                }

                var episode = new SeriesSessionModel
                {
                    DateOfSession = DateTime.UtcNow,
                    NumberOfEpisodesWatches = -1,
                    Entry = series,
                    User = await _userManager.GetUserAsync(User)
                };

                _context.Add(episode);
                series.TotalEpisodesWatched --;
                _context.SaveChanges();
            }

            return RedirectToAction("List", "Series");
        }
    }
}
