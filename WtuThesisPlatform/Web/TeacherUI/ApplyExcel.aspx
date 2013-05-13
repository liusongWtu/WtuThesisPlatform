<%@ Page Title="" Language="C#" MasterPageFile="~/TeacherUI/TeacherMasterPage.Master" AutoEventWireup="true" CodeBehind="PublishNotice.aspx.cs" Inherits="Web.TeacherUI.PublishNotice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../css/teacher/teacher_pages.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <div class="wrap-teacher">
        <div class="singleBg">
            <div class="single">
                 <div class="top"><h1>选题申请表</h1></div>
                 <div class="line"></div>
                 <div class="apply-table-wrap center">
                     <table cellspacing="0" cellpadding="0" align="center" class="apply-table">
                        <tr><td class="col-name">题目：</td><td colspan="3"><input class="input-style" type="text" /></td></tr>
                        <tr><td colspan="4" class="col-name">课题内容 ( 国内外现状,重点要解决的问题 )简介：</td></tr>
				        <tr><td colspan="4"><textarea class="input-style td-height"></textarea></td></tr>
                        <tr><td colspan="4"  class="col-name">课题的准备情况及对学生的要求（文献、仪器设备、材料、工作地点及学生须具备的技能）：</td></tr>
				        <tr><td colspan="4"><textarea  class="input-style td-height"></textarea></td></tr>
                        <tr><td class="col-name">课题内容性质：</td><td colspan="3"><input class="input-style" type="text" /></td></tr>
                        <tr><td class="col-name">课题来源性质：</td><td><input class="input-style" type="text" /></td><td class="col-name">类型：</td><td><input class="input-style" type="text" /></td></tr>
                        <tr><td colspan="4" class="col-name">系主任审核意见： </td></tr>
				        <tr><td colspan="4"><textarea  class="input-style td-height"></textarea></td></tr>
                        <tr><td colspan="4" class="col-name">教学督导组审核意见： </td></tr>
				        <tr><td colspan="4"><textarea  class="input-style td-height"></textarea></td></tr>
				        <tr><td colspan="4"><button>保存</button></td></tr>
                     </table>
                 </div>
                 
                 <div class="bottom">
                    <div class="backLink"><a href="TeacherApply.aspx">返回全部申请</a></div>
                 </div>
                 
            </div>
        </div>
    </div>
</asp:Content>
