using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WtuThesisPlatform.MODEL;
using WtuThesisPlatform.BLL;

namespace Web.StudentUI
{
    public partial class PublishGoodWork : System.Web.UI.Page
    {
        Student currStudent = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            currStudent=Session["currUser"] as Student;
            if (currStudent == null)
            {
                return;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Value)|| string.IsNullOrEmpty(txtContent.Value))
            {
                return;
            }
            GoodWork goodWork = new GoodWork();
            goodWork.GTitle = txtName.Value;
            goodWork.GContent = txtContent.Value;
            goodWork.Student = currStudent;
            goodWork.GTime = DateTime.Now;
            if (fileUpImage.HasFile)
            {
                string name=DateTime.Now.ToString("yyyyMMddhhmm")+fileUpImage.FileName;
                fileUpImage.PostedFile.SaveAs(Server.MapPath("~/images/goodwork/" + name));
                goodWork.GCoverPic = name;
            }
            else
            {
                goodWork.GCoverPic = "1.gif";
            }
            GoodWorkBLL goodWorkBll = new GoodWorkBLL();
            if (goodWorkBll.Add(goodWork) > 0)
            {
                btnSubmit.Attributes.Add("isSaved", "saved");
            }
        }
    }
}