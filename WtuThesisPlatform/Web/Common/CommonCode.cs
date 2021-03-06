﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using WtuThesisPlatform.MODEL;
using WtuThesisPlatform.BLL;
using System.Text;

namespace Web.Common
{
    public static class CommonCode
    {
        /// <summary>
        /// 向网页输出消息提示框
        /// </summary>
        /// <param name="page">web窗体页</param>
        /// <param name="msg">要显示的消息</param>
        public static void MessageBox(System.Web.UI.Page page, string msg)
        {
            msg = msg.Replace("\"", "");
            msg = msg.Replace("'", "");
            msg = msg.Replace("\r", "");
            msg = msg.Replace("\n", "");

            page.ClientScript.RegisterClientScriptBlock(page.GetType(), Guid.NewGuid().ToString(),
                "alert('" + msg + "');", true);
        }

        /// <summary>
        /// 向网页输出脚本
        /// </summary>
        /// <param name="page">web窗体页</param>
        /// <param name="script">待注册的脚本</param>
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

        /// <summary>
        /// 获取字符的MD5值
        /// </summary>
        /// <param name="txt">待计算的字符</param>
        /// <returns></returns>
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
            return result.ToLower();
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
            //todo:方便调试用
            return true;

            string nodeId=HttpContext.Current.Request["nodeId"];
            int iNodeId = 0;
            if (!int.TryParse(nodeId, out iNodeId)||iNodeId<=0)
            {
                return false;
            }
            //当前用户的所有权限
            IList<RoleRight> currRoleRights = GetRoleRightsFromSession();
            foreach (RoleRight item in currRoleRights)
            {
                if (item.SysFun.NodeId == iNodeId)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 页面跳转信息
        /// </summary>
        public static void GoLoginUrl()
        {
            HttpContext.Current.Response.Redirect("/Login.aspx?return=" + HttpContext.Current.Request.Url);
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

        /// <summary>
        /// 下面的方面和生成菜单有关,获得当前用户所能访问的所有程序
        /// </summary>
        /// <returns></returns>
        public static IList<RoleRight> GetRoleRightsFromSession()
        {
            if (HttpContext.Current.Session["RoleRights"] != null)
            {
                return (List<RoleRight>)HttpContext.Current.Session["RoleRights"];
            }
            else
            {
                RoleRightBLL bll = new RoleRightBLL();
                string whStr = "RoleId=" + GetUserRoleId().ToString() + " and IsDel=0 order by NodeId";
                IList<RoleRight> list = bll.GetList(whStr);
                HttpContext.Current.Session["RoleRights"] = list;
                return list;
            }
        }

        /// <summary>
        /// 获取当前用户id
        /// </summary>
        /// <returns></returns>
        public static int GetUserRoleId()
        {
            object obj = HttpContext.Current.Session["currUser"];
            if (obj is Student)
            {
                return (obj as Student).RoleInfo.RoleId;
            }
            else if (obj is Teacher)
            {
                return (obj as Teacher).RoleInfo.RoleId;
            }
            else if (obj is Admin)
            {
                return (obj as Admin).RoleInfo.RoleId;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 获得指定节点的程序资料   键:父节点的程序id   值(程序集合):第一个是父节点的程序,后面是这个父节点下的所有的子节点
        /// </summary>
        /// <returns></returns>
        public static Dictionary<int, IList<SysFun>> GetFunsById(int id)
        {
            Dictionary<int, IList<SysFun>> dicResult = new Dictionary<int, IList<SysFun>>();
            SysFunBLL sysfunBll = new SysFunBLL();
            //获取id节点下所有子节点
            IList<SysFun> rootFuns = sysfunBll.GetList("ParentNodeId="+id.ToString ());

            //遍历所有的父节点
            foreach (SysFun rootFun in rootFuns)
            {
                //取得该节点所有子节点
                IList<SysFun> children = sysfunBll.GetList("ParentNodeId="+rootFun.NodeId+" order by DisplayOrder");
                if (children != null)
                {
                    children.Insert(0, rootFun);//把父节点加到所有子节点的前面
                    dicResult.Add(rootFun.NodeId, children);
                }
            }
            return dicResult;
        }

         /// <summary>
        /// 创建菜单树
        /// </summary>
        public static string CreateTree()
        {
            StringBuilder sbTree = new StringBuilder();//菜单树代码
            //当前用户的所有权限
            IList<RoleRight> currRoleRights = GetRoleRightsFromSession();

            //获取当前展开节点
            List<string> openNode = HttpContext.Current.Session["openNodes"] as List<string>;

            //获得所有根节点
            Dictionary<int, IList<SysFun>> dicRootFuns = GetFunsById(0);
            foreach (var item in dicRootFuns.Values)//item中存的是 第一个是父节点,后面是这个父节点的所有子节点
            {
                for (int i = 0; i < item.Count; i++)//遍历每一个程序
                {
                    for (int j = 0; j < currRoleRights.Count; j++)//看改程序有没有权限显示
                    {
                        if (item[i].NodeId == currRoleRights[j].SysFun.NodeId)
                        {
                            if (string.IsNullOrEmpty(item[i].NodeURL))
                            {
                                if (openNode != null && openNode.Contains(item[i].NodeId.ToString ()))
                                {
                                    sbTree.Append("<dl  class=\"menu\">\r\n<dt id=\"" + item[i].NodeId + "\" class=\"menu-header open\"><span class=\"menu-header-icon menu-icon\"></span>" + item[i].DisplayName + "</dt>\r\n");
                                }
                                else
                                {
                                    sbTree.Append("<dl  class=\"menu\">\r\n<dt id=\"" + item[i].NodeId + "\" class=\"menu-header close\"><span class=\"menu-header-icon menu-icon\"></span>" + item[i].DisplayName + "</dt>\r\n");
                                    //  AddChildren(currRoleRights, item[i].NodeId,sbTree);
                                    // sbTree.Append("</dt>");
                                }
                            }
                            else
                            {
                                sbTree.Append("<dd id=\""+item[i].NodeId+"\" class=\"menu-list\"><span class=\"menu-list-icon menu-icon\"></span><a href=\"" + item[i].NodeURL + "?nodeId="+item[i].NodeId+"\">" + item[i].DisplayName + "</a></dd>\r\n");
                                //todo:addchildren
                               // sbTree.Append();
                            }
                            if (i == item.Count - 1)
                            {
                                sbTree.Append("</dl>\r\n");
                            }
                            break;
                        }
                    }
                }
            }
            return sbTree.ToString();
        }

        private static void AddChildren(IList<RoleRight> currRoleRights, int id, StringBuilder sbTree)
        {

        }

        #region +获得功能页码条
        /// <summary>
        /// 获得功能页码条
        /// </summary>
        /// <param name="url">页码连接地址</param>
        /// <param name="searcheurl">搜索url</param>
        /// <param name="allrecord">全部记录条数</param>
        /// <param name="allpage">全部页面数</param>
        /// <param name="curpage">当前页码</param>
        /// <param name="groupsize">页码组大小</param>
        /// <param name="pagesize">页容量</param>
        public static string GetPageTxt(string url, string searcheurl, int allrecord, int allpage, int curpage, int groupsize, int pagesize)
        {
            int curGroupPage = 0;
            StringBuilder test = new StringBuilder();
            StringBuilder test2 = new StringBuilder();
            StringBuilder pagetxt = new StringBuilder();
            if (curpage.Equals("") || curpage < 1) curpage = 1;
            if (allrecord.Equals("") || allrecord < 1) allrecord = 1;
            if (pagesize.Equals("") || pagesize < 1) pagesize = 1;
            if (allrecord == 0) { pagetxt.Append("页码：0/0 │ 共0条</TD> <td align='left'> 首页 << 上一页 | 1 Next | >> 尾页 &nbsp;&nbsp;</td></tr></table>"); }
            else
            {
                test2.Append(allpage.ToString());

                if (allpage.Equals("") || allpage < 1) allpage = 1;
                pagetxt.Append("页码：" + curpage.ToString() + "/" + allpage.ToString() + " │ 共" + allrecord.ToString() + "条");
                pagetxt.Append("<A href='" + url + "1' title='首页'>1</A>&nbsp;");
                curGroupPage = (((curpage - 1) / groupsize) * groupsize) + 1;

                if (curGroupPage <= 1) pagetxt.Append("<a href='" + url + curGroupPage + searcheurl + "' title='回到首页'>&lt;&lt;</A>&nbsp;");
                else pagetxt.Append("<a href='" + url + (curGroupPage - 1) + searcheurl + "' title='前 " + groupsize + " 页'>&lt;&lt;</A>&nbsp;");

                if (curpage <= 1) pagetxt.Append("<A href='" + url + curpage + searcheurl + "' title='首页'>Prev</A>&nbsp;");
                else pagetxt.Append("<A href='" + url + (curpage - 1) + searcheurl + "' title='前一页'>Prev</A>&nbsp;");

                int tempI = 0;
                tempI = curGroupPage;
                do
                {
                    if (tempI == curpage) pagetxt.Append("<span class='nowpage'>" + tempI + "</span>&nbsp;");
                    else pagetxt.Append("<A href='" + url + tempI + searcheurl + "'>" + tempI + "</A>&nbsp;");
                    tempI = tempI + 1;
                } while (tempI < curGroupPage + groupsize && tempI <= allpage);

                if (curpage < allpage) pagetxt.Append("<A href='" + url + (curpage + 1) + searcheurl + "' title='后一页'>Next</A>&nbsp;");
                else pagetxt.Append("<A href='" + url + curpage + searcheurl + "' title='后一页'>Next</A>&nbsp;");

                if (curGroupPage + groupsize > allpage) pagetxt.Append("<a href='" + url + allpage + searcheurl + "' title='后 " + groupsize + " 页'>&gt;&gt;</A>&nbsp;");
                else pagetxt.Append("<a href='" + url + (curGroupPage + groupsize) + searcheurl + "' title='后" + groupsize + "页'>&gt;&gt;</A>&nbsp;");

                pagetxt.Append("<A href='" + url + allpage + searcheurl + "' title='最后一页'>" + allpage + "</A>");
            }
            test.Append("allpage=" + allpage + ",allrecord=" + allrecord + ",pagesize=" + pagesize + ",groupsize=" + groupsize + ",curGroupPage=" + curGroupPage + ",curpage=" + curpage);
            return pagetxt.ToString();
        }
        #endregion


        #region +获得功能页码条
        /// <summary>
        /// 获得功能页码条
        /// </summary>
        /// <param name="funName">js方法名</param>
        /// <param name="allrecord">全部记录条数</param>
        /// <param name="allpage">全部页面数</param>
        /// <param name="curpage">当前页码</param>
        /// <param name="groupsize">页码组大小</param>
        /// <param name="pagesize">页容量</param>
        public static string GetPageTxtAjax(string funName, int allrecord, int allpage, int curpage, int groupsize, int pagesize)
        {
            int curGroupPage = 0;
            StringBuilder test = new StringBuilder();
            StringBuilder test2 = new StringBuilder();
            StringBuilder pagetxt = new StringBuilder();
            if (curpage.Equals("") || curpage < 1) curpage = 1;
            if (allrecord.Equals("") || allrecord < 1) allrecord = 1;
            if (pagesize.Equals("") || pagesize < 1) pagesize = 1;
            if (allrecord == 0) { pagetxt.Append("页码：0/0 │ 共0条</TD> <td align='left'> 首页 << 上一页 | 1 Next | >> 尾页 &nbsp;&nbsp;</td></tr></table>"); }
            else
            {
                test2.Append(allpage.ToString());

                if (allpage.Equals("") || allpage < 1) allpage = 1;
                pagetxt.Append("页码：" + curpage.ToString() + "/" + allpage.ToString() + " │ 共" + allrecord.ToString() + "条");
                pagetxt.Append("<A href='javascript:" + funName + "(1)' title='首页'>1</A>&nbsp;");
                curGroupPage = (((curpage - 1) / groupsize) * groupsize) + 1;

                if (curGroupPage <= 1) pagetxt.Append("<a href='javascript:" + funName + "(" + curGroupPage + ")' title='回到首页'>&lt;&lt;</A>&nbsp;");
                else pagetxt.Append("<a href='javascript:" + funName + "(" + (curGroupPage - 1) + ")' title='前 " + groupsize + " 页'>&lt;&lt;</A>&nbsp;");

                if (curpage <= 1) pagetxt.Append("<A href='javascript:" + funName + "(" + curpage + ")' title='首页'>Prev</A>&nbsp;");
                else pagetxt.Append("<A href='javascript:" + funName + "(" + (curpage - 1) + ")' title='前一页'>Prev</A>&nbsp;");

                int tempI = 0;
                tempI = curGroupPage;
                do
                {
                    if (tempI == curpage) pagetxt.Append("<span class='nowpage'>" + tempI + "</span>&nbsp;");
                    else pagetxt.Append("<A href='javascript:" + funName + "(" + tempI + ")'>" + tempI + "</A>&nbsp;");
                    tempI = tempI + 1;
                } while (tempI < curGroupPage + groupsize && tempI <= allpage);

                if (curpage < allpage) pagetxt.Append("<A href='javascript:" + funName + "(" + (curpage + 1) + ")' title='后一页'>Next</A>&nbsp;");
                else pagetxt.Append("<A href='javascript:" + funName + "(" + curpage + ")' title='后一页'>Next</A>&nbsp;");

                if (curGroupPage + groupsize > allpage) pagetxt.Append("<a href='javascript:" + funName + "(" + allpage + ")' title='后 " + groupsize + " 页'>&gt;&gt;</A>&nbsp;");
                else pagetxt.Append("<a href='javascript:" + funName + "(" + (curGroupPage + groupsize) + ")' title='后" + groupsize + "页'>&gt;&gt;</A>&nbsp;");

                pagetxt.Append("<A href='javascript:" + funName + "(" + allpage + ")' title='最后一页'>" + allpage + "</A>");
            }
            test.Append("allpage=" + allpage + ",allrecord=" + allrecord + ",pagesize=" + pagesize + ",groupsize=" + groupsize + ",curGroupPage=" + curGroupPage + ",curpage=" + curpage);
            return pagetxt.ToString();
        }
        #endregion
    }
}