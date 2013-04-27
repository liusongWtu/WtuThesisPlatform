<%@ Page Title="" Language="C#" MasterPageFile="~/StudentUI/StudentMasterPage.Master" AutoEventWireup="true" CodeBehind="StuMySelect.aspx.cs" Inherits="Web.StudentUI.StuMySelect" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../css/student/stu_page.css" />
    <link rel="stylesheet" type="text/css" href="../js/popup/jquery.confirm.css" />
    <script type="text/javascript" src="../js/popup/jquery.confirm.js"></script>
    <script type="text/javascript" src="../js/student/StuMySelect.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
		<div class="wrap">
			<div class="myselect">
				<dl>
					<dt>我的志愿<span><a href="#" class="arrow-left">进入所有选题页面</a><a href="#" class="aRight">进入我的收藏<span class="arrow-right dis-inline-block" ></span></a></span></dt>
					<dd>
                        <table class="topic-list" cellspacing="0" cellpadding="0">
							<tr>
								<td id="selectOrder" class="selectOrder">志愿<span class="order"></span></td>
								<td id="topicName" class="topicName"><a href="#">网上选题系统</a></td>
								<td id="teacher" class="teacher"><a href="#">何儒汉</a></td>
								<td id="vanancy" class="vanancy">还可以有<span id="vanaNum">&nbsp;3&nbsp;</span>人选择该题</td>
                                <td id="selectState">等待处理...</td>
								<td id="refuseSelect"><span class="refuse-select-icon dis-inline-block"></span></td>		
							</tr>
                            <tr>
								<td id="Td1" class="selectOrder">志愿<span class="order"></span></td>
								<td id="Td2" class="topicName"><a href="#">购物系统</a></td>
								<td id="Td3" class="teacher"><a href="#">何儒汉</a></td>
								<td id="Td4" class="vanancy">还可以有<span id="Span1">&nbsp;3&nbsp;</span>人选择该题</td>
                                <td id="Td5">等待处理...</td>
								<td id="Td6"><span class="refuse-select-icon dis-inline-block"></span></td>		
							</tr>
                            <tr>
								<td id="Td7" class="selectOrder">志愿<span class="order"></span></td>
								<td id="Td8" class="topicName"><a href="#">二手房买卖系统</a></td>
								<td id="Td9" class="teacher"><a href="#">何儒汉</a></td>
								<td id="Td10" class="vanancy">还可以有<span id="Span2">&nbsp;3&nbsp;</span>人选择该题</td>
                                <td id="Td11">等待处理...</td>
								<td id="Td12"><span class="refuse-select-icon dis-inline-block"></span></td>		
							</tr>
						</table>
                    </dd>
				</dl>
			</div>
		</div>
</asp:Content>
