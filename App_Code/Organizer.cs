using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Organizer
/// </summary>
/// 

//code snippet som bruger class information til at restore class
[Serializable]
public class Organizer : Person
{
    public Organizer(string alias, string name, int age, string gender, string email, string password) : base(alias, name, age, gender, email, password)
    {
    }

    public override bool ChangeEmail(string email)
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        return base.ToString();
    }
}