<%@ Page Title="" Language="C#" MasterPageFile="~/AdminUI/AdminMasterPage.Master"
    AutoEventWireup="true" CodeBehind="AdminInfo.aspx.cs" Inherits="Web.AdminUI.AdminInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../css/admin/adm_page.css" />

    <script src="../js/Common.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/om/ui/rules.js"></script>
    <script type="text/javascript" src="../js/om/ui/om-validate.js"></script>
    <script type="text/javascript" src="../js/Validata.js"></script>
    <script src="../js/admin/Admininfo.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    
    <div class="wrap">
        <div class="person-info">
            <dl>
                <dt>个人基本信息
                    <span class="modify"><a href="AdminModifyPwd.aspx" id="mPassword" class="dis-inline-block">
                        修改密码</a><a href="#" id="mInfo" class="dis-inline-block">修改个人信息</a></span></dt>
            </dl>
            <table>
                <tr>
                    <td class="col-name">姓 名：</td>
                    <td><input type="text" id="aName" class="aName" value="<%=currAdmin.UUserName %>" readonly="readonly" /></td></tr>
                <tr>
                    <td class="col-name">电 话：</td>
                    <td><input type="text" name="isMobilePhone" id="aPhone" class="aPhone" value="<%=currAdmin.UPhone %>" readonly="readonly" /></td>
                    <td><span class="errorImg"></span><span class="errorMsg"></span></td>
                    </tr>
                <tr>
                    <td class="col-name">邮 箱：</td>
                    <td><input type="text" name ="isEmail" id="aEmail" class="aEmail" value="<%=currAdmin.UEmail %>" readonly="readonly" /></td>
                    <td><span class="errorImg"></span><span class="errorMsg"></span></td>
                </tr>
                <tr>
                    <td class="col-name">Q Q：</td>
                    <td><input type="text" name="isQQ" id="aQQ" class="aQQ" value="<%=currAdmin.UQQ %>" readonly="readonly" /></td>
                    <td><span class="errorImg"></span><span class="errorMsg"></span></td>
                    </tr>
            </table>
        </div>
    </div>
</asp:Content>
