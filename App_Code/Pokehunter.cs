﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Pokehunter
/// </summary>
public class Pokehunter : Person
{
    String favoritepokemon;
    public Pokehunter(string alias, string name, string gender, int age, string email, string password, String favoritepokemon) : base(alias, name, gender, age, email, password)
    {
        this.favoritepokemon = favoritepokemon;
    }

    public override void ChangeEmail(string email)
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        return base.ToString();
    }
}