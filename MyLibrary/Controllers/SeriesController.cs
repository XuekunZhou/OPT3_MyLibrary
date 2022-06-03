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
    public class SeriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public SeriesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Series
        public async Task<IActionResult> ListAsync(string? id)
        {
            var loggedInUser = await _userManager.GetUserAsync(User);
            var watchedUser = await _userManager.FindByIdAsync(id);

            if (watchedUser == null) 
            {
                return RedirectToAction("Error", "NotFound");
            }
            else 
            {
                if (id == null)
                {
                    var series = _context.SeriesEntries.Where(e => e.User == loggedInUser).ToList();
                    ViewData["Title"] = loggedInUser.UserName + "'s series";
                    return View("List", series);
                }

                if (watchedUser.listsArePublic || loggedInUser.IsFriendsWith(watchedUser))
                {
                    var series = _context.SeriesEntries.Where(e => e.User == watchedUser).ToList();
                    ViewData["Title"] = watchedUser.UserName + "'s series";
                    return View("List", series);
                }

                return RedirectToAction("Error", "Private");
            }
        }

        // GET: Series/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SeriesEntries == null)
            {
                return NotFound();
            }

            var seriesEntryModel = await _context.SeriesEntries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (seriesEntryModel == null)
            {
                return NotFound();
            }

            return View(seriesEntryModel);
        }

        // GET: Series/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Series/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ScoreOutOfTen,DateOfEntry")] SeriesEntryModel seriesEntryModel)
        {
            if (ModelState.IsValid)
            {
                seriesEntryModel.User = await _userManager.GetUserAsync(User);
                _context.Add(seriesEntryModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListAsync));
            }
            return View(seriesEntryModel);
        }

        // GET: Series/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SeriesEntries == null)
            {
                return NotFound();
            }

            var seriesEntryModel = await _context.SeriesEntries.FindAsync(id);
            if (seriesEntryModel == null)
            {
                return NotFound();
            }
            return View(seriesEntryModel);
        }

        // POST: Series/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ScoreOutOfTen,DateOfEntry")] SeriesEntryModel seriesEntryModel)
        {
            if (id != seriesEntryModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seriesEntryModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeriesEntryModelExists(seriesEntryModel.Id))
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
            return View(seriesEntryModel);
        }

        // GET: Series/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SeriesEntries == null)
            {
                return NotFound();
            }

            var seriesEntryModel = await _context.SeriesEntries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (seriesEntryModel == null)
            {
                return NotFound();
            }

            return View(seriesEntryModel);
        }

        // POST: Series/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SeriesEntries == null)
            {
                return Problem("Entity set 'ApplicationDbContext.SeriesEntries'  is null.");
            }
            var seriesEntryModel = await _context.SeriesEntries.FindAsync(id);
            if (seriesEntryModel != null)
            {
                _context.SeriesEntries.Remove(seriesEntryModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListAsync));
        }

        private bool SeriesEntryModelExists(int id)
        {
          return (_context.SeriesEntries?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
