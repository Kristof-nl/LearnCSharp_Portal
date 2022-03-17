﻿using AutoMapper;
using Data.Models;
using Data.Models.ViewModels;
using Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace LearnCSharp.Areas.User.Controllers
{
    [Area("User")]
    public class MVCController : Controller
    {
        private readonly ILogger<MVCController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MVCController(ILogger<MVCController> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            IEnumerable<Tutorial> tutorialsList = _unitOfWork.Tutorial.GetAll(includeProperties: "Category,Subcategory,UserScores,Source").Where(x => x.Category.Name == "MVC");
            IEnumerable<TutorialWithScoreVM> tutorialsListVM = _mapper.Map<IEnumerable<Tutorial>, IEnumerable<TutorialWithScoreVM>>(tutorialsList);

            return View(tutorialsListVM);
        }

        public IActionResult Details(int id)
        {
            Tutorial tutorial = _unitOfWork.Tutorial.GetFirstOrDefault(x => x.Id == id, includeProperties: "Category,Subcategory,UserScores,Source");
            TutorialWithScoreVM tutorialVM = _mapper.Map<Tutorial, TutorialWithScoreVM>(tutorial);

            return View(tutorialVM);
        }

    }
}