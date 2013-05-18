using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WtuThesisPlatform.MODEL;
using WtuThesisPlatform.BLL;
using Web.Common;

namespace Web.TeacherUI
{
    public partial class AllNotice : System.Web.UI.Page
    {
        Teacher currTeacher = null;
        protected string pageBar = string.Empty;
        string nodeId = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            nodeId=Request["nodeId"];
            currTeacher=Session["currUser"] as Teacher;
            if (currTeacher == null)
            {
                return;
            }

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
            int pageSize = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["pageSize"]);
            int rowCount = 0;
            int pageCount = 0;
            //根据页码 获得当前页数据
            NoticeBLL bll = new NoticeBLL();
            IList<Notice> lstNotice = bll.GetList(intPageIndex, pageSize, " NLevel=1 or (NLevel=2 and NPublisherId=" + currTeacher.TId+")", "NPublishTime desc", out rowCount, out pageCount);
            rptNotice.DataSource = bll.SetIsNew(lstNotice,currTeacher.TId);
            rptNotice.DataBind();
            pageBar = CommonCode.GetPageTxt("AllNotice.aspx?nodeId=" + nodeId + "&i=", "", rowCount, pageCount, intPageIndex, 3, pageSize);

        }
    }
}