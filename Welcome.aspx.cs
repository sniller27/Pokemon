using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Welcome : System.Web.UI.Page
{
    //declare arraylists
    private ArrayList organizerlist;
    private ArrayList pokehunterlist;
    private ArrayList personlist;

    protected void Page_Load(object sender, EventArgs e)
    {
        //initialize (setting object reference to an instance of an object)
        personlist = new ArrayList();

        //cannot go to this page if logged in
        if (Session["Organizer"] != null)
        {
            if (!IsPostBack)
            {
                Response.Redirect("readorganizers.aspx");
            }
        }
        else if (Session["Pokehunter"] != null)
        {
            if (!IsPostBack)
            {
                Response.Redirect("readpokehunters.aspx");
            }
        }
        
    }

    protected void ButtonLogin_Click(object sender, EventArgs e)
    {
        //en samlet liste (deserialization + polymorphism?)
        try
        {
            //deserialize objects from binary file
            organizerlist = FileUtility.ReadFile(Server.MapPath("~/App_Data/Organizers.ser"));
            pokehunterlist = FileUtility.ReadFile(Server.MapPath("~/App_Data/Pokehunters.ser"));

            if (organizerlist.Count == 0 || pokehunterlist.Count == 0)
            {
                LabelNegativeFeedback.Text = "Not all objects found";
            }
            else
            {
                //merge arraylists to Person arraylist
                //add organizers to personlist
                foreach (Person p in organizerlist)
                {
                    personlist.Add(p);
                }

                //add organizers to personlist
                foreach (Person p in pokehunterlist)
                {
                    personlist.Add(p);
                }

                //save Person list in "session"
                Application["Personcollection"] = personlist;
                
            }

        }
        catch (Exception ex)
        {
            //not necessarily file problem
            LabelNegativeFeedback.Text = ex.Message;
        }

        //search list for username (and corresponding password)
        foreach (Person p in personlist)
        {
            string alias = TextBoxAlias.Text;
            string password = TextBoxPassword.Text;

            if (p.alias == alias && p.password == password)
            {
                if (typeof(Organizer) == p.GetType())
                {
                    Session["Organizer"] = p.alias;
                    Response.Redirect("readorganizers.aspx");
                }
                else if (typeof(Pokehunter) == p.GetType())
                {
                    Session["Pokehunter"] = p.alias;
                    Response.Redirect("readpokehunters.aspx");
                }

                break;
            }

        }

        LabelNegativeFeedback.Text = "Wrong username and password";

    }

    public static bool HasProperty(object obj, string propertyName)
    {
        return obj.GetType().GetProperty(propertyName) != null;
    }
}