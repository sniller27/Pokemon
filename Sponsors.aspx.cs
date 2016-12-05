using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class Sponsors : System.Web.UI.Page
{
    private DataSet ds;
    private DataTable dt;
    private int allsponsers = 0;
    private string fileName, Tranfiles, ProcessedFiles;

    protected void Page_Load(object sender, EventArgs e)
    {
        //upload listener
        FileUploadCreateImage.Attributes["onchange"] = "UploadFile(this)";
        FileUploadUpdateImage.Attributes["onchange"] = "UploadFile(this)";

        if (!IsPostBack)
        {
            PopulateDropdownlist();
        }
        else
        {
            Control c = GetPostBackControl(this.Page);

            if (c != null)
            {
                if (DropDownListUpdateChooseSponser.SelectedIndex != 0 && c.ID != "ButtonUpdateSponsor")
                {
                    ds = new DataSet();
                    //get data
                    ds.ReadXml(Server.MapPath(@"~/XML/Sponsors.xml"));
                    //navnet er ikke selvalgt her
                    dt = ds.Tables["Sponsor"];

                    foreach (DataRow r in dt.Select("SponsorID = " + Convert.ToInt32(DropDownListUpdateChooseSponser.SelectedValue)))
                    {
                        TextBoxUpdateCompanyName.Text = r["CompanyName"].ToString();
                        TextBoxUpdateCompanyWebsite.Text = r["Website"].ToString();
                        ImageUpdate.ImageUrl = "Images/sponsors/" + r["LogoUrl"].ToString();
                        LabelUpdateChooseImage.Text = r["LogoUrl"].ToString();
                    }

                }
            }

        }
    }

    private void PopulateDropdownlist()
    {
        try
        {
            ds = new DataSet();
            //get data
            ds.ReadXml(Server.MapPath(@"~/XML/Sponsors.xml"));
            //navnet er ikke selvalgt her
            dt = ds.Tables["Sponsor"];

            DropDownListUpdateChooseSponser.DataSource = dt;
            DropDownListUpdateChooseSponser.DataTextField = dt.Columns[1].ToString();
            DropDownListUpdateChooseSponser.DataValueField = dt.Columns[0].ToString();
            DropDownListUpdateChooseSponser.DataBind();

        }
        catch (Exception ex)
        {
            //hvis der ikke findes XML fil så laves der et nyt datatable
            //MakeNewDataSetAndDataTable();
        }
        finally
        {
            //dropdown list default value
            DropDownListUpdateChooseSponser.Items.Insert(0, "Choose sponsor");
        }
    }

    protected void ButtonCreateSponsor_Click(object sender, EventArgs e)
    {
        try
        {
            ds = new DataSet();
            //get XML data for dataset
            ds.ReadXml(Server.MapPath(@"~/XML/Sponsors.xml"));
            //use dataset for data table and use child element of root
            dt = ds.Tables["Sponsor"];
        }
        catch (Exception)
        {
            //xml file doesn't exist
            //MakeNewDataSetAndDataTable();
        }

        
        if (dt == null)
        {
            //MakeNewDataSetAndDataTable();
        }
        else
        {
            foreach (DataRow r in dt.Rows)
            {
                if (Convert.ToInt32(r["SponsorID"].ToString()) > allsponsers) allsponsers = Convert.ToInt32(r["SponsorID"].ToString());
            }
        }

        DataRow newRow = dt.NewRow();
        newRow["SponsorID"] = allsponsers + 1;
        newRow["CompanyName"] = TextBoxAddCompanyName.Text;
        newRow["Website"] = TextBoxAddCompanyWebsite.Text;
        newRow["LogoUrl"] = LabelCreateChooseImage.Text;
        dt.Rows.Add(newRow);

        ds.WriteXml(Server.MapPath(@"~/XML/Sponsors.xml"));
        MoveFile(LabelCreateChooseImage.Text);

        LabelAddPosFeedback.Text = "Sponsor added!";

        //clear form
        TextBoxAddCompanyName.Text = "";
        TextBoxAddCompanyWebsite.Text = "";
        LabelCreateChooseImage.Text = "";
        ImageCreate.ImageUrl = "";

        //update dropdownlist
        PopulateDropdownlist();
    }

    protected void Upload(object sender, EventArgs e)
    {
        if (FileUploadCreateImage.HasFile || FileUploadUpdateImage.HasFile)
        {
            
        }

        //show image
        if (FileUploadCreateImage.HasFile)
        {
            //getting filename
            fileName = Path.GetFileName(FileUploadCreateImage.PostedFile.FileName);
            //save in images folder
            FileUploadCreateImage.PostedFile.SaveAs(Server.MapPath("~/temp/") + fileName);

            ImageCreate.ImageUrl = @"~\temp\" + fileName;
            //show filename
            LabelCreateChooseImage.Text = fileName;
        }
        else if(FileUploadUpdateImage.HasFile)
        {
            //getting filename
            fileName = Path.GetFileName(FileUploadUpdateImage.PostedFile.FileName);
            //save in images folder
            FileUploadUpdateImage.PostedFile.SaveAs(Server.MapPath("~/temp/") + fileName);

            ImageUpdate.ImageUrl = @"~\temp\" + fileName;
            //show filename
            LabelUpdateChooseImage.Text = fileName;
        }
    }

    protected void ButtonDelete_Click(object sender, EventArgs e)
    {
        ds = new DataSet();
        //from XML-file to data set
        ds.ReadXml(Server.MapPath(@"~/XML/Sponsors.xml"));
        //give data to data table
        dt = ds.Tables["Sponsor"];

        foreach (DataRow r in dt.Select("SponsorID = " + DropDownListUpdateChooseSponser.SelectedValue))
        {
            r.Delete();
        }

        ds.WriteXml(Server.MapPath(@"~/XML/Sponsors.xml"));
        LabelUpPosFeedback.Text = "Sponsor deleted";

        //update dropdownlist
        PopulateDropdownlist();

        //reset form
        TextBoxUpdateCompanyName.Text = "";
        TextBoxUpdateCompanyWebsite.Text = "";
        ImageUpdate.ImageUrl = "";
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
        ProcessedFiles = Server.MapPath(@"~\Images\sponsors\" + filename);

        //move file
        File.Move(Tranfiles, ProcessedFiles);
    }

    protected void ButtonUpdateSponsor_Click(object sender, EventArgs e)
    {
        ds = new DataSet();
        //get data from XML-file to data set
        ds.ReadXml(Server.MapPath(@"~/XML/Sponsors.xml"));
        //give data to data table
        dt = ds.Tables["Sponsor"];

        foreach (DataRow r in dt.Select("SponsorID = " + DropDownListUpdateChooseSponser.SelectedValue))
        {
            r["SponsorID"] = Convert.ToInt32(DropDownListUpdateChooseSponser.SelectedValue);
            r["CompanyName"] = TextBoxUpdateCompanyName.Text;
            r["Website"] = TextBoxUpdateCompanyWebsite.Text;
            r["LogoUrl"] = LabelUpdateChooseImage.Text;
            //LabelUpPosFeedback.Text = r["CompanyName"].ToString();
        }

        ds.WriteXml(Server.MapPath(@"~/XML/Sponsors.xml"));

        //move file
        var relativePath = "~/Images/sponsors/" + LabelUpdateChooseImage.Text;
        var absolutePath = Server.MapPath(relativePath);
        if (System.IO.File.Exists(absolutePath) == false)
        {
            MoveFile(LabelUpdateChooseImage.Text);
        }

        //refresh dropdownlist
        PopulateDropdownlist();

        //clear form
        TextBoxUpdateCompanyName.Text = "";
        TextBoxUpdateCompanyWebsite.Text = "";
        ImageUpdate.ImageUrl = "";
        LabelUpdateChooseImage.Text = "";

        //feedback
        LabelUpPosFeedback.Text = "Sponsor Updated";
    }

    public static Control GetPostBackControl(Page page)
    {
        Control control = null;
        string ctrlname = page.Request.Params.Get("__EVENTTARGET");
        if (ctrlname != null && ctrlname != String.Empty)
        {
            control = page.FindControl(ctrlname);

        }
        else
        {
            foreach (string ctl in page.Request.Form)
            {
                Control c = page.FindControl(ctl);
                if (c is System.Web.UI.WebControls.Button)
                {
                    control = c;
                    break;
                }
            }

        }
        return control;
    }
}