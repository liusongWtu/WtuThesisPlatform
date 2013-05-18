using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WtuThesisPlatform.BLL;
using WtuThesisPlatform.MODEL;

namespace Web.ashx.admin
{
    /// <summary>
    /// CheckGoodWork 的摘要说明
    /// </summary>
    public class CheckGoodWork : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string operate=context.Request["operate"];
            string tid=context.Request["tid"];
            GoodWorkBLL bll = new GoodWorkBLL();
            GoodWork goodWork = bll.GetModel(Convert.ToInt32 (tid));
            if (operate == "pass")
            {
                goodWork.GPassed = 1;
            }
            else if (operate == "nopass")
            {
                goodWork.GPassed = 2;
            }
            if (bll.Update(goodWork) > 0)
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