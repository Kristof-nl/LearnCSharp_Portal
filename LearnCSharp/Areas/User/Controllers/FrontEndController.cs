using AutoMapper;
using Data.Models;
using Data.Models.ViewModels;
using Data.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        public IActionResult Details(int productId, double score)
        {
            if(score / 100> 1)
            {
                ViewBag.Score = Math.Round(score/100, 2);
            }
            else if (score / 10 > 1)
            {
                ViewBag.Score = Math.Round(score / 10, 2);
            }
            else
            {
                ViewBag.Score = Math.Round(score, 2);
            }

            LearningList listObj = new()
            {
                TutorialId = productId,
                Tutorial = _unitOfWork.Tutorial.GetFirstOrDefault(x => x.Id == productId, includeProperties: "Category,Subcategory,UserScores,Source")
            };

            return View(listObj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Details(LearningList learningList)
        {
            Tutorial tutorial = _unitOfWork.Tutorial.GetFirstOrDefault(x => x.Id == learningList.TutorialId, includeProperties: "Category,Subcategory,UserScores,Source");

            //Check userdId in Db
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            learningList.ApplicationUserId = claim.Value;


            LearningList learningListFromDb = _unitOfWork.LearningList.GetFirstOrDefault(x => x.ApplicationUserId == claim.Value, includeProperties: "LearnedTutorials,ArchivedTutorials");

            if (learningListFromDb == null)
            {
                learningList.LearnedTutorials = new();
                learningList.ArchivedTutorials = new();
                _unitOfWork.LearningList.Add(learningList);
            }
            else
            {
                learningListFromDb.LearnedTutorials.Add(tutorial);
            }

            _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }

    }
}
