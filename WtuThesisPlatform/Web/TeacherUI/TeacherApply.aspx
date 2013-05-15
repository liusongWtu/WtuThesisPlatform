<%@ Page Title="" Language="C#" MasterPageFile="~/TeacherUI/TeacherMasterPage.Master"
    AutoEventWireup="true" CodeBehind="TeacherApply.aspx.cs" Inherits="Web.TeacherUI.TeacherSelect" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../css/teacher/teacher_pages.css" />
    <script type="text/javascript" src="../js/teacher/TeacherSelect.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
   <div class="wrap">
    <div class="topic">
        <dl><dt>我的申请</dt></dl>
        <div class="content-center">
            <table id="applyTopicList" class="topic-list" cellspacing="0" cellpadding="0">
                <tr class="list-header">
                    <td class="tr3">&nbsp;</td>
                    <td class="first left">选题名称</td>
                    <td>状态</td>
                    <td>申请</td>
                    <td>修改</td>
                    <td>预览</td>
                    <td class="last">删除</td>
                </tr>
                <asp:Repeater runat="server" ID="rptThesis">
                    <ItemTemplate>
                        <tr class="list-content nohover" id="<%#Eval("TId") %>">
                            <td><input type="checkbox" name="topiclist" /></td>
                            <td class="bold left">
                                <a href="/TeacherUI/TopicDetail.aspx?tid=<%#Eval("TId") %>"><%#Eval("TName") %></a>
                            </td>
                            <td>
                                <span class="tea-status"><%#Eval("StateString") %></span>
                            </td>
                            <td>
                                <a class="tea-apply" state="<%#Eval("IsDel") %>">申请</a>
                            </td>
                            <td>
                                <a class="tea-modify">修改</a>
                            </td>
                            <td>
                                <a class="tea-check">预览</a>
                            </td>
                            <td>
                                <a class="tea-delete">删除</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
        <div class="content-bottom">
           <ul class="operate">
                <li>
                    <input type="checkbox" name="checkall" id="checkAll" />&nbsp;全选</li>
                <li>|</li>
                <li><a href="#" id="deleteCount">批量删除</a></li>
                <li>|</li>
                <li><a href="ApplyExcel.aspx">创建新申请</a></li>
            </ul>
        </div>
    </div>
    </div>
</asp:Content>
