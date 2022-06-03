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

        // GET: Episodes
        public async Task<IActionResult> ListAsync(int? id)
        {
            var loggedInUser = await _userManager.GetUserAsync(User);
            var watchedSeries = _context.SeriesEntries.Where(s => s.Id == id).FirstOrDefault(); 

            if (watchedSeries == null) 
            {
                return RedirectToAction("Error", "NotFound");
            }
            else 
            {
                var watchedUser = watchedSeries.User;
                if (watchedUser.listsArePublic || loggedInUser.IsFriendsWith(watchedUser))
                {
                    var episodes = _context.EpisodeEntries.Where(e => e.Series == watchedSeries).ToList();
                    ViewData["Title"] = watchedSeries.Title + "'s episodes";
                    return View("List", episodes);
                }

                return RedirectToAction("Error", "Private");
            }
        }

        // GET: Episodes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EpisodeEntries == null)
            {
                return NotFound();
            }

            var episodeEntryModel = await _context.EpisodeEntries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (episodeEntryModel == null)
            {
                return NotFound();
            }

            return View(episodeEntryModel);
        }

        // GET: Episodes/Create
        public IActionResult Create(int id)
        {
            var model = new EpisodeEntryModel { Series = _context.SeriesEntries.Where(s => s.Id == id).FirstOrDefault(),
            Title = "hello"};
            return View(model);
        }

        // POST: Episodes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LengthInMin,Id,Title,ScoreOutOfTen,DateOfEntry")] EpisodeEntryModel episodeEntryModel)
        {
            if (ModelState.IsValid)
            {
                episodeEntryModel.User = await _userManager.GetUserAsync(User);
                _context.Add(episodeEntryModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListAsync));
            }
            return View(episodeEntryModel);
        }

        // GET: Episodes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EpisodeEntries == null)
            {
                return NotFound();
            }

            var episodeEntryModel = await _context.EpisodeEntries.FindAsync(id);
            if (episodeEntryModel == null)
            {
                return NotFound();
            }
            return View(episodeEntryModel);
        }

        // POST: Episodes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LengthInMin,Id,Title,ScoreOutOfTen,DateOfEntry")] EpisodeEntryModel episodeEntryModel)
        {
            if (id != episodeEntryModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(episodeEntryModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EpisodeEntryModelExists(episodeEntryModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListAsync));
            }
            return View(episodeEntryModel);
        }

        // GET: Episodes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EpisodeEntries == null)
            {
                return NotFound();
            }

            var episodeEntryModel = await _context.EpisodeEntries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (episodeEntryModel == null)
            {
                return NotFound();
            }

            return View(episodeEntryModel);
        }

        // POST: Episodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EpisodeEntries == null)
            {
                return Problem("Entity set 'ApplicationDbContext.EpisodeEntries'  is null.");
            }
            var episodeEntryModel = await _context.EpisodeEntries.FindAsync(id);
            if (episodeEntryModel != null)
            {
                _context.EpisodeEntries.Remove(episodeEntryModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListAsync));
        }

        private bool EpisodeEntryModelExists(int id)
        {
          return (_context.EpisodeEntries?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
