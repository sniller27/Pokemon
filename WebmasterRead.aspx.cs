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

        //update gridview
        UpdateGridview();

        //populates dropdownlist if it is empty
        if (DropdownlistImages.Items.Count == 0)
        {
            UpdateDropdownlist();
        }
    }

    public void UpdateGridview()
    {
        //connection info
        SqlConnection conn = new SqlConnection(@"data source = .\sqlexpress; integrated security = true; database = PokemonDB");
        SqlDataAdapter da = null;
        DataSet ds = null;
        DataTable dt = null;
        //query
        string sqlsel = "select * from Pokemon order by PokemonId";

        try
        {
            //new data adapter
            da = new SqlDataAdapter();

            //new command
            da.SelectCommand = new SqlCommand(sqlsel, conn);

            //new dataset
            ds = new DataSet();
            //get data from DB to dataset
            da.Fill(ds, "Pokemontable");
            //create datatable and get data from dataset
            dt = ds.Tables["Pokemontable"];

            //populate gridview by using data in data table
            GridViewPokemonTable.DataSource = dt;
            GridViewPokemonTable.DataBind();
        }
        catch (Exception ex)
        {
            LabelError.Text = ex.Message;
        }
        finally
        {
            //DA closes automatically, but let's close connection just in case.
            conn.Close();
        }
    }

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

            cb = new SqlCommandBuilder(da);

            //new data set
            ds = new DataSet();
            //fill data set
            da.Fill(ds, "Pokemontable");
            //fill data table
            dt = ds.Tables["Pokemontable"];

            //deletes row with PokemonId by iterating rows
            foreach (DataRow myrow in dt.Select("PokemonId =" + Convert.ToInt32(chosenrow)))
            {
                myrow.Delete();
            }

            //update DA
            da.Update(ds, "Pokemontable");

            //feedback
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
        ImageToUpload.ImageUrl = "";
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
        //connection info
        SqlConnection conn = new SqlConnection(@"data source = .\sqlexpress; integrated security = true; database = PokemonDB");
        SqlDataAdapter da = null;
        DataSet ds = null;
        DataTable dt = null;
        SqlCommand cmd = null;
        //SQL queries
        string sqlsel = "select * from pokemon";
        string sqlupd = "update pokemon set Number = @pokedex, Name = @pokename, NextEvolution = @nextevolution, Image = @image, Type = @type where PokemonId = @pokemonid";

        try
        {
            //new DA
            da = new SqlDataAdapter();

            //new command
            da.SelectCommand = new SqlCommand(sqlsel, conn);
            //new dataset
            ds = new DataSet();
            //fill dataset
            da.Fill(ds, "AdminPokemon");
            //fill data table
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

            //set command for adapter
            da.UpdateCommand = cmd;

            //adapter sync
            da.Update(ds, "AdminPokemon");

            //update gridview
            UpdateGridview();

            //feedback
            LabelSucces.Text = "Updated";

            //clear form
            TextboxPokedex.Text = "";
            TextboxPokemonName.Text = "";
            TextboxNextEvolution.Text = "";
            TextboxType.Text = "";
            DropdownlistImages.ClearSelection();
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

        //gets file urls, shortens them and adds to dropdownlist
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
        //if file is chosen then get file name and upload to temp
        if (FileUploadImage.HasFile)
        {
            //getting filename
            fileName = Path.GetFileName(FileUploadImage.PostedFile.FileName);
            //save in images folder
            FileUploadImage.PostedFile.SaveAs(Server.MapPath("~/temp/") + fileName);
        }

        //show chosen image
        ImageToUpload.ImageUrl = @"~\temp\" + fileName;

        //show filename
        LabelChooseImage.Text = fileName;
    }

    public void MoveFile(string filename)
    {
        //if file is chosen
        if (LabelChooseImage.Text != "")
        {
        //define current file location
        Tranfiles = Server.MapPath(@"~\temp\" + filename);
        //delete file
        if (File.Exists(Server.MapPath(@"~\temp\" + filename)))
        {
            // File.Delete(Server.MapPath(@"~\Images\" + Filename));
        }

        //define new file location
        ProcessedFiles = Server.MapPath(@"~\Images\" + filename);
        
        //move file
        File.Move(Tranfiles, ProcessedFiles);
        
        //update dropdownlist
        UpdateDropdownlist();
        }
    }
}