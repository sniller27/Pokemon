using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
class Money
{
    public int amount { get; set; }
    public string type { get; set; }

    public int X
    {
        get
        {
            return x;
        }

        set
        {
            x = value;
        }
    }

    private int x;
}
public partial class _Default : System.Web.UI.Page
{
    Person person;
    static ArrayList personlist = new ArrayList();
    static ArrayList kidslist = new ArrayList();
    static ArrayList adultlist = new ArrayList();
/**
    List<Money> myMoney = new List<Money> {
        new Money{amount = 10, type="US"},
        new Money{amount = 20, type="US"}};
    **/
    protected void Page_Load(object sender, EventArgs e)
    {
        /**
        foreach (var money in myMoney)
        {
            Console.WriteLine("Amount is {0} and type is {1}", money.amount, money.type);
        }
        **/
    }

    protected void ButtonSubmit_Click(object sender, EventArgs e)
    {
        person = new Person(TextBoxAlias.Text, TextBoxName.Text, RadioButtonListGender.SelectedValue, int.Parse(TextBoxAge.Text), TextBoxEmail.Text, TextBoxPassword.Text);
        personlist.Add(person);
        printinfo.Text = person.ToString();
        if (person.age < 18)
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

            if (item.age > 18)
            {
                kidslistid.Items.Add(item.name);
            }
            else {
                adultlistid.Items.Add(item.name);
            }
        }
      

        /**
        foreach (var item in personlist)
        {
            personlistid.Items.Add(item.ToString());
        }
        foreach (var item in kidslist)
        {
            kidslistid.Items.Add(item.ToString());
        }
        foreach (var item in adultlist)
        {
            adultlistid.Items.Add(item.ToString());
        }
    **/
    }
}