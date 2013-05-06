using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WtuThesisPlatform.MODEL;
using WtuThesisPlatform.BLL;
using System.Web.SessionState;

namespace Web.ashx.admin
{
    /// <summary>
    /// ModifyInfo 的摘要说明
    /// </summary>
    public class ModifyInfo : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string phone = context.Request["phone"].Trim();
            string email = context.Request["email"].Trim();
            string qq = context.Request["qq"].Trim();
            //todo:后台验证

            Admin currAdmin = context.Session["currUser"] as Admin;
            //修改前保存当前用户，修改失败时以还原
            Admin oldAdmin = currAdmin.Clone(true);

            currAdmin.UPhone = phone;
            currAdmin.UQQ = qq;
            currAdmin.UEmail = email;

            AdminBLL bll = new AdminBLL();
            if (bll.Update(currAdmin)>0)
            {
                context.Response.Write("ok");
            }
            else
            {
                context.Session["currUser"] = oldAdmin;
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