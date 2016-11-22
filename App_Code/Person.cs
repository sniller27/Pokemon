using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Person
/// This class is responsible for handling Persons
/// </summary>
/// 
//allows object serialization
[Serializable]
public abstract class Person
{
    //declaring private fields/attributes with (automated implemented) properties for getters/setters
    public String alias { get; set; }
    public String name { get; set; }
    public int age { get; set; }
    public String gender { get; set; }
    public String email { get; set; }
    public String password { get; set; }

    //constructor defines the structure of an object and is being called everytime a specific object is created.
    public Person(String alias, String name, int age, String gender, String email, String password)
    {
        this.alias = alias;
        this.name = name;
        this.age = age;
        this.gender = gender;
        this.email = email;
        this.password = password;
    }

    //overriding ToString Method
    public override string ToString()
    {
        return "Alias: " + alias + ", Name: " + name + ", Age: " + age + ", Gender: " + gender + ", Email: " + email + ", Password: " + password;
    }

    //Change email method
    public abstract bool ChangeEmail(String email);
}