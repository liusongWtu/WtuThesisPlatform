using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WtuThesisPlatform.BLL;
using WtuThesisPlatform.MODEL;
using System.Web.Script.Serialization;

namespace Web.ashx.admin
{
    /// <summary>
    /// TeacherManager 的摘要说明
    /// </summary>
    public class TeacherManager : IHttpHandler
    {
        HttpContext context = null;
        TeacherBLL bll = new TeacherBLL();

        public void ProcessRequest(HttpContext context)
        {
            this.context = context;
            context.Response.ContentType = "text/plain";
            string operate=context.Request["operate"];
            switch (operate)
            {
                case "getAInfo":
                    string teacherId=context.Request["teacherId"];
                    GetModelByTId(teacherId);
                    break;
                default:
                    break;
            }
        }

        private void GetModelByTId(string teacherId)
        {
            int iTeacherId = 0;
            if (!int.TryParse(teacherId, out iTeacherId) || iTeacherId <= 0)
            {
                return;
            }
            Teacher teacher = bll.GetModel(iTeacherId);
            JavaScriptSerializer jsS = new JavaScriptSerializer();
            string jsonTeacher = jsS.Serialize(teacher);
            context.Response.Write(jsonTeacher);
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