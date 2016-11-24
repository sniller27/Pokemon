using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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