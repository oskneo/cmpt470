using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;

public partial class _Default : System.Web.UI.Page
{
    private string upDir;

    protected void Page_Load(object sender, EventArgs e)
    {
        upDir = Path.Combine(Request.PhysicalApplicationPath, "imageUploads");
        if (!this.IsPostBack)
        {
            rptImgs.DataSource = GetImageNames();
            rptImgs.DataBind();
        }
    }
    
    public List<FileInfo> GetImageNames()
    {
        string imgPath = Server.MapPath("~/imageUploads/");
        List<FileInfo> images = new List<FileInfo>();

        DirectoryInfo directoryInfo = new DirectoryInfo(imgPath);
        FileInfo[] fileInfo = directoryInfo.GetFiles();

        foreach (FileInfo file in fileInfo)
        {
            images.Add(file);
        }

        return images;
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        // check if a file is being submitted
        if (FileUpload1.PostedFile.FileName != "")
        {
            // check extension
            string ext = Path.GetExtension(FileUpload1.PostedFile.FileName);
            switch (ext.ToLower())
            {
                case ".png":
                case ".jpg":
                case ".jpeg":
                    break;
                default: lblError.Text = "Unfortunately the selected file type is not currently supported, sorry...";
                    return;
            }
            // using the following 2 lines of code the file will retain its original name.
            string sfn = Path.GetFileName(FileUpload1.PostedFile.FileName);
            string fPath = Path.Combine(upDir, sfn);

            try
            {
                FileUpload1.PostedFile.SaveAs(fPath);
                rptImgs.DataSource = GetImageNames();
                rptImgs.DataBind();
            }
            catch (IOException ex)
            {
                lblError.Text = "Error uploading file: " + ex.Message;
            }
            catch (Exception er)
            {
                lblError.Text += "Unknown error: " + er.Message;
            }
        }
    }
}