using App;
string[] users_csv = File.ReadAllLines("Account.csv");
string[] items_csv = File.ReadAllLines("Items.csv");
List<Account> users = new List<Account>();
List<Items> item = new List<Items>();
Account? active_user = null;
foreach (string items_data in items_csv)
{
  string[] split_item_data = items_data.Split(",");
  item.Add(new Items(split_item_data[0], split_item_data[1], split_item_data[2]));
}
foreach (string user_data in users_csv)
{
  string[] split_user_data = user_data.Split(",");
  users.Add(new Account(split_user_data[0], split_user_data[1], split_user_data[2]));
}

bool running = true;
while (running)
{
  if (active_user != null)
  {
    Console.WriteLine($"Welcome {active_user.Name}");
    Console.WriteLine("\n\nnew- add an item to your inventory\nbrowse\nlogout");
    switch (Console.ReadLine())
    {
      case "new":
        Console.Write("Enter the name of the item: ");
        string? item_name = Console.ReadLine();
        Console.Write("Enter a description of the item: ");
        string? item_info = Console.ReadLine();
        string item_owner = active_user.Name;
        item.Add(new Items(item_name!, item_info!, item_owner));
        string[] new_item = { $"{item_name},{item_info},{item_owner}" };
        File.AppendAllLines("Items.csv", new_item);
        break;
      case "browse":
        Console.WriteLine("All items available to trade: ");
        foreach (var i in item)
        {
          if (i.Item_owner != active_user.Name)
          {
            Console.WriteLine($"{i.Item_name},Item description: {i.Item_info},item owner: {i.Item_owner}");
          }
        }
        break;


      case "logout":
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
        Console.Write("Password: ");
        string? _password = Console.ReadLine();
        users.Add(new Account(name, email, _password));
        string[] new_account = { $"{name},{email},{_password}" };
        File.AppendAllLines("Account.csv", new_account);
        break;
      case "login":
        if (active_user == null)
        {
          Console.Write("Username: ");
          string? username = Console.ReadLine();
          Console.Write("password: ");
          string? password = Console.ReadLine();
          foreach (Account user in users)
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