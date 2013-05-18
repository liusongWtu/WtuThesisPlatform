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
    public partial class AddNotice : System.Web.UI.Page
    {
        Admin currAdmin = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            currAdmin=Session["currUser"] as Admin;
            if (currAdmin == null)
                return;

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
            notice.NLevel = 1;
            notice.NName = currAdmin.UName;
            notice.NPublisherId = currAdmin.UId;
            notice.NPublishUnits = txtUnits.Value;
            notice.NPublishTime = DateTime.Now;
            notice.NTitle = txtName.Value;
            notice.NContent = txtContent.Value;
            notice.NDeadTime = DateTime.Parse(deadLine.Value);

            if (bll.Add(notice) > 0)
            {
                string year = System.Configuration.ConfigurationManager.AppSettings["currentYear"];
                TeacherBLL teacherBll = new TeacherBLL();
                IList<int> lstTeacher = teacherBll.GetAllTId();
                NewNoticeBLL newNoticeBll = new NewNoticeBLL();
                foreach (int item in lstTeacher)
                {
                    NewNotice newNotice = new NewNotice();
                    newNotice.NoticeId = notice.NId;
                    newNotice.NUserId = item;
                    newNotice.NUserType = 2;
                    newNoticeBll.Add(newNotice);
                }

                StudentBLL studentBll = new StudentBLL();
                IList<int> lstStudent = studentBll.GetAllSId();
                foreach (int item in lstStudent)
                {
                    NewNotice newNotice = new NewNotice();
                    newNotice.NoticeId = notice.NId;
                    newNotice.NUserId = item;
                    newNotice.NUserType = 1;
                    newNoticeBll.Add(newNotice);
                }

                btnSubmit.Attributes.Add("isSaved", "saved");
            }
        }
    }
}