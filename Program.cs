using App;

List<Iuser> users = new List<Iuser>();
users.Add(new Account("test", "a@a", "test"));
Iuser? active_user = null;

bool running = true;
while (running)
{
  if (active_user is Account a)
  {
    Console.WriteLine("Welcome " + a.Name);
    Console.WriteLine("\n\nquit");
    switch (Console.ReadLine())
    {

      case "quit":
        active_user = null;
        break;
    }
  }
  else
  {
    Console.WriteLine("add- Register new account\nlogin - Login on a new account\nquit - closes the program");
    switch (Console.ReadLine())
    {
      case "add":
        Console.WriteLine("Welcome new user, please enter your credentials\n\n\n");
        Console.Write("Name: ");
        string? name = Console.ReadLine();
        Console.Write("Email: ");
        string? email = Console.ReadLine();
        Console.Write("Password");
        string? _password = Console.ReadLine();
        users.Add(new Account(name, email, _password));


        break;
      case "login":
        if (active_user == null)
        {
          Console.Write("Username: ");
          string? username = Console.ReadLine();
          Console.Write("password: ");
          string? password = Console.ReadLine();
          foreach (Iuser user in users)
          {
            if (username is null or "" || password is null or "")
            {
              Console.WriteLine("username or password is wrong.");
            }
            else if (user.TryLogin(username, password))
            {
              active_user = user;
              break;
            }
          }
        }
        break;
      case "quit":
        running = false;
        break;
      default:
        Console.WriteLine("You must enter a valid command.");
        break;
    }
  }
}