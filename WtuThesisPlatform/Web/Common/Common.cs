using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;

namespace Web.Common
{
    public static class CommonCode
    {
        public static void MessageBox(System.Web.UI.Page page, string msg)
        {
            msg = msg.Replace("\"", "");
            msg = msg.Replace("'", "");
            msg = msg.Replace("\r", "");
            msg = msg.Replace("\n", "");

            page.ClientScript.RegisterClientScriptBlock(page.GetType(), Guid.NewGuid().ToString(),
                "alert('" + msg + "');", true);

        }
        public static void WriteScript(System.Web.UI.Page page, string script)
        {


            page.ClientScript.RegisterClientScriptBlock(page.GetType(), Guid.NewGuid().ToString(),
                string.Format("{0};", script), true);

        }

        public static string Md5Compute(string txt)
        {

            MD5 md5 = MD5.Create();
            //把txt转成byte数组
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(txt);
            byte[] returnBytes = md5.ComputeHash(bytes);
            md5.Clear();
            string result = "";
            for (int i = 0; i < returnBytes.Length; i++)
            {
                //ToString中的X表示转成16进制后再转string类型,2表示两位显示,不足两位前面补0
                result += returnBytes[i].ToString("X2");

            }
            return result;
        }

        public static bool CheckLogin()
        {
            if (HttpContext.Current.Session["currentUser"] == null)
            {
                //判断当前用记是否有Cookie,如果有的话就自动登录!

                HttpContext.Current.Response.Redirect("/member/login.aspx?return=" +
                    HttpContext.Current.Request.Url.ToString());
                return false;
            }
            else
            {
                return true;
            }

        }

        public static string GetAppSettings(string keyName)
        {
            if (System.Configuration.ConfigurationManager.AppSettings[keyName] != null)
            {
                return System.Configuration.ConfigurationManager.AppSettings[keyName];
            }
            else
            {
                return "";
            }
        }

    }
}