using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WtuThesisPlatform.BLL;
using WtuThesisPlatform.MODEL;
using System.Web.Script.Serialization;
using Web.Common;

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
                case "addNew":
                    AddTeacher();
                    break;
                case "modify":
                    ModifyTeacher();
                    break;
                default:
                    break;
            }
        }

        private void ModifyTeacher()
        {
            Teacher teacher = InitTeacher();
            if (bll.Update(teacher) > 0)
            {
                context.Response.Write("ok");
            }
            else
            {
                context.Response.Write("failed");
            }
        }

        //添加教师信息
        private void AddTeacher()
        {
            Teacher teacher = InitTeacher();
            if (bll.Add(teacher) > 0)
            {
                context.Response.Write("ok");
            }
            else
            {
                context.Response.Write("failed");
            }
        }

        /// <summary>
        /// 构造教师实体
        /// </summary>
        /// <returns></returns>
        private Teacher InitTeacher()
        {
            Teacher teacher = new Teacher();
            teacher.TNo = context.Request["tNo"];
            teacher.TName = context.Request["tName"];
            teacher.TPhone = context.Request["tPhone"];
            teacher.TSex = context.Request["tSex"];
            teacher.TEmail = context.Request["tEmail"];
            teacher.TQQ = context.Request["tQQ"];
            teacher.TZhiCheng = context.Request["tZhiCheng"];
            teacher.TTeachNum = Convert.ToInt32(context.Request["tTeachNum"]);
            teacher.Department = new Department();
            teacher.Department.DId = Convert.ToInt32(context.Request["did"]);
            teacher.Major = new Major();
            teacher.Major.MId = Convert.ToInt32(context.Request["mid"]);
            teacher.TResearchFields=context.Request["tResearchFields"];
            teacher.TTeachCourse=context.Request["tTeachCourse"];
            teacher.RoleInfo = new RoleInfo();
            teacher.RoleInfo.RoleId = 2;
            teacher.TPassword = CommonCode.Md5Compute(teacher.TNo);
            return teacher;
        }

        /// <summary>
        /// 根据教师id获取教师信息
        /// </summary>
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