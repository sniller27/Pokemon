using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Loginmenu : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["Pokefight"] = null;
        if (Session["Pokehunter"] == null)
        {
            loginmenu.Visible = false;
        }
        else
        {
            loginmenu.Visible = true;
        }

        if (Session["Webmaster"] == null)
        {
            loginwebmaster.Visible = false;
        }
        else
        {
            loginwebmaster.Visible = true;
        }
    }

    public string IsCurrentPage(string itemName)
    {
        return Path.GetFileName(Request.Url.AbsolutePath) == itemName ? "class='active'" : string.Empty;
        //return "class='"+ Path.GetFileName(Request.Url.AbsolutePath) + "'";

    }
}
