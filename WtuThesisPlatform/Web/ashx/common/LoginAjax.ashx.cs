using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using WtuThesisPlatform.BLL;
using WtuThesisPlatform.MODEL;
using Web.Common;

namespace Web.ashx
{
    /// <summary>
    /// CheckLogin 的摘要说明
    /// </summary>
    public class CheckLogin : IHttpHandler, IRequiresSessionState
    {
        string code = string.Empty;
        string username = string.Empty;
        string password = string.Empty;
        string type = string.Empty;
        string isRemember = string.Empty;

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            code = context.Request["code"].Trim();
            username = context.Request["username"].Trim();
            password = context.Request["pwd"].Trim();
            type = context.Request["type"].Trim();
            isRemember = context.Request["isremember"].Trim();

            //todo:取消下面注释即可添加验证功能
            //验证码为空
            //if (string.IsNullOrWhiteSpace(code))
            //{
            //    context.Response.Write("codeEmpty");
            //    return;
            //}
            ////验证码错误
            //if (code.ToLower() != HttpContext.Current.Session["vCode"].ToString().ToLower())
            //{
            //    context.Response.Write("codeError");
            //    return;
            //}

            LoginManager(context);
        }

        /// <summary>
        /// 验证用户信息，并设置用户状态信息
        /// </summary>
        /// <param name="context"></param>
        private void LoginManager(HttpContext context)
        {
            switch (type)
            {
                case "1"://学生
                    if (System.Configuration.ConfigurationManager.AppSettings["studentOpen"] != "yes")
                    {
                        context.Response.Write("close");
                        return;
                    }
                    StudentBLL studentBll = new StudentBLL();
                    Student student = studentBll.GetModel(username);
                    if (student == null)
                    {
                        context.Response.Write("userError");
                        return;
                    }
                    password = CommonCode.Md5Compute(password);
                    if (student.SPassword.ToLower() == password.ToLower())
                    {
                        bool isDel = student.IsDel;
                        if (isDel)//已被冻结
                        {
                            context.Response.Write("del");
                        }
                        else
                        {
                            context.Session["currUser"] = student;
                            HttpCookie currUser = new HttpCookie("loginId", student.SNo);
                            context.Response.Cookies.Add(currUser);
                            if (isRemember == "1")//记住我被选中了
                            {
                                string encryptPwd =CommonCode.Encrypt(student.SPassword);
                                HttpCookie currPwd = new HttpCookie("pwd", encryptPwd);
                                HttpCookie currType = new HttpCookie("userType", "1");
                                currUser.Expires = currPwd.Expires = currType.Expires =                                             DateTime.Now.AddYears(10);
                                context.Response.Cookies.Add(currPwd);
                                context.Response.Cookies.Add(currType);
                            }
                            context.Response.Write("ok");//登录成功
                        }
                    }
                    else
                    {
                        context.Response.Write("pwdError");//密码错误
                    }
                    break;
                case "2"://教师
                    if (System.Configuration.ConfigurationManager.AppSettings["studentOpen"] != "yes")
                    {
                        context.Response.Write("close");
                        return;
                    }
                    TeacherBLL teacherBll = new TeacherBLL();
                    Teacher teacher = teacherBll.GetModel(username);
                    if (teacher == null)
                    {
                        context.Response.Write("userError");
                        return;
                    }
                    password = CommonCode.Md5Compute(password);
                    if (teacher.TPassword.ToLower() == password.ToLower())
                    {
                        if (teacher.IsDel == true)
                        {
                            context.Response.Write("del");
                        }
                        else
                        {
                            context.Session["currUser"] = teacher;
                            HttpCookie currUser = new HttpCookie("loginId", teacher.TNo);
                            context.Response.Cookies.Add(currUser);
                            if (isRemember == "1")
                            {
                                string encryptPwd = CommonCode.Encrypt(teacher.TPassword);
                                HttpCookie currPwd = new HttpCookie("pwd", encryptPwd);
                                HttpCookie currType = new HttpCookie("userType", "2");
                                currUser.Expires = currPwd.Expires = currType.Expires = DateTime.Now.AddYears(10);
                                context.Response.Cookies.Add(currPwd);
                                context.Response.Cookies.Add(currType);
                            }
                            context.Response.Write("ok");
                        }
                    }
                    else
                    {
                        context.Response.Write("pwdError");
                    }
                    break;
                case "3"://管理员
                    AdminBLL bll = new AdminBLL();
                    Admin admin = bll.GetModel(username);
                    if (admin == null)
                    {
                        context.Response.Write("userError");
                        return;
                    }
                    password = CommonCode.Md5Compute(password);
                    if (admin.UPassword.ToLower() == password.ToLower())
                    {
                        if (admin.IsDel)
                        {
                            context.Response.Write("del");
                        }
                        else
                        {
                            context.Session["currUser"] = admin;
                            HttpCookie currUser = new HttpCookie("loginId", admin.UUserName);
                            context.Response.Cookies.Add(currUser);
                            if (isRemember == "1")
                            {
                                string encryptPwd = CommonCode.Encrypt(admin.UPassword);
                                HttpCookie currPwd = new HttpCookie("pwd", encryptPwd);
                                HttpCookie currType = new HttpCookie("userType", "3");
                                currUser.Expires = currPwd.Expires = currType.Expires = DateTime.Now.AddYears(10);
                                context.Response.Cookies.Add(currPwd);
                                context.Response.Cookies.Add(currType);
                            }
                            context.Response.Write("ok");
                        }
                    }
                    else
                    {
                        context.Response.Write("pwdError");
                    }
                    break;
                default:
                    context.Response.Write("typeError");
                    break;
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