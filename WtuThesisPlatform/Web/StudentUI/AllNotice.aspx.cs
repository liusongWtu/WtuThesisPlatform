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
    public partial class AllNotice : System.Web.UI.Page
    {
        Student currStudent = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            currStudent = Session["currUser"] as Student;
            if (currStudent == null)
            {
                return;
            }
            IList<Notice> lstNotice = new NoticeBLL().GetListBySId(currStudent);
            rptNotice.DataSource = lstNotice;
            rptNotice.DataBind();
        }
    }
}