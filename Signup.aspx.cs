using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Signup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void buttonsignup_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(@"data source = .\SQLEXPRESS; integrated security = true; database = PokemonDB");
        SqlCommand cmd = null;
        //update with paramters @xxx
        string sqlins = "insert into PokemonHunters values (@Alias, @Name, @Gender, @Age, @Email, @Password)";

        try
        {
            conn.Open();

            cmd = new SqlCommand(sqlins, conn);
            //for parameters aka. prepared statments
            cmd.Parameters.Add("@Alias", SqlDbType.Text);
            cmd.Parameters.Add("@Name", SqlDbType.Text);
            cmd.Parameters.Add("@Gender", SqlDbType.Text);
            cmd.Parameters.Add("@Age", SqlDbType.TinyInt);
            cmd.Parameters.Add("@Email", SqlDbType.Text);
            cmd.Parameters.Add("@Password", SqlDbType.Text);

            cmd.Parameters["@Alias"].Value = TextBoxSignupAlias.Text;
            cmd.Parameters["@Name"].Value = TextBoxSignupName.Text;
            cmd.Parameters["@Gender"].Value = RadioButtonListSignupGender.Text;
            cmd.Parameters["@Age"].Value = TextBoxSignupAge.Text;
            cmd.Parameters["@Email"].Value = TextBoxSignupEmail.Text;
            cmd.Parameters["@Password"].Value = TextBoxSignupPassword.Text;

            cmd.ExecuteNonQuery();
            labelsignupfeedback.Text = "Your account has been created";

            //clear form
            TextBoxSignupAlias.Text = "";
            TextBoxSignupName.Text = "";
            RadioButtonListSignupGender.ClearSelection();
            TextBoxSignupAge.Text = "";
            TextBoxSignupEmail.Text = "";
            TextBoxSignupPassword.Text = "";
            TextBoxSignupPasswordConfirm.Text = "";
        }
        catch (Exception ex)
        {
            labelsignupfeedback.Text = ex.Message;
        }
        finally
        {
            conn.Close();
        }
    }
}