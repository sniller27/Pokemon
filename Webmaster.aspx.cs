using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Webmaster : System.Web.UI.Page
{
    private string fileName, Tranfiles, ProcessedFiles;

    protected void Page_Load(object sender, EventArgs e)
    {
        //redirects you if you don't have access to this page
        if (Session["Webmaster"] == null)
        {
            Response.Redirect("Index.aspx");
        }

        //upload listener
        FileUploadImage.Attributes["onchange"] = "UploadFile(this)";
    }

    protected void Upload(object sender, EventArgs e)
    {
        if (FileUploadImage.HasFile)
        {
            //getting filename
            fileName = Path.GetFileName(FileUploadImage.PostedFile.FileName);
            //save in images folder
            FileUploadImage.PostedFile.SaveAs(Server.MapPath("~/temp/") + fileName);
        }

        //show image
        ImageToUpload.ImageUrl = @"~\temp\" + fileName;

        //show filename
        LabelChooseImage.Text = fileName;
    }

    protected void ButtonCreatePokemon_Click(object sender, EventArgs e)
    {
        //database connection info
        SqlConnection conn = new SqlConnection(@"data source = .\sqlexpress; integrated security = true; database = PokemonDB");
        SqlDataAdapter da = null;
        DataSet ds = null;
        DataTable dt = null;
        SqlCommand cmd = null;
        //SQL queries
        string sqlsel = "select * from pokemon";
        string sqlins = "insert into Pokemon values (@pokedex, @pokename, @nextevolution, @image, @type)";

        try
        {
            //new DA
            da = new SqlDataAdapter();

            //select command
            da.SelectCommand = new SqlCommand(sqlsel, conn);
            //new data set
            ds = new DataSet();
            //fill data set with data
            da.Fill(ds, "Pokemontable");
            //fill data table by using data set
            dt = ds.Tables["Pokemontable"];

            //add new row to data table
            DataRow newrow = dt.NewRow();
            newrow["Number"] = TextBoxNumber.Text;
            newrow["Name"] = TextBoxName.Text;
            newrow["NextEvolution"] = TextBoxNextEvolution.Text;
            newrow["Type"] = TextBoxType.Text;
            //check if image is chosen
            if (LabelChooseImage.Text != "")
            {
                newrow["Image"] = LabelChooseImage.Text;
            }
            else
            {
                newrow["Image"] = null;
            }
            
            //add new row to data table
            dt.Rows.Add(newrow);

            //insert command
            cmd = new SqlCommand(sqlins, conn);

            //add parameters
            cmd.Parameters.Add("@pokedex", SqlDbType.Int, 50, "Number");
            cmd.Parameters.Add("@pokename", SqlDbType.Text, 50, "Name");
            cmd.Parameters.Add("@nextevolution", SqlDbType.Text, 50, "NextEvolution");
            cmd.Parameters.Add("@image", SqlDbType.Text, 50, "Image");
            cmd.Parameters.Add("@type", SqlDbType.Text, 50, "Type");

            //set insert command to adapter
            da.InsertCommand = cmd;

            //adapter update
            da.Update(ds, "Pokemontable");

            Labelpositivefeedback.Text = "Pokemon created";

            //movefile if file is chosen
            if (LabelChooseImage.Text != "") {
            MoveFile(LabelChooseImage.Text);
            }

            //clear form
            TextBoxNumber.Text = "";
            TextBoxName.Text = "";
            TextBoxNextEvolution.Text = "";
            TextBoxType.Text = "";
            ImageToUpload.ImageUrl = "";
        }
        catch (Exception ex)
        {
            Labelnegativefeedback.Text = ex.Message;
        }
        finally
        {
            //close connection just to be sure
            conn.Close();
        }
    }

    public void MoveFile(string filename)
    {
        //current file path
        Tranfiles = Server.MapPath(@"~\temp\" + filename);

        //delete file if it exists
        if (File.Exists(Server.MapPath(@"~\temp\" + filename)))
        {
            // File.Delete(Server.MapPath(@"~\Images\" + Filename));
        }

        //new file path
        ProcessedFiles = Server.MapPath(@"~\Images\" + filename);

        //move file
        File.Move(Tranfiles, ProcessedFiles);
    }
}