using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WtuThesisPlatform.MODEL;
using WtuThesisPlatform.BLL;
using System.Text;

namespace Web.TeacherUI
{
    public partial class PublishNotice : System.Web.UI.Page
    {
        Teacher currTeacher = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            currTeacher=Session["currUser"] as Teacher;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!IsValid)
            {
                Response.End();
            } 
            if (string.IsNullOrEmpty(txtName.Value) || string.IsNullOrEmpty(txtUnits.Value) ||
                string.IsNullOrEmpty(txtUnits.Value) || string.IsNullOrEmpty(deadLine.Value))
            {
                return;
            }
            NoticeBLL bll = new NoticeBLL();
            Notice notice = new Notice();
            notice.NLevel = 2;
            notice.NName = currTeacher.TName;
            notice.NPublisherId = currTeacher.TId;
            notice.NPublishUnits = txtUnits.Value;
            notice.NPublishTime = DateTime.Now;
            notice.NTitle = txtName.Value;
            notice.NContent = txtContent.Value;
            notice.NDeadTime = DateTime.Parse(deadLine.Value);

            if (bll.Add(notice ) > 0)
            {
                string year = System.Configuration.ConfigurationManager.AppSettings["currentYear"];
                TeacherBLL teacherBll = new TeacherBLL();
                IList<int> lstStudent = teacherBll.GetTeachStudent(currTeacher.TId, year);
                NewNoticeBLL newNoticeBll = new NewNoticeBLL();
                foreach (int item in lstStudent)
                {
                    NewNotice newNotice = new NewNotice();
                    newNotice.NoticeId = notice.NId;
                    newNotice.NUserId = currTeacher.TId;
                    newNotice.NUserType = 1;
                    newNoticeBll.Add(newNotice);
                }
                btnSubmit.Attributes.Add("isSaved","saved");
            }
        }
    }
}