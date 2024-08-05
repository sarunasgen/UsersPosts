using System;
using UsersPosts.Core.Contracts;
using UsersPosts.Core.Models;
using UsersPosts.Core.Repository;
using UsersPosts.Core.Services;

namespace UsersPosts;

public class Program
{
    public static void Main(string[] args)
    {
        IPostsRespository postsRespository = 
            new PostsRepository("Server=localhost\\MSSQLSERVER01;Database=autonuoma;Trusted_Connection=True;");
        IUsersRepository usersRepository =
            new UsersRepository("Server=localhost\\MSSQLSERVER01;Database=autonuoma;Trusted_Connection=True;");

        IPostsService postsService = new PostsService(postsRespository);
        IUsersService usersService = new UsersService(usersRepository);

        while (true)
        {
            Console.WriteLine("1. Gauti Post");
            Console.WriteLine("2. Gauti User");
            Console.WriteLine("3. Istrinti Post");
            Console.WriteLine("4. Istrinti User");
            Console.WriteLine("5. Ideti Post");
            Console.WriteLine("6. Ideti User");
            
            string selection = Console.ReadLine();

            switch (selection)
            {
                case "1":
                    int postSelect = int.Parse(Console.ReadLine());
                    Console.WriteLine(postsService.Get(postSelect));
                    break;
                case "2":
                    int userSelect = int.Parse(Console.ReadLine());
                    Console.WriteLine(usersService.Get(userSelect));
                    break;
                case "3":
                    int postDelete = int.Parse(Console.ReadLine());
                    postsService.Delete(postDelete);
                    break;
                case "4":
                    int userDelete = int.Parse(Console.ReadLine());
                    usersService.Delete(userDelete);
                    break;
                case "5":
                    usersService.Add(new User(Console.ReadLine(),Console.ReadLine()));
                    break;
                case "6":
                    postsService.Add(new Post(int.Parse(Console.ReadLine()),Console.ReadLine(),Console.ReadLine()));
                    break;
            }

        }
    }
}

