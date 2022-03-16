using AutoMapper;
using Data.Models;
using Data.Models.ViewModels;
using Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace LearnCSharp.Controllers
{

    [Area("User")]
    public class FrontEndController : Controller
    {
        private readonly ILogger<FrontEndController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FrontEndController(ILogger<FrontEndController> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
           IEnumerable<Tutorial> tutorialsList = _unitOfWork.Tutorial.GetAll(includeProperties: "Category,Subcategory,UserScores,Source").Where(x => x.Category.Name == "Front-End");
           IEnumerable<TutorialWithScoreVM>  tutorialsListVM = _mapper.Map<IEnumerable<Tutorial>, IEnumerable<TutorialWithScoreVM>>(tutorialsList);

           return View(tutorialsListVM);
        }

    }
}
