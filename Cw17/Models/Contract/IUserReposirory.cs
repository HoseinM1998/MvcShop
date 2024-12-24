using Cw17.Models.Entities;

namespace Cw17.Models.Contract
{
    public interface IUserReposirory
    {
        public void Add(User user);
        public User Get(string userName);
        public User GetById(int id);

        public List<User> GetAll();
        public void Delete(int id);
        public void Update(User user);




    }
}
