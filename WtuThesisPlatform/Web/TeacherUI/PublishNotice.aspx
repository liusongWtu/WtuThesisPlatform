<%@ Page Title="" Language="C#" MasterPageFile="~/TeacherUI/TeacherMasterPage.Master" AutoEventWireup="true" CodeBehind="PublishNotice.aspx.cs" Inherits="Web.TeacherUI.PublishNotice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../css/teacher/teacher_pages.css" />
    <script type="text/javascript" src="../js/om/ui/om-calendar.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#deadLine").omCalendar();
        })
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <div class="wrap-teacher">
        <div class="singleBg">
            <div class="single">
                 <div class="top"><h1>公告发布表</h1></div>
                 <div class="line"></div>
                 <div class="noticeContent center">
                     <table class="notice-excel">
                        <tr><td class="tab-name"><h2>公告名称：</h2></td><td><input type="text" /></td></tr>
                        <tr><td class="tab-name"><h2>发布单位：</h2></td><td><input type="text" /></td></tr>
                        <tr><td class="tab-name"><h2>截止日期：</h2></td><td><input id="deadLine" class="deadline" /></td></tr>
                        <tr><td class="tab-name"><h2>公告内容：</h2></td><td><textarea></textarea></td></tr>
                        <tr><td></td><td align="center"><button>提交</button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<button>取消</button></td></tr>
                     </table>
                 </div>
                 
                 <div class="bottom">
                    <div class="backLink"><a href="AllNotice.aspx">返回全部公告</a></div>
                 </div>
                 
            </div>
        </div>
    </div>
</asp:Content>
