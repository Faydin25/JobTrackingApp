using Microsoft.AspNetCore.Mvc;

namespace MyApplication.Web.Models
{
    public class ProfileEditModel : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
