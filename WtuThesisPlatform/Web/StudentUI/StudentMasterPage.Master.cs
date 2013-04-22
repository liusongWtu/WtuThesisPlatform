using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Web.Common;
using WtuThesisPlatform.MODEL;

namespace Web.StudentUI
{
    public partial class StudentMasterPage : System.Web.UI.MasterPage
    {
        protected Student currStudent = null;
        protected StringBuilder sbNavigateHTML = new StringBuilder();//左边导航树代码
        //todo:补充页面信息 eg:noticeNum="(4)";并且切换图片显示
        protected string noticeNum = "( 4 )";//公告信息
        protected string msgNum = "(2)";//消息信息

        protected void Page_Load(object sender, EventArgs e)
        {
            //验证用户是否登录及是否有权限访问本页面
            if (!CommonCode.CheckUserLogin())
            {
                CommonCode.GoLoginUrl();
                return;
            }
            currStudent= Session["currUser"] as Student;


            sbNavigateHTML.Append("<dl class=\"menu\">");
            sbNavigateHTML.Append("<dt class=\"menu-header cursor\"><span class=\"menu-header-icon menu-icon\"></span>毕业设计展示</dt>");
            sbNavigateHTML.Append("<dd class=\"menu-list cursor\"><span class=\"menu-list-icon menu-icon\"></span><a href=\"#\">最新作品</a></dd>");
            sbNavigateHTML.Append("<dd class=\"menu-list cursor\"><span class=\"menu-list-icon menu-icon\"></span><a href=\"#\">全部作品</a></dd>");
            sbNavigateHTML.Append("</dl>");

        }
    }
}