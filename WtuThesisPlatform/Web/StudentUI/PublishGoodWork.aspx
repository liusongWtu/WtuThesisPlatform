﻿<%@ Page Title="" Language="C#" MasterPageFile="~/StudentUI/StudentMasterPage.Master" AutoEventWireup="true" CodeBehind="PublishGoodWork.aspx.cs" Inherits="Web.StudentUI.PublishGoodWork" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../css/common_notice.css" />
    <script type="text/javascript" src="../js/student/PublishWork.js"></script>
    <script type="text/javascript">
        $(function () {
            if ($(".btnSubmit").attr("isSaved") == "saved") {
                $.omMessageTip.show({ content: '保存成功！', timeout: 1000, type: 'success' });
                $(".txtName").val("");
                $(".txtContent").val("");
            }
            $(".cancel").click(function () {
                $(".txtName").val("");
                $(".txtContent").val("");
                $(".fileUpImage").val("");
            });
        });
    </script>
   <script src="../kindeditor/lang/zh_CN.js" type="text/javascript"></script>
    <script src="../kindeditor/kindeditor.js" type="text/javascript"></script>
    <script src="../kindeditor/plugins/code/prettify.js" type="text/javascript"></script> 
    <script type="text/javascript">
        KindEditor.ready(function (K) {
            var editor = K.create('#ContentPlaceHolderBody_txtContent', {
                //上传管理
                uploadJson: '../kindeditor/asp.net/upload_json.ashx',
                //文件管理
                fileManagerJson: '../kindeditor/asp.net/file_manager_json.ashx',
                allowFileManager: true,
                //设置编辑器创建后执行的回调函数
                afterCreate: function () {
                    var self = this;
                    K.ctrl(document, 13, function () {
                        self.sync();
                        K('form[name=example]')[0].submit();
                    });
                    K.ctrl(self.edit.doc, 13, function () {
                        self.sync();
                        K('form[name=example]')[0].submit();
                    });
                },
                //上传文件后执行的回调函数,获取上传图片的路径
                afterUpload: function (url) {
                    // alert(url);
                },
                //编辑器高度
                width: '700px',
                //编辑器宽度
                height: '450px;',
                //配置编辑器的工具栏
                items: [
                'source', '|', 'undo', 'redo', '|', 'preview', 'print', 'template', 'code', 'cut', 'copy', 'paste',
                'plainpaste', 'wordpaste', '|', 'justifyleft', 'justifycenter', 'justifyright',
                'justifyfull', 'insertorderedlist', 'insertunorderedlist', 'indent', 'outdent', 'subscript',
                'superscript', 'clearhtml', 'quickformat', 'selectall', '|', 'fullscreen', '/',
                'formatblock', 'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold',
                'italic', 'underline', 'strikethrough', 'lineheight', 'removeformat', '|', 'image', 'multiimage',
                'flash', 'media', 'insertfile', 'table', 'hr', 'emoticons', 'baidumap', 'pagebreak',
                'anchor', 'link', 'unlink', '|', 'about'
                ]
            });
            prettyPrint();
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
                        <tr><td><input type="text" class="txtName" runat="server" id="txtName" /></td></tr>
                        <tr>
                            <td class="tab-name"><h2>封面图片：</h2></td></tr>
                        <tr><td> 
                            <asp:FileUpload ID="fileUpImage" CssClass="fileUpImage" runat="server" /></td>
                        </tr>
                        <tr><td class="tab-name"><h2>作品概要：</h2></td></tr>
                        <tr><td><textarea style="width:600px;height:400px;visibility:hidden;" runat="server" id="txtContent" class="txtContent"></textarea></td></tr>
                        <tr><td align="center">
                            <asp:Button ID="btnSubmit"  runat="server" Text="提交" class="btnSubmit" 
                                style="width: 40px;height: 20px" onclick="btnSubmit_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type="button" id="cancel" class="cancel" value="取消" style="width: 40px;height: 20px"  /></td></tr>
                     </table>
                 </div>
                 
                 <div class="bottom">
                    <div class="backLink"><a href="AllNotice.aspx">返回全部公告</a></div>
                 </div>
                 
            </div>
        </div>
    </div>
</asp:Content>
