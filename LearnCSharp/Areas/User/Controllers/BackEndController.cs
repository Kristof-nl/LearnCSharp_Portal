using AutoMapper;
using Data.Models;
using Data.Models.ViewModels;
using Data.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Utility;

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

        public IActionResult Details(int productId, double score)
        {
            ViewBag.Score = ViewBagScore.CalculateScore(score);

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
            Tutorial tutorial = _unitOfWork.Tutorial.GetFirstOrDefault(
                x => x.Id == learningList.TutorialId, includeProperties: "Category,Subcategory,UserScores,Source");

            //Check userdId in Db
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            learningList.ApplicationUserId = claim.Value;


            LearningList learningListFromDb = _unitOfWork.LearningList.GetFirstOrDefault(
                x => x.ApplicationUserId == claim.Value, includeProperties: "LearnedTutorials,ArchivedTutorials");

            //Check of user has all his learning list
            if (learningListFromDb == null)
            {
                learningList.LearnedTutorials = new();
                learningList.ArchivedTutorials = new();
                _unitOfWork.LearningList.Add(learningList);
            }
            else
            {
                //Check of user has all tutorial in his learning list(also in archived tutorials)
                if (learningListFromDb.LearnedTutorials.Contains(tutorial))
                {
                    TempData["Error"] = $"Tutorial {tutorial.Title} is already in your learning list. Please select another tutorial to learn.";
                    return RedirectToAction("Index");
                }
                else if (learningListFromDb.ArchivedTutorials.Contains(tutorial))
                {
                    TempData["Error"] = $"Tutorial {tutorial.Title} is already in your archived tutorial section. Please select another tutorial to learn.";
                    return RedirectToAction("Index");
                }
                else
                {
                    learningListFromDb.LearnedTutorials.Add(tutorial);
                }
            }

            _unitOfWork.Save();

            TempData["success"] = "Tutorial added to your learning list";
            return RedirectToAction(nameof(Index));
        }

    }
}
