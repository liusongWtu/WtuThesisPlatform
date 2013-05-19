using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WtuThesisPlatform.MODEL;
using WtuThesisPlatform.BLL;

namespace Web.AdminUI
{
    public partial class TeacherApplyDetail : System.Web.UI.Page
    {
        Admin currAdmin = null;
        protected ThesisTitle currThesisTitle = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            currAdmin = Session["currUser"] as Admin;
            if (currAdmin == null)
            {
                return;
            }
            string tid = Request["tid"];
            currThesisTitle = new ThesisTitleBLL().GetModel(Convert.ToInt32(tid));
        }
    }
}