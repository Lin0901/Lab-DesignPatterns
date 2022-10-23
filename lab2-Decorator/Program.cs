
using System.Reflection.Emit;

public abstract class Client
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public Client(string userName, string email)
    {
        UserName = userName;
        Email = email;
    }

    //这是 Decorator 的关键
    protected string description { get; set; }
    public virtual string GetDescription()
    {
        return description;
    }

    protected string badeges { get; set; }
    public virtual string GetBadeges()
    {
        return badeges;
    }
}

public class User : Client
{
    public User(string userName, string email) : base(userName, email)
    {
        description = "Base - level User";
    }
}

public abstract class BadgeDecorator : Client
{
    protected BadgeDecorator(string userName, string email) : base(userName, email)
    {
    }

    public Client Client { get; set; }
    public abstract override string GetBadeges();

}
