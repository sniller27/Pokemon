using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class _Default : System.Web.UI.Page
{
    Organizer organizer;
    static ArrayList personlist = new ArrayList();
    //XML solution... XDocument
    XDocument xmldoc;

    protected void Page_Load(object sender, EventArgs e)
    {
        /** 
         * 
         * TXT FILE
         * 
         * **/
        ////Write to txt file
        //string[] lines = { "Firs1t line", "Secon1d line", "Third2 line" };
        //System.IO.File.WriteAllLines(@"C:\Users\Jonas\Documents\Visual Studio 2015\WebSites\Pokemon\crudfiles\persons.txt", lines);

        ////Read from txt file
        //string persontext0 = System.IO.File.ReadAllText(@"C:\Users\Jonas\Documents\Visual Studio 2015\WebSites\Pokemon\crudfiles\persons.txt");
        //string[] persontext = System.IO.File.ReadAllLines(@"C:\Users\Jonas\Documents\Visual Studio 2015\WebSites\Pokemon\crudfiles\persons.txt");
        //foreach (var person in persontext)
        //{
        //    //Label8.Text += person;
        //    //Label8.Text += ", ";
        //}

        //Gridview
        //GridView1.DataSource = persontext;
        //GridView1.DataBind();

        /**
         * 
         * XML FILE
         * 
         * **/

        //READ ORGANIZER
        xmldoc = XDocument.Load("C:/Users/Jonas/Documents/Visual Studio 2015/WebSites/Pokemon/crudfiles/personsfile.xml");   //add xml document  
        var bind = xmldoc.Descendants("Organizer").Select(p => new
        {
            Id = p.Element("id").Value,
            Alias = p.Element("alias").Value,
            Name = p.Element("name").Value,
            Salary = p.Element("gender").Value,
            Email = p.Element("age").Value,
            Address = p.Element("email").Value,
            Password = p.Element("password").Value
        }).OrderBy(p => p.Id);
        GridView1.DataSource = bind;
        GridView1.DataBind();

        //INSERT (using namespace using System.Xml.Linq)

        //INSERT ORGANIZER
        XElement emp = new XElement("Organizer",
        new XElement("id", "23"),
        new XElement("alias", "orgyss"),
        new XElement("name", "dox"),
        new XElement("gender", "1233d"),
        new XElement("age", "fsdofjos"),
        new XElement("email", "adress"),
        new XElement("password", "12345"));
        xmldoc.Root.Add(emp);
        xmldoc.Save("C:/Users/Jonas/Documents/Visual Studio 2015/WebSites/Pokemon/crudfiles/personsfile.xml");

        //using dataset
        //using (DataSet ds = new DataSet())
        //{
        //    ds.ReadXml(Server.MapPath("~/crudfiles/personsfile.xml"));
        //    GridView1.DataSource = ds;
        //    GridView1.DataBind();
        //}
        
    }

    protected void ButtonSubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            organizer = new Organizer(TextBoxAlias.Text, TextBoxName.Text, RadioButtonListGender.SelectedValue, int.Parse(TextBoxAge.Text), TextBoxEmail.Text, TextBoxPassword.Text);
            personlist.Add(organizer);
            printinfo.Text = organizer.ToString();

            showAllPersons();
        }
       

    }
    public void showAllPersons() {
        personlistid.Items.Clear();
        kidslistid.Items.Clear();
        adultlistid.Items.Clear();

        foreach (Person item in personlist)
        {
            personlistid.Items.Add(item.ToString());

            if (item.age > organizer.getAdultcap())
            {
                kidslistid.Items.Add(item.name);
            }
            else {
                adultlistid.Items.Add(item.name);
            }
        }
      
    }
}