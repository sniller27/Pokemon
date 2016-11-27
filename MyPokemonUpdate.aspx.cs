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
        //hide catchid's
        GridviewUpdateCatches.Columns[6].Visible = false;

        UpdateGridView();
    }

    public void UpdateGridView()
    {
        //connection
        SqlConnection conn = new SqlConnection(@"data source = .\SQLEXPRESS; integrated security = true; database = PokemonDB");
        SqlCommand cmd = null;
        SqlDataReader rdr = null;
        string sqlselpokemons = "select * from PokemonCatches where HunderId_FK = @hunterid";

        try
        {
            conn.Open();

            //cmd = new SqlCommand(sqlselcheck, conn);
            cmd = new SqlCommand(sqlselpokemons, conn);

            //hunter id parameter
            SqlParameter pa1 = cmd.Parameters.Add("@hunterid", SqlDbType.Int);
            pa1.Direction = ParameterDirection.Input;
            pa1.Value = Session["Pokehunter"];

            rdr = cmd.ExecuteReader();

            GridviewUpdateCatches.DataSource = rdr;
            GridviewUpdateCatches.DataBind();

            //close reader
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

    protected void ButtonUpdatePokecatch_Click(object sender, EventArgs e)
    {
        //connection
        SqlConnection conn = new SqlConnection(@"data source = .\SQLEXPRESS; integrated security = true; database = PokemonDB");
        SqlCommand cmd = null;
        string sqlupd = "update PokemonCatches set CatchName = @catchname, Lvl = @lvl, CurrentExp = @curexp, NextLvlExp = @nextexp, PokemonGender = @gender  where CatchId = @catchid";

        try
        {
            conn.Open();
            cmd = new SqlCommand(sqlupd, conn);

            SqlParameter pa1 = cmd.Parameters.Add("@catchname", SqlDbType.Text);
            pa1.Direction = ParameterDirection.Input;
            pa1.Value = TextBoxPokemonName.Text;

            SqlParameter pa2 = cmd.Parameters.Add("@lvl", SqlDbType.Int);
            pa2.Direction = ParameterDirection.Input;
            pa2.Value = Convert.ToInt32(TextBoxPokemonLevel.Text);

            SqlParameter pa3 = cmd.Parameters.Add("@curexp", SqlDbType.Int);
            pa3.Direction = ParameterDirection.Input;
            pa3.Value = Convert.ToInt32(TextBoxPokemonCurExp.Text);

            SqlParameter pa4 = cmd.Parameters.Add("@nextexp", SqlDbType.Int);
            pa4.Direction = ParameterDirection.Input;
            pa4.Value = Convert.ToInt32(TextBoxNextLvlExp.Text);

            SqlParameter pa5 = cmd.Parameters.Add("@gender", SqlDbType.Text);
            pa5.Direction = ParameterDirection.Input;
            pa5.Value = RadioButtonListPokemonGender.SelectedValue;

            SqlParameter pa6 = cmd.Parameters.Add("@catchid", SqlDbType.Int);
            pa6.Direction = ParameterDirection.Input;
            pa6.Value = Convert.ToUInt32(HiddenFieldCatchId.Value);

            //execute non query for update
            cmd.ExecuteNonQuery();

            //feedback
            LabelPositiveFeedback.Text = "Pokémoninfo has been updated";

            //update gridview
            UpdateGridView();
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

    protected void GridviewUpdateCatches_SelectedIndexChanged(object sender, EventArgs e)
    {
        //populate update fields
        TextBoxPokemonName.Text = GridviewUpdateCatches.SelectedRow.Cells[1].Text;
        TextBoxPokemonLevel.Text = GridviewUpdateCatches.SelectedRow.Cells[2].Text;
        TextBoxPokemonCurExp.Text = GridviewUpdateCatches.SelectedRow.Cells[3].Text;
        TextBoxNextLvlExp.Text = GridviewUpdateCatches.SelectedRow.Cells[4].Text;
        RadioButtonListPokemonGender.SelectedValue = GridviewUpdateCatches.SelectedRow.Cells[5].Text;

        //set catch id for hidden field
        int rowid = GridviewUpdateCatches.SelectedRow.DataItemIndex;
        string catchidrow = GridviewUpdateCatches.DataKeys[rowid].Value.ToString();
        HiddenFieldCatchId.Value = catchidrow;
    }
}