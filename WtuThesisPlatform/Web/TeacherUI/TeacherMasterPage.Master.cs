using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WtuThesisPlatform.MODEL;
using Web.Common;

namespace Web.TeacherUI
{
    public partial class TeacherMasterPage : System.Web.UI.MasterPage
    {
        protected Teacher currTeacher =null;
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
            currTeacher = Session["currUser"] as Teacher;
            userType.Value = "2";
            currentNavNode.Value = Request["nodeId"];
            NavigateHTML = CommonCode.CreateTree();
        }
    }
}