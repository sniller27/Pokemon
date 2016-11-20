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
    
    //buttons
    public void DeleteRowButton_Click(Object sender, EventArgs e)
    {
        // Programmatically delete the selected record.
       // CustomersGridView.DeleteRow(CustomersGridView.SelectedIndex);
    }

    //gridviews
    public void CustomersGridView_RowDeleting(Object sender, GridViewDeleteEventArgs e)
    {
        CustomersGridView.DeleteRow(CustomersGridView.SelectedIndex);
        CustomersGridView.DataBind();
    }

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
                LabelReadOrganizersInfo.Text = "No data at the moment1";
            }
            else
            {
                GridViewOrganizers.DataSource = organizerlist;
                GridViewOrganizers.DataBind();
            }

        }
        catch (Exception ex)
        {
            LabelReadOrganizersInfo.Text = ex.Message;
        }


        //read pokehunters from file
        try
        {
            pokehunterlist = FileUtility.ReadFile(Server.MapPath("~/App_Data/Pokehunters.ser"));

            Application["Pokehuntercollection"] = pokehunterlist;

            if (pokehunterlist.Count == 0)
            {
                LabelReadPokehuntersInfo.Text = "No data at the moment1";
            }
            else
            {
                GridViewPokehunters.DataSource = pokehunterlist;
                GridViewPokehunters.DataBind();
            }

        }
        catch (Exception ex)
        {
            LabelReadPokehuntersInfo.Text = ex.Message;
        }

        //EXPERIMENT
        CustomersGridView.DataSource = pokehunterlist;
        CustomersGridView.DataBind();
    
    }

    //SELECT ROW ORGANIZER METHOD
    protected void GridViewOrganizers_SelectedIndexChanged(object sender, EventArgs e)
    {
        //clean form
        Formcleaner.ClearForm(participantform);
        LabelUpdateInfoFor.Text = "";
        LabelUpdateInfoAlias.Text = "";
        LabelUpdateShowType.Text = "";

        //disable favorite pokemon textbox
        TextBoxUpdateFavorite.Enabled = false;

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
        TextBoxUpdateFavorite.Enabled = true;

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
        if (LabelUpdateShowType.Text.Contains("Organizer")) {
            //update organiser
            UpdateOrganizer();
        }
        else if(LabelUpdateShowType.Text.Contains("Pokehunter"))
        {
            //updatepokehunter
            UpdatePokehunter();
        }

    }


    protected void OrganizerGridviewDeleteRow(object sender, GridViewDeleteEventArgs e)
    {
        //FOREACH LOOP DELETE METODE
        //foreach (Organizer item in organizerlist)
        //{
        //    //find match in arraylist
        //    if (GridViewOrganizers.SelectedRow.Cells[1].Text == item.alias.ToString())
        //    {
        //        organizerlist.Remove(item);
        //        LabelUpdateFeedback.Text = "Person deleted";
        //        break;
        //    }
        //    else
        //    {
        //        LabelUpdateFeedback.Text = "Person not found";

        //    }
        //}


        //FOR LOOP DELETE METODE

        //for (int i = 0; i < organizerlist.Count; i++)
        //{
        //    //find match in arraylist
        //    if (GridViewOrganizers.SelectedRow.Cells[1].Text == organizerlist[i].ToString())
        //    {
        //        organizerlist.Remove(i);
        //        LabelUpdateFeedback.Text = "Person deleted";
        //        break;
        //    }
        //    else
        //    {
        //        LabelUpdateFeedback.Text = "Person not found";
        //    }
        //}

        //update gridview
        GridViewOrganizers.DataSource = organizerlist;
        GridViewOrganizers.DataBind();
    }

    public void GridViewPokehunters_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        //LabelUpdateFeedback.Text = GridViewPokehunters.SelectedRow.Cells[1].Text;
        //foreach (Pokehunter item in pokehunterlist)
        //{
        //    find match in arraylist
        //    if (GridViewPokehunters.SelectedRow.Cells[1].Text == item.alias.ToString())
        //    {
        //        pokehunterlist.Remove(item);
        //        LabelUpdateFeedback.Text = "Person deleted";
        //        break;
        //    }
        //    else
        //    {
        //        LabelUpdateFeedback.Text = "Person not found";

        //    }
        //}

        //update gridview
        //GridViewPokehunters.DataSource = pokehunterlist;
        //GridViewPokehunters.DataBind();

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
                LabelUpdateFeedback.Text = "Information has been changed";

                break;
            }
            else
            {
                LabelUpdateFeedback.Text = "Person not found";

            }
        }
    }

    //UPDATE POKEHUNTER METHOD
    public void UpdatePokehunter() {
        
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
                LabelUpdateFeedback.Text = "Information has been changed";

                break;
            }
            else
            {
                LabelUpdateFeedback.Text = "Person not found";

            }
        }
        
    }

}