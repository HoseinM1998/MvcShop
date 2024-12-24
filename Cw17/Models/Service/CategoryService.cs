using Cw17.Models.Contract;
using Cw17.Models.Entities;
using Cw17.Models.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Cw17.Models.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryService _category;

        public CategoryService()
        {
            _category = new CategoryRepository();
        }

        public List<Category> GetAll()
        {
            try
            {
                return _category.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        public void Create(string name)
        {
            try
            {
                _category.Create(name);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        public void Update(int id, string name)
        {
            try
            {
                _category.Update(id, name);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        public void Delete(int id)
        {
            try
            {
                _category.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }
    }
}