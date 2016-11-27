using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebmasterRead : System.Web.UI.Page
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

        UpdateGridview();
        if (DropdownlistImages.Items.Count == 0)
        {
            UpdateDropdownlist();
        }
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
        MoveFile(LabelChooseImage.Text);
    }

    protected void GridViewPokemonTable_SelectedIndexChanged(object sender, EventArgs e)
    {
        //populate update fields
        TextboxPokedex.Text = GridViewPokemonTable.SelectedRow.Cells[3].Text;
        TextboxPokemonName.Text = GridViewPokemonTable.SelectedRow.Cells[4].Text;
        TextboxNextEvolution.Text = GridViewPokemonTable.SelectedRow.Cells[5].Text;
        TextboxType.Text = GridViewPokemonTable.SelectedRow.Cells[7].Text;
        DropdownlistImages.Text = GridViewPokemonTable.SelectedRow.Cells[6].Text;
    }


    protected void ButtonUpdate_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(@"data source = .\sqlexpress; integrated security = true; database = PokemonDB");
        SqlDataAdapter da = null;
        DataSet ds = null;
        DataTable dt = null;
        SqlCommand cmd = null;
        string sqlsel = "select * from pokemon";
        //string sqlupd = "update shippers set companyname = @companyname, phone = @phone where shipperid = @shipperid";
        string sqlupd = "update pokemon set Number = @pokedex, Name = @pokename, NextEvolution = @nextevolution, Image = @image, Type = @type where PokemonId = @pokemonid";

        try
        {
            //instantiate
            da = new SqlDataAdapter();

            //fill data table with data
            da.SelectCommand = new SqlCommand(sqlsel, conn);
            ds = new DataSet();
            da.Fill(ds, "AdminPokemon");
            dt = ds.Tables["AdminPokemon"];

            //change rows in data table
            int mytableindex = GridViewPokemonTable.SelectedIndex;
            dt.Rows[mytableindex]["Number"] = TextboxPokedex.Text;
            dt.Rows[mytableindex]["Name"] = TextboxPokemonName.Text;
            dt.Rows[mytableindex]["NextEvolution"] = TextboxNextEvolution.Text;
            dt.Rows[mytableindex]["Image"] = DropdownlistImages.SelectedValue;
            dt.Rows[mytableindex]["Type"] = TextboxType.Text;

            //new sqlcommand
            cmd = new SqlCommand(sqlupd, conn);
            //add parameters
            cmd.Parameters.Add("@pokedex", SqlDbType.Int, 50, "Number");
            cmd.Parameters.Add("@pokename", SqlDbType.Text, 50, "Name");
            cmd.Parameters.Add("@nextevolution", SqlDbType.Text, 50, "NextEvolution");
            cmd.Parameters.Add("@image", SqlDbType.Text, 50, "Image");
            cmd.Parameters.Add("@type", SqlDbType.Text, 50, "Type");
            cmd.Parameters.Add("@pokemonid", SqlDbType.Int, 50, "PokemonId");

            //extra parameter for security reasons. if someone changes id by mistake.
            //SqlParameter parm = cmd.Parameters.Add("@shipperid", SqlDbType.Int, 4, "shipperid");
            //parm.SourceVersion = DataRowVersion.Original;

            //set command for adapter
            da.UpdateCommand = cmd;
            //adapter sync
            da.Update(ds, "AdminPokemon");

            //update gridview
            UpdateGridview();

            LabelSucces.Text = "Updated";
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
    }

    public void UpdateDropdownlist() {

        DropdownlistImages.Items.Clear();


        //giver lange urls
        try
        {
            DirectoryInfo Dir = new DirectoryInfo(Server.MapPath("~/Images/"));
            FileInfo[] FileList = Dir.GetFiles("*.*", SearchOption.AllDirectories);
            foreach (FileInfo FI in FileList)
            {
                DropdownlistImages.Items.Add(Path.GetFileName(FI.FullName));
            }
        }
        catch (Exception ex)
        {
            LabelError.Text = ex.Message;
        }
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
        }

        //show image
        ImageToUpload.ImageUrl = @"~\temp\" + fileName;

        LabelChooseImage.Text = fileName;
    }

    public void MoveFile(string filename)
    {
        if (LabelChooseImage.Text != "")
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

        UpdateDropdownlist();
        }
    }
}