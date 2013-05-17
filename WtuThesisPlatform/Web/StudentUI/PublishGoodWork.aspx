<%@ Page Title="" Language="C#" MasterPageFile="~/StudentUI/StudentMasterPage.Master" AutoEventWireup="true" CodeBehind="PublishGoodWork.aspx.cs" Inherits="Web.StudentUI.PublishGoodWork" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../css/common_notice.css" />
    <script type="text/javascript" src="../js/student/PublishWork.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <div class="wrap-teacher">
        <div class="singleBg">
            <div class="single">
                 <div class="top"><h1>优秀毕业作品申请表</h1></div>
                 <div class="line"></div>
                 <div class="noticeContent center">
                     <table class="notice-excel">
                        <tr><td class="tab-name"><h2>作品名称：</h2></td><td><input type="text" class="txtName" runat="server" id="txtName" /><asp:RequiredFieldValidator ID="rfvName"
                                runat="server" ErrorMessage="*" style="color:Red;" ControlToValidate="txtName"></asp:RequiredFieldValidator></td></tr>
                        <tr>
                            <td class="tab-name"><h2>封面图片：</h2></td>
                            <td><input type="file" id="picURL"/>
                            <button id="upload" class="btn"/>上传</td>
                        </tr>
                        <tr><td class="tab-name"><h2>作品概要：<asp:RequiredFieldValidator ID="rfvContent"
                                runat="server" ErrorMessage="*" style="color:Red;" ControlToValidate="txtContent"></asp:RequiredFieldValidator></h2></td><td><textarea runat="server" id="txtContent" class="txtContent"></textarea></td></tr>
                        <tr><td></td><td align="center">
                            <asp:Button ID="btnSubmit"  runat="server" Text="提交" class="btnSubmit" style="width: 40px;height: 20px" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type="button" id="cancel" class="cancel" value="取消" style="width: 40px;height: 20px"  /></td></tr>
                     </table>
                 </div>
                 
                 <div class="bottom">
                    <div class="backLink"><a href="AllNotice.aspx">返回全部公告</a></div>
                 </div>
                 
            </div>
        </div>
    </div>
</asp:Content>
