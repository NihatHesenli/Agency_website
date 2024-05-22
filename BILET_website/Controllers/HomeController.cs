using Microsoft.AspNetCore.Mvc;

namespace BILET_website.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
