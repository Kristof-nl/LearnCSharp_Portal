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

            return View(userLearningList);
        }

        public IActionResult Archived()
        {
            return View();
        }

    }
}
