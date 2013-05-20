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
using System.IO;
using NPOI.HSSF.UserModel;
using System.Data;
using System.Collections;

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
            IList<Student> lstStudent = bll.GetList(intPageIndex, pageSize, where, "DId desc", out rowCount, out pageCount);
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

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            //导入学生信息
            if (!fileUpExcel.HasFile || fileUpExcel.FileName.ToLower().IndexOf(".xls") <= 0)
            {
                return;
            }
            string strPath = fileUpExcel.FileName;//获得 要读取 的 excel文件 路径
            string year = strPath.Substring(0, 4);
            int total = 0;
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
                        total=AddStudent(dr, year,total);
                    }
                    catch { }
                }
            }
            LoadPageData(1);
        }

        /// <summary>
        /// 添加学生信息
        /// </summary>
        private static int AddStudent(HSSFRow dr, string year,int total)
        {
            Student student = new Student();
            if (dr.GetCell(0) == null && !string.IsNullOrEmpty(dr.GetCell(0).ToString().Trim()))//学号不存在则放弃该条记录
            {
                return total;
            }
            student.SNo = dr.GetCell(0).ToString();
            if (dr.GetCell(1) != null && !string.IsNullOrEmpty(dr.GetCell(1).ToString().Trim()))//姓名
            {
                student.SName = dr.GetCell(1).ToString();
            }
            if (dr.GetCell(2) != null && !string.IsNullOrEmpty(dr.GetCell(2).ToString().Trim()))//性别
            {
                student.SSex = dr.GetCell(2).ToString();
            }
            if (dr.GetCell(3) != null && !string.IsNullOrEmpty(dr.GetCell(3).ToString().Trim()))//院系
            {
                string deparmentName = dr.GetCell(3).ToString();
                student.Department = new Department();
                student.Department.DId = new DepartmentBLL().GetInsertDId(deparmentName);
            }
            if (dr.GetCell(4) != null && !string.IsNullOrEmpty(dr.GetCell(4).ToString().Trim()))//专业
            {
                string majorName = dr.GetCell(4).ToString();
                student.Major = new Major();
                student.Major.MId = new MajorBLL().GetInsertMId(majorName, student.Department.DId);
            }
            if (dr.GetCell(5) != null && !string.IsNullOrEmpty(dr.GetCell(5).ToString().Trim()))//班级
            {
                string className = dr.GetCell(5).ToString();
                student.ClassInfo = new ClassInfo();
                student.ClassInfo.CId = new ClassInfoBLL().GetInsertCId(className, student.Major.MId);
            }
            if (dr.GetCell(6) != null && !string.IsNullOrEmpty(dr.GetCell(6).ToString().Trim()))//电话
            {
                student.SPhone = dr.GetCell(6).ToString();
            }
            if (dr.GetCell(7) != null && !string.IsNullOrEmpty(dr.GetCell(7).ToString().Trim()))//QQ
            {
                student.SQQ = dr.GetCell(7).ToString();
            }
            if (dr.GetCell(8) != null && !string.IsNullOrEmpty(dr.GetCell(8).ToString().Trim()))//Email
            {
                student.SEmail = dr.GetCell(8).ToString();
            }
            student.SYear = year;
            student.SPassword = CommonCode.Md5Compute(student.SNo);
            student.RoleInfo = new RoleInfo();
            student.RoleInfo.RoleId = 1;
            StudentBLL bll = new StudentBLL();
            bll.Add(student);
            total++;
            return total;
        }

        //导出excel表
        protected void btnExport_Click(object sender, EventArgs e)
        {
            string year = System.Configuration.ConfigurationManager.AppSettings["currentYear"];
            //导出学生信息
            DataTable dtSource = new StudentBLL().GetAll(year);
            StarTech.NPOI.NPOIHelper.ListColumnsName = new SortedList(new StarTech.NPOI.NoSort());
            StarTech.NPOI.NPOIHelper.ListColumnsName.Add("SNo", "学号");
            StarTech.NPOI.NPOIHelper.ListColumnsName.Add("SName", "姓名");
            StarTech.NPOI.NPOIHelper.ListColumnsName.Add("SSex", "性别");
            StarTech.NPOI.NPOIHelper.ListColumnsName.Add("DName", "学院");
            StarTech.NPOI.NPOIHelper.ListColumnsName.Add("MName", "专业");
            StarTech.NPOI.NPOIHelper.ListColumnsName.Add("CName", "班级");
            StarTech.NPOI.NPOIHelper.ListColumnsName.Add("SPhone", "电话");
            StarTech.NPOI.NPOIHelper.ListColumnsName.Add("SQQ", "QQ");
            StarTech.NPOI.NPOIHelper.ListColumnsName.Add("SEmail", "Email");
            Response.Clear();
            Response.BufferOutput = false;
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            string filename = HttpUtility.UrlEncode(DateTime.Now.ToString(year));
            Response.AddHeader("Content-Disposition", "attachment;filename=" + filename + "届学生信息.xls");
            Response.ContentType = "application/ms-excel";
            StarTech.NPOI.NPOIHelper.ExportExcel(dtSource, Response.OutputStream);
            Response.Close();
        }
    }
}