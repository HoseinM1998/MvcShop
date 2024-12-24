using Cw17.Models.Contract;
using Cw17.Models.Entities;
using Cw17.Models.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Cw17.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController()
        {
            _categoryService = new CategoryService();
        }

        public IActionResult List()
        {
            List<Category> categories = _categoryService.GetAll();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View(new Category());
        }

        [HttpPost]
        public IActionResult Create(string name)
        {
            _categoryService.Create(name);
            return RedirectToAction("List");
        }

        public IActionResult Update(int id)
        {
            var category = _categoryService.GetAll().FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Update(int id, string name)
        {
            _categoryService.Update(id, name);
            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            _categoryService.Delete(id);
            return RedirectToAction("List");
        }
    }
}