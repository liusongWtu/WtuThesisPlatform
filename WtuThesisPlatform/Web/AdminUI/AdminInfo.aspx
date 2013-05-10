<%@ Page Title="" Language="C#" MasterPageFile="~/AdminUI/AdminMasterPage.Master"
    AutoEventWireup="true" CodeBehind="AdminInfo.aspx.cs" Inherits="Web.AdminUI.AdminInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../css/student/stu_page.css" />
    <link rel="stylesheet" type="text/css" href="../js/popup/jquery.confirm.css" />
    <script src="../js/Common.js" type="text/javascript"></script>
    <script src="../js/admin/Admininfo.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/popup/jquery.confirm.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <div class="wrap">
        <div class="person-info">
            <dl>
                <dt>个人基本信息
                    <span class="modify"><a href="AdminModifyPwd.aspx" id="mPassword" class="dis-inline-block">
                        修改密码</a><a href="#" id="mInfo" class="dis-inline-block">修改个人信息</a></span></dt>
                <dd>
                    姓 名：<input type="text" id="sName" class="sName" runat="server" value="刘松" readonly="readonly" /></dd>
                <dd>
                    电 话：<input type="text" id="sPhone" class="sPhone" runat="server" value="13419540412"
                        readonly="readonly" /><span id="phoneError" style="color: red; display: none">*</span>
                </dd>
                <dd>
                    邮 箱：<input type="text" id="sEmail" class="sEmail" runat="server" value="594659037@qq.com"
                        readonly="readonly" /><span id="emailError" style="color: red; display: none">*</span>
                </dd>
                <dd>
                    Q Q：
                    <input type="text" id="sQQ" class="sQQ" runat="server" value="594659037" readonly="readonly" />
                    <span id="qqError" style="color: red; display: none">*</span></dd>
            </dl>
            <!--<div id="tPhoto">
								待定
							</div>-->
        </div>
    </div>
</asp:Content>
