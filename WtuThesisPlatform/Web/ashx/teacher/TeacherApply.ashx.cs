using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WtuThesisPlatform.MODEL;
using WtuThesisPlatform.BLL;

namespace Web.ashx.teacher
{
    /// <summary>
    /// TeacherApply 的摘要说明
    /// </summary>
    public class TeacherApply : IHttpHandler
    {
        HttpContext context = null;
        ThesisTitleBLL bll = new ThesisTitleBLL();

        public void ProcessRequest(HttpContext context)
        {
            this.context = context;
            context.Response.ContentType = "text/plain";
            string operate=context.Request["operate"];
            switch (operate)
            {
                case "apply":
                    ChangeDel(true);
                    break;
                case "cancel":
                    ChangeDel(false);
                    break;
                case "del":
                    DelThesisTitle();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 删除选题申请
        /// </summary>
        private void DelThesisTitle()
        {
            string tid=context.Request["tid"];
            ThesisTitle thesisTitle = bll.GetModel(Convert.ToInt32(tid));
            if (thesisTitle.TState != 1)//审核通过的选题不能删除
            {
                if (bll.Del(tid) > 0)
                {
                    context.Response.Write("ok");
                }
                else
                {
                    context.Response.Write("failed");
                }
            }
            else
            {
                context.Response.Write("failed");
            }
        }

        /// <summary>
        /// 修改是否申请标志
        /// </summary>
        /// <param name="isDel">申请标志</param>
        private void ChangeDel(bool isDel)
        {
            string tid=context.Request["tid"];
            ThesisTitle thesisTitle = bll.GetModel(Convert.ToInt32(tid));
            if (bll.UpdateDel(tid, isDel) > 0)
            {
                context.Response.Write("{result:'ok',state:'"+thesisTitle.StateString+"'}");
            }
            else
            {
                context.Response.Write("{result:failed}");
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