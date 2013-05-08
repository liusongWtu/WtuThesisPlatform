<%@ Page Title="" Language="C#" MasterPageFile="~/AdminUI/AdminMasterPage.Master"
    AutoEventWireup="true" CodeBehind="StudentManager.aspx.cs" Inherits="Web.AdminUI.StudentManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../css/admin/adm_page.css" />
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
                        学号
                    </td>
                    <td>
                        姓名
                    </td>
                    <td>
                        院系
                    </td>
                    <td>
                        专业
                    </td>
                    <td>
                        班级
                    </td>
                    <td>
                        详细信息
                    </td>
                    <td>
                        重置密码
                    </td>
                    <td>
                        修改
                    </td>
                    <td class="last">
                        删除
                    </td>
                </tr>
                <asp:Repeater ID="rptStudent" runat="server">
                    <ItemTemplate>
                        <tr class="list-content">
                            <td>
                                <input type="checkbox" name="topiclist" id="<%#Eval("SId") %>" />
                            </td>
                            <td class="first">
                                <%#Eval("SNo") %>
                            </td>
                            <td>
                                <%#Eval("SName") %>
                            </td>
                            <td>
                                <%#Eval("Department.DName") %>
                            </td>
                            <td>
                                <%#Eval("Major.MName") %>
                            </td>
                            <td>
                                <%#Eval("ClassInfo.CName") %>
                            </td>
                            <td>
                                <a href="#">查看详情</a>
                            </td>
                            <td>
                                <a href="#">重置</a>
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
                <div id="pageBar">
                    <%=pageBar%></div>
            </div>
        </div>
    </div>
</asp:Content>
