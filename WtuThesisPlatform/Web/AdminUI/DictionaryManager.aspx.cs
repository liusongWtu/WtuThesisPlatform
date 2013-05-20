using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Web.AdminUI
{
    public partial class DictionaryManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int year = DateTime.Now.Year-1958;
                for (int i = year; i >=0 ; i--)
                {
                    int item=1958+i;
                    currYear.Items.Add(item.ToString());
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ConfigurationManager.AppSettings["currentYear"] = currYear.Value;
            ConfigurationManager.AppSettings["studentOpen"] = rblStuOpen.SelectedValue;
            ConfigurationManager.AppSettings["teacherOpen"] = rblTeaOpen.SelectedValue;
            ConfigurationManager.AppSettings["MaxSelect"] = wish.Value;
        }
    }
}