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
    public partial class TeacherSelect1 : System.Web.UI.Page
    {
        Teacher currTeacher = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            currTeacher = Session["currUser"] as Teacher;
            if (currTeacher != null)
            {
                ThesisTitleBLL bll = new ThesisTitleBLL();
                string currYear = System.Configuration.ConfigurationManager.AppSettings["currentYear"];
                IList<ThesisTitle> lstThesisTitle = bll.GetListByTId(currTeacher.TId.ToString(),currYear);
                rptThesis.DataSource = lstThesisTitle;
                rptThesis.DataBind();
            }

        }
    }
}