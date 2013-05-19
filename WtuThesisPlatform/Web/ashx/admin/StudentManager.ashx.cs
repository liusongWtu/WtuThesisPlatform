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
    /// StudentManager 的摘要说明
    /// </summary>
    public class StudentManager : IHttpHandler
    {
        HttpContext context = null;
        StudentBLL bll = new StudentBLL();

        public void ProcessRequest(HttpContext context)
        {
            this.context = context;
            context.Response.ContentType = "text/plain";
            string operate = context.Request["operate"];
            switch (operate)
            {
                case "checkTNo":
                    CheckSNo();
                    break;
                case "getAInfo":
                    GetModelBySId();
                    break;
                case "addNew":
                    AddStudent();
                    break;
                case "modify":
                    ModifyStudent();
                    break;
                case "del":
                    DelAStudent();
                    break;
                case "resetPwd":
                    ResetPwd();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 重置密码
        /// </summary>
        private void ResetPwd()
        {
            string sid=context.Request["sid"];
            Student student = bll.GetModel(Convert.ToInt32(sid));
            student.SPassword = CommonCode.Md5Compute(student.SNo);
            if (bll.Update(student) > 0)
            {
                context.Response.Write("ok");
            }
            else
            {
                context.Response.Write("failed");
            }
        }

        /// <summary>
        /// 删除学生信息
        /// </summary>
        private void DelAStudent()
        {
            string sid=context.Request["sid"];
            if (bll.UpdateDel(sid) > 0)
            {
                context.Response.Write("ok");
            }
            else
            {
                context.Response.Write("failed");
            }
        }

        /// <summary>
        /// 修改学生信息
        /// </summary>
        private void ModifyStudent()
        {
            int studentId = Convert.ToInt32(context.Request["sid"]);
            Student student = InitStudent();
            student.SId = studentId;
            if (bll.Update(student) > 0)
            {
                context.Response.Write("ok");
            }
            else
            {
                context.Response.Write("failed");
            }
        }

        /// <summary>
        /// 添加学生
        /// </summary>
        private void AddStudent()
        {
            Student student = InitStudent();
            if (bll.Add(student) > 0)
            {
                context.Response.Write("{result:'ok',id:" + student.SId + "}");
            }
            else
            {
                context.Response.Write("failed");
            }
        }

        /// <summary>
        /// 构造学生实体
        /// </summary>
        /// <returns></returns>
        private Student InitStudent()
        {
            Student student = new Student();
            student.SNo=context.Request["sNo"];
            student.SName=context.Request["sName"];
            student.SPhone=context.Request["sPhone"];
            student.SSex=context.Request["sSex"];
            student.SEmail=context.Request["sEmail"];
            student.SQQ=context.Request["sQQ"];
            student.Department = new Department();
            student.Department.DId = Convert.ToInt32(context.Request["did"]);
            student.Major = new Major();
            student.Major.MId = Convert.ToInt32(context.Request["mid"]);
            student.ClassInfo = new ClassInfo();
            student.ClassInfo.CId = Convert.ToInt32(context.Request["cid"]);
            student.RoleInfo = new RoleInfo();
            student.RoleInfo.RoleId = 1;
            student.SYear=context.Request["sYear"];
            student.SPassword = CommonCode.Md5Compute(student.SNo);
            return student;
        }

        /// <summary>
        /// 根据学生id获取学生信息
        /// </summary>
        private void GetModelBySId()
        {
            string strStudentId = context.Request["studentId"];
            int iStudentId = 0;
            if (!int.TryParse(strStudentId, out iStudentId) || iStudentId <= 0)
            {
                return;
            }
            Student student = bll.GetModel(iStudentId);
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string jsonStudent = jss.Serialize(student);
            context.Response.Write(jsonStudent);
        }

        /// <summary>
        /// 检测学号是否存在
        /// </summary>
        private void CheckSNo()
        {
            string sno=context.Request["sno"];
            if (bll.GetModel(sno) == null)
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