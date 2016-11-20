using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class readorganizers : System.Web.UI.Page
{
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






    protected void Page_Load(object sender, EventArgs e)
    {
        organizerlist = (ArrayList)Application["Organizercollection"];
        pokehunterlist = (ArrayList)Application["Pokehuntercollection"];

        //var columnToMove = GridViewPokehunters.Columns[1];
        //GridViewPokehunters.Columns.RemoveAt(1);
        //GridViewPokehunters.Columns.Insert(0, columnToMove);


        //experiment
        CustomersGridView.DataSource = pokehunterlist;
        CustomersGridView.DataBind();


        try
        {
            if (organizerlist.Count == 0)
            {
                LabelReadOrganizersInfo.Text = "No data at the moment";
            }
            else
            {
                //for (int i = 0; i < organizerlist.Count; i++)
                //{
                //    TextBoxReadOrganizers.Text += organizerlist[i].ToString() + "\n";
                //}
                GridViewOrganizers.DataSource = organizerlist;
                GridViewOrganizers.DataBind();
            }

            //checks if arraylist is empty
            if (pokehunterlist.Count == 0)
            {
                LabelReadPokehuntersInfo.Text = "No data at the moment";
            }
            else
            {
                //for (int i = 0; i < pokehunterlist.Count; i++)
                //{
                //    TextBoxReadPokehunters.Text += pokehunterlist[i].ToString() + "\n";
                //    ListBoxReadPokehunters.Items.Add(pokehunterlist[i].ToString());
                //}
                GridViewPokehunters.DataSource = pokehunterlist;
                GridViewPokehunters.DataBind();
            }
        }
        catch (Exception ex)
        {
            LabelUpdateFeedback.Text = ex.Message;
        }
            
        
        
    }


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



    protected void OrganizerGridviewDeleteRow(object sender, GridViewDeleteEventArgs e)
    {
        foreach (Organizer item in organizerlist)
        {
            //find match in arraylist
            if (GridViewOrganizers.SelectedRow.Cells[1].Text == item.alias.ToString())
            {
                organizerlist.Remove(item);
                LabelUpdateFeedback.Text = "Person deleted";
                break;
            }
            else
            {
                LabelUpdateFeedback.Text = "Person not found";

            }
        }

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

                //feedback message
                LabelUpdateFeedback.Text = "Information has been changed";

                //empty gridview

                //populate gridview
                GridViewPokehunters.DataSource = pokehunterlist;
                GridViewPokehunters.DataBind();

                //clear form
                Formcleaner.ClearForm(participantform);
                LabelUpdateInfoFor.Text = "";
                LabelUpdateInfoAlias.Text = "";
                LabelUpdateShowType.Text = "";

            }
            else
            {
                LabelUpdateFeedback.Text = "Person not found";

            }
        }
    }

    public void UpdateOrganizer() {
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

                //feedback message
                LabelUpdateFeedback.Text = "Information has been changed";

                //empty gridview

                //populate gridview
                GridViewOrganizers.DataSource = organizerlist;
                GridViewOrganizers.DataBind();

                //clear form
                Formcleaner.ClearForm(participantform);
                LabelUpdateInfoFor.Text = "";
                LabelUpdateInfoAlias.Text = "";
                LabelUpdateShowType.Text = "";

            }
            else
            {
                LabelUpdateFeedback.Text = "Person not found";

            }
        }
    }
}