<%@ Page Title="" Language="C#" MasterPageFile="~/AdminUI/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="TeacherApply.aspx.cs" Inherits="Web.AdminUI.TeacherApply" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <div class="select-list">
    <div class="topic">
        <dl><dt>教师选题申请</dt></dl>
        <div class="content-center">
            <table id="applyTopicList" class="topic-list" cellspacing="0" cellpadding="0">
                <tr class="list-header">
                    <td class="tr3">&nbsp;</td>
                    <td class="first left">选题名称</td>
                    <td>教师</td>
                    <td>状态</td>
                    <td class="last">操作</td>
                </tr>
                
                <asp:Repeater ID="rptThesis" runat="server">
                <ItemTemplate>
                <tr class="list-content nohover" id="">
                    <td><input type="checkbox" name="topiclist" /></td>
                    <td class="bold left">
                        <a href="/AdminUI/TeacherApplyDetail.aspx?nodeId=3051&tid=<%#Eval("TId") %>"><%#Eval("TName") %></a>
                    </td>
                    <td>
                        <span class="tea-name"><%#Eval("Teacher.TName") %></span>
                    </td>
                    <td>
                        <span class="tea-status"><%#Eval("StateString")%></span>
                    </td>
                    <td>
                        <span class="ope-state"><a href="#">通过</a>/<a href="#">不通过</a></span>
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
