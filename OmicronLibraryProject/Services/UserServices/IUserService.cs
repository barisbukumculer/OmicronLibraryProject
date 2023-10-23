using OmicronLibraryProject.Models;

namespace OmicronLibraryProject.Services.UserServices
{
    public interface IUserService
    {
        User GetById(int id);
        List<User> GetAll();
        void Add(User user);
        void Update(User user);
        void Delete(int id);
        User GetByTC(string TC);
    }
}
