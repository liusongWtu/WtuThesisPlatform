<%@ Page Title="" Language="C#" MasterPageFile="~/AdminUI/AdminMasterPage.Master"
    AutoEventWireup="true" CodeBehind="NoticeManager.aspx.cs" Inherits="Web.AdminUI.NoticeManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../css/student/stu_select.css" />
    <link rel="stylesheet" type="text/css" href="../css/student/stu_page.css" />
    <style type="text/css">
        #pageBar a
        {
            border: 2px solid #fff;
            background-color: #ff6600;
            padding: 0px 6px;
            text-decoration: none;
            color: #fff;
        }
        #pageBar a:hover
        {
            color: #fff;
            background-color: #7AB64F;
        }
    </style>
    <script type="text/javascript" src="../js/student/StuSelect.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <div class="select-list">
        <div class="content-top">
            <div class="search fl fillet">
                <label class="ablt">
                    关键字...</label>
                <input type="text" class="search-input" />
                <button id="searchButton" class="search-button abrt">
                    <span>搜索</span></button>
            </div>
        </div>
        <div class="content-center">
            <!-- <table id="grid"></table>-->
            <table id="topicList" class="topic-list" cellspacing="0" cellpadding="0">
                <tr class="list-header">
                    <td class="td0">
                        &nbsp;
                    </td>
                    <td class="td1">
                        公告标题
                    </td>
                    <td class="td2">
                        发布单位
                    </td>
                    <td class="td3">
                        发布人
                    </td>
                    <td class="td4">
                        发布日期
                    </td>
                    <td class="td5">
                        修改
                    </td>
                    <td class="td5">
                        删除
                    </td>
                </tr>
                <asp:Repeater ID="rptAdmin" runat="server">
                    <ItemTemplate>
                        <tr class="list-content">
                            <td class="td0">
                                <input type="checkbox" name="topiclist" id="<%#Eval("NId") %>" />
                            </td>
                            <td class="td1">
                                <a href="#" title="<%#Eval("NTitle") %>">
                                    <%#Eval("NTitle").ToString().Length > 15 ? Eval("NTitle").ToString().Substring(0, 15) + "..." : Eval("NTitle")%></a>
                            </td>
                            <td class="td2">
                                <%#Eval("NPublishUnits") %>
                            </td>
                            <td class="td3">
                                <%#Eval("NName") %>
                            </td>
                            <td class="td4">
                                <%#string.Format ("{0:yyyy/MM/dd}",Eval("NPublishTime")) %>
                            </td>
                            <td class="td5">
                                <a href="#">修改</a>
                            </td>
                            <td class="td6">
                                <a href="#">删除</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
        <table class="pagechange">
            <tr>
                <div id="pageBar">
                    <%=pageBar%></div>
            </tr>
        </table>
    </div>
</asp:Content>
