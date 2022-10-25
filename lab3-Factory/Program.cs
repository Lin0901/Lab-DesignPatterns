using System;
using System.Collections.Generic;

public abstract class User
{
    public string Password { get; set; }
    public void PasswordHash()
    {
       
    }

}

public class AuthorizedUser : User
{
    public string Password { get; set; }
    public AuthorizedUser(string password)
    {
        Password = password;
    }

    public string PasswordHash()
    {
        return Password + "Authorized";
    }
}

public class Administrator : User
{
    public string Password { get; set; }
    public Administrator(string password)
    {
        Password = password;
    }

    public string PasswordHash()
    {
        return Password + "Administrator";
    }
}

public abstract class Factory
{
    public abstract User CreatUser(string password, bool twoFactorAuthentication, bool isAdmin);
}

public class TwoFactorRequired : Factory
{
    public override User CreatUser(string password, bool twoFactorAuthentication, bool isAdmin)
    {

        if (twoFactorAuthentication == true)
        {
            return new AuthorizedUser("You will be AuthorizedUser");
        } 
        
        else if (isAdmin == true)
        {
            return new Administrator("You will be Administrator");
        }
        else
        {
            throw new ArgumentException("Is wrong");
        }
    }
}

public class TwoFactorNotRequired : Factory
{
    public override User CreatUser(string password, bool twoFactorAuthentication, bool isAdmin)
    {

        if (twoFactorAuthentication == true)
        {
            return new AuthorizedUser("You will be AuthorizedUser");
        }

        else if (isAdmin == true)
        {
            return new Administrator("You will be Administrator");
        }
        else
        {
            throw new ArgumentException("Is wrong");
        }
    }
}