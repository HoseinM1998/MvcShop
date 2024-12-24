using Cw17.Models.Contract;
using Cw17.Models.DbContext;
using Cw17.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cw17.Models.Repository
{
    public class UserRepository : IUserReposirory
    {
        private readonly ShopDbcontext _context;
        public UserRepository()
        {
            _context = new ShopDbcontext();
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public User Get(string userName)
        {
            return _context.Users.AsNoTracking().FirstOrDefault(u => u.UserName == userName);
        }

        public User GetById(int id)
        {
            return _context.Users.AsNoTracking().FirstOrDefault(u => u.Id == id);
        }

        public List<User> GetAll()
        {
            return _context.Users.AsNoTracking().ToList();
        }

        public void Delete(int id)
        {
            var user = _context.Users.Where(p => p.Id == id).First();
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public void Update(User user)
        {
            var updateUser = _context.Users.Find(user.Id);
            if (updateUser != null)
            { 
                updateUser.FullName = user.FullName;
                updateUser.UserName = user.UserName;
                updateUser.Email = user.Email;
                updateUser.Role = user.Role;
                _context.SaveChanges();

            }
        }
    }

}

