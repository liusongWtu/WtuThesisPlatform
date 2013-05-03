using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using WtuThesisPlatform.MODEL;
using WtuThesisPlatform.BLL;

namespace Web.ashx.student
{
    /// <summary>
    /// StoreManager 的摘要说明
    /// </summary>
    public class StoreManager : IHttpHandler,IRequiresSessionState
    {
        
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string thesisId = context.Request["thesisId"];
            string operate = context.Request["operate"];
            Student currStudent = context.Session["currUser"] as Student;
            if (currStudent == null)
            {
                context.Response.Write("error");
            }
            ThesisCollect thesisCollect = new ThesisCollect();
            thesisCollect.ThesisTitle =new ThesisTitleBLL().GetModel(Convert.ToInt32 (thesisId));
            thesisCollect.Student = currStudent;
            ThesisCollectBLL bll = new ThesisCollectBLL();

            if (operate == "add")
            {
                if (bll.Contians(thesisCollect))
                {
                    return;
                }
                if (bll.Add(thesisCollect)>0)
                {
                    context.Response.Write("ok");
                    return;
                }
            }
            else if (operate == "del")
            {
                if (bll.Del(thesisId) > 0)
                {
                    context.Response.Write("ok");
                    return;
                }
            }
            context.Response.Write("failed");
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