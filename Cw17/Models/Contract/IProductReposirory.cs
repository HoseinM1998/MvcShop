using Cw17.Models.Entities;

namespace Cw17.Models.Contract
{
    public interface IProductReposirory
    {
        public List<Product> GetProducts();
        public void Add(Product product);
        public Product GetProductById(int id);

        public void Delete(int id);
        public void Update(Product product);



    }
}
