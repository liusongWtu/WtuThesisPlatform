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

        /// <summary>
        /// object类型的扩展方法，用于验证checkObj对象是否为空或""
        /// </summary>
        /// <param name="obj">被扩展对象</param>
        /// <param name="checkObj">待检测对象</param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this  object obj, object checkObj)
        {
            if (checkObj == null)
                return true;
            if (checkObj.ToString().Trim().Length == 0)
                return true;
            return false;

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



        /// <summary>
        /// 把用户传过来txt进行加密
        /// </summary>
        /// <param name="txt">待加密字符</param>
        /// <returns></returns>
        public static string Encrypt(string txt, string key)
        {

            if (key == null || key.Length == 0)
            {
                //大写A的Ascii码是65  大写Z的是90
                Random r = new Random();
                key = ((char)r.Next(65, 91)).ToString() + ((char)r.Next(65, 91)).ToString();
            }

            //result 是一个34位的字符串,并且前两位就是我们随机产生的两个字符
            string result = key + CommonCode.Md5Compute(key + CommonCode.Md5Compute(txt));
            return result;
        }

        /// <summary>
        /// 把用户传过来txt进行加密
        /// </summary>
        /// <param name="txt">待加密字符</param>
        /// <returns></returns>
        public static string Encrypt(string txt)
        {
            return Encrypt(txt, null);
        }

        /// <summary>
        /// 验证用户是否登录或是否有权限访问当前页面
        /// </summary>
        /// <returns></returns>
        public static bool CheckUserLogin()
        {
            if (HttpContext.Current.Session["currUser"] == null)
            {
                //判断当前是否有Cookie,如果没有则转向登录页面
                HttpContext.Current.Response.Redirect("/Login.aspx?return=" +
                    HttpContext.Current.Request.Url.ToString());
                return false;
            }
            else
            {//验证当前用户,是否有权限访问当前页面.
                if (CheckAuth() == false)
                {
                    //todo:优化：没有权限访问时给图提示页面
                    HttpContext.Current.Response.Redirect("/Login.aspx?return="+
                        HttpContext.Current.Request.Url.ToString ());
                    return false;
                }
                return true;
            }

        }

        /// <summary>
        /// 验证当前用户,是否有权限访问当前页面.
        /// </summary>
        /// <returns></returns>
        public static bool CheckAuth()
        {
            //todo:待补充...
            return true;
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