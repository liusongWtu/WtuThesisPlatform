﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AdminUI/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="TeacherManager.aspx.cs" Inherits="Web.AdminUI.TeacherManager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../css/admin/adm_page.css" />
    <script type="text/javascript" src="../js/om/ui/rules.js"></script>
    <script type="text/javascript" src="../js/om/ui/om-validate.js"></script>
    <script type="text/javascript" src="../js/Validata.js"></script>
    <script type="text/javascript" src="../js/admin/TeacherManager.js"></script>
    <script src="../js/DataHelper.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/admin/Import.js"></script>
    <script type="text/javascript">
        $(function () {
            var num = $(".btnUpload").attr("success");
            if (typeof (num) != 'undefined') {
                $.omMessageBox.alert({
                    title: '提示信息',
                    content: '上传成功' + num + '条数据！',
                    onClose: function (value) {
                    }
                });
            }
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
<div class="select-list">
        <div class="content-top">
            <div class="search fl fillet">
                <label class="ablt">
                    关键字...</label>
                <input type="text" class="search-input" id="txtSearch" runat="server" />
                <button id="searchButton" runat="server" class="search-button abrt">
                    <span>搜索</span></button>
            </div>
        </div>
        <div class="content-center">
            <!-- <table id="grid"></table>-->
            <ul class="toolBar">
                <li id="add" class="opeAdd">添加</li>
                <li id="delete" class="opeDelete">批量删除</li>
                <li id="import" class="opeImport">导入</li>
                <li id="export" class="opeExport">
                    <asp:Button ID="btnExport" CssClass="btnExport" style="border:0;font-weight: bold;cursor: pointer" runat="server" Text="导出" onclick="btnExport_Click" /></li>
            </ul>
            <div class="importDiv" style="display: none"> <asp:FileUpload ID="fileUpExcel" CssClass="fielUpExcel"   runat="server" />
            <asp:Button ID="btnUpload" CssClass="btnUpload" runat="server" Text="上传" OnClientClick="return clientClick()" onclick="btnUpload_Click" /></div>
            <table id="topicList" class="topic-list" cellspacing="0" cellpadding="0">
                <tr class="list-header">
                    <td class="tr3">
                        &nbsp;
                    </td>
                    <td class="first">
                        教工号
                    </td>
                    <td>
                        姓名
                    </td>
                    <td>
                        院系
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
                        <tr class="list-content" id="<%#Eval("TId") %>">
                            <td>
                                <input type="checkbox" name="topiclist"/>
                            </td>
                            <td class="first">
                                    <%#Eval("TNo") %>
                            </td>
                            <td>
                                <%#Eval("TName") %>
                            </td>
                            <td>
                                <%#Eval("Department.DName") %>
                            </td>
                            <td>
                                <%#Eval("TPhone") %>
                            </td>
                            <td>
                                <%#Eval("TEmail") %>
                            </td>
                            <td>
                                <a href="#" class="checkDetail">
                                    查看详情</a>
                            </td>
                            <td>
                                <a href="#" class="resetPwd">重置</a>
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
    <div id="teaAddNew" title="添加用户">
        <table class="addTable">
            <tr><td>教工号：</td><td><input type="text" class="TNo" name="isUserNameEmpty" /></td><td><span class="errorImg"></span><span class="errorMsg"></span></td><td>姓名：</td><td><input type="text" name="isNameEmpty" class="TName"/></td><td><span class="errorImg"></span><span class="errorMsg"></span></td></tr>
            <tr><td>性别：</td><td><select class="TSex"><option>男</option><option>女</option></select></td><td><span class="errorImg"></span><span class="errorMsg"></span></td><td>电话：</td><td><input type="text" name="isMobilePhone" class="TPhone" /></td><td><span class="errorImg"></span><span class="errorMsg"></span></td></tr>
            <tr><td>EMAIL：</td><td><input type="text" name="isEmail" class="TEmail" /></td><td><span class="errorImg"></span><span class="errorMsg"></span></td><td>QQ：</td><td><input type="text" name="isQQ"  class="TQQ" /></td><td><span class="errorImg"></span><span class="errorMsg"></span></td></tr>
            <tr><td>职称：</td><td><input type="text"  class="TZhiCheng" /></td><td><span class="errorImg"></span><span class="errorMsg"></span></td><td>限带人数：</td><td><input type="text" name="isTeaNum"  class="TTeachNum" /></td><td><span class="errorImg"></span><span class="errorMsg"></span></td></tr>
            <tr><td>院系：</td><td><select  class="DepartmentId"></select></td><td><span class="errorImg"></span><span class="errorMsg"></span></td><td>专业：</td><td><select  class="MajorId"></select></td><td><span class="errorImg"></span><span class="errorMsg"></span></td></tr>
            <tr><td>主讲课程：</td><td colspan="5"><textarea   class="TTeachCourse" rows="10" cols="10"></textarea></td></tr>
            <tr><td>研究方向：</td><td colspan="5"><textarea  class="TResearchFields" rows="10" cols="10"></textarea></td></tr>
        </table>
    </div>

</asp:Content>
