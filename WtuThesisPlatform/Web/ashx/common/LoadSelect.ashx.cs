using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.ashx.common
{
    /// <summary>
    /// LoadSelect 的摘要说明
    /// </summary>
    public class LoadSelect : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string departmentId = context.Request["did"];
            string majorId = context.Request["mid"];
            string classId = context.Request["cid"];
            
            //院系存在，则表明之后的专业，班级信息都要获取
            if (!string.IsNullOrEmpty(departmentId))
            {
                //获取院系信息

                //获取专业信息

                //获取班级信息

            }

            //专业
            if (!string.IsNullOrEmpty(majorId))
            {

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