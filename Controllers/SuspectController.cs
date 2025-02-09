using Microsoft.AspNetCore.Mvc;

namespace Detective_App.Controllers
{
    public class SuspectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
