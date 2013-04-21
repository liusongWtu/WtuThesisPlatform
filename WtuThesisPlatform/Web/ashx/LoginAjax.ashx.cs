using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using WtuThesisPlatform.BLL;
using WtuThesisPlatform.MODEL;

namespace Web.ashx
{
    /// <summary>
    /// CheckLogin 的摘要说明
    /// </summary>
    public class CheckLogin : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string code = context.Request["code"].Trim();
            string username = context.Request["username"].Trim();
            string password = context.Request["pwd"].Trim();
            string type = context.Request["type"].Trim();

            //验证码为空
            if (string.IsNullOrWhiteSpace(code))
            {
                context.Response.Write("codeEmpty");
                return;
            }
            //验证码错误
            if (code.ToLower() != HttpContext.Current.Session["vCode"].ToString().ToLower())
            {
                context.Response.Write("codeError");
                return;
            }

            if (type == "1")//学生
            {
                StudentBLL bll = new StudentBLL();
                Student student = bll.GetModel(username);
                if (student == null)
                {
                    context.Response.Write("userError");
                    return;
                }
                if (student.SPassword == password)
                {
                    if (student.IsDel == true)
                    {
                        context.Response.Write("del");//已被冻结
                    }
                    else
                    {
                        context.Response.Write("ok");//登录成功
                    }
                }
                else
                {
                    context.Response.Write("pwdError");//密码错误
                }
                return;
            }
            else if (type == "2")//教师
            {
            }
            else if (type == "3")//管理员
            {
            }
            else
            {
                context.Response.Write("typeError");
                return;
            }


            context.Response.Write("Hello World");
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