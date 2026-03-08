using KrishiBazaarProject.Data;
using KrishiBazaarProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace KrishiBazaarProject.Controllers
{
    public class AuthController : Controller
    {
        private readonly AppDbContext _context;
        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Register()
        {
            ViewBag.Locations = _context.Locations.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Register(Users user, int postalCode)
        {
            var location = _context.Locations.FirstOrDefault(l => l.PostalCode == postalCode);
            if (location != null)
            {
                user.AddressID = location.PostalCode;
                user.Address = location;
            }

            if (true)
            {
                user.UserID = user.Email;
                user.Password = new PasswordHasher<Users>().HashPassword(user, user.Password);
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(user);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);
            if (user != null)
            {
                var passwordHasher = new PasswordHasher<Users>();
                var result = passwordHasher.VerifyHashedPassword(user, user.Password, password);
                if (result == PasswordVerificationResult.Success)
                {
                    HttpContext.Session.SetString("UserID", user.UserID);
                    HttpContext.Session.SetString("IsFarmer", user.IsFarmer.ToString());
                    return user.IsFarmer ? RedirectToAction("Index", "FarmerDashboard") : RedirectToAction("Index", "BuyerDashboard");
                }
            }
            ViewBag.Error = "Invalid email or password";
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Clear all session data
            return RedirectToAction("Index", "Home"); // Redirect to landing page
        }
    }
}
