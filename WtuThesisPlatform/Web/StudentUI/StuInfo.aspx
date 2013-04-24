<%@ Page Title="" Language="C#" MasterPageFile="~/StudentUI/StudentMasterPage.Master"
    AutoEventWireup="true" CodeBehind="StuInfo.aspx.cs" Inherits="Web.StudentUI.StuInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../css/student/stu_page.css" />
    <link rel="stylesheet" type="text/css" href="../js/popup/jquery.confirm.css" />
    <script type="text/javascript" src="../js/student/stu_pages.js"></script>
    <script type="text/javascript" src="../js/popup/jquery.confirm.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <div class="wrap">
        <div class="stu-info">
            <dl>
                <dt>
                    <h1>
                        个人基本信息</h1>
                    <span class="modify"><a href="stu_modify_password.html" id="mPassword" class="dis-inline-block">
                        修改密码</a><a href="#" id="mInfo" class="dis-inline-block">修改个人信息</a></span></dt>
                <dd>
                    姓名：<input type="text" id="sName" runat="server" value="刘松" readonly="readonly" /></dd>
                <dd>
                    学号：<input type="text" id="sNo" runat="server" value="0904681206" readonly="readonly" /></dd>
                <dd>
                    院系：<select id="sFaculty" runat="server" readonly="readonly">
                    </select></dd>
                <dd>
                    专业：<input type="text" id="sProfession" runat="server" value="软件工程" readonly="readonly" /></dd>
                <dd>
                    班级：<input type="text" id="sGrade" runat="server" value="软件091" readonly="readonly" /></dd>
                <dd>
                    Q Q：
                    <input type="text" id="sQQ" runat="server" value="594659037" readonly="readonly" /></dd>
                <dd>
                    电话：<input type="text" id="sPhone" runat="server" value="13419540412" readonly="readonly" /></dd>
                <dd>
                    邮箱：<input type="text" id="sEmail" runat="server" value="594659037@qq.com" readonly="readonly" />
                </dd>
            </dl>
            <!--<div id="tPhoto">
								待定
							</div>-->
        </div>
    </div>
</asp:Content>
