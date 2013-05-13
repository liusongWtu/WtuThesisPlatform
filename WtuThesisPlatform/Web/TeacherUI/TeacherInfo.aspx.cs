using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WtuThesisPlatform.MODEL;
using WtuThesisPlatform.BLL;

namespace Web.TeacherUI
{
    public partial class TeacherInfo : System.Web.UI.Page
    {
        protected Teacher currTeacher = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            currTeacher = Session["currUser"] as Teacher;
            if (currTeacher != null)
            {
                LoadSelect(currTeacher);
            }

        }

        //加载下拉列表
        private void LoadSelect(Teacher currTeacher)
        {
            IList<Department> lstDepartment = new DepartmentBLL().GetAll();
            IList<Major> lstMajor = new MajorBLL().GetListByDId(currTeacher.Department.DId.ToString());
            foreach (var item in lstDepartment)
            {
                tFaculty.Items.Add(new ListItem(item.DName,item.DId.ToString ()));
                if (item.DId == currTeacher.Department.DId)
                {
                    tFaculty.SelectedIndex = tFaculty.Items.Count - 1;
                }
            }
            foreach (var item in lstMajor)
            {
                tProfession.Items.Add(new ListItem(item.MName, item.MId.ToString()));
                if (item.MId == currTeacher.Major.MId)
                {
                    tProfession.SelectedIndex = tProfession.Items.Count - 1;
                }
            }
        }
    }
}