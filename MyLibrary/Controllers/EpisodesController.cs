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
            var model = new EpisodeEntryModel
            {
                DateOfEntry = DateTime.UtcNow,
                Series = _context.SeriesEntries.Where(s => s.Id == id).FirstOrDefault(),
                User = await _userManager.GetUserAsync(User)
            };

            _context.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("Series", "List");
        }

        public async Task<IActionResult> RemoveEpisode(int id)
        {
            var episode = _context.EpisodeEntries.Where(s => s.Series.Id == id).OrderBy(e => e.Id).LastOrDefault();

            _context.Remove(episode);
            await _context.SaveChangesAsync();
            
            return RedirectToAction("Series", "List");
        }
    }
}
