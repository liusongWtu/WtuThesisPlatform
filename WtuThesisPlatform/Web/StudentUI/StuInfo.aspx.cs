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
                

            }
        }
    }
}