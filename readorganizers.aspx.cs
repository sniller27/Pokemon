using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class readorganizers : System.Web.UI.Page
{
    //declare arraylists
    private ArrayList organizerlist;
    private ArrayList pokehunterlist;
    private Pokehunter pokehunter;


    //PAGE LOAD METHOD
    protected void Page_Load(object sender, EventArgs e)
    {
        //read organizers from file
        try
        {
            organizerlist = FileUtility.ReadFile(Server.MapPath("~/App_Data/Organizers.ser"));

            Application["Organizercollection"] = organizerlist;

            if (organizerlist.Count == 0)
            {
                LabelReadOrganizersInfo.Text = "No data available at the moment";
            }
            else
            {
                GridViewOrganizers.DataSource = organizerlist;
                GridViewOrganizers.DataBind();
            }

        }
        catch (Exception)
        {
            LabelReadOrganizersInfo.Text = "File not created";
        }


        //read pokehunters from file
        try
        {
            pokehunterlist = FileUtility.ReadFile(Server.MapPath("~/App_Data/Pokehunters.ser"));

            Application["Pokehuntercollection"] = pokehunterlist;

            if (pokehunterlist.Count == 0)
            {
                LabelReadPokehuntersInfo.Text = "No data available at the moment";
            }
            else
            {
                GridViewPokehunters.DataSource = pokehunterlist;
                GridViewPokehunters.DataBind();
            }

        }
        catch (Exception)
        {
            LabelReadPokehuntersInfo.Text = "File not created";
        }

        //reset label
        LabelUpdateFeedbackNegative.Text = "";
        LabelUpdateFeedbackPositive.Text = "";
    }

    //SELECT ROW ORGANIZER METHOD
    protected void GridViewOrganizers_SelectedIndexChanged(object sender, EventArgs e)
    {
        //clean form
        Formcleaner.ClearForm(participantform);
        LabelUpdateInfoFor.Text = "";
        LabelUpdateInfoAlias.Text = "";
        LabelUpdateShowType.Text = "";

        //disable and disable fields
        TextBoxUpdateAlias.Enabled = true;
        TextBoxUpdateName.Enabled = true;
        TextBoxUpdateAge.Enabled = true;
        RadioButtonListUpdate.Enabled = true;
        TextBoxUpdateEmail.Enabled = true;
        TextBoxUpdatePassword.Enabled = true;
        TextBoxUpdateFavorite.Enabled = true;
        ButtonUpdate.Enabled = true;
        TextBoxUpdateFavorite.Enabled = false;

        //deactivate validation label for favoritepokemon
        RequiredFieldValidatorUpdateFavorite.Enabled = false;

        //can be done in a smarter way?
        TextBoxUpdateAlias.Text = GridViewOrganizers.SelectedRow.Cells[1].Text;
        TextBoxUpdateName.Text = GridViewOrganizers.SelectedRow.Cells[2].Text;
        TextBoxUpdateAge.Text = GridViewOrganizers.SelectedRow.Cells[3].Text;
        RadioButtonListUpdate.SelectedValue = GridViewOrganizers.SelectedRow.Cells[4].Text;
        TextBoxUpdateEmail.Text = GridViewOrganizers.SelectedRow.Cells[5].Text;
        TextBoxUpdatePassword.Text = GridViewOrganizers.SelectedRow.Cells[6].Text;

        LabelUpdateInfoFor.Text = "Information about: ";
        LabelUpdateInfoAlias.Text = GridViewOrganizers.SelectedRow.Cells[1].Text;
        LabelUpdateShowType.Text = "(Organizer)";
    }

    //SELECT ROW POKEHUNTERS METHOD
    protected void GridViewPokehunters_SelectedIndexChanged(object sender, EventArgs e)
    {
        //clean form
        Formcleaner.ClearForm(participantform);
        LabelUpdateInfoFor.Text = "";
        LabelUpdateInfoAlias.Text = "";
        LabelUpdateShowType.Text = "";

        //enable favorite pokemon textbox
        TextBoxUpdateAlias.Enabled = true;
        TextBoxUpdateName.Enabled = true;
        TextBoxUpdateAge.Enabled = true;
        RadioButtonListUpdate.Enabled = true;
        TextBoxUpdateEmail.Enabled = true;
        TextBoxUpdatePassword.Enabled = true;
        TextBoxUpdateFavorite.Enabled = true;
        ButtonUpdate.Enabled = true;

        //activate validation label for favoritepokemon
        RequiredFieldValidatorUpdateFavorite.Enabled = true;

        //can be done in a smarter way?
        TextBoxUpdateAlias.Text = GridViewPokehunters.SelectedRow.Cells[1].Text;
        TextBoxUpdateName.Text = GridViewPokehunters.SelectedRow.Cells[2].Text;
        TextBoxUpdateAge.Text = GridViewPokehunters.SelectedRow.Cells[3].Text;
        RadioButtonListUpdate.SelectedValue = GridViewPokehunters.SelectedRow.Cells[4].Text;
        TextBoxUpdateEmail.Text = GridViewPokehunters.SelectedRow.Cells[5].Text;
        TextBoxUpdatePassword.Text = GridViewPokehunters.SelectedRow.Cells[6].Text;
        TextBoxUpdateFavorite.Text = GridViewPokehunters.SelectedRow.Cells[7].Text;

        LabelUpdateInfoFor.Text = "Information about: ";
        LabelUpdateInfoAlias.Text = GridViewPokehunters.SelectedRow.Cells[1].Text;
        LabelUpdateShowType.Text = "(Pokehunter)";

    }

    //UPDATE BUTTON METHOD
    protected void ButtonUpdate_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            if (LabelUpdateShowType.Text.Contains("Organizer"))
            {
                //update organiser
                UpdateOrganizer();
            }
            else if (LabelUpdateShowType.Text.Contains("Pokehunter"))
            {
                //updatepokehunter
                UpdatePokehunter();
            }
        }
    }

    //UPDATE ORGANIZER METHOD
    public void UpdateOrganizer()
    {
        foreach (Organizer item in organizerlist)
        {
            //find match in arraylist
            if (LabelUpdateInfoAlias.Text == item.alias.ToString())
            {
                item.alias = TextBoxUpdateAlias.Text;
                item.name = TextBoxUpdateName.Text;
                item.age = Convert.ToInt32(TextBoxUpdateAge.Text);
                item.gender = RadioButtonListUpdate.SelectedValue;
                item.email = TextBoxUpdateEmail.Text;
                item.password = TextBoxUpdatePassword.Text;

                //write to file
                FileUtility.WriteFile(organizerlist, Server.MapPath("~/App_Data/Organizers.ser"));

                //populate gridview
                GridViewOrganizers.DataSource = organizerlist;
                GridViewOrganizers.DataBind();

                //clear form
                Formcleaner.ClearForm(participantform);
                LabelUpdateInfoFor.Text = "";
                LabelUpdateInfoAlias.Text = "";
                LabelUpdateShowType.Text = "";

                //feedback message
                LabelUpdateFeedbackPositive.Text = "Information has been changed";

                DisableUpdateForm();

                break;
            }
            else if(item == organizerlist[organizerlist.Count - 1])
            {
                LabelUpdateFeedbackNegative.Text = "Person not found";

            }
        }
    }
    
    //UPDATE POKEHUNTER METHOD
    public void UpdatePokehunter() {
        //create object
        pokehunter = new Pokehunter(TextBoxUpdateAlias.Text, TextBoxUpdateName.Text, Convert.ToInt32(TextBoxUpdateAge.Text), RadioButtonListUpdate.SelectedValue, TextBoxUpdateEmail.Text, TextBoxUpdatePassword.Text, TextBoxUpdateFavorite.Text);

        //checks valid email
        if (pokehunter.ChangeEmail(TextBoxUpdateEmail.Text))
        {
            //going through list
            foreach (Pokehunter item in pokehunterlist)
            {
                //find match in arraylist
                if (LabelUpdateInfoAlias.Text == item.alias.ToString())
                {
                    item.alias = TextBoxUpdateAlias.Text;
                    item.name = TextBoxUpdateName.Text;
                    item.age = Convert.ToInt32(TextBoxUpdateAge.Text);
                    item.gender = RadioButtonListUpdate.SelectedValue;
                    item.email = TextBoxUpdateEmail.Text;
                    item.password = TextBoxUpdatePassword.Text;
                    item.FavoritePokemon = TextBoxUpdateFavorite.Text;

                    //write to file
                    FileUtility.WriteFile(pokehunterlist, Server.MapPath("~/App_Data/Pokehunters.ser"));

                    //populate gridview
                    GridViewPokehunters.DataSource = pokehunterlist;
                    GridViewPokehunters.DataBind();

                    //clear form
                    Formcleaner.ClearForm(participantform);
                    LabelUpdateInfoFor.Text = "";
                    LabelUpdateInfoAlias.Text = "";
                    LabelUpdateShowType.Text = "";

                    //feedback message
                    LabelUpdateFeedbackPositive.Text = "Information has been changed";

                    DisableUpdateForm();

                    break;
                }
                else if(item == pokehunterlist[pokehunterlist.Count-1])
                {
                    //if no of the elements in the list is found
                    LabelUpdateFeedbackNegative.Text = "Person not found";

                }
            }
        }
        else
        {
            LabelUpdateFeedbackNegative.Text = "A pokehunters mail must end with @poke.dk";
        }
   
    }

    //DELETE FROM ORGANIZER
    public void GridViewOrganizers_RowDeleting(Object sender, GridViewDeleteEventArgs e)
    {
        //int index = GridViewOrganizers.SelectedIndex;   //this one not workin properly. needs a selected field already

        //get alias (unique)
        string organizernamerow = GridViewOrganizers.DataKeys[e.RowIndex].Value.ToString();
        
        //searching for alias
        foreach (Organizer item in organizerlist)
        {
            //find match in arraylist
            if (organizernamerow == item.alias.ToString())
            {
                organizerlist.Remove(item);
                LabelUpdateFeedbackPositive.Text = "Person deleted";
                break;
            }
            else if(item == organizerlist[organizerlist.Count - 1])
            {
                LabelUpdateFeedbackNegative.Text = "Person not found";

            }
        }

        //write to file
        FileUtility.WriteFile(organizerlist, Server.MapPath("~/App_Data/Organizers.ser"));

        //update gridview
        GridViewOrganizers.DataSource = organizerlist;
        GridViewOrganizers.DataBind();
    }

    //DELETE FROM POKEHUNTERS
    public void GridViewPokehunters_RowDeleting(Object sender, GridViewDeleteEventArgs e)
    {
        //int index = GridViewPokehunters.SelectedIndex;   //this one not workin properly. needs a selected field already

        //get alias (unique)
        string pokehunternamerow = GridViewPokehunters.DataKeys[e.RowIndex].Value.ToString();
        
        //searching for alias
        foreach (Pokehunter item in pokehunterlist)
        {
            //find match in arraylist
            if (pokehunternamerow == item.alias.ToString())
            {
                pokehunterlist.Remove(item);
                LabelUpdateFeedbackPositive.Text = "Person deleted";
                break;
            }
            else if(item == pokehunterlist[pokehunterlist.Count - 1])
            {
                LabelUpdateFeedbackNegative.Text = "Person not found";

            }
        }

        //write to file
        FileUtility.WriteFile(pokehunterlist, Server.MapPath("~/App_Data/Pokehunters.ser"));

        //update gridview
        GridViewPokehunters.DataSource = pokehunterlist;
        GridViewPokehunters.DataBind();
    }

    private void DisableUpdateForm()
    {
        TextBoxUpdateAlias.Enabled = false;
        TextBoxUpdateName.Enabled = false;
        TextBoxUpdateAge.Enabled = false;
        RadioButtonListUpdate.Enabled = false;
        TextBoxUpdateEmail.Enabled = false;
        TextBoxUpdatePassword.Enabled = false;
        TextBoxUpdateFavorite.Enabled = false;
        ButtonUpdate.Enabled = false;
    }
}