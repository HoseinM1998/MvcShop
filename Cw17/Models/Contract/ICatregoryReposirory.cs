using Cw17.Models.Entities;

namespace Cw17.Models.Contract
{
    public interface ICatregoryReposirory
    {
        public List<Category> GetCategories();
        public void Add(string name);
        public void Delete(int id);
        public void Update(int id, string name);

    }
}
