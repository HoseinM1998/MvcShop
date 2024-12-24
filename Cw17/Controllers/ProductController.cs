using Cw17.Models.Contract;
using Cw17.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Cw17.Models.Service;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace Cw17.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        IProductService productService = new ProductService();

        public IActionResult List()
        {
            List<Product> products = productService.GetAll();
            return View(products);
        }

        public IActionResult Create()
        {
            return View(new Product());
        }

        [HttpPost]
        public IActionResult Create(string name, string title, int price, int categoryId)
        {
            productService.Create(name, title, price, categoryId);
            return RedirectToAction("List");

        }



        public IActionResult Edit(int id)
        {
            var product = productService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(int id, string name, string title, int price, int categoryId)
        {
            try
            {
                productService.Update(id, name, title, price, categoryId);
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating product: {ex.Message}");
                return View();
            }
        }


        public IActionResult Delete(int id)
        {
            productService.Delete(id);
            return RedirectToAction("List");
        }
    }
}