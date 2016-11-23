using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CatchPokemon : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Pokebattle"] == "yes")
        {
            LabelFight.Text = "Vi kæmper";
  
        }
        else
        {
            //connection
            SqlConnection conn = new SqlConnection(@"data source = .\SQLEXPRESS; integrated security = true; database = PokemonDB");
            SqlCommand cmd = null;
            SqlDataReader rdr = null;
            string sqlsel = "select TOP 1 * from Pokemon order by NEWID()";

            try
            {
                //populate datalist
                conn.Open();
                cmd = conn.CreateCommand();
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
                datalistcatchpokemon.DataSource = dt;
                datalistcatchpokemon.DataBind();


            }
            catch (Exception ex)
            {
            }
            finally
            {
                //4. Close connection
                conn.Close();
            }
            //start battle
            Session["Pokebattle"] = "yes";
        }

    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {

    }
}