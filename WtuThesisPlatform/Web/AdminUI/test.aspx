﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AdminUI/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="Web.AdminUI.test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../css/admin/adm_page.css" />
    <script type="text/javascript" src="../js/admin/TeacherManager.js"></script>
    <script src="../js/DataHelper.js" type="text/javascript"></script>
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
                <asp:Button ID="changeConfig" runat="server" Text="修改配置文件" 
                    onclick="changeConfig_Click" />
                <li id="add" class="opeAdd">添加</li>
                <li id="delete" class="opeDelete">批量删除</li>
                <li id="import" class="opeImport">导入</li>
                <li id="export" class="opeExport">导出</li>
                 <asp:FileUpload ID="fileUpExcel" runat="server" />
                <asp:Button ID="Button3" runat="server" Text="导入"  onclick="Button3_Click" />
                <asp:Button ID="Button1" runat="server" Text="导出.." onclick="Button1_Click" />
                <asp:Button ID="Button2" runat="server" Text="下载.." onclick="Button2_Click"  />
                <asp:Button ID="Button4" runat="server" Text="导出学生" onclick="Button4_Click" />
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </ul>
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
                                <a href="#">重置</a>
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
    <div id="addNew" title="添加用户">
        <table class="addTable">
            <tr><td>教工号：</td><td><input type="text" class="TNo" /></td><td>&nbsp;&nbsp;&nbsp;&nbsp;姓名：</td><td><input type="text" class="TName"/></td></tr>
            <tr><td>性别：</td><td><input type="text"  class="TSex" /></td><td>&nbsp;&nbsp;&nbsp;&nbsp;电话：</td><td><input type="text" class="TPhone" /></td></tr>
            <tr><td>EMAIL：</td><td><input type="text" class="TEmail" /></td><td>&nbsp;&nbsp;&nbsp;&nbsp;QQ：</td><td><input type="text"  class="TQQ" /></td></tr>
            <tr><td>职称：</td><td><input type="text"  class="TZhiCheng" /></td><td>&nbsp;&nbsp;&nbsp;&nbsp;限带人数：</td><td><input type="text"  class="TTeachNum" /></td></tr>
            <tr><td>院系：</td><td><select  class="DepartmentId"></select></td><td>&nbsp;&nbsp;&nbsp;&nbsp;专业：</td><td><select  class="MajorId"></select></td></tr>
            <tr><td>主讲课程：</td><td colspan="3"><textarea   class="TTeachCourse" rows="10" cols="10"></textarea></td></tr>
            <tr><td>研究方向：</td><td colspan="3"><textarea  class="TResearchFields" rows="10" cols="10"></textarea></td></tr>
        </table>
    </div>

</asp:Content>
