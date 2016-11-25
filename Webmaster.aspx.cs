using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Webmaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ButtonBrowseImage_Click(object sender, EventArgs e)
    {



        //show image
        ImageToUpload.ImageUrl = "Images/ivysaur.jpg";
    }
}