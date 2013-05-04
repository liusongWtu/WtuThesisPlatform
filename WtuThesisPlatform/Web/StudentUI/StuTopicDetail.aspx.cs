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
    public partial class StuTopicDetail : System.Web.UI.Page
    {
        Student currStudent = null;
        protected ThesisTitle currThesisTitle = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            currStudent = Session["currUser"] as Student;
            if (currStudent != null)
            {
                string thesisTitleId=Request["thesisId"];
                currThesisTitle=new ThesisTitleBLL().GetModel(Convert.ToInt32 (thesisTitleId));

            }
        }
    }
}