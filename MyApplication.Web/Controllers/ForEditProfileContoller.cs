using Microsoft.AspNetCore.Mvc;
using MyApplication.Web.Data;
using MyApplication.Web.Models;

namespace MyApplication.Web.Controllers
{
    public class ForEditProfileContoller : Controller
    {
        private readonly ApplicationDbContext _context;

        public ForEditProfileContoller(ApplicationDbContext context)
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
            if (ModelState.IsValid)
            {
                var user = await _context.Users.FindAsync(model.Id);
                if (user != null)
                {
                    user.UserName = model.UserName;
                    user.Email = model.Email;
                    user.Password = model.Password;
                    await _context.SaveChangesAsync();
                    return RedirectToAction("ProfileUpdated");
                }
            }
            return View(model);
        }

    }
}
