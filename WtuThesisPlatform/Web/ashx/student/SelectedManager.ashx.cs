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
    public class SelectedManager : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string thesisId = context.Request["thesisId"];
            string operate = context.Request["operate"];
            string srcPage = context.Request["srcPage"];
            Student currStudent = context.Session["currUser"] as Student;
            if (currStudent == null)
            {
                context.Response.Write("error");
            }
            ThesisSelected thesisSelected = new ThesisSelected();
            if (srcPage == "myStore")
            {
                ThesisCollect thesisCollect = new ThesisCollectBLL().GetModel(Convert.ToInt32(thesisId));
                thesisSelected.ThesisTitle = thesisCollect.ThesisTitle;
            }
            else if (srcPage == "mySelect")
            {
                thesisSelected = new ThesisSelectedBLL().GetModel(Convert.ToInt32(thesisId));
            }
            else if (srcPage == "stuSelect")
            {
                thesisSelected.ThesisTitle = new ThesisTitleBLL().GetModel(Convert.ToInt32(thesisId));
            }
            thesisSelected.Student = currStudent;
            ThesisSelectedBLL tsBll = new ThesisSelectedBLL();
            ThesisCollectBLL tcBll = new ThesisCollectBLL();
            ThesisTitleBLL thesisTitleBll = new ThesisTitleBLL();

            if (operate == "add")
            {
                tcBll.Del(thesisId);
                if (tsBll.Contains(thesisSelected))
                {
                    context.Response.Write("ok");
                    return;
                }
                thesisSelected.ThesisTitle.TSelectedNum += 1;
                if (tsBll.Add(thesisSelected) > 0 && thesisTitleBll.Update(thesisSelected.ThesisTitle) > 0)
                {
                    context.Response.Write("ok");
                    return;
                }
            }
            else if (operate == "del")
            {
                thesisSelected.ThesisTitle.TSelectedNum -= 1;
                if (thesisSelected.TPassed)
                {
                    thesisSelected.ThesisTitle.TAcceptNum -= 1;
                    thesisSelected.Student.SFlag = false;
                    StudentBLL studentBll= new StudentBLL();
                    if (studentBll.Update(thesisSelected.Student) <= 0)
                    {
                        return;
                    }
                }
                if (thesisTitleBll.Update(thesisSelected.ThesisTitle)>0&&tsBll.Del(thesisId) > 0)
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