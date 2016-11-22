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

    protected void Page_Load(object sender, EventArgs e)
    {
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
                //not necessarily file problem
                LabelReadOrganizersInfo.Text = "File not created";
            }

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
                //not necessarily file problem
                LabelReadPokehuntersInfo.Text = "File not created";
            }

        //clear labels on pageload
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
        //check if alias is taken
        foreach (Organizer item in organizerlist)
        {
            if (item.alias == TextBoxUpdateAlias.Text && !item.alias.Contains(LabelUpdateInfoAlias.Text))
            {
                LabelUpdateFeedbackNegative.Text = "Alias is already taken";
                break;
            }
            else if (item == organizerlist[organizerlist.Count - 1])
            {
                foreach (Organizer searchorganizer in organizerlist)
                {
                    //find match in arraylist
                    if (LabelUpdateInfoAlias.Text == searchorganizer.alias.ToString())
                    {
                        if (searchorganizer.ChangeEmail(TextBoxUpdateEmail.Text))
                        {
                            searchorganizer.alias = TextBoxUpdateAlias.Text;
                            searchorganizer.name = TextBoxUpdateName.Text;
                            searchorganizer.age = Convert.ToInt32(TextBoxUpdateAge.Text);
                            searchorganizer.gender = RadioButtonListUpdate.SelectedValue;
                            searchorganizer.email = TextBoxUpdateEmail.Text;
                            searchorganizer.password = TextBoxUpdatePassword.Text;

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
                        }
                        else
                        {
                            LabelUpdateFeedbackNegative.Text = "An organizers mail must end with @poke.dk";
                        }
                        break;
                    }
                    else if (searchorganizer == organizerlist[organizerlist.Count - 1])
                    {
                        LabelUpdateFeedbackNegative.Text = "Person not found";
                    }
                }
                break;
            }
        }
    }
    
    //UPDATE POKEHUNTER METHOD
    public void UpdatePokehunter() {
        //check if alias is taken
        foreach (Pokehunter item in pokehunterlist)
        {
            if (item.alias == TextBoxUpdateAlias.Text && !item.alias.Contains(LabelUpdateInfoAlias.Text))
            {
                LabelUpdateFeedbackNegative.Text = "Alias is already taken";
                break;
            }
            else if (item == pokehunterlist[pokehunterlist.Count - 1])
            {
                //going through list
                foreach (Pokehunter searchpokehunter in pokehunterlist)
                {
                    //find match in arraylist
                    if (LabelUpdateInfoAlias.Text == searchpokehunter.alias.ToString())
                    {
                        if (searchpokehunter.ChangeEmail(TextBoxUpdateEmail.Text))
                        {
                            searchpokehunter.alias = TextBoxUpdateAlias.Text;
                            searchpokehunter.name = TextBoxUpdateName.Text;
                            searchpokehunter.age = Convert.ToInt32(TextBoxUpdateAge.Text);
                            searchpokehunter.gender = RadioButtonListUpdate.SelectedValue;
                            searchpokehunter.email = TextBoxUpdateEmail.Text;
                            searchpokehunter.password = TextBoxUpdatePassword.Text;
                            searchpokehunter.FavoritePokemon = TextBoxUpdateFavorite.Text;

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
                        }
                        break;
                    }
                    else if (searchpokehunter == pokehunterlist[pokehunterlist.Count - 1])
                    {
                        //if no of the elements in the list is found
                        LabelUpdateFeedbackNegative.Text = "Person not found";
                    }
                }
            }
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