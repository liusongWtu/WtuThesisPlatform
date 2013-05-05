using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.TeacherUI
{
    public partial class TeacherSelect1 : System.Web.UI.Page
    {
        TeacherInfo currTeacher = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            currTeacher = Session["currUser"] as TeacherInfo;
            if (currTeacher != null)
            {
                return;
            }

        }
    }
}