using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace Web.StudentUI
{
    public partial class StudentMasterPage : System.Web.UI.MasterPage
    {

        protected StringBuilder sbNavigateHTML = new StringBuilder();

        protected void Page_Load(object sender, EventArgs e)
        {

            sbNavigateHTML.Append("<dl class=\"menu\">");
            sbNavigateHTML.Append("<dt class=\"menu-header cursor\"><span class=\"menu-header-icon menu-icon\"></span>毕业设计展示</dt>");
            sbNavigateHTML.Append("<dd class=\"menu-list cursor\"><span class=\"menu-list-icon menu-icon\"></span><a href=\"#\">最新作品</a></dd>");
            sbNavigateHTML.Append("<dd class=\"menu-list cursor\"><span class=\"menu-list-icon menu-icon\"></span><a href=\"#\">全部作品</a></dd>");
            sbNavigateHTML.Append("</dl>");
        }
    }
}