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
    /// AdminManager 的摘要说明
    /// </summary>
    public class AdminManager : IHttpHandler
    {
        HttpContext context = null;
        AdminBLL bll = new AdminBLL();

        public void ProcessRequest(HttpContext context)
        {
            this.context = context;
            context.Response.ContentType = "text/plain";
            string operate=context.Request["operate"];
            switch (operate)
            {
                case "getAInfo":
                    GetModelByAId();
                    break;
                case "addNew":
                    AddAdmin();
                    break;
                case "modify":
                    ModifyAdmin();
                    break;
                case "del":
                    DelAAdmin();
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
            string aid=context.Request["aid"];
            Admin admin = bll.GetModel(Convert.ToInt32 (aid));
            admin.UPassword = CommonCode.Md5Compute(admin.UUserName);
            if (bll.Update(admin) > 0)
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
        private void DelAAdmin()
        {
            string aid=context.Request["aid"];
            if (bll.Del(aid) > 0)
            {
                context.Response.Write("ok");
            }
            else
            {
                context.Response.Write("failed");
            }
        }

        /// <summary>
        /// 修改管理员
        /// </summary>
        private void ModifyAdmin()
        {
            int adminId = Convert.ToInt32(context.Request["aid"]);
            Admin admin = InitAdmin();
            admin.UId = adminId;
            if (bll.Update(admin) > 0)
            {
                context.Response.Write("ok");
            }
            else
            {
                context.Response.Write("failed");
            }
        }

        /// <summary>
        /// 添加管理员
        /// </summary>
        private void AddAdmin()
        {
            Admin admin = InitAdmin();
            if (bll.Add(admin) > 0)
            {
                context.Response.Write("ok");
            }
            else
            {
                context.Response.Write("failed");
            }
        }

        /// <summary>
        /// 构造管理员实体
        /// </summary>
        private Admin InitAdmin()
        {
            Admin admin = new Admin();
            admin.UUserName = context.Request["uUserName"];
            admin.UName = context.Request["uName"];
            admin.UPhone = context.Request["uPhone"];
            admin.UEmail = context.Request["uEmail"];
            admin.UQQ=context.Request["uQQ"];
            admin.RoleInfo = new RoleInfo();
            admin.RoleInfo.RoleId = 3;
            admin.UPassword = CommonCode.Md5Compute(admin.UUserName);
            return admin;
        }

        /// <summary>
        /// 根据id获取管理员信息
        /// </summary>
        private void GetModelByAId()
        {
            string aid = context.Request["adminId"];
            int iAid = 0;
            if (!int.TryParse(aid, out iAid) || iAid <= 0)
            {
                return;
            }
            Admin admin = bll.GetModel(iAid);
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string jsonAdmin = jss.Serialize(admin);
            context.Response.Write(jsonAdmin);
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