using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyLibrary.Models;

namespace MyLibrary.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(ApplicationDbContext context, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _userManager.GetUserAsync(User));
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterAsync(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser(model.Email, model.Username);
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, true);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);

                    if (result.Succeeded) return RedirectToAction("Index", "Home");
                }
            }
            ViewData["LoginError"] = "Incorrect email or password";
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> LogoutAsync()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> SetPrivate()
        {
            var loggedInUser = await _userManager.GetUserAsync(User);
            loggedInUser.SetPrivacy(false);
            _context.SaveChanges();

            return RedirectToAction("Index", "Account");
        }

        public async Task<IActionResult> SetPublic()
        {
            var loggedInUser = await _userManager.GetUserAsync(User);
            loggedInUser.SetPrivacy(true);
            _context.SaveChanges();

            return RedirectToAction("Index", "Account");
        }
        
        public async Task<IActionResult> PeopleAsync()
        {
            var loggedInUser = await _userManager.GetUserAsync(User);
            return View(_context.ApplicationUsers.Where(u => u.Id != loggedInUser.Id).ToList());
        }

        public async Task<IActionResult> FriendsAsync()
        {
            var loggedInUser = await _userManager.GetUserAsync(User);
            return View(_context.ApplicationUsers.Where(u => u.Id != loggedInUser.Id).ToList());
        }

        public async Task<IActionResult> RemoveFriendAsync(string id)
        {
            var loggedInUser = await _userManager.GetUserAsync(User);
            var watchedUser = await _userManager.FindByIdAsync(id);

            loggedInUser.RemoveFriend(watchedUser);
            _context.SaveChanges();
            return RedirectToAction("Friends");
        }

        public async Task<IActionResult> AddFriendPAsync(string id)
        {
            var loggedInUser = await _userManager.GetUserAsync(User);
            var watchedUser = await _userManager.FindByIdAsync(id);

            loggedInUser.AddFriend(watchedUser);
            _context.SaveChanges();
            return RedirectToAction("People");
        }

        public async Task<IActionResult> RemoveFriendPAsync(string id)
        {
            var loggedInUser = await _userManager.GetUserAsync(User);
            var watchedUser = await _userManager.FindByIdAsync(id);

            loggedInUser.RemoveFriend(watchedUser);
            _context.SaveChanges();
            return RedirectToAction("People");
        }
    }
}