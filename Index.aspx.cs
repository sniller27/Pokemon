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
    SqlConnection conn = new SqlConnection(@"data source = .\SQLEXPRESS; integrated security = true; database = PokemonDB");

    SqlCommand cmd = null;
    SqlDataReader rdr = null;
    String sqlsel = "";

    protected void Page_Load(object sender, EventArgs e)
    {
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
            //datalistpokemoncarousel.DataSource
            cmd.CommandText = sqlsel;
            cmd.ExecuteNonQuery();

            //create datatable and uses sqldataadapter to sync data from db(SqlCommand?)
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //binds data to table?
            da.Fill(dt);
            //datalist gets data from datatable?
            datalistpokemoncarousel.DataSource = dt;
            datalistpokemoncarousel.DataBind();
        }
        catch (Exception ex)
        {
        }
        finally
        {
            //4. Close connection
            conn.Close();
        }
    }
}