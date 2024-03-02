namespace Back_End.IRepository
{
  public interface IAcount<User> where User : class
  {
      Task<User> Register(User user,string passwd);
      Task<User> Login(User user,string passwd,bool persistent, bool lockOnFail);
      Task Logout();
  }
}

