public abstract class Client
{
    public string Name { get; set; }
    public string Email { get; set; }
    public int? Age { get; set; }
    public bool AccessDisabled { get; set; }
    public AccessHandler AccessHandler { get; set; } // why???????

    public Client(string name, string email, int? age, bool accessDisabled)
    {
        Name = name;
        Email = email;
        Age = age;
        AccessDisabled = accessDisabled;
    }

    public virtual void HandleAccess()
    {
        AccessHandler.getAccess();    // why need: public AccessHandler AccessHandler { get; set; }
    }

}


public class User : Client
{
    public int Reputation { get; set; }
    public User(string name, string email, int? age, bool accessDisabled) : base(name, email, age, accessDisabled)
    {
        AccessHandler = new HasReputation();
    }

    public override void HandleAccess()
    {
        AccessHandler.getAccess(Reputation);
    }

}

public class Manager : Client
{
    public Manager(string name, string email, int? age, bool accessDisabled) : base(name, email, age, accessDisabled)
    {
        AccessHandler = new HasAccessAutomatic();
    }
}

public class Admin : Client
{
    public Admin(string name, string email, int? age, bool accessDisabled):base(name, email, age, accessDisabled)
    {
        AccessHandler = new HasAccessAutomatic();
    }
}

public interface AccessHandler
{
    public bool getAccess(int? Reputation = 0, bool accessDisabled = false);
}

public class HasReputation : AccessHandler
{
    public bool getAccess(int? Reputation = 0, bool accessDisabled = false)
    {
        if( Reputation > 20)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

public class HasAccessAutomatic : AccessHandler
{
    public bool getAccess(int? Reputation = 0, bool accessDisabled = false)
    {
        if (accessDisabled == false)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}





