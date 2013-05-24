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
        string nodeId = string.Empty;
        string searchWord;

        protected void Page_Load(object sender, EventArgs e)
        {
            currStudent = Session["currUser"] as Student;
            if (currStudent == null)
            {
                return;
            }
            nodeId=Request["nodeId"];
            searchWord = Request["searchWord"];
            string strPageIndex=Request.QueryString["i"];
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
            int rowCount=0;
            int pageCount=0;
            string currYear = System.Configuration.ConfigurationManager.AppSettings["currentYear"];
            string filter = txtSearch.Value.Trim();
            //根据页码 获得当前页数据
            ThesisTitleBLL bll = new ThesisTitleBLL();
            IList<ThesisTitle> lstThesisTitle = bll.GetList(intPageIndex, pageSize, "TState=1 and IsDel=1 and TYear='"+currYear
                +"' and (TName like '%"+filter+"%' or TPlatform like '%"+filter+"%' or TIntroduct like '%"+filter
                +"%' or TRequire like '%"+filter+"%')", "TTeacherId", out rowCount, out pageCount);
            rptThesises.DataSource = lstThesisTitle;
            rptThesises.DataBind();
            pageBar = CommonCode.GetPageTxt("StuSelect.aspx?nodeId=" + nodeId + "&i=", "&searchWord=" + filter, rowCount, pageCount, intPageIndex, 3, pageSize);

            //根据学生选择情况设置收藏的显示属性
            IList<ThesisCollect> lstStore = new ThesisCollectBLL().GetListBySId(currStudent.SId.ToString());
            foreach (ThesisCollect item in lstStore)
            {
                foreach (ThesisTitle thesisTitle in lstThesisTitle)
                {
                    if (thesisTitle.TId == item.ThesisTitle.TId)
                    {
                        thesisTitle.IsStore = "store-icon-actived";
                    }
                }
            }

            IList<ThesisSelected> lstSelected = new ThesisSelectedBLL().GetListById(currStudent.SId.ToString());
            foreach (ThesisSelected item in lstSelected)
            {
                foreach (ThesisTitle thesisTitle in lstThesisTitle)
                {
                    if (thesisTitle.TId == item.ThesisTitle.TId)
                    {
                        thesisTitle.IsSeleted = "select-icon-actived";
                    }
                }
            }

        }
    }
}