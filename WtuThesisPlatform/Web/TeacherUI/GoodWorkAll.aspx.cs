﻿using System;
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
    public partial class GoodWorkAll : System.Web.UI.Page
    {
        Teacher currTeacher = null;
        protected string pageBar = string.Empty;
        string nodeId = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            nodeId=Request["nodeId"];
            currTeacher = Session["currUser"] as Teacher;
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
            GoodWorkBLL bll = new GoodWorkBLL();
            IList<GoodWork> lstGoodWork = bll.GetList(intPageIndex, pageSize, "", " GTime desc", out rowCount, out pageCount);
            rptGoodWork.DataSource = lstGoodWork;
            rptGoodWork.DataBind();
            pageBar = CommonCode.GetPageTxt("GoodWorkAll.aspx?nodeId="+nodeId+"&i=", "", rowCount, pageCount, intPageIndex, 3, pageSize);

        }

    }
}