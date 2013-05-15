<%@ Page Title="" Language="C#" MasterPageFile="~/TeacherUI/TeacherMasterPage.Master" AutoEventWireup="true" CodeBehind="ApplyExcel.aspx.cs" Inherits="Web.TeacherUI.ApplyExcel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../css/teacher/teacher_pages.css" />
    <link rel="stylesheet" type="text/css" href="../css/common_notice.css" />
    <script src="../js/teacher/ApplyExcel.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <div class="wrap-teacher">
        <div class="singleBg">
            <div class="single">
                 <div class="top"><h1>选题申请表</h1></div>
                 <div class="line"></div>
                 <div class="apply-table-wrap center">
                     <table cellspacing="0" cellpadding="0" align="center" class="apply-table">
                        <tr><td class="col-name"><span style="color: red">*</span>题目：</td><td colspan="3"><input class="input-style txtTitle" runat="server" id="txtTitle" type="text" /></td></tr>
                        <tr><td class="col-name"><span style="color: red">*</span>开发平台</td><td><input class="input-style platform" runat="server"  id="platform" type="text" /></td><td class="col-name"><span style="color: red">*</span>限选人数</td><td><input id="number" class="input-style number" runat="server" type="text" /></td></tr>
                        <tr><td colspan="4" class="col-name"><span style="color: red">*</span>课题内容 ( 国内外现状,重点要解决的问题 )简介：</td></tr>
				        <tr><td colspan="4"><textarea id="txtIntroduct" runat="server" class="input-style td-height txtIntroduct"></textarea></td></tr>
                        <tr><td colspan="4"  class="col-name"><span style="color: red">*</span>课题的准备情况及对学生的要求（文献、仪器设备、材料、工作地点及学生须具备的技能）：</td></tr>
				        <tr><td colspan="4"><textarea id="txtRequire"  class="input-style td-height txtRequire" runat="server"></textarea></td></tr>
				        <tr><td colspan="4"> <input type="button" id="btnSave"  runat="server" class="btnSave"  value="保 存" />
                            </td></tr>
                     </table>
                 </div>
                 
                 <div class="bottom">
                    <div class="backLink"><a href="TeacherApply.aspx">返回全部申请</a></div>
                 </div>
                 
            </div>
        </div>
    </div>
</asp:Content>
