using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CreateOrganizer : System.Web.UI.Page
{
    //instance variables
    private Organizer organizer;
    private Pokehunter pokehunter;
    private ArrayList organizerlist;
    private ArrayList pokehunterlist;

    protected void Page_Load(object sender, EventArgs e)
    {
        organizerlist = new ArrayList();
        pokehunterlist = new ArrayList();

        //check if "session"/global arraylist exists (Organizer)
        if (Application["Organizercollection"] == null)
        {
            //if not. then new arraylist
            organizerlist = new ArrayList();
            //declare or assign "session"/global arraylist
            Application["Organizercollection"] = organizerlist;
        }
        //check if "session"/global arraylist exists (Pokehunter)
        if (Application["Pokehuntercollection"] == null)
        {
            //if not. then new arraylist
            pokehunterlist = new ArrayList();
            //declare or assign "session"/global arraylist
            Application["Pokehuntercollection"] = pokehunterlist;
        }

        ////hvorfor gør vi dette?
        //organizerlist = (ArrayList)Application["Organizercollection"];

        //disable pokehunter textfield
        TextBoxFavorite.Enabled = false;
    }

    protected void ButtonCreateOrganizer_Click(object sender, EventArgs e)
    {
        //checks if you are an Organizer
        if (DropdownlistCreateParticipant.Text == "Organizer")
        {
            //make instance of Organizer object
            organizer = new Organizer(TextBoxAlias.Text, TextBoxName.Text, Convert.ToInt32(TextBoxAge.Text), RadioButtonListOrganizerGender.Text, TextBoxEmail.Text, TextBoxPassword.Text);
            //getting the arraylist before inserting
            organizerlist = (ArrayList)Application["Organizercollection"];
            //add to list
            organizerlist.Add(organizer);

            organizerlist = (ArrayList)Application["Organizercollection"];

            //saves to file
            FileUtility.WriteFile(organizerlist, Server.MapPath("~/App_Data/Organizers.ser"));
            LabelAddOrganizerFeedback.Text = "You have been signed up";

            //clearform
            Formcleaner.ClearForm(createorganizerform);
        }

        //checks if you are a Pokehunter
        if (DropdownlistCreateParticipant.Text == "Pokehunter")
        {
            //make instance of pokehunter object
            pokehunter = new Pokehunter(TextBoxAlias.Text, TextBoxName.Text, Convert.ToInt32(TextBoxAge.Text), RadioButtonListOrganizerGender.Text, TextBoxEmail.Text, TextBoxPassword.Text, TextBoxFavorite.Text);

            //checks mail by using instance of object
            if (pokehunter.ChangeEmail(TextBoxEmail.Text))
            {
                //getting the arraylist before inserting
                pokehunterlist = (ArrayList)Application["Pokehuntercollection"];
                //add to list
                pokehunterlist.Add(pokehunter);

                pokehunterlist = (ArrayList)Application["Pokehuntercollection"];

                //saves to file
                FileUtility.WriteFile(pokehunterlist, Server.MapPath("~/App_Data/Pokehunters.ser"));

                LabelAddOrganizerFeedback.Text = "You have been signed up";

                //resetform
                DropdownlistCreateParticipant.SelectedValue = "Organizer";

                //clearform
                Formcleaner.ClearForm(createorganizerform);
            }
            else
            {
                LabelAddOrganizerFeedback.Text = "A pokehunters mail must end with @poke.dk";
                TextBoxFavorite.Enabled = true;
            }
        }
    }

    protected void Unnamed1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropdownlistCreateParticipant.Text == "Pokehunter")
        {
            TextBoxFavorite.Enabled = true;
        }
        else
        {
            TextBoxFavorite.Text = "";
            TextBoxFavorite.Enabled = false;
        }
    }
}