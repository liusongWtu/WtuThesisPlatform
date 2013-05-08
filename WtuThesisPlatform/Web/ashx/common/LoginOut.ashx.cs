using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace Web.ashx.common
{
    /// <summary>
    /// LoginOut 的摘要说明
    /// </summary>
    public class LoginOut : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Session["currUser"] = null;
            context.Session["openNodes"] = null;
            context.Session["RoleRights"] = null;
            context.Response.Cookies["loginId"].Expires=DateTime.Now.AddYears(-1);
            context.Response.Cookies["pwd"].Expires = DateTime.Now.AddYears(-1);
            context.Response.Cookies["userType"].Expires = DateTime.Now.AddYears(-1);
            context.Response.Redirect("/Login.aspx");
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