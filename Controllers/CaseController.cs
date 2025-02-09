using Microsoft.AspNetCore.Mvc;

namespace Detective_App.Controllers
{
    public class CaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
