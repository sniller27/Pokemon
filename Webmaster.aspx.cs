using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
        
    }

    protected void ButtonCreatePokemon_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(@"data source = .\sqlexpress; integrated security = true; database = PokemonDB");
        SqlDataAdapter da = null;
        DataSet ds = null;
        DataTable dt = null;
        SqlCommand cmd = null;
        string sqlsel = "select * from pokemon";
        string sqlins = "insert into Pokemon values (@pokedex, @pokename, @nextevolution, @image, @type)";

        try
        {
            //new DA
            da = new SqlDataAdapter();

            //select command
            da.SelectCommand = new SqlCommand(sqlsel, conn);
            //new data set
            ds = new DataSet();
            //fill data set with data
            da.Fill(ds, "Pokemontable");
            //fill data table by using data set
            dt = ds.Tables["Pokemontable"];

            //add new row to data table
            DataRow newrow = dt.NewRow();
            newrow["Number"] = TextBoxNumber.Text;
            newrow["Name"] = TextBoxName.Text;
            newrow["NextEvolution"] = TextBoxNextEvolution.Text;
            newrow["Image"] = "default.jpg";
            newrow["Type"] = TextBoxType.Text;
            dt.Rows.Add(newrow);

            //insert command
            cmd = new SqlCommand(sqlins, conn);

            //add parameters
            cmd.Parameters.Add("@pokedex", SqlDbType.Int, 50, "Number");
            cmd.Parameters.Add("@pokename", SqlDbType.Text, 50, "Name");
            cmd.Parameters.Add("@nextevolution", SqlDbType.Text, 50, "NextEvolution");
            cmd.Parameters.Add("@image", SqlDbType.Text, 50, "Image");
            cmd.Parameters.Add("@type", SqlDbType.Text, 50, "Type");


            //set insert command to adapter
            da.InsertCommand = cmd;

            //adapter update
            da.Update(ds, "Pokemontable");

            Labelpositivefeedback.Text = "Pokemon created";

        }
        catch (Exception ex)
        {
            Labelnegativefeedback.Text = ex.Message;
            throw;
        }
        finally
        {
            //close connection just to be sure
            conn.Close();
        }
    }
}