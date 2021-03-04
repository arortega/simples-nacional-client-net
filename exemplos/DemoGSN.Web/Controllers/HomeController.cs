using Microsoft.AspNetCore.Mvc;

namespace DemoGSN.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
