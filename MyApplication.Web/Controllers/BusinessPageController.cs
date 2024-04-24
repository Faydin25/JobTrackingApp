using Microsoft.AspNetCore.Mvc;

namespace MyApplication.Web.Controllers
{
    public class BusinessPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
