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
    private string fileName;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ButtonBrowseImage_Click(object sender, EventArgs e)
    {
        
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
            if (ImageUpload())
            {
                newrow["Image"] = fileName;
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

    public bool ImageUpload()
    {
        if (FileUploadImage.HasFile)
        {
            //int length = FileUploadImage.PostedFile.ContentLength;
            //byte[] pic = new byte[length];

            //FileUploadImage.PostedFile.InputStream.Read(pic, 0, length);

            //getting filename
            fileName = Path.GetFileName(FileUploadImage.PostedFile.FileName);
            //save in images folder
            FileUploadImage.PostedFile.SaveAs(Server.MapPath("~/Images/") + fileName);
            //en redirect?
            //Response.Redirect(Request.Url.AbsoluteUri);

            return true;
        }
        else
        {
            return false;
        }
        /////



        //SqlConnection connection = null;
        //try
        //{
        //    //fileupload
        //    FileUpload img = (FileUpload)FileUploadImage;
        //    //byte
        //    Byte[] imgByte = null;

        //    //check
        //    if (img.HasFile && img.PostedFile != null)
        //    {
        //        //To create a PostedFile
        //        HttpPostedFile File = FileUploadImage.PostedFile;
        //        //Create byte Array with file length
        //        imgByte = new Byte[File.ContentLength];
        //        //force the control to load data in array
        //        File.InputStream.Read(imgByte, 0, File.ContentLength);
        //    }
        //    // Insert the employee name and image into db
        //    //string conn = ConfigurationManager.ConnectionStrings["EmployeeConnString"].ConnectionString;

        //    connection = new SqlConnection(@"data source = .\sqlexpress; integrated security = true; database = PokemonDB");

        //    //connection = new SqlConnection(conn);

        //    connection.Open();
        //    string sql = "INSERT INTO EmpDetails(empname,empimg) VALUES(@enm, @eimg) SELECT @@IDENTITY";
        //    SqlCommand cmd = new SqlCommand(sql, connection);
        //    cmd.Parameters.AddWithValue("@enm", txtEName.Text.Trim());
        //    cmd.Parameters.AddWithValue("@eimg", imgByte);
        //    int id = Convert.ToInt32(cmd.ExecuteScalar());
        //    lblResult.Text = String.Format("Employee ID is {0}", id);
        //}
        //catch
        //{
        //    lblResult.Text = "There was an error";
        //}
        //finally
        //{
        //    connection.Close();
        //}

    }
}