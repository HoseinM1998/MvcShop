using Cw17.Models.Entities;

namespace Cw17.Models.Contract
{
    public interface IProductService
    {
        List<Product> GetAll();
        public Product GetById(int id);

        public void Create(string name, string title, int price, int categoryId);
        public void Update(int id, string name, string title, int price, int categoryId);
        public void Delete(int id);






    }
}
