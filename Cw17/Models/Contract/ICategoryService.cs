using Cw17.Models.Entities;

namespace Cw17.Models.Contract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        public void Create(string name);
        public void Delete(int id);
        public void Update(int id, string name);




    }
}
