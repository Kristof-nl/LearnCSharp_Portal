
using Data;
using Data.Models;
using Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LearnCSharp.Controllers
{
    [Area("Admin")]
    public class TutorialController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TutorialController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Tutorial> objCategoryList = _unitOfWork.Tutorial.GetAll();
            return View(objCategoryList);
        }

        
        //GET
        public IActionResult Upsert(int? id)
        {
            Tutorial tutorial = new();
            IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category.GetAll().Select(
               u => new SelectListItem
               {
                   Text = u.Name,
                   Value = u.Id.ToString()
               });
            IEnumerable<SelectListItem> SubcategoryList = _unitOfWork.Subcategory.GetAll().Select(
               u => new SelectListItem
               {
                   Text = u.Name,
                   Value = u.Id.ToString()
               });
            if (id == null || id == 0)
            {
                //Create tutorial
                return View(tutorial);
            }
            else
            {
                //Update
            }

            return View(tutorial);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Tutorial obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Tutorial.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Tutorial updated successfully";
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
