using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using System.Security.Claims;
    using Project.Models.Database;
    using Microsoft.AspNetCore.Identity;
    using Project.Services;

    public class AccountController : Controller
    {
        private readonly ProjectDbContext _context;

        public AccountController(ProjectDbContext context)
        {
            _context = context;
        }

        // GET: /Account/Register
        public IActionResult Register() => View();

        // POST: /Account/Register
        [HttpPost]
        public IActionResult Register(string username, string password)
        {
            if (_context.Users.Any(u => u.Username == username))
            {
                ModelState.AddModelError("", "Имя занято");
                return View();
            }

            var user = new UserData
            {
                Username = username,
                PasswordHash = PasswordHasher.Hash(password)
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return RedirectToAction("Login");
        }

        // GET: /Account/Login
        public IActionResult Login() => View();

        // POST: /Account/Login
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            if (user == null || user.PasswordHash != PasswordHasher.Hash(password))
            {
                ModelState.AddModelError("", "Неверный логин или пароль");
                return View();
            }

            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim("UserId", user.Id.ToString())
        };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return RedirectToAction("Index", "Place");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }

}
