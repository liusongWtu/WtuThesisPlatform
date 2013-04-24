using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Common;
using WtuThesisPlatform.MODEL;

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
                sFaculty.Items.Add(currStudent.Department.DName);
                sProfession.Items.Add(currStudent.Major.MName);
                sClass.Items.Add(currStudent.ClassInfo.CName);
                sPhone.Value = currStudent.SPhone;
                sEmail.Value = currStudent.SEmail;
                sQQ.Value = currStudent.SQQ;
            }
        }
    }
}