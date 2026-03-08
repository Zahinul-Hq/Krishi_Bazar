using Microsoft.AspNetCore.Mvc;

namespace KrishiBazaarProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}