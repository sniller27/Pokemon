using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Pokehunter
/// </summary>
public class Pokehunter : Person
{
    public String Favoritepokemon { get; set; }

    public Pokehunter(string alias, string name, string gender, int age, string email, string password, string Favoritepokemon) : base(alias, name, gender, age, email, password)
    {
        //
        // TODO: Add constructor logic here
        //
        this.Favoritepokemon = Favoritepokemon;
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