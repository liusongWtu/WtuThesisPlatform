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
    public partial class ApplyExcel : System.Web.UI.Page
    {
        protected ThesisTitle currThesisTitle = new ThesisTitle();

        protected void Page_Load(object sender, EventArgs e)
        {
            string operate=Request["operate"];
            string thesisTilteId=Request["tid"];
            if (string.IsNullOrEmpty(operate))
            {
                return;
            }
            currThesisTitle = new ThesisTitleBLL().GetModel(Convert.ToInt32(thesisTilteId));
            if (operate == "read")
            {
                btnSave.Style.Add("display", "none");
                txtTitle.Attributes.Add("readonly", "true");
                txtRequire.Attributes.Add("readonly", "true");
                txtIntroduct.Attributes.Add("readonly", "true");
                number.Attributes.Add("readonly", "true"); 
            }
            else if (operate == "modify")
            {
                btnSave.Attributes.Add("operate", "modify");
                btnSave.Attributes.Add("thesisId",currThesisTitle.TId.ToString ());
            }
            txtTitle.Value = currThesisTitle.TName;
            platform.Value = currThesisTitle.TPlatform;
            number.Value = currThesisTitle.TNumber.ToString ();
            txtIntroduct.Value = currThesisTitle.TIntroduct;
            txtRequire.Value = currThesisTitle.TRequire;

        }
    }
}