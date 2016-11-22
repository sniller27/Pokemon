using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Mastermenu : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public string IsCurrentPage(string itemName)
    {
        return Path.GetFileName(Request.Url.AbsolutePath) == itemName ? "class='active'" : string.Empty;
        //return "class='"+ Path.GetFileName(Request.Url.AbsolutePath) + "'";

    }
}
