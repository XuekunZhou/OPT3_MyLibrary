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
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public BooksController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> ListAsync(string? id)
        {
            var loggedInUser = await _userManager.GetUserAsync(User);
            var watchedUser = await _userManager.FindByIdAsync(id);

            if (id == null)
            {
                watchedUser = loggedInUser;
            }

            if (watchedUser == null) 
            {
                return RedirectToAction("NotFound", "Error");
            }

            if (watchedUser.listsArePublic || loggedInUser.IsFriendsWith(watchedUser))
            {
                var books = _context.BookEntries.Where(e => e.User == watchedUser).ToList();
                ViewData["Title"] = watchedUser.UserName + "'s books";
                return View(books);
            }

            return RedirectToAction("Private", "Error");
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
                bookEntryModel.User = await _userManager.GetUserAsync(User);
                _context.Add(bookEntryModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("List");
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
                return RedirectToAction("List");
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
            return RedirectToAction("List");
        }

        private bool BookEntryModelExists(int id)
        {
          return (_context.BookEntries?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
