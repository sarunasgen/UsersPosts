namespace UsersPosts.Core.Models;

public class User
{
    // Users lentelė: su laukais Id, Name, Email.
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    public User()
    {
    }

    public User(int id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }
    public User(string name, string email)
    {
        Name = name;
        Email = email;
    }
}