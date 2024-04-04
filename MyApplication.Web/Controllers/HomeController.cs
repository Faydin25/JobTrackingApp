using Microsoft.AspNetCore.Identity;
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
        public IActionResult Index()
        {
            return View();
        }
        //------------------------------------------------
        public IActionResult Register()
        {
            return View();
        }
        //------------------------------------------------
        public IActionResult Profile()
        {
            return View();
        }
        //------------------------------------------------
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context; //?? throw new ArgumentNullException(nameof(context));
        }


        [HttpPost]
        public async Task<IActionResult> Register(User model)//Kullanıcıları eklemek için
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
        [HttpPost]


        public IActionResult EditProfile()
        {
            return View();
        }

        public IActionResult Logout() //Profile
        {
            // Örneğin, HttpContext.SignOutAsync() kullanılabilir
            return RedirectToAction("Index");
        }

    }
}
