using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using WtuThesisPlatform.MODEL;
using WtuThesisPlatform.BLL;
using System.Text;

namespace Web.ashx.teacher
{
    /// <summary>
    /// TeacherSelect 的摘要说明
    /// </summary>
    public class TeacherSelect : IHttpHandler, IRequiresSessionState
    {
        HttpContext context = null;
        Teacher currTeacher = null;

        public void ProcessRequest(HttpContext context)
        {
            this.context = context;
            context.Response.ContentType = "text/plain";
            currTeacher=context.Session["currUser"] as Teacher;
            string operate = context.Request["operate"];
            switch (operate)
            {
                case "select":
                    SelectStudent();
                    break;
                case "cancel":
                    DelStudent();
                    break;
                default:
                    break;
            }
        }

        //退选
        private void DelStudent()
        {

        }

        //选择学生
        private void SelectStudent()
        {
            if (currTeacher.TTeachNum <= currTeacher.CurrNum)
            {
                context.Response.Write("SelectFull");
                return;
            }
            string thesisTitleId=context.Request["tid"];
            string studentId=context.Request["sid"];
            ThesisTitle thesisTitle = new ThesisTitleBLL().GetModel(Convert.ToInt32(thesisTitleId));
            if (thesisTitle.TNumber <= thesisTitle.TAcceptNum)
            {
                context.Response.Write("ThesisFull");
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("update ThesisSelected set TPassed=1 where TId="+thesisTitleId);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}