<%@ Page Title="" Language="C#" MasterPageFile="~/AdminUI/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="ClassManager.aspx.cs" Inherits="Web.AdminUI.ClassManager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../css/admin/adm_page.css" />
    <script type="text/javascript" src="../js/om/ui/rules.js"></script>
    <script type="text/javascript" src="../js/om/ui/om-validate.js"></script>
    <script type="text/javascript" src="../js/Validata.js"></script>
    <script src="../js/DataHelper.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/admin/ClassManager.js"></script>
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
            <ul class="toolBar">
                <li id="add" class="opeAdd">添加</li>
                <li id="delete" class="opeDelete">批量删除</li>
                <li id="import" class="opeImport">导入</li>
                <li id="export" class="opeExport">导出</li>
            </ul>
            <!-- <table id="grid"></table>-->
            <table id="topicList" class="topic-list" cellspacing="0" cellpadding="0">
                <tr class="list-header">
                    <td class="tr3">
                        &nbsp;
                    </td>
                    <td class="first">
                        班级名称
                    </td>
                    <td>
                        所在专业
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
                        <tr class="list-content" id="<%#Eval("CId") %>">
                            <td>
                                <input type="checkbox" name="topiclist"  />
                            </td>
                            <td class="first">
                                    <%#Eval("CName") %>
                            </td>
                            <td>
                                <%#Eval("Major.MName") %>
                            </td>
                            <td>
                                <%#Eval("CNumber") %>
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
            <td><select class="DepartmentId"></select></td>
            <td><span class="errorImg"></span><span class="errorMsg"></span></td>
            </tr>
            <tr><td>专业名称：</td>
            <td><select class="MajorId"></select></td>
            <td><span class="errorImg"></span><span class="errorMsg"></span></td>
            </tr>
            <tr>
            <td>班级名称：</td>
            <td><input type="text" name="isNameEmpty" class="CName"/></td>
            <td><span class="errorImg"></span><span class="errorMsg"></span></td>
            </tr>
            
        </table>
    </div>
</asp:Content>
