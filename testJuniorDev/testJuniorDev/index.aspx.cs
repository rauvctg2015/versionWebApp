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
                string[,] numbers = new string[f.Content.Length, f.Content.Length];

                for (int i = 0; i < f.Content.Length; i++)
                {
                    if (f.Content[i].ToString() != ",")
                    {
                        int intvariable;
                        if (Int32.TryParse(f.Content[i].ToString(), out intvariable) && i + 1 < f.Content.Length)
                        {
                            if (Int32.TryParse(f.Content[i + 1].ToString(), out intvariable))
                            {
                                array.Add(f.Content[i].ToString() + f.Content[i + 1].ToString());
                                i = i + 1;
                            }
                            else
                            {
                                array.Add(f.Content[i].ToString());
                            }  
                        }
                    }
                    
                }

                List<string> arrayFiltrado = new List<string>();
                foreach (var item in array)
                {
                    if (Convert.ToInt32(item) % 5 != 0)
                    {
                        arrayFiltrado.Add(item);
                    }
                }

                if (array.Count >= 1)
                {

                    foreach (var item in arrayFiltrado)
                    {
                       int intVariable;
                       if (Int32.TryParse(item, out intVariable))
                       {

                            int firstNumber, secondNumber;
                            firstNumber = intVariable +5;
                            secondNumber = intVariable + 10;
                            if (this.txtContent.Text.Contains(item.Last()))
                            {
                                break;
                            }
                            if(Convert.ToInt32(item) < firstNumber && Convert.ToInt32(item) < secondNumber)
                            {
                                this.txtContent.Text += intVariable + ", " + (intVariable + 5) + ", " + (intVariable + 10); this.txtContent.Text += "\n\r";
                            }
                       }
                         
                    }

                    string fileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                    string dirUpload = Server.MapPath("~/Uploads/");
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