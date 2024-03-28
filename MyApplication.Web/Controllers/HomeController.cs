using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
// using MyApplication.Models; 

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
