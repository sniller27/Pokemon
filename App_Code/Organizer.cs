using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Organizer
/// </summary>
public class Organizer : Person
{
    public Organizer(string alias, string name, string gender, int age, string email, string password) : base(alias, name, gender, age, email, password)
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public override void ChangeEmail(string email)
    {
        this.email = email;
    }

    public override string ToString()
    {
        return base.ToString();
    }
}