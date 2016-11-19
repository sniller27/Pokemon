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

    protected void Page_Load(object sender, EventArgs e)
    {
        organizerlist = (ArrayList)Application["Organizercollection"];
        pokehunterlist = (ArrayList)Application["Pokehuntercollection"];

        GridViewPokehunters.DataSource = pokehunterlist;
        GridViewPokehunters.DataBind();

        //var columnToMove = GridViewPokehunters.Columns[1];
        //GridViewPokehunters.Columns.RemoveAt(1);
        //GridViewPokehunters.Columns.Insert(0, columnToMove);


        if (organizerlist.Count == 0)
        {
            LabelReadOrganizersInfo.Text = "listen er tom";
        }
        else
        {
            for (int i = 0; i < organizerlist.Count; i++)
            {
                TextBoxReadOrganizers.Text += organizerlist[i].ToString() + "\n";
            }
        }

        if (pokehunterlist.Count == 0)
        {
            LabelReadPokehunterInfo.Text = "listen er tom";
        }
        else
        {
            for (int i = 0; i < pokehunterlist.Count; i++)
            {
                TextBoxReadPokehunters.Text += pokehunterlist[i].ToString() + "\n";
                ListBoxReadPokehunters.Items.Add(pokehunterlist[i].ToString());
            }
        }
        
    }


    protected void ButtonUpdate_Click(object sender, EventArgs e)
    {
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

            }
            else
            {
                LabelUpdateFeedback.Text = "Person not found";

            }
        }
        //LabelUpdateFeedback.Text = "Participant updated";
    }

    protected void ListBoxReadPokehunters_SelectedIndexChanged(object sender, EventArgs e)
    {
        LabelReadPokehunterInfo.Text = ListBoxReadPokehunters.SelectedItem.ToString();
    }


    protected void GridViewPokehunters_SelectedIndexChanged(object sender, EventArgs e)
    {
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

    }

    protected void gdview_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        LabelUpdateFeedback.Text = "kagemand";
    }
}