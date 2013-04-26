﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using WtuThesisPlatform.MODEL;
using WtuThesisPlatform.BLL;

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

           
            JavaScriptSerializer jsS = new JavaScriptSerializer();//创建 js序列化器对象

            //院系存在，则表明之后的专业，班级信息都要获取
            if (!string.IsNullOrEmpty(departmentId))
            {
                IList<Major> lstMajor = new MajorBLL().GetListByDId(departmentId);
                //将泛型集合，转成javascript的 json数组字符串
                string jsonArrStr = jsS.Serialize(lstMajor);
                context.Response.Write(jsonArrStr);
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