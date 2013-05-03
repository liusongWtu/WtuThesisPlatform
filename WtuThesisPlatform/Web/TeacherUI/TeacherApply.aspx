<%@ Page Title="" Language="C#" MasterPageFile="~/TeacherUI/TeacherMasterPage.Master"
    AutoEventWireup="true" CodeBehind="TeacherApply.aspx.cs" Inherits="Web.TeacherUI.TeacherSelect" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../css/teacher/teacher_pages.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <div class="wrap">
        <div class="topic">
            <dl>
                <dt>我的申请</dt>
                <dd>
                    <table id="applyTopicList" class="topic-list" cellspacing="0" cellpadding="0">
                        <tr class="list-header">
                            <td class="td0">选题名称</td>
                            <td class="td1">申请</td>
                            <td class="td2">修改</td>
                            <td class="td3">预览</td>
                            <td class="td4 last">删除</td>
                        </tr>
                        <tr class="list-content nohover">
                            <td class="td0">
                                <a href="#">毕业设计选题系统</a>
                            </td>
                            <td class="td1">
                                <a class="tea-apply">申请</a>
                            </td>
                            <td class="td2">
                                <a class="tea-modify">修改</a>
                            </td>
                            <td class="td3">
                                <a class="tea-check">预览</a>
                            </td>
                            <td class="td4">
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
