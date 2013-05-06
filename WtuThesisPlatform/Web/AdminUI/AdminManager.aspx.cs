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

        protected void Page_Load(object sender, EventArgs e)
        {
            currAdmin = Session["currUser"] as Admin;
            if (currAdmin == null)
                return;
            string strPageIndex = Request.QueryString["i"];
            int intPageIndex = 0;
            if (!int.TryParse(strPageIndex, out intPageIndex) && intPageIndex <= 0)
            {
                intPageIndex = 1;
            }
            LoadPageData(intPageIndex);

        }

        private void LoadPageData(int intPageIndex)
        {
            int pageSize = 6;
            int rowCount = 0;
            int pageCount = 0;
            //根据页码 获得当前页数据
            AdminBLL bll = new AdminBLL();
            IList<Admin> lstAdmin = bll.GetList(intPageIndex, pageSize, "IsDel=0", "UUserName", out rowCount, out pageCount);
            rptAdmin.DataSource = lstAdmin;
            rptAdmin.DataBind();
            pageBar = CommonCode.GetPageTxt("AdminManager.aspx?i=", "", rowCount, pageCount, intPageIndex, 3, pageSize);

        }
    }
}