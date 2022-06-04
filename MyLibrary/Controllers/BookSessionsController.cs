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
    public class BookSessionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public BookSessionsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> AddPage(int id)
        {
            var book = _context.BookEntries.Where(s => s.Id == id).FirstOrDefault();

            if (book != null)
            {
                var page = new BookSessionModel
                {
                    DateOfSession = DateTime.UtcNow,
                    NumberOfPagesRead = 1,
                    Entry = book,
                    User = await _userManager.GetUserAsync(User)
                };

                _context.Add(page);
                book.TotalPagesRead ++;;
                _context.SaveChanges();
            }

            return RedirectToAction("List", "Books");
        }

        public async Task<IActionResult> RemovePage(int id)
        {
            var book = _context.BookEntries.Where(s => s.Id == id).FirstOrDefault();

            if (book != null)
            {
                if (book.TotalPagesRead < 1)
                {
                    book.TotalPagesRead = 0;;
                    _context.SaveChanges();
                    return RedirectToAction("List", "Books");
                }

                var page = new BookSessionModel
                {
                    DateOfSession = DateTime.UtcNow,
                    NumberOfPagesRead = -1,
                    Entry = book,
                    User = await _userManager.GetUserAsync(User)
                };

                _context.Add(page);
                book.TotalPagesRead--;
                _context.SaveChanges();
            }

            return RedirectToAction("List", "Books");
        }
    }
}
