using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Mypokemon : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Pokebattle"] == "yes")
        {
            Session["Pokebattle"] = null;
        }

        //show Pokémon
        UpdateGridView();
        RemoveEvolveButtons();
    }

    public void UpdateGridView()
    {
        //connection
        SqlConnection conn = new SqlConnection(@"data source = .\SQLEXPRESS; integrated security = true; database = PokemonDB");
        SqlCommand cmd = null;
        SqlDataReader rdr = null;

        try
        {
            conn.Open();

            //cmd = new SqlCommand(sqlselcheck, conn);
            cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "readusercatches";

            SqlParameter in2 = cmd.Parameters.Add("@hunterid", SqlDbType.Int);
            in2.Direction = ParameterDirection.Input;
            in2.Value = (int)Session["Pokehunter"];

            //output parameter
            //SqlParameter out1 = cmd.Parameters.Add("@totalrowsfound", SqlDbType.Int);
            //out1.Direction = ParameterDirection.Output;

            //return value
            //SqlParameter returnval = cmd.Parameters.Add("return_value", SqlDbType.Int);
            //returnval.Direction = ParameterDirection.ReturnValue;

            //bruger reader
            //cmd.ExecuteNonQuery();
            rdr = cmd.ExecuteReader();

            gridviewUserReadpokemon.DataSource = rdr;
            gridviewUserReadpokemon.DataBind();


            //ved ikke?
            //cmd.ExecuteNonQuery();

            //close reader
            rdr.Close();

            //update evolve buttons
            RemoveEvolveButtons();
        }
        catch (Exception ex)
        {
        }
        finally
        {
            conn.Close();
        }
    }

    //row delete
    public void gridviewUserReadpokemon_RowDeleting(Object sender, GridViewDeleteEventArgs e)
    {
        //connection
        SqlConnection conn = new SqlConnection(@"data source = .\SQLEXPRESS; integrated security = true; database = PokemonDB");
        SqlCommand cmd = null;
        SqlDataReader rdr = null;

        //select row
        string catchidrow = gridviewUserReadpokemon.DataKeys[e.RowIndex].Value.ToString();
        //sql string
        string sqldelpokemon = "delete from PokemonCatches where CatchId = @CatchId";

        try
        {
            //open conenction to db
            conn.Open();

            //new sqlcommand
            cmd = new SqlCommand(sqldelpokemon, conn);

            //parameters
            cmd.Parameters.Add("@CatchId", SqlDbType.Int);
            cmd.Parameters["@CatchId"].Value = catchidrow;

            //execute query
            cmd.ExecuteNonQuery();

            //update gridview
            UpdateGridView();

        }
        catch (Exception)
        {
            throw;
        }
    }

    //row update/evovle
    public void gridviewUserReadpokemon_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        //current row button clicked
        int currentrowvalue = Convert.ToInt32(e.CommandArgument);
        //catch id
        string selectedrow = gridviewUserReadpokemon.DataKeys[currentrowvalue].Value.ToString();
        //next evolution
        string nextevolution = gridviewUserReadpokemon.Rows[currentrowvalue].Cells[8].Text;


    }

    //Remove Evolve buttons method
    public void RemoveEvolveButtons()
    {
        string nextevolutionrow = "";

        //remove evolvebuttons on load
        for (int i = 0; i < gridviewUserReadpokemon.Rows.Count; i++)
        {
            nextevolutionrow = gridviewUserReadpokemon.Rows[i].Cells[8].Text;
            //replacing HTML entities (blanck space) with empty string
            nextevolutionrow = Regex.Replace(nextevolutionrow, @"<[^>]+>|&nbsp;", "").Trim();

            //removes button if Pokemon has no evolution
            if (nextevolutionrow.Length == 0)
            {
                //remove or hide button
                gridviewUserReadpokemon.Rows[i].Cells[9].Controls.Clear();
            }
        }
    }
}