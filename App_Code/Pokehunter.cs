using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Pokehunter
/// </summary>
/// 
//allows object serialization
[Serializable]
public class Pokehunter : Person
{
    //instance variables and properties
    public string FavoritePokemon { get; set; }

    //cosntructor
    public Pokehunter(string alias, string name, int age, string gender, string email, string password, string FavoritePokemon) : base(alias, name, age, gender, email, password)
    {
        this.FavoritePokemon = FavoritePokemon;
    }

    //change mail
    public override bool ChangeEmail(string email)
    {
        this.email = email;
        return true;
    }

    //toString method
    public override string ToString()
    {
        return base.ToString() + ", FavoritePokemon: " + FavoritePokemon;
    }
}