using App;

List<Iuser> users = new List<Iuser>();
users.Add(new Account("test", "a@a", "test"));


bool running = true;
while (running)
{
  Console.WriteLine("add- Register new account\nlogin - Login on a new account\nquit - closes the program");
  switch (Console.ReadLine())
  {
    case "add":
      break;
    case "login":
      break;
    case "quit":
      running = false;
      break;
    default:
      Console.WriteLine("You must enter a valid command.");
      break;
  }
}