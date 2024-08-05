using UsersPosts.Core.Models;

namespace UsersPosts.Core.Contracts;

public interface IUsersRepository
{
    void Add(User user);
    void Delete(int userId);
    User Get(int userId);
}