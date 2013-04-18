using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace Web.ashx
{
    /// <summary>
    /// CheckLogin 的摘要说明
    /// </summary>
    public class CheckLogin : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string code = context.Request["code"];
            string username=context.Request["username"];
            string password = context.Request["pwd"];
            if (string.IsNullOrWhiteSpace(code))
            {

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