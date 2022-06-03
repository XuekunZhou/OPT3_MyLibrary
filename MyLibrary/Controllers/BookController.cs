using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyLibrary.Models;

namespace MyLibrary.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;
        
        private readonly UserManager<ApplicationUser> _userManager;

        public BookController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> ListAsync(string? id)
        {
            var loggedInUser = await _userManager.GetUserAsync(User);
          
            if (loggedInUser == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var watchedUser = await _userManager.FindByIdAsync(id);  
            var films = _context.BookEntries.Where(u => u.User == watchedUser).ToList();
            
            if ((id != null) && (watchedUser.listsArePublic || loggedInUser.IsFriendsWith(watchedUser)))
            {
                ViewData["Title"] = watchedUser.UserName + "'s books";
                return View("List", films);
            }

            return RedirectToAction("Error", "Private");
        }

        // GET: Book/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BookEntries == null)
            {
                return NotFound();
            }

            var bookEntryModel = await _context.BookEntries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookEntryModel == null)
            {
                return NotFound();
            }

            return View(bookEntryModel);
        }

        // GET: Book/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PagesRead,Id,Title,ScoreOutOfTen,DateOfEntry")] BookEntryModel bookEntryModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookEntryModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookEntryModel);
        }

        // GET: Book/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BookEntries == null)
            {
                return NotFound();
            }

            var bookEntryModel = await _context.BookEntries.FindAsync(id);
            if (bookEntryModel == null)
            {
                return NotFound();
            }
            return View(bookEntryModel);
        }

        // POST: Book/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PagesRead,Id,Title,ScoreOutOfTen,DateOfEntry")] BookEntryModel bookEntryModel)
        {
            if (id != bookEntryModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookEntryModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookEntryModelExists(bookEntryModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bookEntryModel);
        }

        // GET: Book/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BookEntries == null)
            {
                return NotFound();
            }

            var bookEntryModel = await _context.BookEntries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookEntryModel == null)
            {
                return NotFound();
            }

            return View(bookEntryModel);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BookEntries == null)
            {
                return Problem("Entity set 'ApplicationDbContext.BookEntries'  is null.");
            }
            var bookEntryModel = await _context.BookEntries.FindAsync(id);
            if (bookEntryModel != null)
            {
                _context.BookEntries.Remove(bookEntryModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookEntryModelExists(int id)
        {
          return (_context.BookEntries?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
