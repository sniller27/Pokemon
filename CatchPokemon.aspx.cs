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
    Image datalistimage;
    Label datalistname, datalistlevel;
    HiddenField datalisthiddenfield;
    Random random = new Random();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Pokebattle"] != "yes")
        {
            //connection
            SqlConnection conn = new SqlConnection(@"data source = .\SQLEXPRESS; integrated security = true; database = PokemonDB");
            SqlCommand cmd = null;
            SqlDataReader rdr = null;
            string sqlsel = "select TOP 1 *,CEILING(99*RAND()) as RandomLevel from Pokemon order by NEWID()";

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

            //genereate random level 1-99
            

            //start battle
            Session["Pokebattle"] = "yes";
        }
    }

    protected void ImageButtonPokeballCatch_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["Pokebattle"] == "yes")
        {
            //generates a random number
            int randomnumber = random.Next(1, 3);

            if (randomnumber == 1)
            {
                //pokemon caught
                LabelFight.Text = "You caught it! <br> Return to 'My Pokemon' to see your catch.";
                ImageButtonPokeballCatch.Visible = false;
                Session["Pokebattle"] = null;

                //insert into db
                InsertNewPokemon();
            }
            else
            {
                LabelFight.Text = "Too bad you missed";
            }
        }
    }

    public void InsertNewPokemon() {
        SqlConnection conn = new SqlConnection(@"data source = .\SQLEXPRESS; integrated security = true; database = PokemonDB");
        SqlCommand cmd = null;
        //update with paramters @xxx
        string insertpokemon = "insert into PokemonCatches values (@level, @nickname, @curexp, @nextexp, @gender, @pokemonid, @pokehunterid)";


        try
        {
            conn.Open();

            cmd = new SqlCommand(insertpokemon, conn);

            //create parameter with datatypes
            cmd.Parameters.Add("@level", SqlDbType.TinyInt);
            cmd.Parameters.Add("@nickname", SqlDbType.NVarChar);
            cmd.Parameters.Add("@curexp", SqlDbType.Int);
            cmd.Parameters.Add("@nextexp", SqlDbType.Int);
            cmd.Parameters.Add("@gender", SqlDbType.NVarChar);
            cmd.Parameters.Add("@pokemonid", SqlDbType.Int);
            cmd.Parameters.Add("@pokehunterid", SqlDbType.Int);

            //fetching data from datalist
            foreach (DataListItem item in datalistcatchpokemon.Items)
            {
                datalistname = (Label)item.FindControl("LabelCatchPokemonName");
                datalistlevel = (Label)item.FindControl("LabelCatchPokemonLevel");
                datalisthiddenfield = (HiddenField)item.FindControl("HiddenFieldPokemonId");
            }

            //generate random values
            //level raise according to level
            int nextlevel = 100*Convert.ToInt32(datalistlevel.Text)+20;
            //gender
            string gender = (random.NextDouble() >= 0.5) ? "male" : "female";

            ////assign parameters
            cmd.Parameters["@level"].Value = datalistlevel.Text;
            cmd.Parameters["@nickname"].Value = datalistname.Text;
            cmd.Parameters["@curexp"].Value = 0;
            cmd.Parameters["@nextexp"].Value = nextlevel;
            cmd.Parameters["@gender"].Value = gender;
            cmd.Parameters["@pokemonid"].Value = datalisthiddenfield.Value;
            cmd.Parameters["@pokehunterid"].Value = Session["Pokehunter"];

            ////execute query
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
        }
        finally
        {
            conn.Close();
        }
    }
}