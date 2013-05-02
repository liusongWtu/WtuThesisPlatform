using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WtuThesisPlatform.MODEL;
using System.Web.SessionState;

namespace Web.ashx.common
{
    /// <summary>
    /// 修改密码
    /// </summary>
    public class ChangePwd : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string type = context.Request["type"];
            string pwd=context.Request["oldPwd"];

            GetUserFromSession(context, type, pwd);

        }

        //从session中获取用户并验证用户密码
        private static void GetUserFromSession(HttpContext context, string type, string pwd)
        {
            if (type == "1")
            {
                Student student = context.Session["currUser"] as Student;
                if (student.SPassword.ToLower() == pwd.ToLower())
                {
                    context.Response.Write("ok");
                }
            }
            else if (type == "2")
            {
                Teacher teacher = context.Session["currUser"] as Teacher;
                if (teacher.TPassword.ToLower() == pwd.ToLower())
                {
                    context.Response.Write("ok");
                }
            }
            else if (type == "3")
            {
                Admin admin = context.Session["currUser"] as Admin;
                if (admin.UPassword.ToLower() == pwd.ToLower())
                {
                    context.Response.Write("ok");
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