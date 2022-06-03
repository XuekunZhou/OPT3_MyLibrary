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
    public class FilmsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public FilmsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [AllowAnonymous]
        public async Task<IActionResult> ListAsync(string? id)
        {
            var loggedInUser = await _userManager.GetUserAsync(User);
          
            if (loggedInUser == null)
            {
                return RedirectToAction("Login", "Account");
            }
            
            var watchedUser = await _userManager.FindByIdAsync(id);

            if (watchedUser == null) 
            {
                return RedirectToAction("Error", "NotFound");
            }
            else 
            {
                if (watchedUser.listsArePublic || loggedInUser.IsFriendsWith(watchedUser))
                {
                    var films = _context.FilmEntries.Where(e => e.User == watchedUser).ToList();
                    ViewData["Title"] = watchedUser.UserName + "'s films";
                    return View("List", films);
                }

                return RedirectToAction("Error", "Private");
            }
        }

        // GET: Film/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FilmEntries == null)
            {
                return NotFound();
            }

            var filmEntryModel = await _context.FilmEntries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filmEntryModel == null)
            {
                return NotFound();
            }

            return View(filmEntryModel);
        }

        // GET: Film/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Film/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LengthInMinutes,Id,Title,ScoreOutOfTen,DateOfEntry")] FilmEntryModel filmEntryModel)
        {
            if (ModelState.IsValid)
            {
                filmEntryModel.User = await _userManager.GetUserAsync(User);
                _context.Add(filmEntryModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("List", new {id = _userManager.GetUserId(User)});
            }
            return View(filmEntryModel);
        }

        // GET: Film/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FilmEntries == null)
            {
                return NotFound();
            }

            var filmEntryModel = await _context.FilmEntries.FindAsync(id);
            if (filmEntryModel == null)
            {
                return NotFound();
            }
            return View(filmEntryModel);
        }

        // POST: Film/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LengthInMinutes,Id,Title,ScoreOutOfTen,DateOfEntry")] FilmEntryModel filmEntryModel)
        {
            if (id != filmEntryModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filmEntryModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmEntryModelExists(filmEntryModel.Id))
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
            return View(filmEntryModel);
        }

        // GET: Film/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FilmEntries == null)
            {
                return NotFound();
            }

            var filmEntryModel = await _context.FilmEntries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filmEntryModel == null)
            {
                return NotFound();
            }

            return View(filmEntryModel);
        }

        // POST: Film/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FilmEntries == null)
            {
                return Problem("Entity set 'ApplicationDbContext.FilmEntries'  is null.");
            }
            var filmEntryModel = await _context.FilmEntries.FindAsync(id);
            if (filmEntryModel != null)
            {
                _context.FilmEntries.Remove(filmEntryModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListAsync));
        }

        private bool FilmEntryModelExists(int id)
        {
          return (_context.FilmEntries?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}