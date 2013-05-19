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
using System.Configuration;
using System.IO;
using NPOI.HSSF.UserModel;


namespace Web.AdminUI
{
    public partial class test : System.Web.UI.Page
    {
        Admin currAdmin = null;
        protected string pageBar = string.Empty;
        string nodeId = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            nodeId = Request["nodeId"];
            Label1.Text = ConfigurationManager.AppSettings["open"];
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
            int pageSize = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["pageSize"]);
            int rowCount = 0;
            int pageCount = 0;
            //根据页码 获得当前页数据
            TeacherBLL bll = new TeacherBLL();
            IList<Teacher> lstTeacher = bll.GetList(intPageIndex, pageSize, "IsDel=0", "", out rowCount, out pageCount);
            rptAdmin.DataSource = lstTeacher;
            rptAdmin.DataBind();
            pageBar = CommonCode.GetPageTxt("TeacherManager.aspx?nodeId=" + nodeId + "&i=", "", rowCount, pageCount, intPageIndex, 3, pageSize);

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Text = ConfigurationManager.AppSettings["open"];
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

        protected void changeConfig_Click(object sender, EventArgs e)
        {
            ConfigurationManager.AppSettings["open"] = "false";
            Label1.Text = ConfigurationManager.AppSettings["open"];
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (!fileUpExcel.HasFile)
            {
                return;
            }
            string strPath = fileUpExcel.FileName;//获得 要读取 的 excel文件 路径
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
                for (int j = 0; j <= rowNum; j++)//循环所有行
                {
                    try
                    {
                        //获得 当前循环的 行
                        HSSFRow dr = sheet.GetRow(j);
                        AddStudent(dr);
                    }
                    catch { }
                }
            }
        }

        /// <summary>
        /// 添加学生信息
        /// </summary>
        /// <param name="dr"></param>
        private static void AddStudent(HSSFRow dr)
        {
            Student student = new Student();
            if (dr.GetCell(0) == null && !string.IsNullOrEmpty(dr.GetCell(0).ToString().Trim()))//学号不存在则放弃该条记录
            {
                return;
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
                student.Department.DId = new DepartmentBLL().GetInsertDId(deparmentName);
            }
            if (dr.GetCell(4) != null && !string.IsNullOrEmpty(dr.GetCell(4).ToString().Trim()))//专业
            {
                string majorName = dr.GetCell(4).ToString();
                student.Major.MId = new MajorBLL().GetInsertMId(majorName,student.Department.DId);
            }
            if (dr.GetCell(5) != null && !string.IsNullOrEmpty(dr.GetCell(5).ToString().Trim()))//班级
            {
                string className = dr.GetCell(5).ToString();
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
            StudentBLL bll = new StudentBLL();
            bll.Add(student);
        }
    }
}