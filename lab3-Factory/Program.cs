using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

public abstract class ClientHandler
{
    public ClientFactory ClientFactory { get; set; }

    public abstract void CreateClient();
}

public class RetailClientHandler : ClientHandler
{ 

}

public class EnterpriseClientHandler : ClientHandler
{

}



public class ClientFactory
{
    public void CreateClient(string clientType, string userName)
    {
        Client newClient = new User(userName);

        newClient.BuilAuthString(userName);

        return newClient;
    }
}

public interface Client
{
    public string UserName { get; set; }
    public string UserAuthString { get; set; }
    public bool HasAccess { get; set; }
    public void BuildAuthString(string UserName);
}

public class User : Client
{
    public string UserName { get; set; }
    public string UserAuthString { get; set; }
    public bool HasAccess { get; set; }

    public User(string name)
    {
        UserName = name;
        HasAccess = false;
    }

    public void BuildAuthString(string UserName)
    {
        UserAuthString = UserName;
    }

}

public class Manager : Client
{
    public string UserName { get; set; }
    public string UserAuthString { get; set; }
    public bool HasAccess { get; set; }
    public Manager(string name)
    {
        UserName = name;
        HasAccess = true;
    }
    public void BuildAuthString(string UserName)
    {
        UserAuthString = UserName + "MAN";
    }
}

public class Admin : Client
{
    public string UserName { get; set; }
    public string UserAuthString { get; set; }
    public bool HasAccess { get; set; }
    public Admin(string name)
    {
        UserName = name;
        HasAccess = true;
    }
    public void BuildAuthString(string UserName)
    {
        UserAuthString = UserName + "ADMIN";
    }
}

public interface AccessBehaviour
{
    public Client Client { get; set; }

    public bool HandleAccess(Client client);
}

public class CheckString : AccessBehaviour
{
    public Client Client { get; set; }


    public bool HandleAccess(Client client)
    {
        if (client.UserAuthString)
        {
            return true;
        }
    }

}

public class SwitchAuth : AccessBehaviour
{
    public Client Client { get; set; }
    public bool HandleAccess(Client client)
    {
        if (client.HasAccess)
        {
            client.HasAccess = false;
        } else if (!client.HasAccess)
        {
            client.HasAccess = true;
        }

        return client.HasAccess;
    }
}