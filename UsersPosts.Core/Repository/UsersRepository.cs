using System.Data;
using System.Data.SqlClient;
using Dapper;
using UsersPosts.Core.Contracts;
using UsersPosts.Core.Models;

namespace UsersPosts.Core.Repository;

public class UsersRepository : IUsersRepository
{
    private readonly string _connectionString;

    public UsersRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void Add(User user)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        dbConnection.Execute("INSERT INTO dbo.Users (Name, Email) VALUES (@Name, @Email)", user);
        dbConnection.Close();
    }

    public void Delete(int userId)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        dbConnection.Execute("DELETE FROM dbo.Users WHERE Id = @Id", new { Id = userId });
        dbConnection.Close();
    }

    public User Get(int userId)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        var result = dbConnection.
            QueryFirstOrDefault<User>(@"SELECT Id, Name, Email FROM dbo.Users WHERE Id = @Id", new { Id = userId });
        dbConnection.Close();
        return result;
    }
}