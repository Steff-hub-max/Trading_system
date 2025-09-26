namespace App;

class Account : Iuser
{
  public string Name;
  public string Email;
  string _password;

  public Account(string name, string email, string password)
  {
    Name = name;
    Email = email;
    _password = password;
  }

  public bool TryLogin(string username, string password)
  {
    return username == Name && password == _password;
  }
}