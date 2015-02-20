using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace testJuniorDev
{
    public partial class index : System.Web.UI.Page
    {
        FileContent f = new FileContent();
        List<string> array = new List<string>();
        string resulString = "1,6,11" + Environment.NewLine + Environment.NewLine + "2,7,12" + Environment.NewLine + Environment.NewLine + "3,8,13" + Environment.NewLine + Environment.NewLine + "4,9,14";

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        private void validateUpload()
        {
            try
            {
                string ext = System.IO.Path.GetExtension(this.FileUpload1.PostedFile.FileName);
                

                if (ext != ".txt")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "OpenDialog", "javascript:alert('Error, file extension no valid !!');", true);
                }

                if (FileUpload1.FileName != null && ext == ".txt")
                {
                    this.lblFileName.Text = FileUpload1.FileName.Replace(".txt", "");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "OpenDialog", "javascript:alert('File dont have a Name !!');", true);
                }

                byte[] content = this.FileUpload1.FileBytes;
                
                f.Content = System.Text.Encoding.UTF8.GetString(content);
                array.Add(f.Content);

                if (array.Count >= 1)
                {
                    this.txtContent.Text = array.FirstOrDefault();
                    string fileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                    string dirUpload = Server.MapPath("~/Uploads/");

                    FileUpload1.PostedFile.SaveAs(dirUpload + fileName);
                    System.IO.File.WriteAllText(dirUpload + fileName, string.Empty);
                    System.IO.File.WriteAllText(dirUpload + fileName, resulString);
                    string content2 = System.IO.File.ReadAllText(dirUpload + fileName);
                    this.txtContent.Text = content2;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "OpenDialog", "javascript:openDialog();", true);                 
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "OpenDialog", "javascript:alert('This file is Empty !!');", true);

                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

            
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            this.validateUpload();
        }

    }

    public class FileContent
    {
        private string _content;

        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }
    }
}