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
        //initialize arraylists
        organizerlist = new ArrayList();
        pokehunterlist = new ArrayList();

        //session checks
        SessionCheck(organizerlist, "Organizercollection");
        SessionCheck(pokehunterlist, "Pokehuntercollection");

        //clear labels on pageload (submit)
        LabelAddOrganizerFeedbackPositive.Text = "";
        LabelAddOrganizerFeedbackNegative.Text = "";
    }

    protected void ButtonCreateOrganizer_Click(object sender, EventArgs e)
    {
        //form validation
        if (Page.IsValid)
        {
            if (DropdownlistCreateParticipant.Text == "Organizer")
            {
                CreateNewOrganizer();
            }else if (DropdownlistCreateParticipant.Text == "Pokehunter")
            {
                CreateNewPokehunter();
            }
        }
    }

    protected void Unnamed1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //selected dropdown option
        if (DropdownlistCreateParticipant.Text == "Pokehunter")
        {
            TextBoxFavorite.Enabled = true;
            RequiredFieldValidatorCreateFavorite.Enabled = true;
        }
        else if (DropdownlistCreateParticipant.Text == "Organizer")
        {
            TextBoxFavorite.Text = "";
            TextBoxFavorite.Enabled = false;
            RequiredFieldValidatorCreateFavorite.Enabled = false;
        }
    }

    public void SessionCheck(ArrayList list, string sessionname)
    {
        if (Application[sessionname] == null)
        {
            //if not. then new arraylist
            list = new ArrayList();
            //declare or assign "session"/global arraylist
            Application[sessionname] = list;
        }
        list = (ArrayList)Application[sessionname];
    }

    public void AddPersonToFile(ArrayList list, string session, string filepath, Person pers) {
        //I'm not quite sure why this method works
        list = (ArrayList)Application[session];
        ////add to list
        list.Add(pers);
        list = (ArrayList)Application[session];

        //saves to file
        FileUtility.WriteFile(list, Server.MapPath(filepath));
        LabelAddOrganizerFeedbackPositive.Text = "You have been signed up";

        //clearform
        Formcleaner.ClearForm(createorganizerform);
    }

    public void CreateNewOrganizer() {
        //updates list again?
        organizerlist = (ArrayList)Application["Organizercollection"];

        //if list is empty
        if (organizerlist.Count == 0)
        {
            //make instance of pokehunter object in order to check (and change) email
            organizer = new Organizer(TextBoxAlias.Text, TextBoxName.Text, Convert.ToInt32(TextBoxAge.Text), RadioButtonListOrganizerGender.Text, TextBoxEmail.Text, TextBoxPassword.Text);

            //checks if emails has extension @poke.dk
            if (organizer.ChangeEmail(TextBoxEmail.Text))
            {
                AddPersonToFile(organizerlist, "Organizercollection", "~/App_Data/Organizers.ser", organizer);
            }
            else
            {
                LabelAddOrganizerFeedbackNegative.Text = "An organizers mail must end with @poke.dk";
                TextBoxFavorite.Enabled = false;
            }
        }
        else
        {
            //checks if alias already exists
            foreach (Organizer item in organizerlist)
            {
                if (item.alias == TextBoxAlias.Text)
                {
                    LabelAddOrganizerFeedbackNegative.Text = "Alias already exists";
                    break;
                }
                else if (item == organizerlist[organizerlist.Count - 1])
                {
                    ////make instance of pokehunter object in order to check (and change) email
                    organizer = new Organizer(TextBoxAlias.Text, TextBoxName.Text, Convert.ToInt32(TextBoxAge.Text), RadioButtonListOrganizerGender.Text, TextBoxEmail.Text, TextBoxPassword.Text);

                    //checks if emails has extension @poke.dk
                    if (organizer.ChangeEmail(TextBoxEmail.Text))
                    {
                        AddPersonToFile(organizerlist, "Organizercollection", "~/App_Data/Organizers.ser", organizer);
                    }
                    else
                    {
                        LabelAddOrganizerFeedbackNegative.Text = "An organizers mail must end with @poke.dk";
                        TextBoxFavorite.Enabled = false;
                    }
                    break;
                }
            }
        }
    }

    public void CreateNewPokehunter() {
        //updates list again?
        pokehunterlist = (ArrayList)Application["Pokehuntercollection"];

        if (pokehunterlist.Count == 0)
        {
            //make instance of pokehunter object
            pokehunter = new Pokehunter(TextBoxAlias.Text, TextBoxName.Text, Convert.ToInt32(TextBoxAge.Text), RadioButtonListOrganizerGender.Text, TextBoxEmail.Text, TextBoxPassword.Text, TextBoxFavorite.Text);

            //checks mail by using instance of object
            if (pokehunter.ChangeEmail(TextBoxEmail.Text))
            {
                AddPersonToFile(pokehunterlist, "Pokehuntercollection", "~/App_Data/Pokehunters.ser", pokehunter);

                //resetform
                DropdownlistCreateParticipant.SelectedValue = "Organizer";
                RequiredFieldValidatorCreateFavorite.Enabled = false;
                TextBoxFavorite.Enabled = false;
            }
            else
            {
                TextBoxFavorite.Enabled = true;
            }
        }
        else
        {
            //checks if alias already exists
            foreach (Pokehunter item in pokehunterlist)
            {
                if (item.alias == TextBoxAlias.Text)
                {
                    LabelAddOrganizerFeedbackNegative.Text = "Alias already exists";
                    break;
                }
                else if (item == pokehunterlist[pokehunterlist.Count - 1])
                {
                    //make instance of pokehunter object
                    pokehunter = new Pokehunter(TextBoxAlias.Text, TextBoxName.Text, Convert.ToInt32(TextBoxAge.Text), RadioButtonListOrganizerGender.Text, TextBoxEmail.Text, TextBoxPassword.Text, TextBoxFavorite.Text);

                    //checks mail by using instance of object
                    if (pokehunter.ChangeEmail(TextBoxEmail.Text))
                    {
                        AddPersonToFile(pokehunterlist, "Pokehuntercollection", "~/App_Data/Pokehunters.ser", pokehunter);

                        //resetform
                        DropdownlistCreateParticipant.SelectedValue = "Organizer";
                        RequiredFieldValidatorCreateFavorite.Enabled = false;
                        TextBoxFavorite.Enabled = false;
                        break;
                    }
                    else
                    {
                        TextBoxFavorite.Enabled = true;
                        break;
                    }
                }
            }
        }
    }
}