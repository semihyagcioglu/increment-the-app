using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace increment_the_app
{
    public partial class ProfilePicture : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            int userId = int.Parse(Session["userId"].ToString());
            imgProfile.Src = "Image.ashx?id=" + userId;
        }

        protected void btnUpdatePicture_Click(object sender, EventArgs e)
        {
            string userId = Session["userId"].ToString();

            string imgName = FileUpload1.FileName;           

            int imgSize = FileUpload1.PostedFile.ContentLength;

            string ext = System.IO.Path.GetExtension(this.FileUpload1.PostedFile.FileName);

            if (FileUpload1.PostedFile != null && FileUpload1.PostedFile.FileName != "")
            {

                if (FileUpload1.PostedFile.ContentLength > 1000000)
                {
                    Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Alert", "alert('Dosya boyutu çok büyük.')", true);
                }
              
                if (ext.ToUpper().Trim() != ".JPG" && ext.ToUpper() != ".PNG"  && ext.ToUpper() != ".JPEG")
                {
                    Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Alert", "alert('Lütfen sadece jpg ve png türünde resimler seçin!')", true);
                }

                else
                {
                    string id = Session["userId"].ToString();
                    byte[] myimage = new byte[FileUpload1.PostedFile.ContentLength];
                    HttpPostedFile Image = FileUpload1.PostedFile;
                    Image.InputStream.Read(myimage, 0, (int)FileUpload1.PostedFile.ContentLength);
                    Library.Users.ChangePicture(myimage,id);
                    Response.Redirect("Profile.aspx");

                }
            }
        }
    }
}
