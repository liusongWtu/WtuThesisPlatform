<%@ Page Title="" Language="C#" MasterPageFile="~/StudentUI/StudentMasterPage.Master"
    AutoEventWireup="true" CodeBehind="StuMySelect.aspx.cs" Inherits="Web.StudentUI.StuMySelect" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../css/student/stu_page.css" />
    <link rel="stylesheet" type="text/css" href="../js/popup/jquery.confirm.css" />
    <script type="text/javascript" src="../js/popup/jquery.confirm.js"></script>
    <script type="text/javascript" src="../js/student/StuMySelect.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <div class="wrap">
        <div class="myselect">
            <dl>
                <dt>我的志愿<span><a href="/StudentUI/StuSelect.aspx?nodeId=201" class="arrow-left">进入所有选题页面</a><a href="/StudentUI/StuMyStore.aspx?nodeId=202" class="aRight">进入我的收藏<span
                    class="arrow-right dis-inline-block"></span></a></span></dt>
                <dd>
                    <table class="topic-list" cellspacing="0" cellpadding="0">
                        <asp:Repeater ID="rptMySelect" runat="server">
                            <ItemTemplate>
                                <tr id="<%#Eval("TId") %>">
                            <td id="selectOrder" class="selectOrder">
                                志愿<span class="order"></span>
                            </td>
                            <td id="topicName" class="topicName">
                                <a href="/StudentUI/StuTopicDetail.aspx?nodeId=1013&thesisId=<%#Eval("ThesisTitle.TId") %>"><%#Eval("ThesisTitle.TName") %></a>
                            </td>
                            <td id="teacher" class="teacher">
                                <a href="/StudentUI/StuTopicInfo.aspx?nodeId=1013&teacherId=<%#Eval("ThesisTitle.Teacher.TId") %>"><%#Eval("ThesisTitle.Teacher.TName") %></a>
                            </td>
                            <td id="vanancy" class="vanancy">
                                剩余<span id="vanaNum">&nbsp;<%#Eval("LeftNum") %>&nbsp;</span>人
                            </td>
                            <td id="selectState">
                                <%#Eval("StateString") %>
                            </td>
                            <td id="refuseSelect">
                                <span class="refuse-select-icon dis-inline-block"></span>
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
