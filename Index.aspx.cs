using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Index : System.Web.UI.Page
{
    //connection info
    SqlConnection conn = new SqlConnection(@"data source = .\SQLEXPRESS; integrated security = true; database = PokemonDB");
    SqlCommand cmd = null;
    SqlDataReader rdr = null;
    String sqlsel = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        //query
        sqlsel = "select * from Pokemon";
        showData();
    }

    public void showData()
    {
        try
        {
            //populate datalist
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            //set command
            cmd.CommandText = sqlsel;
            //execute query
            cmd.ExecuteNonQuery();

            //create datatable
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //gives data to data table
            da.Fill(dt);
            //populates datalist
            datalistpokemoncarousel.DataSource = dt;
            datalistpokemoncarousel.DataBind();
        }
        catch (Exception ex)
        {
        }
        finally
        {
            //close connection
            conn.Close();
        }
    }
}