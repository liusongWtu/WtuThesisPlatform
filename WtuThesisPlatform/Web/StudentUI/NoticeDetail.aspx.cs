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
    public partial class NoticeDetail : System.Web.UI.Page
    {
        Student currStudent = null;
        protected Notice currNotice = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            currStudent = Session["currUser"] as Student;
            if (currStudent == null)
            {
                return;
            }
            string nid = Request["nid"];
            currNotice = new NoticeBLL().GetModel(Convert.ToInt32(nid));

            NewNoticeBLL newNoticeBll = new NewNoticeBLL();
            newNoticeBll.Del(currNotice.NId, currStudent.SId, 1);
        }
    }
}