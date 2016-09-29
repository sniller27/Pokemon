using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    Person person;
    static ArrayList personlist = new ArrayList();
    static ArrayList kidslist = new ArrayList();
    static ArrayList adultlist = new ArrayList();

    protected void Page_Load(object sender, EventArgs e)
    {
         
    }

    protected void ButtonSubmit_Click(object sender, EventArgs e)
    {
        person = new Person(TextBoxAlias.Text, TextBoxName.Text, RadioButtonListGender.SelectedValue, int.Parse(TextBoxAge.Text), TextBoxEmail.Text, TextBoxPassword.Text);
        personlist.Add(person);
        printinfo.Text = person.ToString();

        //making kids- and adult lists.. just in case
        if (person.age < person.getAdultcap())
        {
            kidslist.Add(person);
        }
        else {
            adultlist.Add(person);
        }
        showAllPersons();

    }
    public void showAllPersons() {
        personlistid.Items.Clear();
        kidslistid.Items.Clear();
        adultlistid.Items.Clear();
        
        foreach (Person item in personlist)
        {
            personlistid.Items.Add(item.ToString());

            if (item.age > person.getAdultcap())
            {
                kidslistid.Items.Add(item.name);
            }
            else {
                adultlistid.Items.Add(item.name);
            }
        }
      
    }
}