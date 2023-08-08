using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EXommerceApp.Models.Models;
using EcommerceApp.DataAccess.Data;
using EcommerceApp.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        
        // constructor
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        // Views
        public IActionResult Index()
        {
            List<Category> objCategoryList = _unitOfWork.CategoryRepository.GetAll().ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var category = _unitOfWork.CategoryRepository.Get(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        public IActionResult Delete(int? id)
        {
            var category = _unitOfWork.CategoryRepository.Get(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        
        
        // Access Data Logic 
        [HttpPost]
        public IActionResult Create(Category category)
        {

            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The display order cannot exactly match the name");
            }

            if (category.Name != null && category.Name.ToLower() == "test")
            {
                ModelState.AddModelError("Name", "test is an invalid value");
            }
            // if add success the page will redirect to category list page
            if (ModelState.IsValid)
            {
                _unitOfWork.CategoryRepository.Add(category);
                _unitOfWork.Save();
                TempData["success"] = "Category created successfully!";
                return RedirectToAction("Index","Category");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CategoryRepository.Update(obj);
               _unitOfWork.Save();
                TempData["success"] = "Category updated successfully!";
                return RedirectToAction("Index", "Category");
            }

            return View();
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? category = _unitOfWork.CategoryRepository.Get(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            _unitOfWork.CategoryRepository.Remove(category);
            _unitOfWork.Save();
            TempData["success"] = "Category deleted successfully!";
            return RedirectToAction("Index");

        }
    }
}