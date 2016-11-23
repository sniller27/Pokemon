using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

    protected void buttonlogin_Click(object sender, EventArgs e)
    {
        Labelcheck.Text = "wmaha";

        //connection
        SqlConnection conn = new SqlConnection(@"data source = .\SQLEXPRESS; integrated security = true; database = PokemonDB");
        SqlCommand cmd = null;
        SqlDataReader rdr = null;
        string sqlselcheck = "select count(*) from PokemonHunters where Alias = @username and Password = @password";
        string sqlselid = "select HunterId from PokemonHunters where Alias = @username and Password = @password";
        //string sqlselcheck = "select Alias, count(*) from PokemonHunters where Alias = @username and Password = @password group by Alias;";


        try
        {
            conn.Open();

            cmd = new SqlCommand(sqlselcheck, conn);
            //for parameters aka. prepared statments
            cmd.Parameters.Add("@username", SqlDbType.NVarChar);
            cmd.Parameters.Add("@password", SqlDbType.NVarChar);

            cmd.Parameters["@username"].Value = TextBoxUsernameLogin.Text;
            cmd.Parameters["@password"].Value = TextBoxPasswordLogin.Text;

            //cmd.ExecuteNonQuery();
            int userCount = (int)cmd.ExecuteScalar();

            //rdr = cmd.ExecuteReader();
            //if (rdr.HasRows){...}
            if (userCount > 0)
            {
                cmd = new SqlCommand(sqlselid, conn);
                //for parameters aka. prepared statments
                cmd.Parameters.Add("@username", SqlDbType.NVarChar);
                cmd.Parameters.Add("@password", SqlDbType.NVarChar);

                cmd.Parameters["@username"].Value = TextBoxUsernameLogin.Text;
                cmd.Parameters["@password"].Value = TextBoxPasswordLogin.Text;

                Int32 id = (Int32)cmd.ExecuteScalar();
                //rdr = cmd.ExecuteReader();

                //found username and password match
                Labelcheck.Text = "found " + id;
                //start login session
                Session["Pokehunter"] = id;
                Response.Redirect("Mypokemon.aspx");
            }
            else
            {
                Labelcheck.Text = "not found";
            }

        }
        catch (Exception ex)
        {
            Labelcheck.Text = ex.Message;
        }
        finally
        {
            conn.Close();
        }
    }

    public string ShowLogoutLink()
    {
        if (Session["Pokehunter"] != null)
        {
            return "logged in";
            //return "< li >< a href = '#' data - toggle = 'modal' data - target = '#myModal' >< span class='glyphicon glyphicon-log-in'></span> Logout</a></li>";
        }
        else
        {
            return "logged out";
            //return "< li >< a href = '#' data - toggle = 'modal' data - target = '#myModal' >< span class='glyphicon glyphicon-log-in'></span> Login</a></li>";
        }

    }
}
