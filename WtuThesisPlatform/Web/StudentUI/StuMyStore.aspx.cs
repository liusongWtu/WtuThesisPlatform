using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WtuThesisPlatform.MODEL;
using WtuThesisPlatform.BLL;

namespace Web.StudentUI
{
    public partial class StuMyStore : System.Web.UI.Page
    {
        private Student currStudent = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            currStudent = Session["currUser"] as Student;
            if (currStudent!=null)
            {
                ThesisCollectBLL bll = new ThesisCollectBLL();
                IList<ThesisCollect> list = bll.GetListBySId(currStudent.SId.ToString());
                rptMyStore.DataSource = list;
                rptMyStore.DataBind(); 
            }
        }
    }
}