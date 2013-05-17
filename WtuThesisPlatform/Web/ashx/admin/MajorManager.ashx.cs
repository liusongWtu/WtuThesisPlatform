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
    /// MajorManager 的摘要说明
    /// </summary>
    public class MajorManager : IHttpHandler
    {
        HttpContext context = null;
        MajorBLL bll = new MajorBLL();

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            this.context = context;
            context.Response.ContentType = "text/plain";
            string operate = context.Request["operate"];
            switch (operate)
            {
                case "checkName":
                    CheckName();
                    break;
                case "getAInfo":
                    GetModelByMId();
                    break;
                case "addNew":
                    AddMajor();
                    break;
                case "modify":
                    ModifyMajor();
                    break;
                case "del":
                    DelADepartment();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 根据专业id获取院系信息
        /// </summary>
        private void GetModelByMId()
        {
            string mid = context.Request["majorId"];
            int iDid = 0;
            if (!int.TryParse(mid, out iDid) || iDid <= 0)
            {
                return;
            }
            Major major = bll.GetModel(iDid);
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string jsonMajor = jss.Serialize(major);
            context.Response.Write(jsonMajor);
        }

        /// <summary>
        /// 删除专业
        /// </summary>
        private void DelADepartment()
        {
            //string did = context.Request["did"];
            //if (bll.UpdateDelByDId(did) > 0)
            //{
            //    context.Response.Write("ok");
            //}
            //else
            //{
            //    context.Response.Write("failed");
            //}
        }

        /// <summary>
        /// 修改
        /// </summary>
        private void ModifyMajor()
        {
            int mid = Convert.ToInt32(context.Request["did"]);
            Major major = InitMajor();
            major.MId = mid;
            if (bll.Update(major) > 0)
            {
                context.Response.Write("ok");
            }
            else
            {
                context.Response.Write("failed");
            }
        }

        /// <summary>
        /// 添加专业
        /// </summary>
        private void AddMajor()
        {
            Major major = InitMajor();
            if (bll.Add(major) > 0)
            {
                context.Response.Write("{result:'ok',id:" + major.MId + "}");
            }
            else
            {
                context.Response.Write("failed");
            }
        }

        /// <summary>
        /// 构造一个专业对象
        /// </summary>
        /// <returns></returns>
        private Major InitMajor()
        {
            Major major = new Major();
            major.MName = context.Request["MName"];
            major.Department=new Department ();
            major.Department.DId = Convert.ToInt32(context.Request["DId"]);
            return major;
        }

        /// <summary>
        /// 检查专业是否已存在
        /// </summary>
        private void CheckName()
        {
            string name = context.Request["MName"];
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