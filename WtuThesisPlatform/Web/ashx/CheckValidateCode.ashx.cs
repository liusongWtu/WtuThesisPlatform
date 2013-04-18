using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace Web.ashx
{
    /// <summary>
    /// CheckValidateCode 的摘要说明
    /// </summary>
    public class CheckValidateCode : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string code = context.Request["code"];
            if (!string.IsNullOrEmpty(code))
            {
                string vCode = HttpContext.Current.Session["vCode"].ToString();
                if (code.ToLower() == vCode.ToLower())
                {
                    context.Response.Write("ok");
                }
                else
                {
                    context.Response.Write("error");
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