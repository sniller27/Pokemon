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
        //redirects you if you don't have access to this page
        if (Session["Pokehunter"] == null)
        {
            Response.Redirect("Index.aspx");
        }

        //check if you are battling
        if (Session["Pokebattle"] == "yes")
        {
            Session["Pokebattle"] = null;
        }

        //show Pokémon
        UpdateGridView();
        RemoveEvolveButtons();

        //hide catchid's
        gridviewUserReadpokemon.Columns[12].Visible = false;
    }

    public void UpdateGridView()
    {
        //connection
        SqlConnection conn = new SqlConnection(@"data source = .\SQLEXPRESS; integrated security = true; database = PokemonDB");
        SqlCommand cmd = null;
        SqlDataReader rdr = null;

        try
        {
            //open connection
            conn.Open();

            //new command
            cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "readusercatches";

            //add paramter
            SqlParameter in2 = cmd.Parameters.Add("@hunterid", SqlDbType.Int);
            in2.Direction = ParameterDirection.Input;
            in2.Value = (int)Session["Pokehunter"];

            //execute
            rdr = cmd.ExecuteReader();

            //populate
            gridviewUserReadpokemon.DataSource = rdr;
            gridviewUserReadpokemon.DataBind();

            //close reader
            rdr.Close();

            //update evolve buttons
            RemoveEvolveButtons();
        }
        catch (Exception ex)
        {
            Labelnegativefeedback.Text = ex.Message;
        }
        finally
        {
            conn.Close();
        }
    }

    public void gridviewUserReadpokemon_RowDeleting(Object sender, GridViewDeleteEventArgs e)
    {
        //connection info
        SqlConnection conn = new SqlConnection(@"data source = .\SQLEXPRESS; integrated security = true; database = PokemonDB");
        SqlCommand cmd = null;

        //select gridview row
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
        catch (Exception ex)
        {
            Labelnegativefeedback.Text = ex.Message;
        }
    }

    public void gridviewUserReadpokemon_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        //code that only responds to update button
        if (e.CommandName == "buttonlevelchange")
        {
            //connection info
            SqlConnection conn = new SqlConnection(@"data source = .\sqlexpress; integrated security = true; database = PokemonDB");
            SqlCommand cmd = null;

            //current row button clicked
            int currentrowvalue = Convert.ToInt32(e.CommandArgument);
            //catch id
            string selectedrow = gridviewUserReadpokemon.DataKeys[currentrowvalue].Value.ToString();
            //next evolution
            string nextevolution = gridviewUserReadpokemon.Rows[currentrowvalue].Cells[8].Text;
            Labelpositivefeedback.Text = selectedrow;
            Labelnegativefeedback.Text = nextevolution;
            try
            {
                //open connection to db
                conn.Open();
                //create command
                cmd = conn.CreateCommand();
                //define type of command
                cmd.CommandType = CommandType.StoredProcedure;
                //name of procedure
                cmd.CommandText = "Evolve";

                //add parameters
                SqlParameter pa1 = cmd.Parameters.Add("@catchid", SqlDbType.Int);
                //direction input/output/return value
                pa1.Direction = ParameterDirection.Input;
                //parameter value
                pa1.Value = Convert.ToInt32(selectedrow);

                SqlParameter pa2 = cmd.Parameters.Add("@nextevolve", SqlDbType.Text);
                pa2.Direction = ParameterDirection.Input;
                pa2.Value = nextevolution;

                //execute and update
                cmd.ExecuteNonQuery();
                Labelpositivefeedback.Text = "Your Pokémon has evolved";
                UpdateGridView();
            }
            catch (Exception ex)
            {
                Labelpositivefeedback.Text = ex.Message;
            }
            finally
            {
                //close connection
                conn.Close();
            }
        }
    }

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