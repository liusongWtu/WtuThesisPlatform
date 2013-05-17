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
    public partial class SingleWork : System.Web.UI.Page
    {
        Teacher currTeacher = null;
        protected GoodWork currGoodWork=null; 

        protected void Page_Load(object sender, EventArgs e)
        {
            currTeacher=Session["currUser"] as Teacher;
            if (currTeacher == null)
            {
                return;
            }
            string gid=Request["gid"];
            currGoodWork = new GoodWorkBLL().GetModel(Convert.ToInt32(gid));
           }

    }
}