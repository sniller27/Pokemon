using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Pokehunter
/// </summary>
public class Pokehunter : Person
{
    public string FavoritePokemon { get; set; }
    public Pokehunter(string alias, string name, int age, string gender, string email, string password, string FavoritePokemon) : base(alias, name, age, gender, email, password)
    {
        this.FavoritePokemon = FavoritePokemon;
    }

    public override void ChangeEmail(string email)
    {
        throw new NotImplementedException();
    }
}