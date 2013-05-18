<%@ Page Title="" Language="C#" MasterPageFile="~/AdminUI/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="GoodWorkManager.aspx.cs" Inherits="Web.AdminUI.GoodWorkManager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <div class="select-list">
    <div class="topic">
        <dl><dt>学生优秀毕业作品申请</dt></dl>
        <div class="content-center">
            <table id="applyTopicList" class="topic-list" cellspacing="0" cellpadding="0">
                <tr class="list-header">
                    <td class="tr3">&nbsp;</td>
                    <td class="first left">作品名称</td>
                    <td>学生</td>
                    <td>状态</td>
                    <td class="last">操作</td>
                </tr>
                
                <asp:Repeater ID="rptGoodWork" runat="server">
                <ItemTemplate>
                    <tr class="list-content nohover">
                    <td><input type="checkbox" name="topiclist" /></td>
                    <td class="bold left">
                        <a href="#"><%#Eval("GTitle") %></a>
                    </td>
                    <td>
                        <span class="tea-name"><%#Eval("Student.SName") %></span>
                    </td>
                    <td>
                        <span class="tea-status"><%#Eval("StateString") %></span>
                    </td>
                    <td>
                        <span class="ope"><a href="#">通过</a>/<a href="#">不通过</a></span>
                    </td>
                </tr>
                </ItemTemplate>
                </asp:Repeater>
                    
            </table>
        </div>
        <div class="content-bottom">
           <div class="pagechange">
                <%--<div id="pageBar"><%=pageBar%></div>--%>
            </div>
        </div>
    </div>
    </div>
</asp:Content>
