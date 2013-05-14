using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using WtuThesisPlatform.MODEL;
using WtuThesisPlatform.BLL;

namespace Web.ashx.teacher
{
    /// <summary>
    /// ApplyExcel 的摘要说明
    /// </summary>
    public class ApplyExcel : IHttpHandler,IRequiresSessionState
    {
        Teacher currTeacher = null;

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            currTeacher=context.Session["currUser"] as Teacher;
            if (currTeacher == null)
            {
                return;
            }
            string title = context.Request["title"];
            string number=context.Request["number"];
            string introduct = context.Request["introduct"];
            string require = context.Request["require"];
            string platform=context.Request["platform"];
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(introduct) || string.IsNullOrEmpty(require)||
                string.IsNullOrEmpty(number)||string.IsNullOrEmpty(platform))
            {
                return;
            }
            ThesisTitleBLL bll = new ThesisTitleBLL();
            //获取当前届数
            string year=System.Configuration.ConfigurationManager.AppSettings ["currentYear"];
            if (bll.GetModel(currTeacher.TId, title,year) != null)
            {
                context.Response.Write("exist");
                return;
            }
            ThesisTitle thesisTitle = new ThesisTitle();
            thesisTitle.TDepartmentId = currTeacher.Department.DId;
            thesisTitle.Teacher= currTeacher;
            thesisTitle.TIntroduct = introduct;
            thesisTitle.TName = title;
            thesisTitle.TNumber = Convert.ToInt32(number);
            thesisTitle.TPlatform = platform;
            thesisTitle.TRequire = require;
            thesisTitle.TYear = year;

            if (bll.Add(thesisTitle) > 0)
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