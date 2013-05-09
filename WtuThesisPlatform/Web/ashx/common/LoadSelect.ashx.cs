using System;
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
            string operate = context.Request["operate"];//获取院系，专业信息

            JavaScriptSerializer jsS = new JavaScriptSerializer();//创建 js序列化器对象

            switch (operate)
            {
                case "getDM"://获取院系和专业信息
                    GetDM(context, jsS);
                    break;
                case "getClass"://获取班级信息
                    string majorId = context.Request["mid"];
                    IList<ClassInfo> lstClassInfo = new ClassInfoBLL().GetListByMId(majorId);
                    string jsoArrStr = jsS.Serialize(lstClassInfo);
                    context.Response.Write(jsoArrStr);
                    break;
                case "getDepartment"://获取院系信息
                    IList<Department> lstDepartment = new DepartmentBLL().GetAll();
                    string jsonDepartment = jsS.Serialize(lstDepartment);
                    context.Response.Write(jsonDepartment);
                    break;
                case "getMajor"://获取专业信息
                    string departmentId = context.Request["did"];
                    IList<Major> lstMajor = new MajorBLL().GetListByDId(departmentId);
                    string jsonMajor = jsS.Serialize(lstMajor);
                    context.Response.Write(jsonMajor);
                    break;
                default:
                    context.Response.Write("error");
                    break;
            }
        }

        /// <summary>
        /// 获取院系和专业信息
        /// </summary>
        private static void GetDM(HttpContext context, JavaScriptSerializer jsS)
        {
            string departmentId = context.Request["did"];
            IList<Major> lstMajor = new MajorBLL().GetListByDId(departmentId);
            //将泛型集合，转成javascript的 json数组字符串
            string jsonArrStrMajor = jsS.Serialize(lstMajor);

            IList<ClassInfo> lstClassInfo = new ClassInfoBLL().GetListByMId(lstMajor[0].MId.ToString());
            string jsonArrStrClass = jsS.Serialize(lstClassInfo);

            string finalStr = "{major:" + jsonArrStrMajor + ",class:" + jsonArrStrClass + "}";
            context.Response.Write(finalStr);
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