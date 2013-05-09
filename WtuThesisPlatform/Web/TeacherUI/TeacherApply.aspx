<%@ Page Title="" Language="C#" MasterPageFile="~/TeacherUI/TeacherMasterPage.Master"
    AutoEventWireup="true" CodeBehind="TeacherApply.aspx.cs" Inherits="Web.TeacherUI.TeacherSelect" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../css/teacher/teacher_pages.css" />
    <script type="text/javascript" src="../js/teacher/TeacherSelect.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <div class="wrap">
        <div class="topic">
            <dl>
                <dt>我的申请</dt>
                <dd>
                    <table id="applyTopicList" class="topic-list" cellspacing="0" cellpadding="0">
                        <tr class="list-header">
                            <td>选题名称</td>
                            <td>状态</td>
                            <td>申请</td>
                            <td>修改</td>
                            <td>预览</td>
                            <td class="last">删除</td>
                        </tr>
                        <tr class="list-content nohover">
                            <td class="bold">
                                <a href="#">毕业设计选题系统</a>
                            </td>
                            <td>
                                <span class="tea-status">状态</span>
                            </td>
                            <td>
                                <a class="tea-apply">申请</a>
                            </td>
                            <td>
                                <a class="tea-modify">修改</a>
                            </td>
                            <td>
                                <a class="tea-check">预览</a>
                            </td>
                            <td>
                                <a class="tea-delete">删除</a>
                            </td>
                        </tr>
                    </table>
                </dd>
            </dl>
        </div>
        <div class="content-bottom">
            <button class="create-apply">
            </button>
        </div>
    </div>
</asp:Content>
