using Microsoft.EntityFrameworkCore;
using OmicronLibraryProject.Context;
using OmicronLibraryProject.Models;

namespace OmicronLibraryProject.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly LibraryDbContext _context;

        public UserService(LibraryDbContext context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            _context.Set<User>().Add(user);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = GetById(id);
            if (user != null)
            {
                _context.Set<User>().Remove(user);
                _context.SaveChanges();
            }
        }

        public List<User> GetAll()
        {
            return _context.Set<User>().ToList();
        }

        public User GetById(int id)
        {
            return _context.Set<User>().Find(id);
        }

        public User GetByTC(string TC)
        {
            return _context.Users.SingleOrDefault(user => user.TCIdentityNumber == TC);
        }

        public void Update(User user)
        {
            _context.Set<User>().Update(user);
            _context.SaveChanges();
        }
    }
}
