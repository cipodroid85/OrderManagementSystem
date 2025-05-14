using UserService.Models;

namespace UserService.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        User? GetById(Guid id);
        void Create(User user);
        void Delete(Guid id);
    }
}
