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
    /// DepartmentManager 的摘要说明
    /// </summary>
    public class DepartmentManager : IHttpHandler
    {
        HttpContext context = null;
        DepartmentBLL bll = new DepartmentBLL();

        public void ProcessRequest(HttpContext context)
        {
            this.context = context;
            context.Response.ContentType = "text/plain";
            string operate = context.Request["operate"];
            switch (operate)
            {
                case "checkName":
                    CheckName();
                    break;
                case "getAInfo":
                    GetModelByDId();
                    break;
                case "addNew":
                    AddDepartment();
                    break;
                case "modify":
                    ModifyDepartment();
                    break;
                case "del":
                    DelADepartment();
                    break;
                default:
                    break;
            }

        }

        /// <summary>
        /// 根据院系id获取院系信息
        /// </summary>
        private void GetModelByDId()
        {
            string did = context.Request["did"];
            int iDid = 0;
            if (!int.TryParse(did, out iDid) || iDid <= 0)
            {
                return;
            }
            Department department = bll.GetModel(iDid);
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string jsonDepartment = jss.Serialize(department);
            context.Response.Write(jsonDepartment);
        }

        /// <summary>
        /// 删除院系
        /// </summary>
        private void DelADepartment()
        {
            string did = context.Request["did"];
            if (bll.UpdateDelByDId(did) > 0)
            {
                context.Response.Write("ok");
            }  
            else
            {
                context.Response.Write("failed");
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        private void ModifyDepartment()
        {
            int did = Convert.ToInt32(context.Request["did"]);
            Department department = InitDepartment();
            department.DId = did;
            if (bll.Update(department) > 0)
            {
                context.Response.Write("ok");
            }
            else
            {
                context.Response.Write("failed");
            }
        }

        /// <summary>
        /// 添加院系
        /// </summary>
        private void AddDepartment()
        {
            Department department = InitDepartment();
            if (bll.Add(department) > 0)
            {
                context.Response.Write("{result:'ok',id:" + department.DId + "}");
            }
            else
            {
                context.Response.Write("failed");
            }
        }

        /// <summary>
        /// 构造一个院系对象
        /// </summary>
        /// <returns></returns>
        private Department InitDepartment()
        {
            Department department = new Department();
            department.DName=context.Request["DName"];
            department.DTelPhone = context.Request["DTelPhone"];
            return department;
        }

        /// <summary>
        /// 检查院系是否已存在
        /// </summary>
        private void CheckName()
        {
            string name = context.Request["DName"];
            if (bll.GetModel(name) == null)
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