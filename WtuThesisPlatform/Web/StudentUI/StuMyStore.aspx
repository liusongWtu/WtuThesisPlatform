<%@ Page Title="" Language="C#" MasterPageFile="~/StudentUI/StudentMasterPage.Master"
    AutoEventWireup="true" CodeBehind="StuMyStore.aspx.cs" Inherits="Web.StudentUI.StuMyStore" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../css/student/stu_page.css" />
    <link rel="stylesheet" type="text/css" href="../js/popup/jquery.confirm.css" />
    <script type="text/javascript" src="../js/popup/jquery.confirm.js"></script>
    <script type="text/javascript" src="../js/student/StuMyStore.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <div class="wrap">
        <div class="mystore">
            <dl>
                <dt>我的收藏<span><a href="/StudentUI/StuSelect.aspx?nodeId=201" class="arrow-left">进入所有选题页面</a><a href="/StudentUI/StuMySelect.aspx?nodeId=203" class="aRight">进入我的选题<span
                    class="arrow-right dis-inline-block"></span></a></span></dt>
                <dd>
                    <table class="topic-list" cellspacing="0" cellpadding="0">
                        <asp:Repeater ID="rptMyStore" runat="server">
                            <ItemTemplate>
                                <tr id="<%#Eval("CId") %>">
                                    <td class="topicName">
                                        <a href="/StudentUI/StuTopicDetail.aspx?thesisId=<%#Eval("ThesisTitle.TId") %>"><%#Eval("ThesisTitle.TName")%></a>
                                    </td>
                                    <td class="teacher">
                                        <a href="/StudentUI/StuTopicInfo.aspx?teacherId=<%#Eval("ThesisTitle.Teacher.TId") %>"><%#Eval("ThesisTitle.Teacher.TName")%></a>
                                    </td>
                                    <td class="vanancy">
                                        剩余<span id="vanaNum">&nbsp;<%#Eval("LeftNum")%>&nbsp;</span>人
                                    </td>
                                    <td class="select">
                                        <span class="select-icon dis-inline-block"></span>
                                    </td>
                                    <td class="delete">
                                        <span class="delete-icon dis-inline-block"></span>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </dd>
            </dl>
        </div>
    </div>
</asp:Content>
