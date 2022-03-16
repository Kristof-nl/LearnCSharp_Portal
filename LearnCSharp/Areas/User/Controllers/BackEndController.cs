using Microsoft.AspNetCore.Mvc;

namespace LearnCSharp.Areas.User.Controllers
{
    public class BackEndController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
