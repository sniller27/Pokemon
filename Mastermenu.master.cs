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
        CheckSession();
    }

    public string IsCurrentPage(string itemName)
    {
        return Path.GetFileName(Request.Url.AbsolutePath) == itemName ? "class='active'" : string.Empty;
        //return "class='"+ Path.GetFileName(Request.Url.AbsolutePath) + "'";

    }

    protected void buttonlogin_Click(object sender, EventArgs e)
    {
        //connection
        SqlConnection conn = new SqlConnection(@"data source = .\SQLEXPRESS; integrated security = true; database = PokemonDB");
        SqlCommand cmd = null;
        SqlDataReader rdr = null;
        //string sqlselcheck = "select count(*) from PokemonHunters where Alias = @username and Password = @password";
        string sqlselid = "select HunterId from PokemonHunters where Alias = @username and Password = @password";
        //string sqlselcheck = "select Alias, count(*) from PokemonHunters where Alias = @username and Password = @password group by Alias;";

        try
        {
            conn.Open();

            //cmd = new SqlCommand(sqlselcheck, conn);
            cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "CountAccessRows";

            //cmd.Parameters["@username"].Value = TextBoxUsernameLogin.Text;
            //cmd.Parameters["@password"].Value = TextBoxPasswordLogin.Text;

            //for parameters aka. prepared statments (i forlængelse af SqlCommand i stedet for SqlParameter)
            //cmd.Parameters.Add("@username", SqlDbType.NVarChar);
            //cmd.Parameters.Add("@password", SqlDbType.NVarChar);

            //VIRKER IKKE!?? VARCHAR??
            SqlParameter in1 = cmd.Parameters.Add("@username", SqlDbType.Text);
            in1.Direction = ParameterDirection.Input;
            in1.Value = TextBoxUsernameLogin.Text;

            SqlParameter in2 = cmd.Parameters.Add("@password", SqlDbType.NVarChar);
            in2.Direction = ParameterDirection.Input;
            in2.Value = TextBoxPasswordLogin.Text;

            //output parameter
            SqlParameter out1 = cmd.Parameters.Add("@totalrowsfound", SqlDbType.Int);
            out1.Direction = ParameterDirection.Output;

            //return value
            SqlParameter returnval = cmd.Parameters.Add("return_value", SqlDbType.Int);
            returnval.Direction = ParameterDirection.ReturnValue;

            //bruger reader
            //cmd.ExecuteNonQuery();
            rdr = cmd.ExecuteReader();

            //fra internet
            //string retunvalue = cmd.Parameters["@rowcounts"].Value.ToString();

            //torben
            Labelcheck.Text = "Resultat: " + cmd.Parameters["return_value"].Value;
            Labelcheck1.Text = "Resultat: " + cmd.Parameters["@totalrowsfound"].Value;


            //ved ikke?
            //cmd.ExecuteNonQuery();

            //close reader
            rdr.Close();

            //virkede før
            //int userCount = (int)cmd.ExecuteScalar();
            int userCount = (int)cmd.Parameters["@totalrowsfound"].Value;

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

    protected void ButtonLogout_Click(object sender, EventArgs e)
    {
        Session["Pokehunter"] = null;
        Response.Redirect("Welcome.aspx");
    }

    public void CheckSession() {
        //check session and set login/logout links i menu
        if (Session["Pokehunter"] == null)
        {
            ButtonLogout.Visible = false;
            loginmodalhyperlink.Visible = true;
            //return "< li >< a href = '#' data - toggle = 'modal' data - target = '#myModal' >< span class='glyphicon glyphicon-log-in'></span> Logout</a></li>";
        }
        else
        {
            ButtonLogout.Visible = true;
            loginmodalhyperlink.Visible = false;
            //return "< li >< a href = '#' data - toggle = 'modal' data - target = '#myModal' >< span class='glyphicon glyphicon-log-in'></span> Login</a></li>";
        }
    }

}
