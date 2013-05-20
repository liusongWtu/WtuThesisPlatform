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
using System.Data;
using System.Collections;
using System.IO;
using NPOI.HSSF.UserModel;

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
            sb.Append(" and (TNo like '%" + filter + "%' or TName like '%" + filter + "%'");//工号和姓名
            string dids = new DepartmentBLL().GetDidsByName(filter);
            if (!string.IsNullOrEmpty(dids))
            {
                sb.Append(" or DepartmentId in (" + dids + ")");
            }

            sb.Append(")");
            return sb.ToString();
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            //导入教师信息
            if (!fileUpExcel.HasFile || fileUpExcel.FileName.ToLower().IndexOf(".xls") <= 0)
            {
                return;
            }
            string strPath = fileUpExcel.FileName;//获得 要读取 的 excel文件 路径
            int total=0;
            using (Stream file = new MemoryStream(fileUpExcel.FileBytes))//将 指定 的 文件 以流的方式读取到 file对象中
            {
                //将 文件流 对象 传入 workbook，此时，workbook 就相当于一个 Excel文件操作对象了
                HSSFWorkbook workbook = new HSSFWorkbook(file);
                //获得 Excel中 第一个工作表的 名字
                //MessageBox.Show(workbook.GetSheetName(0));
                //获得 Excel 中 第一个 表
                HSSFSheet sheet = workbook.GetSheetAt(0);
                //获得最后一行的下标
                int rowNum = sheet.LastRowNum;
                for (int j = 1; j <= rowNum; j++)//循环所有行
                {
                    try
                    {
                        //获得 当前循环的 行
                        HSSFRow dr = sheet.GetRow(j);
                        total= AddTeacher(dr, total);
                        
                    }
                    catch { }
                }
            }
            LoadPageData(1);
            btnUpload.Attributes.Add("success",total.ToString ());
        }

        private static int AddTeacher(HSSFRow dr, int total)
        {
            Teacher teacher = new Teacher();
            if (dr.GetCell(0) == null && !string.IsNullOrEmpty(dr.GetCell(0).ToString().Trim()))//学号不存在则放弃该条记录
            {
                return total;
            }
            teacher.TNo = dr.GetCell(0).ToString();
            if (dr.GetCell(1) != null && !string.IsNullOrEmpty(dr.GetCell(1).ToString().Trim()))//姓名
            {
                teacher.TName = dr.GetCell(1).ToString();
            }
            if (dr.GetCell(2) != null && !string.IsNullOrEmpty(dr.GetCell(2).ToString().Trim()))//性别
            {
                teacher.TSex = dr.GetCell(2).ToString();
            }
            if (dr.GetCell(3) != null && !string.IsNullOrEmpty(dr.GetCell(3).ToString().Trim()))//院系
            {
                string deparmentName = dr.GetCell(3).ToString();
                teacher.Department = new Department();
                teacher.Department.DId = new DepartmentBLL().GetInsertDId(deparmentName);
            }
            if (dr.GetCell(4) != null && !string.IsNullOrEmpty(dr.GetCell(4).ToString().Trim()))//专业
            {
                string majorName = dr.GetCell(4).ToString();
                teacher.Major = new Major();
                teacher.Major.MId = new MajorBLL().GetInsertMId(majorName, teacher.Department.DId);
            }
            if (dr.GetCell(5) != null && !string.IsNullOrEmpty(dr.GetCell(5).ToString().Trim()))//班级
            {
                teacher.TZhiCheng = dr.GetCell(5).ToString();
            }
            if (dr.GetCell(6) != null && !string.IsNullOrEmpty(dr.GetCell(6).ToString().Trim()))//电话
            {
                teacher.TTeachCourse = dr.GetCell(6).ToString();
            }
            if (dr.GetCell(7) != null && !string.IsNullOrEmpty(dr.GetCell(7).ToString().Trim()))//QQ
            {
                teacher.TResearchFields = dr.GetCell(7).ToString();
            }
            if (dr.GetCell(8) != null && !string.IsNullOrEmpty(dr.GetCell(8).ToString().Trim()))//Email
            {
                teacher.TTeachNum = Convert.ToInt32(dr.GetCell(8).ToString());
            }
            if (dr.GetCell(9) != null && !string.IsNullOrEmpty(dr.GetCell(9).ToString().Trim()))//Email
            {
                teacher.TPhone = dr.GetCell(9).ToString();
            }
            if (dr.GetCell(10) != null && !string.IsNullOrEmpty(dr.GetCell(10).ToString().Trim()))//Email
            {
                teacher.TEmail = dr.GetCell(10).ToString();
            } 
            if (dr.GetCell(11) != null && !string.IsNullOrEmpty(dr.GetCell(11).ToString().Trim()))//Email
            {
                teacher.TQQ = dr.GetCell(11).ToString();
            }
            teacher.TPassword = CommonCode.Md5Compute(teacher.TNo);
            teacher.RoleInfo = new RoleInfo();
            teacher.RoleInfo.RoleId = 2;
            TeacherBLL bll = new TeacherBLL();
            bll.Add(teacher);
            total++;
            return total;
        }

        //导出excel表
        protected void btnExport_Click(object sender, EventArgs e)
        {
            //导出学生信息
            DataTable dtSource = new TeacherBLL().GetAll();
            StarTech.NPOI.NPOIHelper.ListColumnsName = new SortedList(new StarTech.NPOI.NoSort());
            StarTech.NPOI.NPOIHelper.ListColumnsName.Add("TNo", "教工号");
            StarTech.NPOI.NPOIHelper.ListColumnsName.Add("TName", "姓名");
            StarTech.NPOI.NPOIHelper.ListColumnsName.Add("TSex", "性别");
            StarTech.NPOI.NPOIHelper.ListColumnsName.Add("DName", "学院");
            StarTech.NPOI.NPOIHelper.ListColumnsName.Add("MName", "专业");
            StarTech.NPOI.NPOIHelper.ListColumnsName.Add("TZhiCheng", "班级");
            StarTech.NPOI.NPOIHelper.ListColumnsName.Add("TTeachNum", "限带人数");
            StarTech.NPOI.NPOIHelper.ListColumnsName.Add("TTeachCourse", "主讲课程");
            StarTech.NPOI.NPOIHelper.ListColumnsName.Add("TResearchFields", "研究方向");
            StarTech.NPOI.NPOIHelper.ListColumnsName.Add("TPhone", "电话");
            StarTech.NPOI.NPOIHelper.ListColumnsName.Add("TEmail", "Email");
            StarTech.NPOI.NPOIHelper.ListColumnsName.Add("TQQ", "QQ");
            Response.Clear();
            Response.BufferOutput = false;
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.AddHeader("Content-Disposition", "attachment;filename=教师信息.xls");
            Response.ContentType = "application/ms-excel";
            StarTech.NPOI.NPOIHelper.ExportExcel(dtSource, Response.OutputStream);
            Response.Close();
        }
    }
}