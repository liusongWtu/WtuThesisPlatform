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
                case "checkTNo":
                    CheckTNo();
                    break;
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
                case "del":
                    DelATeacher();
                    break;
                case "resetPwd":
                    ResetPwd();
                    break;
                default:
                    break;
            }
        }

        //重置用户密码
        private void ResetPwd()
        {
            string tid=context.Request["tid"];
            Teacher teacher = bll.GetModel(Convert.ToInt32(tid));
            teacher.TPassword = CommonCode.Md5Compute(teacher.TNo);
            if (bll.Update(teacher) > 0)
            {
                context.Response.Write("ok");
            }
            else
            {
                context.Response.Write("failed");
            }
        }

        /// <summary>
        /// 检测工号是否存在
        /// </summary>
        private void CheckTNo()
        {
            string tno=context.Request["tno"];
            if (bll.GetModel(tno) == null)
            {
                context.Response.Write("ok");
            }
            else
            {
                context.Response.Write("failed");
            }
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        private void DelATeacher()
        {
            string tid=context.Request["tid"];
            if (bll.Del(tid)>0)
            {
                context.Response.Write("ok");
            }
            else
            {
                context.Response.Write("failed");
            }
        }

        /// <summary>
        /// 修改教师信息
        /// </summary>
        private void ModifyTeacher()
        {
            int teacherId = Convert.ToInt32(context.Request["tid"]);
            Teacher teacher = InitTeacher();
            teacher.TId = teacherId;
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