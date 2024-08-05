using UsersPosts.Core.Contracts;
using UsersPosts.Core.Models;

namespace UsersPosts.Core.Services;

public class UsersService : IUsersService
{
    private readonly IUsersRepository _usersRepository;

    public UsersService(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public void Add(User user)
    {
        _usersRepository.Add(user);
    }

    public void Delete(int userId)
    {
        _usersRepository.Delete(userId);
    }

    public User Get(int userId)
    {
        return _usersRepository.Get(userId);
    }
}