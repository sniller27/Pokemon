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
        }
       

    }
    public void showAllPersons() {
        personlistid.Items.Clear();

        
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