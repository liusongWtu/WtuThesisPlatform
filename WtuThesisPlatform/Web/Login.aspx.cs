using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WtuThesisPlatform.MODEL;
using WtuThesisPlatform.BLL;
using Web.Common;

namespace Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["loginId"] != null &&
                Request.Cookies["pwd"] != null &&
                Request.Cookies["userType"] != null)//说明客户端有选中记住我时写入的cookie
            {
                //检测用户是否存在或者被冻结
                if (CheckUser())
                {
                    //数据库中不存在从cookie中读出的用户,有可能这个cookie是用户伪造的,也有可能管理员已经把这个用户删除了.
                    //及其他不合法情况
                    Response.Cookies["loginId"].Expires=DateTime.Now.AddYears(-1);
                    Response.Cookies["pwd"].Expires = DateTime.Now.AddYears(-1);
                    Response.Cookies["userType"].Expires = DateTime.Now.AddYears(-1);
                }
            }
        }

        /// <summary>
        /// 检验cookie中的信息是否合法
        /// </summary>
        /// <returns></returns>
        private bool CheckUser()
        {
            string loginId = Request.Cookies["loginId"].Value;
            string pwd = Request.Cookies["pwd"].Value;
            string userType = Request.Cookies["userType"].Value;
            if (userType == "1")//学生
            {
                StudentBLL bll = new StudentBLL();
                Student currStudent = bll.GetModel(loginId);
                if (currStudent != null)
                {
                    string sysEncrypt =CommonCode.Encrypt(currStudent.SPassword, pwd.Substring(0, 2));
                    if (sysEncrypt == pwd)//说明这个cookie是正确的
                    {
                        if (currStudent.IsDel)//用户被冻结
                        {
                            CommonCode.MessageBox(Page, "对不起，您已被冻结！");
                            return true;
                        }
                        Session["currUser"] = currStudent;
                        GoPage("window.location='/StudentUI/StuIndex.aspx'");
                        return false;
                    }
                }
            }
            else if (userType == "2")//教师
            {
                TeacherBLL bll = new TeacherBLL();
                Teacher currTeacher = bll.GetModel(loginId);
                if (currTeacher != null)
                {
                    string sysEncrypt = CommonCode.Encrypt(currTeacher.TPassword, pwd.Substring(0, 2));
                    if (sysEncrypt == pwd)
                    {
                        if (currTeacher.IsDel)
                        {
                            CommonCode.MessageBox(Page, "对不起，您已被冻结！");
                            return true;
                        }
                        Session["currUser"] = currTeacher;
                        GoPage("window.location='/TeacherUI/TeacherIndex.aspx'");
                        return false;
                    }
                }
            }
            else if (userType == "3")//管理员
            {
                AdminBLL bll = new AdminBLL();
                Admin currAdmin = bll.GetModel(loginId);
                if (currAdmin != null)
                {
                    string sysEncrypt =CommonCode.Encrypt(currAdmin.UPassword, pwd.Substring(0, 2));
                    if (sysEncrypt == pwd)
                    {
                        if (currAdmin.IsDel)
                        {
                            CommonCode.MessageBox(Page, "对不起，您已被冻结！");
                            return true;
                        }
                        Session["currUser"] = currAdmin;
                        GoPage("window.location='/AdminUI/AdminInfo.aspx'");
                        return false;
                    }
                }
            }
            return true;
        } 

        //导向上一个页面
        protected void GoPage(string url)
        {
            if (Request.QueryString["return"] != null)
            {
                //证明是从另一个需要登录的页面导过来的
                CommonCode.WriteScript(Page, "window.location='" + Request.QueryString["return"] + "'");
            }
            else
            {
                //证明用户直接打开的登录页面.
                CommonCode.WriteScript(Page, url);
            }
        }
    }
}