<%@ Page Title="" Language="C#" MasterPageFile="~/StudentUI/StudentMasterPage.Master"
    AutoEventWireup="true" CodeBehind="StuSelect.aspx.cs" Inherits="Web.StudentUI.StuSelect" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../css/student/stu_select.css" />
    <link rel="stylesheet" type="text/css" href="../css/student/stu_page.css" />
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
            <!--<div class="top-change-page fr">
								<span id="topPageUp" class="top-page-up top-page"></span>
								<strong><span id="currentPage" class="current-page">123</span>\<span id="totalPage" class="total-page">1000</span></strong>
								<span id="topPageDown" class="top-page-down top-page"></span>
							</div>-->
            <!--<table>
								<tr>
									<td id="topPageUp"></td>
									<td></td>
									<td id="topPageDown"></td>
								</tr>
							</table>-->
        </div>
        <div class="content-center">
            <!-- <table id="grid"></table>-->
            <table id="topicList" class="topic-list" cellspacing="0" cellpadding="0">
                <tr class="list-header">
                    <td class="td0">
                        &nbsp;
                    </td>
                    <td class="td1">
                        选题名称
                    </td>
                    <td class="td2">
                        允许人数
                    </td>
                    <td class="td3">
                        新选人数
                    </td>
                    <td class="td4">
                        确定人数
                    </td>
                    <td class="td5">
                        教师
                    </td>
                    <td class="td6">
                        收藏
                    </td>
                    <td class="td7 last">
                        选题
                    </td>
                </tr>
                <asp:Repeater ID="rptThesises" runat="server">
                    <ItemTemplate>
                        <tr class="list-content">
                            <td class="td0">
                                <input type="checkbox" name="topiclist" id="<%#Eval("TId") %>" />
                            </td>
                            <td class="td1">
                                <a href="/StudentUI/StuTopicDetail.aspx?thesisId=<%#Eval("TId") %>">
                                    <%#Eval("TName") %></a>
                            </td>
                            <td class="td2">
                                <%#Eval("TNumber") %>
                            </td>
                            <td class="td3">
                                <%#Eval("TNewNum") %>
                            </td>
                            <td class="td4">
                                <%#Eval("TAcceptNum") %>
                            </td>
                            <td class="td5 teacher">
                                <a href="/StudentUI/StuTopicInfo.aspx?teacherId=<%#Eval("Teacher.TId") %>">
                                    <%#Eval("Teacher.TName") %></a>
                            </td>
                            <td class="td6" id="<%#Eval("TId") %>">
                                <span class="store-icon list-icon"></span>
                            </td>
                            <td class="td7" id="<%#Eval("TId") %>">
                                <span class="select-icon list-icon"></span>
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
                <li><a href="#" id="clickToStore">一键收藏</a></li>
            </ul>
            <div class="pagechange">
                
                    <div id="pageBar"><%=pageBar%></div>
                
            </div>
        </div>
    </div>
</asp:Content>
