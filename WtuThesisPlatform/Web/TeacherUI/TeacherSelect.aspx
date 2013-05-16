<%@ Page Title="" Language="C#" MasterPageFile="~/TeacherUI/TeacherMasterPage.Master"
    AutoEventWireup="true" CodeBehind="TeacherSelect.aspx.cs" Inherits="Web.TeacherUI.TeacherSelect1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="Stylesheet" type="text/css" href="../css/teacher/teacher_pages.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <div class="select-list">
        <div class="topic">
            <dl>
                <dt>
                        学生选题情况
                </dt>
            </dl>
            <table id="topicList" class="topic-list" cellspacing="0" cellpadding="0">
                <tr class="list-header">
                    <td style="width: 40%" class="left">
                        选题名称
                    </td>
                    <td style="width: 20%">
                        允许人数
                    </td>
                    <td style="width: 20%">
                        新选人数
                    </td>
                    <td style="width: 20%;" class="last">
                        确定人数
                    </td>
                </tr>
                <asp:Repeater ID="rptThesis" runat="server">
                    <ItemTemplate>
                        <tr class="list-content">
                            <td class="topicName bold left">
                                <a href="/TeacherUI/TopicDetail.aspx?tid=<%#Eval("TId") %>">
                                    <%#Eval("TName")%>
                                </a>
                            </td>
                            <td>
                                <%#Eval("TNumber") %>
                            </td>
                            <td>
                                <a href="/TeacherUI/TeacherSelectStu.aspx?tid=<%#Eval("TId") %>"><%#Eval("TNewNum")%></a>
                            </td>
                            <td>
                                <a href="/TeacherUI/TeacherCancelStu.aspx?tid=<%#Eval("TId") %>"><%#Eval("TAcceptNum")%></a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
    </div>
</asp:Content>
