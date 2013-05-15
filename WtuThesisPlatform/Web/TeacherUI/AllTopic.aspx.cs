using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WtuThesisPlatform.MODEL;
using WtuThesisPlatform.BLL;

namespace Web.TeacherUI
{
    public partial class AllTopic : System.Web.UI.Page
    {
        Teacher currTeacher = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            currTeacher=Session["currUser"] as Teacher;
            if (currTeacher == null)
            {
                return;
            }
            IList<ThesisTitle> lstThesisTitle = new ThesisTitleBLL().GetAllListByTid(currTeacher.TId.ToString());
            rptThesis.DataSource = lstThesisTitle;
            rptThesis.DataBind();
        }
    }
}