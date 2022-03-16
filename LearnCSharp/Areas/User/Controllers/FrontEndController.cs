using Data.Models;
using Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace LearnCSharp.Controllers
{

    [Area("User")]
    public class FrontEndController : Controller
    {
        private readonly ILogger<FrontEndController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public FrontEndController(ILogger<FrontEndController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
           IEnumerable<Tutorial> tutorialsList = _unitOfWork.Tutorial.GetAll(includeProperties: "Category,Subcategory,UserScores,Source").Where(x => x.Category.Name == "Front-End");

           return View(tutorialsList);
        }

    }
}
