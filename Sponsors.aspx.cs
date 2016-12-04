using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class Sponsors : System.Web.UI.Page
{
    private string filename = "Sponsors.xml";
    private string filepath = "~/XML/";
    private XDocument xmldoc;

    protected void Page_Load(object sender, EventArgs e)
    {
        UpdateSponsors();   
    }

    public void UpdateSponsors() {

        //load XML-file
        xmldoc = XDocument.Load(@Server.MapPath(filepath) + filename);

        //choose data
        var bindsponsor = xmldoc.Descendants("Sponsor").Select(p => new
        {
            CompanyName = p.Element("CompanyName").Value,
            Website = p.Element("Website").Value,
            LogoUrl = p.Element("LogoUrl").Value,

        }).OrderBy(p => p.CompanyName);

        //bind gridview
        GridView1.DataSource = bindsponsor;
        GridView1.DataBind();
    }

    public void CreateSponsor()
    {
        //new xElement
        XElement sponsor = new XElement("Sponsor",
        new XElement("CompanyName", TextBox1.Text),
        new XElement("Website", TextBox2.Text),
        new XElement("LogoUrl", TextBox3.Text));
        //add xElement
        xmldoc.Root.Add(sponsor);
        //save
        xmldoc.Save(Server.MapPath(filepath) + filename);
    }

    public void DeleteSponsor()
    {
        var sponsor = xmldoc.Descendants("Sponsor");

        //XElement sponsor = new XElement("Organizer",
        //new XElement("CompanyName", TextBox1.Text),
        //new XElement("Website", TextBox2.Text),
        //new XElement("LogoUrl", TextBox3.Text));
        if (sponsor != null)
        {
            //sponsor.Remove();
            xmldoc.Descendants("Sponsor")
            .Where(x => x.Element("CompanyName").Value == TextBox4.Text)
            .Remove();
        }
        else
        {
            Label1.Text = "nope";
        }

        //save
        xmldoc.Save(Server.MapPath(filepath) + filename);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        CreateSponsor();
        UpdateSponsors();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        DeleteSponsor();
        UpdateSponsors();
    }
}