<%@ Page Title="" Language="C#" MasterPageFile="~/AdminUI/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="PublishNotice.aspx.cs" Inherits="Web.AdminUI.PublishNotice"  ValidateRequest="false"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../css/common_notice.css" />
    <script type="text/javascript" src="../js/om/ui/om-calendar.js"></script>
    <script type="text/javascript">
        $(function () {
            $(".deadline").omCalendar();
            if ($(".btnSubmit").attr("isSaved") == "saved") {
                $.omMessageTip.show({ content: '保存成功！', timeout: 1000, type: 'success' });
                $(".txtName").val("");
                $(".txtContent").val("");
            }
            $(".cancel").click(function () {
                clearAll();
            });
            function clearAll() {
                $(".txtName").val("");
                $(".txtUnits").val("");
                $(".deadline").val("");
                $(".txtContent").val("");
            }
        })
    </script>
    <script type="text/javascript" src="../js/kindeditor/kindeditor-min.js"></script>
    <script type="text/javascript">
        var editor;
        KindEditor.ready(function (K) {
            editor = K.create('textarea[name="ctl00$ContentPlaceHolde"]', {
                allowFileManager: true
            });
        });
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
                        <tr><td class="tab-name"><h2>公告名称：</h2></td><td><input type="text" class="txtName" runat="server" id="txtName" /><asp:RequiredFieldValidator ID="rfvName"
                                runat="server" ErrorMessage="*" style="color:Red;" ControlToValidate="txtName"></asp:RequiredFieldValidator></td></tr>
                        <tr><td class="tab-name"><h2>发布单位：</h2></td><td><input type="text" runat="server" class="txtUnits" id="txtUnits" /><asp:RequiredFieldValidator ID="rfvUnits"
                                runat="server" ErrorMessage="*" style="color:Red;" ControlToValidate="txtUnits"></asp:RequiredFieldValidator></td></tr>
                        <tr><td class="tab-name"><h2>截止日期：</h2></td><td><input id="deadLine"  class="deadline"  runat="server"  /><asp:RequiredFieldValidator ID="rfvDeadTime"
                                runat="server" ErrorMessage="*" style="color:Red;" ControlToValidate="deadLine"></asp:RequiredFieldValidator></td></tr>
                        <tr><td class="tab-name"><h2>公告内容：<asp:RequiredFieldValidator ID="rfvContent"
                                runat="server" ErrorMessage="*" style="color:Red;" ControlToValidate="txtContent"></asp:RequiredFieldValidator></h2></td><td><textarea style="width:604px;height:200px;visibility:hidden;" name="content" runat="server" id="txtContent" class="txtContent"></textarea></td></tr>
                        <tr><td></td><td align="center">
                            <asp:Button ID="btnSubmit"  runat="server" Text="提交" class="btnSubmit" style="width: 40px;height: 20px" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type="button" id="cancel" class="cancel" value="取消" onclick="clearAll()" style="width: 40px;height: 20px"  /></td></tr>
                     </table>
                 </div>
                 
                 <div class="bottom">
                    <div class="backLink"><a href="NoticeManager.aspx">返回全部公告</a></div>
                 </div>
                 
            </div>
        </div>
    </div>
</asp:Content>
