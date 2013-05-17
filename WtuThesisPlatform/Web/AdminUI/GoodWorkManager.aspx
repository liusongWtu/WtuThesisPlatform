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
                
                <tr class="list-content nohover">
                    <td><input type="checkbox" name="topiclist" /></td>
                    <td class="bold left">
                        <a href="#">毕业设计选题系统</a>
                    </td>
                    <td>
                        <span class="tea-name">刘松</span>
                    </td>
                    <td>
                        <span class="tea-status">待审核</span>
                    </td>
                    <td>
                        <span class="ope"><a href="#">通过</a>/<a href="#">不通过</a></span>
                    </td>
                </tr>
                    
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
