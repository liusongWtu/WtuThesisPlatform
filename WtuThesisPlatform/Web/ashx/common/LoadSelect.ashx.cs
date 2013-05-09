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
            string getDM=context.Request["getDM"];//获取院系，专业信息
           
            JavaScriptSerializer jsS = new JavaScriptSerializer();//创建 js序列化器对象

            //院系存在，则表明之后的专业，班级信息都要获取
            if (!string.IsNullOrEmpty(departmentId))
            {
                IList<Major> lstMajor = new MajorBLL().GetListByDId(departmentId);
                //将泛型集合，转成javascript的 json数组字符串
                string jsonArrStrMajor = jsS.Serialize(lstMajor);

                IList<ClassInfo> lstClassInfo = new ClassInfoBLL().GetListByMId(lstMajor[0].MId.ToString ());
                string jsonArrStrClass = jsS.Serialize(lstClassInfo);

                string finalStr = "{major:"+jsonArrStrMajor+",class:"+jsonArrStrClass+"}";
                context.Response.Write(finalStr);
            }

            //专业
            if (!string.IsNullOrEmpty(majorId))
            {
                IList<ClassInfo> lstClassInfo = new ClassInfoBLL().GetListByMId(majorId);
                string jsoArrStr = jsS.Serialize(lstClassInfo);
                context.Response.Write(jsoArrStr);
            }

            if (!string.IsNullOrEmpty(getDM))
            {
                //获取院系信息
                IList<Department> lstDepartment = new DepartmentBLL().GetAll();
                string jsonDepartment = jsS.Serialize(lstDepartment);

                //获取专业信息
                IList<Major> lstMajor = new MajorBLL().GetAll();
                string jsonMajor = jsS.Serialize(lstMajor);
                string finalStr = "{ department:" + jsonDepartment + ",major:" + jsonMajor + "}";
                context.Response.Write(finalStr);
                return;
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