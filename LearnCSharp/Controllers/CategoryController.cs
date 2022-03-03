using Microsoft.AspNetCore.Mvc;

namespace LearnCSharp.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
