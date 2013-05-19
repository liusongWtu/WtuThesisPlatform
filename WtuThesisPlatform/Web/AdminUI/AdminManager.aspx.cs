using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WtuThesisPlatform.BLL;
using Web.Common;
using WtuThesisPlatform.MODEL;

namespace Web.AdminUI
{
    public partial class AdminManager : System.Web.UI.Page
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
            AdminBLL bll = new AdminBLL();
            IList<Admin> lstAdmin = bll.GetList(intPageIndex, pageSize, "IsDel=0 and (UUserName like '%" + filter
                + "%' or UName like '%" + filter + "%')", "UUserName", out rowCount, out pageCount);
            rptAdmin.DataSource = lstAdmin;
            rptAdmin.DataBind();
            pageBar = CommonCode.GetPageTxt("AdminManager.aspx?nodeId=" + nodeId + "&i=", "&searchWord=" + filter, rowCount, pageCount, intPageIndex, 3, pageSize);

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {

        }
    }
}