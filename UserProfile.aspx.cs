using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserProfile : System.Web.UI.Page
{
    ArrayList personlist, newlist;
    string filename, chooselist;
    bool isorganizer;

    protected void Page_Load(object sender, EventArgs e)
    {
        //redirects you if you don't have access to this page
        if (Session["Organizer"] != null)
        {
            if (!IsPostBack)
            {
            PopulateFormData("Organizer");
            }
        }
        else if (Session["Pokehunter"] != null)
        {
            if (!IsPostBack)
            {
            PopulateFormData("Pokehunter");
            }
        }
        else
        {
            Response.Redirect("Welcome.aspx");
        }

        //assign personlist
        personlist = (ArrayList)Application["Personcollection"];
    }

    public void PopulateFormData(string sessioname)
    {
        try
        {
            //update personlist (necessary?)
            personlist = (ArrayList)Application["Personcollection"];

            foreach (Person p in personlist)
            {
                if (p.alias == Session[sessioname].ToString())
                {
                    TextBoxAlias.Text = p.alias;
                    TextBoxName.Text = p.name;
                    TextBoxAge.Text = p.age.ToString();
                    RadioButtonListGender.SelectedValue = p.gender;
                    TextBoxEmail.Text = p.email;
                    TextBoxPassword.Text = p.password;

                    if (typeof(Pokehunter) == p.GetType())
                    {
                        TextBoxFavorite.Text = ((Pokehunter)p).FavoritePokemon;
                    }
                    else
                    {
                        TextBoxFavorite.Enabled = false;
                    }

                    break;
                }
            }
        }
        catch (Exception ex)
        {
            LabelName.Text = ex.Message;
        }
    }

    protected void ButtonUpdate_Click(object sender, EventArgs e)
    {
            if (Session["Organizer"] != null)
            {
                Update("Organizer");
            }
            else if (Session["Pokehunter"] != null)
            {
                Update("Pokehunter");
            }
    }

    public void Update(string sessioname)
    {
        foreach (Person p in personlist)
        {
            if (p.alias == Session[sessioname].ToString())
            {
                p.alias = TextBoxAlias.Text;
                p.name = TextBoxName.Text;
                p.age = Convert.ToInt32(TextBoxAge.Text);
                p.gender = RadioButtonListGender.SelectedValue;
                p.email = TextBoxEmail.Text;
                p.password = TextBoxPassword.Text;

                if (typeof(Pokehunter) == p.GetType())
                {
                    ((Pokehunter)p).FavoritePokemon = TextBoxFavorite.Text;
                    filename = "~/App_Data/Pokehunters.ser";
                    isorganizer = false;
                }
                else if (typeof(Organizer) == p.GetType())
                {
                    filename = "~/App_Data/Organizers.ser";
                    isorganizer = true;
                }

                break;
            }
        }

        //get Pokemonhunter og Organizer lists (after list iteration)
        chooselist = (isorganizer) ? (chooselist = "organizer") : (chooselist = "pokehunter");
        newlist = GenerateOrganizerlist(personlist, chooselist);


        //write to file
        FileUtility.WriteFile(newlist, Server.MapPath(filename));
        Application["Personcollection"] = personlist;

        //update form data
        PopulateFormData(sessioname);

        LabelPositiveFeedback.Text = "Your information has been updated";
    }

    public ArrayList GenerateOrganizerlist(ArrayList personlist, string chooselist) {

        ArrayList generatelist = new ArrayList();

        if (chooselist == "organizer")
        {
            foreach (Person p in personlist)
            {
                if (typeof(Organizer) == p.GetType())
                {
                    generatelist.Add(p);
                }
            }
        }
        else
        {
            foreach (Person p in personlist)
            {
                if (typeof(Pokehunter) == p.GetType())
                {
                    generatelist.Add(p);
                }
            }
        }

        return generatelist;
    }
}