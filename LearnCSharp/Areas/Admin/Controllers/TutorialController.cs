
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
            IEnumerable<Tutorial> objCategoryList = _unitOfWork.Tutorial.GetAll();
            return View(objCategoryList);
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
            };

            if (id == null || id == 0)
            {
                //Create tutorial
                
                return View(tutorialVM);
            }
            else
            {
                //Update

            }

            return View(tutorialVM);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(TutorialVM obj, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                //Add uploaded files to wwwroot/img/tutorials
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if(file != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"img\tutorials");
                    var extension = Path.GetExtension(file.FileName);

                    using (var fileStreams = new FileStream(Path.Combine(uploads,fileName+extension), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }
                    obj.Tutorial.ImgUrl = @"img\tutorials" + fileName + extension;
                }
                    

                _unitOfWork.Tutorial.Add(obj.Tutorial);
                _unitOfWork.Save();
                TempData["success"] = "Tutorial created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Delete(int? id)
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

            return View(tutorialFromDb);
        }

        //DELETE
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
            {
            var tutorialFromDb = _unitOfWork.Tutorial.GetFirstOrDefault(i => i.Id == id);

            if (tutorialFromDb == null)
            {
                return NotFound();
            }

            _unitOfWork.Tutorial.Remove(tutorialFromDb);
            _unitOfWork.Save();
            TempData["success"] = "Tutorial deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
