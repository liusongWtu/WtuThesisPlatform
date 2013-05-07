<%@ Page Title="" Language="C#" MasterPageFile="~/AdminUI/AdminMasterPage.Master"
    AutoEventWireup="true" CodeBehind="AdminManager.aspx.cs" Inherits="Web.AdminUI.AdminManager" %>

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
            <tr><td><a href="#">添加</a>&nbsp;&nbsp;<a href="#">导入</a>&nbsp;&nbsp;<a href="#">导出</a></td></tr>
                <tr class="list-header">
                    <td class="td0">
                        &nbsp;
                    </td>
                    <td class="td1">
                        登录名
                    </td>
                    <td class="td2">
                        姓名
                    </td>
                    <td class="td3">
                        电话
                    </td>
                    <td class="td4">
                        Email
                    </td>
                    <td class="td5">
                        详细信息
                    </td>
                    <td class="td6">
                        重置密码
                    </td>
                    <td class="td7">
                        修改
                    </td>
                    <td class="td8">
                        删除
                    </td>
                </tr>
                <asp:Repeater ID="rptAdmin" runat="server">
                    <ItemTemplate>
                        <tr class="list-content">
                            <td class="td0">
                                <input type="checkbox" name="topiclist" id="<%#Eval("UId") %>" />
                            </td>
                            <td class="td1">
                                    <%#Eval("UUserName") %>
                            </td>
                            <td class="td2">
                                <%#Eval("UName") %>
                            </td>
                            <td class="td3">
                                <%#Eval("UPhone") %>
                            </td>
                            <td class="td4">
                                <%#Eval("UEmail") %>
                            </td>
                            <td class="td5">
                                <a href="#">
                                    查看详情</a>
                            </td>
                            <td class="td6" >
                                <a href="#">重置</a>
                            </td>
                            <td class="td7">
                                <a href="#">修改</a>
                            </td>
                            <td class="td8">
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
    </div>
</asp:Content>
