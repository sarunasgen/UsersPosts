using UsersPosts.Core.Contracts;
using UsersPosts.Core.Models;

namespace UsersPosts.Core.Services;

public class PostsService : IPostsService
{
    private readonly IPostsRespository _postsRespository;

    public PostsService(IPostsRespository postsRespository)
    {
        _postsRespository = postsRespository;
    }

    public void Add(Post user)
    {
        _postsRespository.Add(user);
    }

    public void Delete(int userId)
    {
        _postsRespository.Delete(userId);
    }

    public Post Get(int userId)
    {
        return _postsRespository.Get(userId);
    }
}