using AutoMapper;
using Data.Models;
using Data.Models.ViewModels;
using Data.Repository.IRepository;
using LearnCSharp.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Utility;

namespace LearnCSharp.Areas.User.Controllers
{
    [Area("User")]
    public class LearningListController : Controller
    {
        private readonly ILogger<LearningListController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LearningListController(ILogger<LearningListController> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            LearningList userLearningList = _unitOfWork.LearningList.GetFirstOrDefault(x => x.ApplicationUserId == claim.Value, includeProperties: "LearnedTutorials,ArchivedTutorials");

            if(userLearningList == null)
            {
                TempData["error"] = "Your list is empty. Please add first a tutorial.";
                return RedirectToAction("Index", "Home");
            }

            return View(userLearningList);
        }

        
        public IActionResult Archive(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var tutorialFromDb = _unitOfWork.Tutorial.GetFirstOrDefault(i => i.Id == id);

            if (tutorialFromDb == null)
            {
                return NotFound();
            }

            ViewBag.Score = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };


            TutorialWithScorePostVM tutorialPost = _mapper.Map<Tutorial, TutorialWithScorePostVM>(tutorialFromDb);

            return View(tutorialPost);
        }


        //Archive tutorial
        [HttpPost, ActionName("Archive")]
        [ValidateAntiForgeryToken]
        public IActionResult ArchivePOST(TutorialWithScorePostVM tutorialPost)
        {
            var tutorialFromDb = _unitOfWork.Tutorial.GetFirstOrDefault(i => i.Id == tutorialPost.Id);

            if (tutorialFromDb == null)
            {
                return NotFound();
            }

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            LearningList userLearningList = _unitOfWork.LearningList.GetFirstOrDefault(x => x.ApplicationUserId == claim.Value, includeProperties: "LearnedTutorials,ArchivedTutorials");

            //Remove tutorial from Learning List
            userLearningList.LearnedTutorials.Remove(tutorialFromDb);

            //Add tutorial to Archived Turotials List
            userLearningList.ArchivedTutorials.Add(tutorialFromDb);

            //Add user score
            int score = tutorialPost.Score;
            UserScore userScore = new()
            {
                Score = score,
            };

            _unitOfWork.UserScore.Add(userScore);

            userScore.Tutorial = tutorialFromDb;


            _unitOfWork.Save();
            TempData["success"] = "Tutorial moved successfully to the Archived Turotials List";
            return RedirectToAction("Index");
        }

        public IActionResult Archived()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            LearningList userLearningList = _unitOfWork.LearningList.GetFirstOrDefault(x => x.ApplicationUserId == claim.Value, includeProperties: "LearnedTutorials,ArchivedTutorials");


            return View(userLearningList);
        }

    }
}
