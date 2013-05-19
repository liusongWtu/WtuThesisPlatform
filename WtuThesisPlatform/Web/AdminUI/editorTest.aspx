<%@ Page Title="" Language="C#" MasterPageFile="~/AdminUI/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="editorTest.aspx.cs" Inherits="Web.AdminUI.editorTest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="../js/kindeditor/kindeditor-min.js"></script>
    <script type="text/javascript">
        var editor;
			KindEditor.ready(function(K) {
				editor = K.create('textarea[name="content"]', {
					allowFileManager : true
				});
            });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <textarea name="content" style="width:800px;height:400px;visibility:hidden;">KindEditor</textarea>
</asp:Content>
