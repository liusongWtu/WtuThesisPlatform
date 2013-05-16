using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using WtuThesisPlatform.MODEL;
using WtuThesisPlatform.BLL;
using System.Text;

namespace Web.ashx.teacher
{
    /// <summary>
    /// TeacherSelect 的摘要说明
    /// </summary>
    public class TeacherSelect : IHttpHandler, IRequiresSessionState
    {
        HttpContext context = null;
        Teacher currTeacher = null;

        public void ProcessRequest(HttpContext context)
        {
            this.context = context;
            context.Response.ContentType = "text/plain";
            currTeacher=context.Session["currUser"] as Teacher;
            string operate = context.Request["operate"];
            switch (operate)
            {
                case "select":
                    SelectStudent();
                    break;
                case "cancel":
                    DelStudent();
                    break;
                default:
                    break;
            }
        }

        //退选
        private void DelStudent()
        {
            string thesisSelectedId = context.Request["tid"];
            ThesisSelected thesisSelected = new ThesisSelectedBLL().GetModel(Convert.ToInt32(thesisSelectedId));
            TeacherBLL bll = new TeacherBLL();
            if (bll.DelStudent(thesisSelected) > 0)
            {
                currTeacher.CurrNum -= 1;
                context.Response.Write("ok");
            }
            else
            {
                context.Response.Write("failed");
            }
        }

        //选择学生
        private void SelectStudent()
        {
            //该教师所带学生数目是否达到限制人数
            if (currTeacher.TTeachNum <= currTeacher.CurrNum)
            {
                context.Response.Write("SelectFull");
                return;
            }
            string thesisSelectedId=context.Request["tid"];
            ThesisSelected thesisSelected = new ThesisSelectedBLL().GetModel(Convert.ToInt32 (thesisSelectedId));

            //该学生已选题成功
            if (thesisSelected.Student.SFlag)
            {
                context.Response.Write("StudentSelected");
                return;
            }

            //该选题已达最大限制人数
            if (thesisSelected.ThesisTitle.TNumber <= thesisSelected.ThesisTitle.TAcceptNum)
            {
                context.Response.Write("ThesisFull");
            }
            else
            {
                TeacherBLL bll=new TeacherBLL ();
                if (bll.SelectStudent(thesisSelected) > 0)
                {
                    currTeacher.CurrNum += 1;
                    context.Response.Write("ok");
                }
                else
                {
                    context.Response.Write("failed");
                }

            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}