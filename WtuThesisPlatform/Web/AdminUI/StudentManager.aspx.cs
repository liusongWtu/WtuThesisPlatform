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
    public partial class StudentManager : System.Web.UI.Page
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
            StudentBLL bll = new StudentBLL();
            string where = GetWhere(filter);
            IList<Student> lstStudent = bll.GetList(intPageIndex, pageSize, where, "DId", out rowCount, out pageCount);
            rptStudent.DataSource = lstStudent;
            rptStudent.DataBind();
            pageBar = CommonCode.GetPageTxt("StudentManager.aspx?nodeId=" + nodeId + "&i=", "&searchWord=" + filter, rowCount, pageCount, intPageIndex, 3, pageSize);

        }

        /// <summary>
        /// 拼接where语句
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        private string GetWhere(string filter)
        {
            string year=System.Configuration.ConfigurationManager.AppSettings["currentYear"];
            StringBuilder sb = new StringBuilder();
            sb.Append("IsDel=0 and SYear='"+year+"'");
            if (string.IsNullOrEmpty(filter))
            {
                return sb.ToString();
            }
            sb.Append(" and (SNo like '%" + filter + "%' or SName like '%" + filter + "%'");//工号和姓名
            string dids = new DepartmentBLL().GetDidsByName(filter);//院系ids
            if (!string.IsNullOrEmpty(dids))
            {
                sb.Append(" or DId in (" + dids + ")");
            }

            string mids = new MajorBLL().GetMIdsByName(filter);//专业ids
            if (!string.IsNullOrEmpty(mids))
            {
                sb.Append(" or MId in ("+mids+")");
            }

            string cids = new ClassInfoBLL().GetCIdsByName(filter);//班级ids
            if (!string.IsNullOrEmpty(cids))
            {
                sb.Append(" or CId in ("+cids+")");
            }

            sb.Append(")");
            return sb.ToString();
        }
    }
}