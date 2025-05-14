using UserService.Models;

namespace UserService.Services
{
    public class UserService : IUserService  // 🔥 deve implementare l'interfaccia
    {
        private readonly List<User> _users = new();

        public IEnumerable<User> GetAll() => _users;

        public User? GetById(Guid id) =>
            _users.FirstOrDefault(u => u.Id == id);

        public void Create(User user) => _users.Add(user);

        public void Delete(Guid id)
        {
            var user = GetById(id);
            if (user != null)
                _users.Remove(user);
        }
    }
}
