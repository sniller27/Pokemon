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

    protected void Page_Load(object sender, EventArgs e)
    {
        organizerlist = (ArrayList)Application["Organizercollection"];

        if (organizerlist.Count == 0)
        {
            LabelReadOrganizersInfo.Text = "listen er tom";
        }
        else
        {
            for (int i = 0; i < organizerlist.Count; i++)
            {
                TextBoxReadOrganizers.Text = TextBoxReadOrganizers.Text + organizerlist[i].ToString() + "\n";
            }
        }
    }
}