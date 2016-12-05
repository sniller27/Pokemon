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
    //for sponsors
    DataSet ds;
    DataTable dt;

    protected void Page_Load(object sender, EventArgs e)
    {
        //query
        sqlsel = "select * from Pokemon";
        showPokemonImages();
        showSponsors();
    }

    public void showPokemonImages()
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

    public void showSponsors()
    {
        try
        {
            ds = new DataSet();
            //get data
            ds.ReadXml(Server.MapPath(@"~/XML/Sponsors.xml"));
            //navnet er ikke selvalgt her
            dt = ds.Tables["Sponsor"];

            //DropDownList1.DataSource = dt;
            //DropDownList1.DataTextField = dt.Columns[1].ToString();
            //DropDownList1.DataValueField = dt.Columns[0].ToString();
            //DropDownList1.DataBind();

        }
        catch (Exception ex)
        {
            //hvis der ikke findes XML fil så laves der et nyt datatable
            //MakeNewDataSetAndDataTable();
        }
        finally
        {
            RepeaterFrontpage.DataSource = dt;
            RepeaterFrontpage.DataBind();

            //dropdown list default value
            //DropDownList1.Items.Insert(0, "You can choose a horse");
        }
    }
}