using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WtuThesisPlatform.MODEL;
using Web.Common;

namespace Web.AdminUI
{
    public partial class AdminMasterPage : System.Web.UI.MasterPage
    {
        protected Admin currAdmin = null;
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
            currAdmin = Session["currUser"] as Admin;
            userType.Value = "3";
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