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
    public class EpisodesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public EpisodesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> AddEpisode(int id)
        {
            var series = _context.SeriesEntries.Where(s => s.Id == id).FirstOrDefault();

            if (series != null)
            {
                var episode = new EpisodeModel
                {
                    DateOfEntry = DateTime.UtcNow,
                    Series = series,
                    User = await _userManager.GetUserAsync(User)
                };

                _context.Add(episode);
                series.Size++;
                _context.SaveChanges();
            }

            return RedirectToAction("List", "Series");
        }

        public IActionResult RemoveEpisode(int id)
        {
            var series = _context.SeriesEntries.Where(s => s.Id == id).FirstOrDefault();
            if (series != null)
            {
                var episode = _context.Episodes.Where(e => e.Series == series).FirstOrDefault();

                if (episode != null)
                {
                    _context.Remove(episode);
                    series.Size--;
                    _context.SaveChanges();
                }
            }

            return RedirectToAction("List", "Series");
        }

    }
}
