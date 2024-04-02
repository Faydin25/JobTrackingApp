using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApplication.Web.Data;
using MyApplication.Web.Models;
using System.Diagnostics;

namespace MyApplication.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Profile()
        {
            return View();
        }
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        [HttpPost]
        public async Task<IActionResult> Register(User model)
        {
            if (ModelState.IsValid)
            {
                var user = new User { UserName = model.UserName, Email = model.Email, Password = model.Password };
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }



        public IActionResult EditProfile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Username, string Password)
        {
            // Basit doğrulama
            if (Username == "admin" && Password == "1234")
            {
                // Doğrulama başarılı
                return RedirectToAction("Profile");
            }
            else
            {
                // Doğrulama başarısız
                ViewBag.Error = "Kullanıcı adı veya şifre hatalı!";
                return View();
            }
        }

        public IActionResult Logout() //Profile
        {
            // Örneğin, HttpContext.SignOutAsync() kullanılabilir
            return RedirectToAction("Index");
        }

    }
}
