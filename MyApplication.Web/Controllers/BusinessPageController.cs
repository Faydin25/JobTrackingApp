using MyApplication.Web.Models; // Doğru namespace
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MyApplication.Web.Data;

namespace MyApplication.Web.Controllers
{
    public class BusinessPageController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BusinessPageController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? userId)
        {
            var users = _context.Users.ToList();
            IEnumerable<MyApplication.Web.Models.Task> tasks = Enumerable.Empty<MyApplication.Web.Models.Task>(); // Açıkça belirt
            if (userId.HasValue)
            {
                tasks = _context.Tasks
                                .Include(t => t.User)
                                .Where(t => t.UserId == userId.Value)
                                .ToList(); // List<MyApplication.Web.Models.Task>
            }

            var viewModel = new BusinessPageViewModel
            {
                Users = users,
                Tasks = tasks
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult DeleteTask(int taskId)
        {
            var task = _context.Tasks.Find(taskId);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
                TempData["Message"] = "Görev başarıyla silindi.";
            }
            else
            {
                TempData["Error"] = "Görev bulunamadı.";
            }
            return RedirectToAction("Index"); // Görev listesi sayfasına geri yönlendir
        }

    }
}
