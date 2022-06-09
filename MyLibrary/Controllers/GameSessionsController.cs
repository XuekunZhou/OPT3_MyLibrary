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
    public class GameSessionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public GameSessionsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> AddSession(int id)
        {
            var game = _context.GameEntries.Where(s => s.Id == id).FirstOrDefault();

            if (game != null)
            {
                var session = FactoryProducer.GetFactory(EntryTypes.Game).GetSession();
                session.Count = 30;
                session.Entry = game;
                session.User = await _userManager.GetUserAsync(User);

                _context.Add(session);
                game.Count += 30;
                _context.SaveChanges();
            }

            return RedirectToAction("List", "Games");
        }

        public async Task<IActionResult> RemoveSession(int id)
        {
            var game = _context.GameEntries.Where(s => s.Id == id).FirstOrDefault();
            int time = 30;

            if (game != null)
            {
                if (game.Count < 0)
                {
                    game.Count = 0;
                    _context.SaveChanges();
                    return RedirectToAction("List", "Games");
                }

                if (game.Count < 30)
                {
                    time = game.Count;
                }

                var session = FactoryProducer.GetFactory(EntryTypes.Game).GetSession();
                session.Count = -time;
                session.Entry = game;
                session.User = await _userManager.GetUserAsync(User);

                _context.Add(session);
                game.Count -= time;
                _context.SaveChanges();
            }

            return RedirectToAction("List", "Games");
        }
    }
}
