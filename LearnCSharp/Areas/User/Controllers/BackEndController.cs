using AutoMapper;
using Data.Models;
using Data.Models.ViewModels;
using Data.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LearnCSharp.Areas.User.Controllers
{
    [Area("User")]
    public class BackEndController : Controller
    {
        private readonly ILogger<BackEndController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BackEndController(ILogger<BackEndController> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            IEnumerable<Tutorial> tutorialsList = _unitOfWork.Tutorial.GetAll(includeProperties: "Category,Subcategory,UserScores,Source").Where(x => x.Category.Name == "Back-End");
            IEnumerable<TutorialWithScoreVM> tutorialsListVM = _mapper.Map<IEnumerable<Tutorial>, IEnumerable<TutorialWithScoreVM>>(tutorialsList);

            return View(tutorialsListVM);
        }

        public IActionResult Details(int id)
        {
            LearningList listObj = new()
            {
                TutorialId = id,
                Tutorial = _unitOfWork.Tutorial.GetFirstOrDefault(x => x.Id == id, includeProperties: "Category,Subcategory,UserScores,Source"),
                ArchivedTutorials = new(),
                LearnedTutorials = new()
                
            };
            

            LearningListVM learningListVM = _mapper.Map<LearningList, LearningListVM>(listObj);

            return View(learningListVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Details(LearningList learningList)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            learningList.ApplicationUserId = claim.Value;
            

            //Tutorial tutorial = _unitOfWork.Tutorial.GetFirstOrDefault(x => x.Id == id, includeProperties: "Category,Subcategory,UserScores,Source");
            //TutorialWithScoreVM tutorialVM = _mapper.Map<Tutorial, TutorialWithScoreVM>(tutorial);

            return View();
        }

    }
}
