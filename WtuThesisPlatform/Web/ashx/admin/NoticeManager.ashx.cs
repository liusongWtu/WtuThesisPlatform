using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WtuThesisPlatform.BLL;

namespace Web.ashx.admin
{
    /// <summary>
    /// NoticeManager 的摘要说明
    /// </summary>
    public class NoticeManager : IHttpHandler
    {
        HttpContext context = null;
        NoticeBLL bll = new NoticeBLL();

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            this.context=context;
            string operate=context.Request["operate"];
            if (operate == "del")
            {
                DelNotice();
            }
        }

        /// <summary>
        /// 删除公告
        /// </summary>
        private void DelNotice()
        {
            string nid = context.Request["nid"];
            if (bll.UpdateDel(nid) > 0)
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