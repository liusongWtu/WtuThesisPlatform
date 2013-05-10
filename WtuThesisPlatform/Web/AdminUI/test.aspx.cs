using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WtuThesisPlatform.BLL;
using WtuThesisPlatform.MODEL;
using Web.Common;
using System.Collections;
using System.Data;
using System.Text;


namespace Web.AdminUI
{
    public partial class test : System.Web.UI.Page
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
            TeacherBLL bll = new TeacherBLL();
            IList<Teacher> lstTeacher = bll.GetList(intPageIndex, pageSize, "IsDel=0", "", out rowCount, out pageCount);
            rptAdmin.DataSource = lstTeacher;
            rptAdmin.DataBind();
            pageBar = CommonCode.GetPageTxt("TeacherManager.aspx?i=", "", rowCount, pageCount, intPageIndex, 3, pageSize);

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dtSource = new TeacherBLL().GetAll();
            StarTech.NPOI.NPOIHelper.ListColumnsName = new SortedList(new StarTech.NPOI.NoSort());
            StarTech.NPOI.NPOIHelper.ListColumnsName.Add("TNo", "工号");
            StarTech.NPOI.NPOIHelper.ListColumnsName.Add("TName", "姓名");
            StarTech.NPOI.NPOIHelper.ListColumnsName.Add("TTeachNum", "限带人数");
            StarTech.NPOI.NPOIHelper.ListColumnsName.Add("IsDel", "状态");
            Response.Clear();
            Response.BufferOutput = false;
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            string filename = HttpUtility.UrlEncode(DateTime.Now.ToString("在线用户yyyyMMdd"));
            Response.AddHeader("Content-Disposition", "attachment;filename=" + filename + ".xls");
            Response.ContentType = "application/ms-excel";
            StarTech.NPOI.NPOIHelper.ExportExcel(dtSource, Response.OutputStream);
            Response.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("11.xls", Encoding.UTF8));
            string filename = Server.MapPath("/download/11.xls");
            Response.TransmitFile(filename);
        }
    }
}