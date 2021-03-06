﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WtuThesisPlatform.MODEL;
using WtuThesisPlatform.BLL;

namespace Web.TeacherUI
{
    public partial class TeacherStuInfo : System.Web.UI.Page
    {
        Teacher currTeacher = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            currTeacher=Session["currUser"] as Teacher;
            if (currTeacher == null)
            {
                return;
            }
            GetData();
        }

        /// <summary>
        /// 获取学生数据
        /// </summary>
        private void GetData()
        {
            string thesisTitleId=Request["tid"];
            ThesisSelectedBLL bll = new ThesisSelectedBLL();
            IList<ThesisSelected> lstThesisSelected = bll.GetListByThesisId(thesisTitleId,false);
            rptStudent.DataSource = lstThesisSelected;
            rptStudent.DataBind();
        }
    }
}