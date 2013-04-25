using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace Web.ashx.common
{
    /// <summary>
    /// SaveTreeState 的摘要说明
    /// </summary>
    public class SaveTreeState : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string nodeId = context.Request["id"].Trim();
            string operate = context.Request["operate"].Trim();
            List<string> openNodes = context.Session["openNodes"] as List<string>;
            if (openNodes == null)
            {
                openNodes = new List<string>();
                context.Session["openNodes"] = openNodes;
            }
            if (operate == "1")
            {
                openNodes.Add(nodeId);
            }
            else
            {
                if (openNodes.Contains(nodeId))
                {
                    openNodes.Remove(nodeId);
                }
            }
            context.Response.Write("ok");

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