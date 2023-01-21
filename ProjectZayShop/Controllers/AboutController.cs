using Microsoft.AspNetCore.Mvc;

namespace ProjectZayShop.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
