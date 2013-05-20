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
    public partial class WebForm1 : System.Web.UI.Page
    {
        Teacher currTeacher = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            currTeacher=Session["currUser"] as Teacher;

            //加载首页公告
            LoadNotice();

            //加载优秀论文
            LoadGoodWork();
        }

        //加载论文
        private void LoadGoodWork()
        {
            GoodWorkBLL bll = new GoodWorkBLL();
            IList<GoodWork> lstGoodWork = bll.GetTop(10);
            rptGoodWork.DataSource = lstGoodWork;
            rptGoodWork.DataBind();
        }

        /// <summary>
        /// 加载公告
        /// </summary>
        private void LoadNotice()
        {
            NoticeBLL bll = new NoticeBLL();
            IList<Notice> lstNotice = bll.GetTop(10,currTeacher.TId.ToString ());
            rptNotice.DataSource = lstNotice;
            rptNotice.DataBind();


        }
    }
}