<%@ Page Title="" Language="C#" MasterPageFile="~/AdminUI/AdminMasterPage.Master"
    AutoEventWireup="true" CodeBehind="AdminManager.aspx.cs" Inherits="Web.AdminUI.AdminManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="Stylesheet" type="text/css" href="../css/admin/adm_page.css" />
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
            <ul class="toolBar">
                <li id="add" class="opeAdd">添加</li>
                <li id="delete" class="opeDelete">批量删除</li>
                <li id="import" class="opeImport">导入</li>
                <li id="export" class="opeExport">导出</li>
            </ul>
            <table id="topicList" class="topic-list" cellspacing="0" cellpadding="0">
                <!--<tr>
                    <td><a href="#">添加</a></td>
                    <td><a href="#">导入</a></td>
                    <td><a href="#">导出</a></td>
                </tr>-->
                <tr class="list-header">
                    <td class="tr3">
                    </td>
                    <td class="first">
                        登录名
                    </td>
                    <td>
                        姓名
                    </td>
                    <td>
                        电话
                    </td>
                    <td>
                        Email
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
                <asp:Repeater ID="rptAdmin" runat="server">
                    <ItemTemplate>
                        <tr class="list-content" id="<%#Eval("UId") %>">
                            <td>
                                <input type="checkbox" name="topiclist"  />
                            </td>
                            <td class="first"><%#Eval("UUserName") %></td>
                            <td><%#Eval("UName") %></td>
                            <td> <%#Eval("UPhone") %></td>
                            <td><%#Eval("UEmail") %></td>
                            <td><a href="#">查看详情</a></td>
                            <td><a href="#">重置</a></td>
                            <td><a href="#">修改</a></td>
                            <td><a href="#">删除</a></td>
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
    <div id="AdmAddNew">
        <table class="addTable">
            <tr><td>登录名：</td><td><input type="text" class="UUserName" /></td><td>&nbsp;&nbsp;&nbsp;&nbsp;姓名：</td><td><input type="text" class="UName"/></td></tr>
            <tr><td>电话：</td><td><input type="text" class="UPhone" /></td><td>&nbsp;&nbsp;&nbsp;&nbsp;EMAIL：</td><td><input type="text" class="UEmail" /></td></tr>
            <tr><td>QQ：</td><td><input type="text"  class="UQQ" /></td></tr>
            <tr><td>院系：</td><td><select  class="DepartmentId"></select></td><td>&nbsp;&nbsp;&nbsp;&nbsp;专业：</td><td><select  class="MajorId"></select></td></tr>
        </table>
    </div>
</asp:Content>
