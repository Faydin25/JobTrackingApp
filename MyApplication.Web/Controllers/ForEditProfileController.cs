using Microsoft.AspNetCore.Mvc;
using MyApplication.Web.Data;
using MyApplication.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;

namespace MyApplication.Web.Controllers
{
    public class ForEditProfileController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ForEditProfileController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditProfile(User model)
        {
            {
                var userName = HttpContext.Session.GetString("UserName");
                var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName);
                model.Id = user.Id;
            }
            if (ModelState.IsValid)
            {
                var user = await _context.Users.FindAsync(model.Id);
                if (user != null)
                {
                    user.UserName = model.UserName;
                    user.Email = model.Email;
                    user.Password = model.Password;
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Profile");// Düzelt!
                }
            }
            return View(model);
        }

    }
}
