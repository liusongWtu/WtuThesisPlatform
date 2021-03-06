﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AdminUI/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="DictionaryManager.aspx.cs" Inherits="Web.AdminUI.DictionaryManager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="Stylesheet" type="text/css" href="../css/admin/adm_page.css" />
    <script type="text/javascript">
        $(function () {
            var num = $(".btnSave").attr("success");
            if (typeof (num) != 'undefined') {
                $.omMessageTip.show({ content: '保存成功', timeout: 1000, type: 'success' });
            }
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <div class="select-list"> 
        <div class="topic"> 
        <dl>
            <dt>
                    系统参数设置
            </dt>
            <br />
        </dl>
        <div class="content-center">
        <table class="dictionary">
            <tr><td class="col-name">当前届：</td><td>
                <select id="currYear" runat="server">
                </select>
            </td></tr>
            <tr><td class="col-name">是否向学生开放：</td><td>
                <asp:RadioButtonList  ID="rblStuOpen" runat="server" Width="120px" RepeatDirection="Horizontal">
                    <asp:ListItem  Selected="True" Value="yes">是</asp:ListItem><asp:ListItem Value="no" >否</asp:ListItem>
                </asp:RadioButtonList>
               
            </td></tr>
            <tr><td>是否向教师开放：</td><td>
                <asp:RadioButtonList  ID="rblTeaOpen" runat="server" Width="120px" RepeatDirection="Horizontal">
                    <asp:ListItem  Selected="True" Value="yes">是</asp:ListItem><asp:ListItem Value="no" >否</asp:ListItem>
                </asp:RadioButtonList>
               
            </td></tr>
            <tr><td class="col-name">学生志愿数：</td><td>
                <select id="wish" runat="server">
                    <option selected="selected">1</option>
                    <option>2</option>
                    <option>3</option>
                    <option>4</option>
                    <option>5</option>
                </select>
            </td></tr>
        </table>
        </div>
        <div class="content-bottom">
            <asp:Button ID="btnSave" CssClass="btnSave" runat="server" Text="保 存" onclick="btnSave_Click" />
        </div>
        </div>
    </div>
</asp:Content>
