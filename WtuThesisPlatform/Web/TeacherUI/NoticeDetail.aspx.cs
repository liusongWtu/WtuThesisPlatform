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
    public partial class NoticeDetail : System.Web.UI.Page
    {
        Teacher currTeacher = null;
        protected Notice currNotice = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            currTeacher=Session["currUser"] as Teacher;
            if (currTeacher == null)
            {
                return;
            }
            string nid=Request["nid"];
            currNotice = new NoticeBLL().GetModel(Convert.ToInt32(nid));
            
            NewNoticeBLL newNoticeBll = new NewNoticeBLL();
            newNoticeBll.Del(currNotice.NId, currTeacher.TId,2);
        }
    }
}