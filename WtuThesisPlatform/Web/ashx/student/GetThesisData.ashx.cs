using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WtuThesisPlatform.MODEL;
using WtuThesisPlatform.BLL;
using Web.Common;

namespace Web.ashx.student
{
    /// <summary>
    /// GetThesisData 的摘要说明
    /// </summary>
    public class GetThesisData : IHttpHandler
    {
        HttpContext context = null;
        ThesisTitleBLL bll = new ThesisTitleBLL();

        public void ProcessRequest(HttpContext context)
        {
            this.context = context;
            context.Response.ContentType = "text/plain";
            string pageIndex = context.Request.QueryString["pageIndex"];
            int iPageIndex = 0;
            if (!int.TryParse(pageIndex, out iPageIndex)&&iPageIndex<=0)
            {////如果将url中获得的页码字符串转成整型变量时出错，则设置默认页码为1
                iPageIndex = 1;
            }
            GetPageList(iPageIndex);
        }

        /// <summary>
        /// 获得分页列表数据
        /// </summary>
        private void GetPageList(int pageIndex)
        {
            int rowCount = 0;
            int pageCount = 0;
            IList<ThesisTitle> lstThesisTitle = bll.GetList(pageIndex, 6,"IsDel=0","TTeacherId", out rowCount, out pageIndex);
            //将泛型集合，转成javascript的 json数组字符串
            System.Web.Script.Serialization.JavaScriptSerializer jsS = new System.Web.Script.Serialization.JavaScriptSerializer();
            //调用序列化方法，将 泛型集合对象list转成json数组字符串
            string jsonArrStr = jsS.Serialize(lstThesisTitle);
            //获得页面条
            string strPageBar = CommonCode.GetPageTxtAjax("", rowCount, pageCount, pageIndex, 3, 6);
            string finalStr = "{data:"+jsonArrStr+",pageBarHtml:\""+strPageBar+"\"}";
            context.Response.Write("finalStr");
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