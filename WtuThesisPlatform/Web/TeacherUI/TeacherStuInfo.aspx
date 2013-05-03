<%@ Page Title="" Language="C#" MasterPageFile="~/TeacherUI/TeacherMasterPage.Master"
    AutoEventWireup="true" CodeBehind="TeacherStuInfo.aspx.cs" Inherits="Web.TeacherUI.TeacherStuInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="Stylesheet" type="text/css" href="../css/teacher/teacher_pages.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <div class="wrap">
        <div class="topic">
            <dl>
                <dt>
                    <h1>选题学生信息</h1>
                </dt>
            </dl>
            <table id="topicList" class="topic-list" cellspacing="0" cellpadding="0">
                <tr class="list-header">
                    <td style="width: 30%">
                        学生姓名
                    </td>
                    <td style="width: 20%">
                        学号
                    </td>
                    <td style="width: 10%">
                        性别
                    </td>
                    <td style="width: 20%">
                        专业
                    </td>
                    
                    <td style="width: 20%;" class="last">
                        操作
                    </td>
                </tr>
                <tr class="list-content">
                    <td>
                        <a href="#">刘大姐</a>
                    </td>
                    <td>
                        0904681111
                    </td>
                    <td>
                        女
                    </td>
                    <td>
                        软件工程
                    </td>
                    <td>
                        <a class="selectStatus">选择</a>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
