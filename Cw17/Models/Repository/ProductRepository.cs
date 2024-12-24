using Cw17.Models.Contract;
using Cw17.Models.DbContext;
using Cw17.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cw17.Models.Repository
{
    public class ProductRepository : IProductReposirory
    {
        private readonly ShopDbcontext _context;
        public ProductRepository()
        {
            _context = new ShopDbcontext();
        }
        public List<Product> GetProducts()
        {
            return _context.products
                .Include(C => C.Category)
                .AsNoTracking().ToList();
        }
        public void Add(Product product)
        {
            _context.products.Add(product);
            _context.SaveChanges();
        }

        public Product GetProductById(int id)
        {
            return _context.products.AsNoTracking().FirstOrDefault(p => p.Id == id);
        }
        public void Delete(int id)
        {
            var product = _context.products.Where(p => p.Id == id).First();
            if (product != null)
            {
                _context.products.Remove(product);
                _context.SaveChanges();
            }
        }

        public void Update(Product product)
            {
                var updateProduct = _context.products.Find(product.Id);
                if (updateProduct != null)
                {
                    updateProduct.Name = product.Name;
                    updateProduct.Title = product.Title;
                    updateProduct.Price = product.Price;
                    updateProduct.CategoryId = product.CategoryId;
                    _context.SaveChanges();
                }
            }
        }
    }
    

