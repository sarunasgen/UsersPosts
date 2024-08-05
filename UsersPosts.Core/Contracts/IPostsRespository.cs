using UsersPosts.Core.Models;

namespace UsersPosts.Core.Contracts;

public interface IPostsRespository
{
    void Add(Post post);
    void Delete(int id);
    Post Get(int id);
}