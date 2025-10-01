namespace App;

class Account
{
  public string Name;
  string _password;

  public Account(string name, string password)
  {
    Name = name;
    _password = password;
  }

  public bool TryLogin(string username, string password)
  {
    return username == Name && password == _password;
  }
}