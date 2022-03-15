
using Data;
using Data.Models;
using Data.Models.ViewModels;
using Data.Repository.IRepository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LearnCSharp.Controllers
{
    [Area("Admin")]
    public class TutorialController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;


        public TutorialController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }


        //GET
        public IActionResult Upsert(int? id)
        {
            TutorialVM tutorialVM = new()
            {
                Tutorial = new(),
                CategoryList = _unitOfWork.Category.GetAll().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }),
                SubcategoryList = _unitOfWork.Subcategory.GetAll().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }),
                SourceList = _unitOfWork.Source.GetAll().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }),
            };

            if (id == null || id == 0)
            {
                //Create tutorial

                return View(tutorialVM);
            }
            else
            {
                //Update
                tutorialVM.Tutorial = _unitOfWork.Tutorial.GetFirstOrDefault(x => x.Id == id);
                return View(tutorialVM);
            }
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(TutorialVM obj, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                //Add uploaded files to wwwroot/img/tutorials
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"img\tutorial");
                    var extension = Path.GetExtension(file.FileName);

                    //Delete old image in edit action
                    if (obj.Tutorial.ImgUrl != null)
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, obj.Tutorial.ImgUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }
                    obj.Tutorial.ImgUrl = @"\img\tutorial\" + fileName + extension;
                }

                if (obj.Tutorial.Id == 0)
                {
                    _unitOfWork.Tutorial.Add(obj.Tutorial);
                }
                else
                {
                    _unitOfWork.Tutorial.Update(obj.Tutorial);
                }

                _unitOfWork.Save();
                TempData["success"] = "Tutorial created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var tutorialtList = _unitOfWork.Tutorial.GetAll(includeProperties:"Category,Subcategory,UserScores,Source");
            return Json(new { data = tutorialtList });
        }

        //DELETE
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var tutorialFromDb = _unitOfWork.Tutorial.GetFirstOrDefault(i => i.Id == id);

            if (tutorialFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            var oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, tutorialFromDb.ImgUrl.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            _unitOfWork.Tutorial.Remove(tutorialFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });
        }
        #endregion
    }
}