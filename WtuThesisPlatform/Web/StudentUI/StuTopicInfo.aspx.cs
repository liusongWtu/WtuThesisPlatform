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
    public partial class WebForm1 : System.Web.UI.Page
    {
        Student currStudent = null;
        protected Teacher currTeacher = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            currStudent = Session["currUser"] as Student;
            if (currStudent == null)
            {
                return;
            }
            string teacherId = Request["teacherId"];
            currTeacher = new TeacherBLL().GetModel(Convert.ToInt32(teacherId));
            ThesisTitleBLL bll = new ThesisTitleBLL();
            IList<ThesisTitle> lstThesisTitle = bll.GetListByTId(teacherId);
            rptThesises.DataSource = lstThesisTitle;
            rptThesises.DataBind();
        }
    }
}