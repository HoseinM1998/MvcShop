using Cw17.Models.Contract;
using Cw17.Models.Entities;
using Cw17.Models.Repository;
using Microsoft.EntityFrameworkCore;

namespace Cw17.Models.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductReposirory _product;
        public ProductService()
        {
            _product = new ProductRepository();
        }
        public List<Product> GetAll()
        {
            try
            {
                return _product.GetProducts();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error : {ex.Message}");
            }
        }

        public Product GetById(int id)
        {
            try
            {
                return _product.GetProductById(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error : {ex.Message}");
            }
        }


        public void Create(string name, string title, int price, int categoryId)
        {
            var product = new Product
            {
                Name = name,
                Title = title,
                Price = price,
                CategoryId = categoryId
            };

            try
            {
                _product.Add(product);
             
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        public void Update(int id, string name, string title, int price, int categoryId)
        {
            try
            {
                var existingProduct = _product.GetProductById(id);
                if (existingProduct != null)
                {
                    existingProduct.Name = name;
                    existingProduct.Title = title;
                    existingProduct.Price = price;
                    existingProduct.CategoryId = categoryId;

                    _product.Update(existingProduct);
 
                }
                else
                {
                    throw new Exception("Product not found");
                }
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
                _product.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error : {ex.Message}");
            }
        }
    }


}
