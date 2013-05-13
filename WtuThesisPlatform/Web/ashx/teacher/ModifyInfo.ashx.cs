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
    /// ModifyInfo 的摘要说明
    /// </summary>
    public class ModifyInfo : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string did=context.Request["did"];
            string mid=context.Request["mid"];
            string phone=context.Request["phone"];
            string email=context.Request["email"];
            string qq=context.Request["qq"];
            string teachCourse = context.Request["teachCourse"];
            string tResearchFields = context.Request["tResearchFields"];
            //todo:后台验证

            Teacher currTeacher=context.Session["currUser"] as Teacher;
            Teacher oldTeacher=currTeacher.Clone(true);

            currTeacher.Department.DId=Convert.ToInt32(did);
            currTeacher.Major.MId=Convert.ToInt32 (mid);
            currTeacher.TPhone=phone;
            currTeacher.TQQ=qq;
            currTeacher.TEmail=email;
            currTeacher.TTeachCourse=teachCourse;
            currTeacher.TResearchFields=tResearchFields;

            TeacherBLL bll=new TeacherBLL ();
            if(bll.Update(currTeacher)>0)
            {
                context.Response.Write ("ok");
            }else
            {
                context.Session["currUser"]=oldTeacher;
                context.Response.Write ("error");
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