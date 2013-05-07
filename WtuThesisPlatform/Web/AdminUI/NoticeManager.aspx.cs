using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WtuThesisPlatform.MODEL;
using WtuThesisPlatform.BLL;
using Web.Common;

namespace Web.AdminUI
{
    public partial class NoticeManager : System.Web.UI.Page
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
            NoticeBLL bll = new NoticeBLL();
            IList<Notice> lstNotice = bll.GetList(intPageIndex, pageSize, "IsDel=0", "NPublishTime", out rowCount, out pageCount);
            rptAdmin.DataSource = lstNotice;
            rptAdmin.DataBind();
            pageBar = CommonCode.GetPageTxt("NoticeManager.aspx?i=", "", rowCount, pageCount, intPageIndex, 3, pageSize);

        }
    }
}