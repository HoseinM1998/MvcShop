using Cw17.Models.Contract;
using Cw17.Models.DbContext;
using Cw17.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Cw17.Models.Repository
{
    public class CategoryRepository : ICategoryService
    {
        private readonly ShopDbcontext _context;

        public CategoryRepository()
        {
            _context = new ShopDbcontext();
        }

        public List<Category> GetAll()
        {
            return _context.Categories.AsNoTracking().ToList();
        }

        public void Create(string name)
        {
            var category = new Category
            {
                Name = name
            };

            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void Delete(int id )
        {
            var category = _context.Categories.FirstOrDefault(p => p.Id == id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }

        public void Update(int id, string name)
        {
            var updateCategory = _context.Categories.Find(id);
            if (updateCategory != null)
            {
                updateCategory.Name = name;
                _context.SaveChanges();
            }
        }
    }
}