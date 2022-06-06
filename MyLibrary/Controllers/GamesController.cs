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
    public class GamesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public GamesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Games
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
                var games = _context.GameEntries.Where(e => e.User == watchedUser).ToList();
                ViewData["Title"] = watchedUser.UserName + "'s games";
                return View(games);
            }

            return RedirectToAction("Private", "Error");
        }

        // GET: Games/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GameEntries == null)
            {
                return NotFound();
            }

            var gameEntryModel = await _context.GameEntries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gameEntryModel == null)
            {
                return NotFound();
            }

            return View(gameEntryModel);
        }

        // GET: Games/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Count,Id,Title,ScoreOutOfTen,DateOfEntry")] GameEntryModel gameEntryModel)
        {
            if (ModelState.IsValid)
            {
                gameEntryModel.User = await _userManager.GetUserAsync(User);

                var session = FactoryProducer.GetFactory(EntryTypes.Game).GetSession();
                session.Count = gameEntryModel.Count;
                session.Entry = gameEntryModel;
                session.User = gameEntryModel.User;
        

                _context.Add(gameEntryModel);
                _context.Add(session);
                await _context.SaveChangesAsync();
                return RedirectToAction("List");
            }
            return View(gameEntryModel);
        }

        // GET: Games/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GameEntries == null)
            {
                return NotFound();
            }

            var gameEntryModel = await _context.GameEntries.FindAsync(id);
            if (gameEntryModel == null)
            {
                return NotFound();
            }
            return View(gameEntryModel);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, int oldTotal, [Bind("Count,Id,Title,ScoreOutOfTen,DateOfEntry")] GameEntryModel gameEntryModel)
        {
            if (id != gameEntryModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {   
                gameEntryModel.User = await _userManager.GetUserAsync(User);
                try
                {
                    _context.Update(gameEntryModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameEntryModelExists(gameEntryModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                var dif = gameEntryModel.Count - oldTotal;
                if(dif != 0)
                {
                    var session = FactoryProducer.GetFactory(EntryTypes.Game).GetSession();
                    session.Count = dif;
                    session.Entry = gameEntryModel;
                    session.User = gameEntryModel.User;

                    _context.Add(session);
                    _context.SaveChanges();
                }
                
                return RedirectToAction("Index");
            }
            return View(gameEntryModel);
        }

        // GET: Games/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GameEntries == null)
            {
                return NotFound();
            }

            var gameEntryModel = await _context.GameEntries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gameEntryModel == null)
            {
                return NotFound();
            }

            return View(gameEntryModel);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GameEntries == null)
            {
                return Problem("Entity set 'ApplicationDbContext.GameEntries'  is null.");
            }
            var gameEntryModel = await _context.GameEntries.FindAsync(id);
            if (gameEntryModel != null)
            {
                _context.GameEntries.Remove(gameEntryModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool GameEntryModelExists(int id)
        {
          return (_context.GameEntries?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
