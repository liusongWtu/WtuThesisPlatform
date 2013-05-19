<%@ Page Title="" Language="C#" MasterPageFile="~/AdminUI/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="MajorManager.aspx.cs" Inherits="Web.AdminUI.MajorManager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../css/admin/adm_page.css" />
    <script type="text/javascript" src="../js/om/ui/rules.js"></script>
    <script type="text/javascript" src="../js/om/ui/om-validate.js"></script>
    <script type="text/javascript" src="../js/Validata.js"></script>
    <script src="../js/DataHelper.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/admin/MajorManager.js"></script>
    <script type="text/javascript" src="../js/admin/Import.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
<div class="select-list">
        <div class="content-top">
            <div class="search fl fillet">
                <label class="ablt">
                    关键字...</label>
                <input type="text" class="search-input" id="txtSearch" runat="server"/>
                <button id="searchButton" class="search-button abrt" runat="server">
                    <span>搜索</span></button>
            </div>
        </div>
        <div class="content-center">
            <!-- <table id="grid"></table>-->
            <ul class="toolBar">
                <li id="add" class="opeAdd">添加</li>
                <li id="delete" class="opeDelete">批量删除</li>
            </ul>
            <table id="topicList" class="topic-list" cellspacing="0" cellpadding="0">
                <tr class="list-header">
                    <td class="tr3">
                        &nbsp;
                    </td>
                    <td class="first">
                        专业名称
                    </td>
                    <td>
                        所在院系
                    </td>
                    <td>
                        人数
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
                        <tr class="list-content" id="<%#Eval("MId") %>">
                            <td>
                                <input type="checkbox" name="topiclist"  />
                            </td>
                            <td class="first">
                                    <%#Eval("MName") %>
                            </td>
                            <td>
                                <%#Eval("Department.DName") %>
                            </td>
                            <td>
                                <%#Eval("MNumber") %>
                            </td>
                            <td>
                                 <a href="#" class="modifyInfo">修改</a>
                            </td>
                            <td>
                                <a href="#" class="deleteOne">删除</a>
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
    <div id="AddNew">
        <table class="addTable">
            <tr><td>院系名称：</td>
            <td><select class="DId"></select></td>
            <td><span class="errorImg"></span><span class="errorMsg"></span></td>
            </tr>
            <tr>
            <td>专业名称：</td>
            <td><input type="text" name="isNameEmpty" class="MName"/></td>
            <td><span class="errorImg"></span><span class="errorMsg"></span></td>
            </tr>
            
        </table>
    </div>
</asp:Content>
