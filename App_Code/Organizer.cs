using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Organizer
/// </summary>
public class Organizer : Person
{
    public Organizer()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public override string ChangeEmail(string email)
    {
        return this.email = email;
    }
}