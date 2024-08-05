using UsersPosts.Core.Models;

namespace UsersPosts.Core.Contracts;

public interface IPostsService
{
    void Add(Post user);
    void Delete(int userId);
    Post Get(int userId);
}