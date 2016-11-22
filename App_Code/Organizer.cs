using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Organizer
/// </summary>
/// 

//allows object serialization
[Serializable]
public class Organizer : Person
{
    //instance variables
    private string mailrequirement = "@poke.dk";

    //constructor
    public Organizer(string alias, string name, int age, string gender, string email, string password) : base(alias, name, age, gender, email, password)
    {
    }

    //change mail method that checks mail
    public override bool ChangeEmail(string email)
    {
        if (email.EndsWith(this.mailrequirement))
        {
            this.email = email;
            return true;
        }
        else
        {
            return false;
        }
    }

    //tostring method
    public override string ToString()
    {
        return base.ToString();
    }
}