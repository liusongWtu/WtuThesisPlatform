using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WtuThesisPlatform.MODEL;

namespace Web.AdminUI
{
    public partial class AdminInfo : System.Web.UI.Page
    {
        Admin currAdmin = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            currAdmin = Session["currUser"] as Admin;
            if (currAdmin == null)
                return;
            sName.Value = currAdmin.UName;
            sPhone.Value = currAdmin.UPhone;
            sEmail.Value = currAdmin.UEmail;
            sQQ.Value = currAdmin.UQQ;
        }
    }
}