using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WtuThesisPlatform.MODEL;
using WtuThesisPlatform.BLL;
using Web.Common;

namespace Web.StudentUI
{
    public partial class StuSelect : System.Web.UI.Page
    {
        Student currStudent = null;
        protected string pageBar = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            currStudent = Session["currUser"] as Student;
            if (currStudent == null)
            {
                return;
            }
            string strPageIndex=Request.QueryString["i"];
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
            int rowCount=0;
            int pageCount=0;
            //根据页码 获得当前页数据
            ThesisTitleBLL bll = new ThesisTitleBLL();
            IList<ThesisTitle> lstThesisTitle = bll.GetList(intPageIndex, pageSize, "IsDel=0", "", out rowCount, out pageCount);
            rptThesises.DataSource = lstThesisTitle;
            rptThesises.DataBind();
            pageBar = CommonCode.GetPageTxt("StuSelect.aspx?i=", "", rowCount, pageCount, intPageIndex, 3, pageSize);
        }
    }
}