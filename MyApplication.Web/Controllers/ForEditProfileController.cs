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
                if (user.Id != model.Id)
                    model.Id = user.Id;
            }
            if (ModelState.IsValid)
            {
                var user = await _context.Users.FindAsync(model.Id);
                if (user != null)
                {
                    if (model.UserName != null)
                    {
                        bool userNameExists = await _context.Users.AnyAsync(u => u.UserName == model.UserName);
                        if (!userNameExists)
                            user.UserName = model.UserName;
                    }
                    if (model.Email != null)
                    {
                        bool emailExists = await _context.Users.AnyAsync(u => u.Email == model.Email);
                        if(!emailExists)
                            user.Email = model.Email;
                    }
                    if(model.Password != null)
                        user.Password = model.Password;
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Profile", "Home");
                }
            }
            return View(model);
        }

    }
}
