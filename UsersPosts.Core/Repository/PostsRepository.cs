using System.Data;
using System.Data.SqlClient;
using Dapper;
using UsersPosts.Core.Contracts;
using UsersPosts.Core.Models;

namespace UsersPosts.Core.Repository;

public class PostsRepository : IPostsRespository
{
    private readonly string _connectionString;

    public PostsRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void Add(Post post)
    {
        //     Posts lentelė: su laukais Id, UserId, Title, Content.
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        dbConnection.Execute("INSERT INTO dbo.Posts (UserId, Title, Content) VALUES (@UserId, @Title, @Content)", post);
        dbConnection.Close();
    }

    public void Delete(int id)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        dbConnection.Execute("DELETE FROM dbo.Posts WHERE Id = @Id", new { Id = id });
        dbConnection.Close();
    }

    public Post Get(int id)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        var result = dbConnection.
            QueryFirstOrDefault<Post>(@"SELECT * FROM dbo.Posts WHERE Id = @Id", new { Id = id });
        dbConnection.Close();
        return result;
    }
}