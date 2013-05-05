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
        protected string NavigateHTML = string.Empty;//左边导航树代码
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
            userType.Value = "1";

            if (!IsPostBack)
            {
                currentNavNode.Value = Request["nodeId"];
                //todo:优化导航树
                //设置导航代码
                //if (Session["naviget"] == null)
                //{
                //    Session["naviget"]=CommonCode.CreateTree();
                //}
                NavigateHTML = CommonCode.CreateTree();

            }


        }
    }
}