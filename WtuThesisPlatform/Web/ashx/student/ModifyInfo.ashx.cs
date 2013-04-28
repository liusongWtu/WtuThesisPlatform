using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WtuThesisPlatform.MODEL;
using System.Web.SessionState;
using Web.Common;
using WtuThesisPlatform.BLL;

namespace Web.ashx.student
{
    /// <summary>
    /// ModifyInfo 的摘要说明
    /// </summary>
    public class ModifyInfo : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string departmentId = context.Request["did"].Trim();
            string majorId = context.Request["mid"].Trim();
            string classId = context.Request["cid"].Trim();
            string phone = context.Request["phone"].Trim();
            string email = context.Request["email"].Trim();
            string qq = context.Request["qq"].Trim();

            Student currSutdent = context.Session["currUser"] as Student;
            //修改前保存当前用户，修改失败时以还原
            Student oldStudent = currSutdent.Clone(true);

            currSutdent.Department.DId = Convert.ToInt32(departmentId);
            currSutdent.Major.MId = Convert.ToInt32(majorId);
            currSutdent.ClassInfo.CId = Convert.ToInt32(classId);
            currSutdent.SPhone = phone;
            currSutdent.SEmail = email;
            currSutdent.SQQ = qq;

            StudentBLL bll = new StudentBLL();
            if (bll.Update(currSutdent) > 0)
            {
                context.Response.Write("ok");
            }
            else
            {
                context.Session["currUser"] = oldStudent;
                context.Response.Write("error");
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