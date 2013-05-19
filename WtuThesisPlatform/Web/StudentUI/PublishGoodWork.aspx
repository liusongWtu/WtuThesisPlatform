<%@ Page Title="" Language="C#" MasterPageFile="~/StudentUI/StudentMasterPage.Master" AutoEventWireup="true" CodeBehind="PublishGoodWork.aspx.cs" Inherits="Web.StudentUI.PublishGoodWork" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../css/common_notice.css" />
    <script type="text/javascript" src="../js/student/PublishWork.js"></script>
    <script type="text/javascript" src="../js/kindeditor/kindeditor-min.js"></script>
    <script type="text/javascript">
        KindEditor.ready(function (K) {
            var editor = K.editor({
                allowFileManager: true
            });
            var editor1 = K.create('textarea[name="ctl00$ContentPlaceHolderBody$txtContent"]', {
                allowFileManager: true
            });
            K('#image3').click(function () {
                editor.loadPlugin('image', function () {
                    editor.plugin.imageDialog({
                        showRemote: false,
                        imageUrl: K('#url3').val(),
                        clickFn: function (url, title, width, height, border, align) {
                            K('#url3').val(url);
                            editor.hideDialog();
                        }
                    });
                });
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <div class="links"><a href="StuIndex.aspx">首页</a>>><a href="GoodWorkAll.aspx">全部作品</a></div>
    
    <div class="wrap-teacher">
        <div class="singleBg">
            <div class="single">
                 <div class="top"><h1>优秀毕业作品申请表</h1></div>
                 <div class="line"></div>
                 <div class="noticeContent center">
                     <table class="notice-excel">
                        <tr><td class="tab-name"><h2>作品名称：</h2></td></tr>
                        <tr><td><input type="text" class="txtName" runat="server" id="txtName" /><asp:RequiredFieldValidator ID="rfvName"
                                runat="server" ErrorMessage="*" style="color:Red;" ControlToValidate="txtName"></asp:RequiredFieldValidator></td></tr>
                        <tr>
                            <td class="tab-name"><h2>封面图片：</h2></td></tr>
                        <tr><td><input type="text" id="url3" value="" /> <input style="width: 70px" type="button" id="image3" value="选择图片" /></td>
                        </tr>
                        <tr><td class="tab-name"><h2>作品概要：<asp:RequiredFieldValidator ID="rfvContent"
                                runat="server" ErrorMessage="*" style="color:Red;" ControlToValidate="txtContent"></asp:RequiredFieldValidator></h2></td></tr>
                        <tr><td><textarea style="width:600px;height:400px;visibility:hidden;" runat="server" id="txtContent" class="txtContent"></textarea></td></tr>
                        <tr><td align="center">
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
