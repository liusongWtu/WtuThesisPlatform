<%@ Page Title="" Language="C#" MasterPageFile="~/StudentUI/StudentMasterPage.Master" AutoEventWireup="true" CodeBehind="StuMyStore.aspx.cs" Inherits="Web.StudentUI.StuMyStore" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../css/student/stu_page.css" />
    <link rel="stylesheet" type="text/css" href="../js/popup/jquery.confirm.css" />
    <script type="text/javascript" src="../js/popup/jquery.confirm.js"></script>
    <script type="text/javascript" src="../js/student/StuMyStore.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <div class="wrap">
		<div class="mystore">
			<dl>
				<dt>我的收藏<span><a href="#" class="arrow-left">进入所有选题页面</a><a href="#" class="aRight">进入我的收藏<span class="arrow-right dis-inline-block" ></span></a></span></dt>
				<dd>
                    <table class="topic-list" cellspacing="0" cellpadding="0">
						<tr>
							<td class="topicName"><a href="#">网上选题系统</a></td>
							<td class="teacher"><a href="#">何儒汉</a></td>
							<td class="vanancy">还可以有<span id="vanaNum">&nbsp;3&nbsp;</span>人选择该题</td>
							<td class="select"><span class="select-icon dis-inline-block"></span></td>
							<td class="delete"><span class="delete-icon dis-inline-block"></span></td>
						</tr>
					</table>
                </dd>
			</dl>
		</div>
	</div>
</asp:Content>
