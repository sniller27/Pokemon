using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    private Person person;
    private static ArrayList personlist = new ArrayList();

    protected void Page_Load(object sender, EventArgs e)
    {
         
    }

    protected void ButtonSubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            person = new Person(TextBoxAlias.Text, TextBoxName.Text, RadioButtonListGender.SelectedValue, int.Parse(TextBoxAge.Text), TextBoxEmail.Text, TextBoxPassword.Text);
            personlist.Add(person);
            printinfo.Text = person.ToString();

            showAllPersons();
            ClearForm(form1);

        }
       

    }
    public void showAllPersons() {
        personlistid.Items.Clear();
        kidslistid.Items.Clear();
        adultlistid.Items.Clear();

        //personlistid.Items.Add(person.ToString());

        //Method 1
        //foreach (Person item in personlist)
        //{
        //    personlistid.Items.Add(item.ToString());

        //    if (item.age > person.getAdultcap())
        //    {
        //        kidslistid.Items.Add(item.name);
        //    }
        //    else {
        //        adultlistid.Items.Add(item.name);
        //    }
        //}

        //Method 2
        Person[] sl = personlist.ToArray(typeof(Person)) as Person[];
        for (int i = 0; i < sl.Length; i++)
        {
            personlistid.Items.Add(sl[i].ToString());
            if (sl[i].age < sl[i].getAdultcap())
            {
                kidslistid.Items.Add(sl[i].name);
            }
            else
            {
                adultlistid.Items.Add(sl[i].name);
            }
        }


    }

    public static void ClearForm(Control parent)
    {
        foreach (Control c in parent.Controls)
        {
            if (c.GetType() == typeof(TextBox))
            {
                ((TextBox)(c)).Text = string.Empty;
            }
            if (c.GetType() == typeof(RadioButtonList))
            {
                ((RadioButtonList)(c)).ClearSelection();
            }
        }
    }
}