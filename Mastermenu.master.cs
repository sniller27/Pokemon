using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Mastermenu : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckSession();
    }

    public string IsCurrentPage(string itemName)
    {
        return Path.GetFileName(Request.Url.AbsolutePath) == itemName ? "class='active'" : string.Empty;
    }

    protected void buttonlogin_Click(object sender, EventArgs e)
    {
        //connection info
        SqlConnection conn = new SqlConnection(@"data source = .\SQLEXPRESS; integrated security = true; database = PokemonDB");
        SqlCommand cmd = null;
        SqlDataReader rdr = null;
        string sqlselid = "select HunterId from PokemonHunters where Alias = @username and Password = @password";

        try
        {
            conn.Open();

            cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "CountAccessRows";

            //add parameters
            SqlParameter in1 = cmd.Parameters.Add("@username", SqlDbType.Text);
            in1.Direction = ParameterDirection.Input;
            in1.Value = TextBoxUsernameLogin.Text;

            SqlParameter in2 = cmd.Parameters.Add("@password", SqlDbType.NVarChar);
            in2.Direction = ParameterDirection.Input;
            in2.Value = TextBoxPasswordLogin.Text;

            //output parameter
            SqlParameter out1 = cmd.Parameters.Add("@totalrowsfound", SqlDbType.Int);
            out1.Direction = ParameterDirection.Output;

            //set data reader
            rdr = cmd.ExecuteReader();

            //close reader
            rdr.Close();

            int userCount = (int)cmd.Parameters["@totalrowsfound"].Value;

            if (userCount > 0)
            {
                cmd = new SqlCommand(sqlselid, conn);

                //parameters
                cmd.Parameters.Add("@username", SqlDbType.NVarChar);
                cmd.Parameters.Add("@password", SqlDbType.NVarChar);

                cmd.Parameters["@username"].Value = TextBoxUsernameLogin.Text;
                cmd.Parameters["@password"].Value = TextBoxPasswordLogin.Text;

                //grabbing id from first row
                Int32 id = (Int32)cmd.ExecuteScalar();

                //starts login session
                if (cmd.Parameters["@username"].Value.ToString() == "Webmaster")
                {
                    Session["Webmaster"] = id;
                    Response.Redirect("Webmaster.aspx");
                }
                else
                {
                    Session["Pokehunter"] = id;
                    Response.Redirect("Mypokemon.aspx");
                }
            }
            else
            {
                LabelLoginError.Text = "Wrong combination of username and password";
                //call script on load that shows login modal
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "script", "$(function () { ShowModal(); });", true);
            }
        }
        catch (Exception ex)
        {
            LabelLoginError.Text = ex.Message;
        }
        finally
        {
            conn.Close();
        }
    }

    protected void Linklogout_Click(object sender, EventArgs e)
    {
        Session["Pokehunter"] = null;
        Session["Webmaster"] = null;
        Response.Redirect("Index.aspx");
    }

    public void CheckSession() {
        //check session and set login/logout links i menu
        if (Session["Pokehunter"] == null && Session["Webmaster"] == null)
        {
            Linklogout.Visible = false;
            loginmodalhyperlink.Visible = true;
        }
        else
        {
            Linklogout.Visible = true;
            loginmodalhyperlink.Visible = false;
        }
    }
}
