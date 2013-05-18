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
    /// ClassManager 的摘要说明
    /// </summary>
    public class ClassManager : IHttpHandler
    {
        HttpContext context = null;
        ClassInfoBLL bll = new ClassInfoBLL();

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
                    GetModelByCId();
                    break;
                case "addNew":
                    AddClassInfo();
                    break;
                case "modify":
                    ModifyClassInfo();
                    break;
                case "del":
                    DelClassInfo();
                    break;
                default:
                    break;
            }

        }

        /// <summary>
        /// 根据班级id获取班级信息
        /// </summary>
        private void GetModelByCId()
        {
            string cid = context.Request["classId"];
            int iDid = 0;
            if (!int.TryParse(cid, out iDid) || iDid <= 0)
            {
                return;
            }
            ClassInfo classInfo = bll.GetModel(iDid);
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string jsonClassInfo = jss.Serialize(classInfo);
            context.Response.Write(jsonClassInfo);
        }

        /// <summary>
        /// 删除班级
        /// </summary>
        private void DelClassInfo()
        {
            string cid = context.Request["cid"];
            if (bll.UpdateDel(cid) > 0)
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
        private void ModifyClassInfo()
        {
            int cid = Convert.ToInt32(context.Request["cid"]);
            ClassInfo classInfo = InitClassInfo();
            classInfo.CId = cid;

            if (bll.Update(classInfo) > 0)
            {
                context.Response.Write("ok");
            }
            else
            {
                context.Response.Write("failed");
            }
        }

        /// <summary>
        /// 添加班级
        /// </summary>
        private void AddClassInfo()
        {
            ClassInfo classInfo = InitClassInfo();

            if (bll.Add(classInfo) > 0)
            {
                context.Response.Write("{result:'ok',id:" + classInfo.CId + "}");
            }
            else
            {
                context.Response.Write("failed");
            }
        }

        /// <summary>
        /// 构造一个班级对象
        /// </summary>
        /// <returns></returns>
        private ClassInfo InitClassInfo()
        {
            ClassInfo classInfo = new ClassInfo();
            classInfo.CName = context.Request["CName"];
            classInfo.Major = new Major();
            classInfo.Major.MId = Convert.ToInt32(context.Request["MajorId"]);
            return classInfo;
        }

        /// <summary>
        /// 检查班级是否已存在
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