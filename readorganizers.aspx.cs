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

        GridView1.DataSource = pokehunterlist;
        GridView1.DataBind();


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

    }

    protected void ListBoxReadPokehunters_SelectedIndexChanged(object sender, EventArgs e)
    {
        LabelReadPokehunterInfo.Text = ListBoxReadPokehunters.SelectedItem.ToString();
    }
}