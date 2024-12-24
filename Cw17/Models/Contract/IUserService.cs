using Cw17.Models.Entities;

namespace Cw17.Models.Contract
{
    public interface IUserService
    {
        public void Register(string fullName, string userName, string password , string email);
        public User Login(string username, string password);
  
        public bool Logout();
        public User Get(string userName);
        public User GetById(int id);

        public List<User> GetAll();
        public void Update(int id, string fullName, string userName, string email,string password);

        public void Delete(int id);

    }
}
