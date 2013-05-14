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
    public partial class TeacherSelect : System.Web.UI.Page
    {
        Teacher currTeacher = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            currTeacher = Session["currUser"] as Teacher;
            if (currTeacher == null)
            {
                return;
            }
            string year = System.Configuration.ConfigurationManager.AppSettings["currentYear"];
            ThesisTitleBLL bll = new ThesisTitleBLL();
            IList<ThesisTitle> lstThesisTitle = bll.GetAllListByTId(currTeacher.TId.ToString(),year,false);
            rptThesis.DataSource = lstThesisTitle;
            rptThesis.DataBind();
        }
    }
}