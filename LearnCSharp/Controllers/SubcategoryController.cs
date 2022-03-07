
using Data;
using Data.Models;
using Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace LearnCSharp.Controllers
{
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
                _unitOfWork.Subcategory.Add(obj);
                //categoryFromDb.Subcategories.Add( new Subcategory
                //{
                //    Name = obj.Name,
                //    Category = categoryFromDb,

                //});
                _unitOfWork.Category.Add(categoryFromDb);
                _unitOfWork.Save();
                TempData["success"] = "Subcategory created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Edit(int? id)
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

            return View(subcategoryFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Subcategory obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Subcategory.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Subcategory updated successfully";
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

            var categoryFromDb = _unitOfWork.Category.GetFirstOrDefault(i => i.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        //DELETE
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
            {
            var categoryFromDb = _unitOfWork.Category.GetFirstOrDefault(i => i.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            _unitOfWork.Category.Remove(categoryFromDb);
            _unitOfWork.Save();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
