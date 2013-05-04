﻿<%@ Page Title="" Language="C#" MasterPageFile="~/TeacherUI/TeacherMasterPage.Master" AutoEventWireup="true" CodeBehind="TeacherSelect.aspx.cs" Inherits="Web.TeacherUI.TeacherSelect1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="Stylesheet" type="text/css" href="../css/teacher/teacher_pages.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <div class="wrap">
        <div class="topic">
            <dl>
                <dt>
                    <h1>学生选题情况</h1>
                </dt>
            </dl>
            <table id="topicList" class="topic-list" cellspacing="0" cellpadding="0">
                <tr class="list-header">
                    <td style="width: 40%">
                        选题名称
                    </td>
                    <td style="width: 20%">
                        允许人数
                    </td>
                    <td style="width: 20%">
                        已选人数
                    </td>
                    <td style="width: 20%;" class="last">
                        确定人数
                    </td>
                </tr>
                <tr class="list-content">
                    <td>
                        毕业设计选题系统
                    </td>
                    <td>
                        8
                    </td>
                    <td>
                        <a href="#">4</a>
                    </td>
                    <td>
                        <a href="#">3</a>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
