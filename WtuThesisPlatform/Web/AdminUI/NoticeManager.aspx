<%@ Page Title="" Language="C#" MasterPageFile="~/AdminUI/AdminMasterPage.Master"
    AutoEventWireup="true" CodeBehind="NoticeManager.aspx.cs" Inherits="Web.AdminUI.NoticeManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                    <td class="tr3">
                        &nbsp;
                    </td>
                    <td class="first">
                        公告标题
                    </td>
                    <td>
                        发布单位
                    </td>
                    <td>
                        发布人
                    </td>
                    <td>
                        发布日期
                    </td>
                    <td>
                        修改
                    </td>
                    <td class="last">
                        删除
                    </td>
                </tr>
                <asp:Repeater ID="rptAdmin" runat="server">
                    <ItemTemplate>
                        <tr class="list-content">
                            <td>
                                <input type="checkbox" name="topiclist" id="<%#Eval("NId") %>" />
                            </td>
                            <td class="first">
                                <a href="#" title="<%#Eval("NTitle") %>">
                                    <%#Eval("NTitle").ToString().Length > 15 ? Eval("NTitle").ToString().Substring(0, 15) + "..." : Eval("NTitle")%></a>
                            </td>
                            <td>
                                <%#Eval("NPublishUnits") %>
                            </td>
                            <td>
                                <%#Eval("NName") %>
                            </td>
                            <td>
                                <%#string.Format ("{0:yyyy/MM/dd}",Eval("NPublishTime")) %>
                            </td>
                            <td>
                                <a href="#">修改</a>
                            </td>
                            <td>
                                <a href="#">删除</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
        <div class="content-bottom">
            <div class="pagechange">
                    <div id="pageBar"><%=pageBar%></div>
            </div>
        </div>
    </div>
</asp:Content>
