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
        //upload listener
        FileUploadImage.Attributes["onchange"] = "UploadFile(this)";


        //////checks if file has been chosen on postback
        //if (IsPostBack && FileUploadImage.HasFile != null)
        //{
        //    //upload file to temp
        //    ImageUpload();

        //    //display image
        //    ImageToUpload.ImageUrl = @"~\temp\" + fileName;

        //    //display image title
        //    LabelChooseImage.Text = fileName;
        //}
    }

    protected void Upload(object sender, EventArgs e)
    {
        //FileUploadImage.SaveAs(Server.MapPath("~/Uploads/" + Path.GetFileName(FileUpload1.FileName)));

        if (FileUploadImage.HasFile)
        {
            //getting filename
            fileName = Path.GetFileName(FileUploadImage.PostedFile.FileName);
            //save in images folder
            FileUploadImage.PostedFile.SaveAs(Server.MapPath("~/temp/") + fileName);
            //en redirect?
            //Response.Redirect(Request.Url.AbsoluteUri);

        Labelpositivefeedback.Text = "uploaded to temp";
        }

        //show image
        ImageToUpload.ImageUrl = @"~\temp\" + fileName;

        LabelChooseImage.Text = fileName;
    }

    protected void ButtonCreatePokemon_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(@"data source = .\sqlexpress; integrated security = true; database = PokemonDB");
        SqlDataAdapter da = null;
        DataSet ds = null;
        DataTable dt = null;
        SqlCommand cmd = null;
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
            if (LabelChooseImage.Text != "")
            {
                newrow["Image"] = LabelChooseImage.Text;
            }
            else
            {
                newrow["Image"] = null;
            }
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

            //movefile
            if (LabelChooseImage.Text != "") {
            MoveFile(LabelChooseImage.Text);
            }

        }
        catch (Exception ex)
        {
            Labelnegativefeedback.Text = ex.Message;
            throw;
        }
        finally
        {
            //close connection just to be sure
            conn.Close();
        }
    }

    public void MoveFile(string filename)
    {
        //send image to image folder
        //Tranfiles = Server.MapPath(@"~\godurian\sth100\transfiles\" + Filename);

        Tranfiles = Server.MapPath(@"~\temp\" + filename);
        if (File.Exists(Server.MapPath(@"~\temp\" + filename)))
        {
            // File.Delete(Server.MapPath(@"~\Images\" + Filename));
        }

        //ProcessedFiles = Server.MapPath(@"~\godurian\sth100\ProcessedFiles");
        ProcessedFiles = Server.MapPath(@"~\Images\" + filename);

        File.Move(Tranfiles, ProcessedFiles);
    }
}