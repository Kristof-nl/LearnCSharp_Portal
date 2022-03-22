
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
    public class SourceController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SourceController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Source> objSourceList = _unitOfWork.Source.GetAll();
            return View(objSourceList);
        }

        //GET
        public IActionResult Create()
        {
            
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Source obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Source.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Source created successfully";
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

            var sourceFromDb = _unitOfWork.Source.GetFirstOrDefault(i => i.Id == id);

            if (sourceFromDb == null)
            {
                return NotFound();
            }

            return View(sourceFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Source obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Source.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Source updated successfully";
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

            var sourceFromDb = _unitOfWork.Source.GetFirstOrDefault(i => i.Id == id);

            if (sourceFromDb == null)
            {
                return NotFound();
            }

            return View(sourceFromDb);
        }

        //DELETE
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
            {
            var sourceFromDb = _unitOfWork.Source.GetFirstOrDefault(i => i.Id == id);

            if (sourceFromDb == null)
            {
                return NotFound();
            }

            _unitOfWork.Source.Remove(sourceFromDb);
            _unitOfWork.Save();
            TempData["success"] = "Source deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
