using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class readpokehunters : System.Web.UI.Page
{
    ArrayList pokehunterlist;

    protected void Page_Load(object sender, EventArgs e)
    {
        //redirects you if you don't have access to this page
        if (Session["Pokehunter"] == null)
        {
            Response.Redirect("Welcome.aspx");
        }

        //try to get data from Pokehunter file
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
                //bind grid
                GridViewPokehunters.DataSource = pokehunterlist;
                GridViewPokehunters.DataBind();
            }

        }
        catch (Exception)
        {
            //not necessarily file problem
            LabelReadPokehuntersInfo.Text = "File not created";
        }

    }
}