using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Common;
using WtuThesisPlatform.MODEL;
using WtuThesisPlatform.BLL;

namespace Web.StudentUI
{
    public partial class StuInfo : System.Web.UI.Page
    {
        private Student currStudent = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            currStudent = Session["currUser"] as Student;
            if (currStudent != null)
            {
                sName.Value = currStudent.SName;
                sNo.Value = currStudent.SNo;
                sYear.Value = currStudent.SYear;
                sPhone.Value = currStudent.SPhone;
                sEmail.Value = currStudent.SEmail;
                sQQ.Value = currStudent.SQQ;

                LoadSelect(currStudent);
            }
        }

        //加载下拉框信息
        private void LoadSelect(Student currStudent)
        {
            IList<Department> lstDepartment = new DepartmentBLL().GetAll();
            IList<Major> lstMajor = new MajorBLL().GetListByDId(currStudent.Department.DId);
            IList<ClassInfo> lstClass = new ClassInfoBLL().GetListByMId(currStudent.Major.MId);
            foreach (var item in lstDepartment)
            {
                sFaculty.Items.Add( new ListItem(item.DName, item.DId.ToString()));
                if (item.DId == currStudent.Department.DId)
                {
                    sFaculty.SelectedIndex = sFaculty.Items.Count-1;
                }
            }
            foreach (var item in lstMajor)
            {
                sProfession.Items.Add(new ListItem(item.MName,item.MId.ToString()));
                if (item.MId == currStudent.Major.MId)
                {
                    sProfession.SelectedIndex = sProfession.Items.Count - 1;
                }
            }
            foreach (var item in lstClass)
            {
                sClass.Items.Add(new ListItem(item.CName,item.CId.ToString ()));
                if (item.CId == currStudent.ClassInfo.CId)
                {
                    sClass.SelectedIndex = sClass.Items.Count - 1;
                }
            }
        }
    }
}