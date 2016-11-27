using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MyPokemonUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
        UpdateDropDownList();
        }
    }

    public void UpdateDropDownList() {
        //connection
        SqlConnection conn = new SqlConnection(@"data source = .\SQLEXPRESS; integrated security = true; database = PokemonDB");
        SqlCommand cmd = null;
        SqlDataReader rdr = null;
        string sqlselpokemons = "select * from Pokemon join PokemonCatches on PokemonId = PokemonId_FK where HunderId_FK = @hunterid";

        try
        {
            conn.Open();
            cmd = new SqlCommand(sqlselpokemons, conn);

            //parameters
            cmd.Parameters.Add("@hunterid", SqlDbType.Int);

            cmd.Parameters["@hunterid"].Value = Convert.ToInt32(Session["Pokehunter"]);

            rdr = cmd.ExecuteReader();
            DropDownListPokemons.DataSource = rdr;
            DropDownListPokemons.DataTextField = "Name";
            DropDownListPokemons.DataValueField = "CatchId";
            DropDownListPokemons.DataBind();

            rdr.Close();
        }
        catch (Exception ex)
        {
            LabelNegativeFeedback.Text = ex.Message;
        }
        finally
        {
            conn.Close();
        }
    }

    protected void DropDownListPokemons_SelectedIndexChanged(object sender, EventArgs e)
    {
        //SqlConnection conn = new SqlConnection(@"data source = .\sqlexpress; integrated security = true; database = PokemonDB");
        ////
        //SqlDataAdapter da = null;
        //DataSet ds = null;
        //DataTable dt = null;
        ////
        //string sqlsel = "select * from Pokemon join PokemonCatches on PokemonId = PokemonId_FK where CatchId = @catchid";

        //try
        //{
        //    da = new SqlDataAdapter();

        //    da.SelectCommand = new SqlCommand(sqlsel, conn);
        //    ds = new DataSet();
        //    da.Fill(ds, "SelectCatch");
        //    dt = ds.Tables["SelectCatch"];

        //    //gridview bind
        //    GridViewshippers.DataSource = dt;
        //    GridViewshippers.DataBind();

        //}
        //catch (Exception ex)
        //{
        //    Labelmessage.Text = ex.Message;
        //    throw;
        //}
        //finally
        //{
        //    conn.Close(); //sqldataadapter connection closes automaticly. but let's close it since it can fail... just in case
        //}
    }

    protected void ButtonUpdatePokecatch_Click(object sender, EventArgs e)
    {
        //SqlConnection conn = new SqlConnection(@"data source = .\sqlexpress; integrated security = true; database = PokemonDB");
        //SqlDataAdapter da = null;
        //DataSet ds = null;
        //DataTable dt = null;
        //SqlCommand cmd = null;
        //string sqlsel = "select * from Pokemon join PokemonCatches on PokemonId = PokemonId_FK where CatchId = @catchid";
        ////string sqlupd = "update pokemon set Number = @pokedex, Name = @pokename, NextEvolution = @nextevolution, Image = @image, Type = @type where PokemonId = @pokemonid";
        //string sqlupd = "update PokemonCatches set CatchName = @catchname, Lvl = @lvl, CurrentExp = @curexp, NextLvlExp = @nextexp, PokemonGender = @gender  where CatchId = @catchid";

        //try
        //{
        //    //instantiate
        //    da = new SqlDataAdapter();

        //    //fill data table with data
        //    da.SelectCommand = new SqlCommand(sqlsel, conn);
        //    ds = new DataSet();
        //    da.Fill(ds, "UpdateCatch");
        //    dt = ds.Tables["UpdateCatch"];

        //    //change rows in data table
        //    dt.Rows[0]["CatchName"] = TextBoxPokemonName.Text;
        //    dt.Rows[0]["Lvl"] = TextBoxPokemonLevel.Text;
        //    dt.Rows[0]["CurrentExp"] = TextBoxPokemonCurExp.Text;
        //    dt.Rows[0]["NextLvlExp"] = TextBoxNextLvlExp.Text;
        //    dt.Rows[0]["PokemonGender"] = RadioButtonListPokemonGender.SelectedValue;

        //    //new sqlcommand
        //    cmd = new SqlCommand(sqlupd, conn);
        //    //add parameters
        //    cmd.Parameters.Add("@pokedex", SqlDbType.Int, 50, "Number");
        //    cmd.Parameters.Add("@pokename", SqlDbType.Text, 50, "Name");
        //    cmd.Parameters.Add("@nextevolution", SqlDbType.Text, 50, "NextEvolution");
        //    cmd.Parameters.Add("@image", SqlDbType.Text, 50, "Image");
        //    cmd.Parameters.Add("@type", SqlDbType.Text, 50, "Type");
        //    cmd.Parameters.Add("@pokemonid", SqlDbType.Int, 50, "PokemonId");

        //    //extra parameter for security reasons. if someone changes id by mistake.
        //    //SqlParameter parm = cmd.Parameters.Add("@shipperid", SqlDbType.Int, 4, "shipperid");
        //    //parm.SourceVersion = DataRowVersion.Original;

        //    //set command for adapter
        //    da.UpdateCommand = cmd;
        //    //adapter sync
        //    da.Update(ds, "UpdateCatch");

        //    //update gridview
        //    UpdateGridview();

        //    LabelSucces.Text = "Updated";
        //}
        //catch (Exception ex)
        //{
        //    LabelNegativeFeedback.Text = ex.Message;
        //}
        //finally
        //{
        //    //close just in case
        //    conn.Close();
        //}
    }
}