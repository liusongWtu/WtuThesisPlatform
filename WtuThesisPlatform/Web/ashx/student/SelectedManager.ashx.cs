using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WtuThesisPlatform.MODEL;
using WtuThesisPlatform.BLL;
using System.Web.SessionState;

namespace Web.ashx.student
{
    /// <summary>
    /// SelectedManager 的摘要说明
    /// </summary>
    public class SelectedManager : IHttpHandler,IRequiresSessionState
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
            ThesisSelected thesisSelected = new ThesisSelected();
            thesisSelected.ThesisTitle = new ThesisTitleBLL().GetModel(Convert.ToInt32(thesisId));
            thesisSelected.Student = currStudent;
            ThesisSelectedBLL tsBll = new ThesisSelectedBLL();
            ThesisCollectBLL tcBll = new ThesisCollectBLL();

            if (operate == "add")
            {
                tcBll.Del(thesisId);
                if (tsBll.Contains(thesisSelected))
                {
                    context.Response.Write("ok");
                    return;
                }
                if (tsBll.Add(thesisSelected) > 0)
                {
                    context.Response.Write("ok");
                    return;
                }
            }
            else if (operate == "del")
            {
                if (tsBll.Del(thesisId) > 0)
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