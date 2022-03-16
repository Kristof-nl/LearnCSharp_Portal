using Data.Models;
using Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace LearnCSharp.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var tutorials = _unitOfWork.Tutorial.GetAll();
            var ids = new List<int>();
            foreach (var tutorial in tutorials)
            {
                ids.Add(tutorial.Id);
            }

            //Get 3 random images to the carousel
            Random rnd = new Random();
            int num1 = ids[rnd.Next(ids.Count)];

            int num2 = ids[rnd.Next(ids.Count)];
            while(num2 == num1)
            {
                num2 = ids[rnd.Next(ids.Count)];
            }

            int num3 = ids[rnd.Next(ids.Count)];
            while (num3 == num2 || num3 == num1)
            {
                num3 = ids[rnd.Next(ids.Count)];
            }

            var first = _unitOfWork.Tutorial.GetFirstOrDefault(x => x.Id == num1);
            ViewBag.First = first.ImgUrl;
            var second = _unitOfWork.Tutorial.GetFirstOrDefault(x => x.Id == num2);
            ViewBag.Second = second.ImgUrl;
            var third = _unitOfWork.Tutorial.GetFirstOrDefault(x => x.Id == num3);
            ViewBag.Third = third.ImgUrl;

            return View();
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}