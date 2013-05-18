using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WtuThesisPlatform.BLL;
using WtuThesisPlatform.MODEL;

namespace Web.ashx.admin
{
    /// <summary>
    /// CheckThesisTitle 的摘要说明
    /// </summary>
    public class CheckThesisTitle : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string operate = context.Request["operate"];
            string tid = context.Request["tid"];
            ThesisTitleBLL bll = new ThesisTitleBLL();
            ThesisTitle thesisTitle = bll.GetModel(Convert.ToInt32(tid));

            if (operate == "pass")//通过
            {
                thesisTitle.TState = 1;
            }
            else if (operate == "nopass")//不通过
            {
                thesisTitle.TState = 2;
            }

            if (bll.Update(thesisTitle) > 0)
            {
                context.Response.Write("ok");
            }
            else
            {
                context.Response.Write("failed");
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