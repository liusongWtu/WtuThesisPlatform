<%@ Page Title="" Language="C#" MasterPageFile="~/StudentUI/StudentMasterPage.Master"
    AutoEventWireup="true" CodeBehind="StuInfo.aspx.cs" Inherits="Web.StudentUI.StuInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../css/student/stu_page.css" />
    <link rel="stylesheet" type="text/css" href="../js/popup/jquery.confirm.css" />
    <script src="../js/student/StuInfo.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/popup/jquery.confirm.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <div class="wrap">
        <div class="stu-info">
            <dl>
                <dt>
                    <h1>
                        个人基本信息</h1>
                    <span class="modify"><a href="StuModifyPwd.aspx" id="mPassword" class="dis-inline-block">
                        修改密码</a><a href="javascript:void(0)" id="mInfo" class="dis-inline-block">修改个人信息</a></span></dt>
                <dd>
                    姓名：<input type="text" id="sName" class="sName" runat="server" value="刘松" readonly="readonly" /></dd>
                <dd>
                    学号：<input type="text" id="sNo" class="sNo" runat="server" value="0904681206" readonly="readonly" /></dd>
                <dd>
                    届数：<input type="text" id="sYear" class="sYear" runat="server" value="" readonly="readonly" /></dd>
                <dd>
                    院系：<select id="sFaculty" class="sFaculty" runat="server" disabled="disabled">
                    </select></dd>
                <dd>
                    专业：<select id="sProfession" class="sProfession" runat="server" disabled="disabled">
                    </select></dd>
                <dd>
                    班级：<select id="sClass" class="sClass" runat="server" disabled="disabled">
                    </select></dd>
                <dd>
                    电话：<input type="text" id="sPhone" class="sPhone" runat="server" value="13419540412"
                        readonly="readonly" /><span id="phoneError" style="color: red; display: none">*</span>
                </dd>
                <dd>
                    邮箱：<input type="text" id="sEmail" class="sEmail" runat="server" value="594659037@qq.com"
                        readonly="readonly" /><span id="emailError" style="color: red; display: none">*</span>
                </dd>
                <dd>
                    Q Q：
                    <input type="text" id="sQQ" class="sQQ" runat="server" value="594659037" readonly="readonly" /></dd>
            </dl>
            <!--<div id="tPhoto">
								待定
							</div>-->
        </div>
    </div>
</asp:Content>
