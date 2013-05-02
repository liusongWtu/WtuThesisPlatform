using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using WtuThesisPlatform.MODEL;
using WtuThesisPlatform.BLL;

namespace Web.ashx.common
{
    /// <summary>
    /// ChangePwd1 的摘要说明
    /// </summary>
    public class ChangePwd1 : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string type = context.Request["type"];
            string oldPwd=context.Request["oldPwd"];
            string newPwd=context.Request["newPwd"];

            if (type == "1")
            {
                Student student = context.Session["currUser"] as Student;
                if (student.SPassword.ToLower() == oldPwd.ToLower())
                {
                    student.SPassword=newPwd;
                    StudentBLL bll = new StudentBLL();
                    if (bll.Update(student) > 0)
                    {
                        context.Response.Write("ok");
                    }
                }
            }
            else if (type == "2")
            {
                Teacher teacher = context.Session["currUser"] as Teacher;
                if (teacher.TPassword.ToLower() == oldPwd.ToLower())
                {
                    teacher.TPassword = newPwd;
                    TeacherBLL bll = new TeacherBLL();
                    if (bll.Update(teacher)>0)
                    {
                        context.Response.Write("ok");
                    }
                }
            }
            else if (type == "3")
            {
                Admin admin = context.Session["currUser"] as Admin;
                if (admin.UPassword.ToLower() == oldPwd.ToLower())
                {
                    admin.UPassword = newPwd;
                    AdminBLL bll = new AdminBLL();
                    if (bll.Update(admin) > 0)
                    {
                        context.Response.Write("ok");
                    }
                }
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