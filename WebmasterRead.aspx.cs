using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebmasterRead : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UpdateGridview();
    }

    public void UpdateGridview()
    {
        SqlConnection conn = new SqlConnection(@"data source = .\sqlexpress; integrated security = true; database = PokemonDB");
        SqlDataAdapter da = null;
        DataSet ds = null;
        DataTable dt = null;
        SqlCommand cmd = null;
        string sqlsel = "select * from Pokemon order by PokemonId";

        try
        {
            //new adapter
            da = new SqlDataAdapter();

            //fill data table
            da.SelectCommand = new SqlCommand(sqlsel, conn);

            //new dataset
            ds = new DataSet();
            //get data from DB
            da.Fill(ds, "Pokemontable");
            //create datatable from data set
            dt = ds.Tables["Pokemontable"];

            GridViewPokemonTable.DataSource = dt;
            GridViewPokemonTable.DataBind();
        }
        catch (Exception ex)
        {
            LabelError.Text = ex.Message;
            throw;
        }
        finally
        {
            //DA closes automatically, but let's close connection just in case.
            conn.Close();
        }
    }

    //delete buttons
    public void GridViewPokemonTable_RowDeleting(Object sender, GridViewDeleteEventArgs e) {
        //setup
        SqlConnection conn = new SqlConnection(@"data source = .\sqlexpress; integrated security = true; database = PokemonDB");
        SqlDataAdapter da = null;
        SqlCommandBuilder cb = null;
        DataSet ds = null;
        DataTable dt = null;
        //SQL query
        string sqlsel = "select * from Pokemon order by PokemonId";

        //PokemonId from clicked row button
        string chosenrow = GridViewPokemonTable.DataKeys[e.RowIndex].Value.ToString();

        try
        {
            //new DA
            da = new SqlDataAdapter();

            //define command
            da.SelectCommand = new SqlCommand(sqlsel, conn);

            //??? it does something, but what?
            cb = new SqlCommandBuilder(da);

            //new data set
            ds = new DataSet();
            //fill data set
            da.Fill(ds, "Pokemontable");
            //fill data table
            dt = ds.Tables["Pokemontable"];

            //deletes row with PokemonId
            foreach (DataRow myrow in dt.Select("PokemonId =" + Convert.ToInt32(chosenrow)))
            {
                myrow.Delete();
            }

            //update DA
            da.Update(ds, "Pokemontable");

            LabelSucces.Text = "Pokémon deleted";
        }
        catch (Exception ex)
        {
            LabelError.Text = ex.Message;
        }
        finally
        {
            //close just in case
            conn.Close();
        }

        //update gridview
        UpdateGridview();
    }

    protected void ButtonUploadImage_Click(object sender, EventArgs e)
    {

    }
}