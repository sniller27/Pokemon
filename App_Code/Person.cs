using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Person
/// This class is responsible for handling Persons
/// </summary>
public class Person
{
    //declaring private fields/attributes with (automated implemented) properties for getters/setters
    public String alias { get; set; }
    public String name { get; set; }
    public String gender { get; set; }
    public String email { get; set; }
    public String password { get; set; }
    public int age { get; set; }
    public int adultcap = 18;

    //constructor defines the structure of an object and is being called everytime a specific object is created.
    public Person(String alias, String name, String gender, int age, String email, String password)
    {
        this.alias = alias;
        this.name = name;
        this.gender = gender;
        this.age = age;
        this.email = email;
        this.password = password;
    }

    //overriding ToString Method
    public override string ToString()
    {
        return alias + name + gender + age + email + password;
    }

    public void setAdultcap(int adultcap) {
        this.adultcap = adultcap;
    }
    public int getAdultcap() {
        return adultcap;
    }
}