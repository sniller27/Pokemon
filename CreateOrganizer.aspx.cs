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
    private ArrayList organizerlist;

    protected void Page_Load(object sender, EventArgs e)
    {
        organizerlist = new ArrayList();

        //check if "session"/global arraylist exists
        if (Application["Organizercollection"] == null)
        {
            //if not. then new arraylist
            organizerlist = new ArrayList();
            //declare or assign "session"/global arraylist
            Application["Organizercollection"] = organizerlist;
        }

        ////hvorfor gør vi dette?
        //organizerlist = (ArrayList)Application["Organizercollection"];
    }

    protected void ButtonCreateOrganizer_Click(object sender, EventArgs e)
    {
        //make instance of Organizer object
        organizer = new Organizer(TextBoxAlias.Text, TextBoxName.Text, Convert.ToInt32(TextBoxAge.Text), RadioButtonListOrganizerGender.Text, TextBoxEmail.Text, TextBoxPassword.Text);
        //getting the arraylist before inserting
        organizerlist = (ArrayList)Application["Organizercollection"];
        //add to list
        organizerlist.Add(organizer);

        organizerlist = (ArrayList)Application["Organizercollection"];

        //saves to file
        FileUtility.WriteFile(organizerlist, Server.MapPath("~/App_Data/Fishfile.ser"));
        //feedback
        LabelAddOrganizerFeedback.Text = "New organizer created";
        //clearform
        ClearForm(createorganizerform);
    }

    //clearform method
    public static void ClearForm(Control parent)
    {
        foreach (Control c in parent.Controls)
        {
            if (c.GetType() == typeof(TextBox))
            {
                ((TextBox)(c)).Text = string.Empty;
            }
            if (c.GetType() == typeof(RadioButtonList))
            {
                ((RadioButtonList)(c)).ClearSelection();
            }
        }
    }
}