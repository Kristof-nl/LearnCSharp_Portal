
using Data;
using Data.Models;
using Data.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Utility;

namespace LearnCSharp.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class SubcategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SubcategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index(int id)
        {
            IEnumerable<Subcategory> objSubcategoryList = _unitOfWork.Subcategory.GetAllSubcategories(id);
            return View(objSubcategoryList);
        }

        //GET
        public IActionResult Create()
        {
            
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Subcategory obj, int id)
        {
            if (ModelState.IsValid)
            {
                var categoryFromDb = _unitOfWork.Category.GetFirstOrDefault(i => i.Id == id);
                obj.Id = 0;
                obj.Category = categoryFromDb;
                _unitOfWork.Subcategory.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Subcategory created successfully";
                return RedirectToAction("Index", new { Id = id });
            }
            return View(obj);
        }

        //GET
        public IActionResult Edit(int? id, int? id2)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            var subcategoryFromDb = _unitOfWork.Subcategory.GetFirstOrDefault(i => i.Id == id);

            if (subcategoryFromDb == null)
            {
                return NotFound();
            }

            ViewBag.Id = id2;

            return View(subcategoryFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Subcategory obj, int categoryId)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Subcategory.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Subcategory updated successfully";
                return RedirectToAction("Index", new { Id = categoryId});
            }
            return View(obj);
        }

        //GET
        public IActionResult Delete(int? id, int? id2)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var categoryFromDb = _unitOfWork.Subcategory.GetFirstOrDefault(i => i.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            ViewBag.Id = id2;

            return View(categoryFromDb);
        }

        //DELETE
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id, int categoryId)
            {
            var categoryFromDb = _unitOfWork.Subcategory.GetFirstOrDefault(i => i.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            _unitOfWork.Subcategory.Remove(categoryFromDb);
            _unitOfWork.Save();
            TempData["success"] = "Supcategory deleted successfully";
            return RedirectToAction("Index", new { Id = categoryId });
        }
    }
}
