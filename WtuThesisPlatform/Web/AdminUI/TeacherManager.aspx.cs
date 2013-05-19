using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WtuThesisPlatform.MODEL;
using WtuThesisPlatform.BLL;
using Web.Common;
using System.Text;

namespace Web.AdminUI
{
    public partial class TeacherManager : System.Web.UI.Page
    {
        Admin currAdmin = null;
        protected string pageBar = string.Empty;
        string nodeId = string.Empty;
        string searchWord;

        protected void Page_Load(object sender, EventArgs e)
        {
            currAdmin = Session["currUser"] as Admin;
            if (currAdmin == null)
                return;

            nodeId = Request["nodeId"];
            searchWord = Request["searchWord"];
            string strPageIndex = Request.QueryString["i"];
            if (IsPostBack)//回传页面
            {
                searchWord = null;
                strPageIndex = null;
            }
            else
            {
                txtSearch.Value = searchWord;
            }
            int intPageIndex = 0;
            if (!int.TryParse(strPageIndex, out intPageIndex) && intPageIndex <= 0)
            {
                intPageIndex = 1;
            }
            LoadPageData(intPageIndex);
        }

        private void LoadPageData(int intPageIndex)
        {
            int pageSize = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["pageSize"]);
            int rowCount = 0;
            int pageCount = 0;
            string filter = txtSearch.Value.Trim();
            //根据页码 获得当前页数据
            TeacherBLL bll = new TeacherBLL();
            string where = GetWhere(filter);
            IList<Teacher> lstTeacher = bll.GetList(intPageIndex, pageSize, where, "DepartmentId", out rowCount, out pageCount);
            rptAdmin.DataSource = lstTeacher;
            rptAdmin.DataBind();
            pageBar = CommonCode.GetPageTxt("TeacherManager.aspx?nodeId=" + nodeId + "&i=", "&searchWord=" + filter, rowCount, pageCount, intPageIndex, 3, pageSize);

        }

        /// <summary>
        /// 拼接where语句
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        private string GetWhere(string filter)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("IsDel=0");
            if (string.IsNullOrEmpty(filter))
            {
                return sb.ToString();
            }
            sb.Append(" and (TNo like '%"+filter+"%' or TName like '%"+filter+"%'");//工号和姓名
            string dids = new DepartmentBLL().GetDidsByName(filter);
            if (!string.IsNullOrEmpty(dids))
            {
                sb.Append(" or DepartmentId in ("+dids+")");
            }

            sb.Append(")");
            return sb.ToString();
        }
    }
}