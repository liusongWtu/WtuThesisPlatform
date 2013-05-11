﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AdminUI/AdminMasterPage.Master"
    AutoEventWireup="true" CodeBehind="StudentManager.aspx.cs" Inherits="Web.AdminUI.StudentManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../css/admin/adm_page.css" />
    <script type="text/javascript" src="../js/student/StuSelect.js"></script>
    <script src="../js/DataHelper.js" type="text/javascript"></script>
    
    <script type="text/javascript" src="../js/admin/StudentManager.js"></script>
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
                        <tr class="list-content" id="<%#Eval("SId") %>">
                            <td>
                                <input type="checkbox" name="topiclist"  />
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
                            <td><a href="#" class="checkDetail">查看详情</a></td>
                            <td><a href="#">重置</a></td>
                            <td><a href="#" class="modifyInfo">修改</a></td>
                            <td><a href="#" class="deleteOne">删除</a></td>
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
    <div id="StuAddNew">
        <table class="addTable">
            <tr><td>学号：</td><td><input type="text" class="SNo" /></td><td><span id="SNoError" style="color: red; display: none">*</span></td><td>姓名：</td><td><input type="text" class="SName"/></td><td><span id="TNoError" style="color: red; display: none">*</span></td></tr>
            <tr><td>性别：</td><td><input type="text" class="SSex" /></td><td><span id="SSexError" style="color: red; display: none">*</span></td><td>电话：</td><td><input type="text" class="SPhone" /></td><td><span id="SPhoneError" style="color: red; display: none">*</span></td></tr>
            <tr><td>QQ：</td><td><input type="text"  class="SQQ" /></td><td><span id="SQQError" style="color: red; display: none">*</span></td><td>EMAIL：</td><td><input type="text" class="SEmail" /></td><td><span id="SEmailError" style="color: red; display: none">*</span></td></tr>
            <tr><td>班级：</td><td><select class="CId"></select></td><td><span id="Span1" style="color: red; display: none">*</span></td><td>毕业届：</td><td><input type="text"  class="SYear" /></td><td><span id="SYearError" style="color: red; display: none">*</span></td></tr>
            <tr><td>院系：</td><td colspan="2"><select  class="DId"></select></td><td>专业：</td><td colspan="2"><select  class="MId"></select></td></tr>
        </table>
    </div>
</asp:Content>
