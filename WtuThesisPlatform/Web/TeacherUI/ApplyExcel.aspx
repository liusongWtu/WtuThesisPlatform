﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplyExcel.aspx.cs" Inherits="Web.TeacherUI.ApplyExcel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../css/base.css" />
    <link rel="stylesheet" type="text/css" href="../css/teacher/teacher_pages.css" />
</head>
<body>
    <form id="form1" runat="server">
<div class="apply-table-wrap">
		<h1 class="t-title">毕业设计（论文）选题申请报表</h1>
        <table cellspacing="0" cellpadding="0" align="center" class="apply-table">
                <tr><td class="col-name">题目</td><td colspan="3"><input class="input-style" runat="server" id="tTitle" type="text" /></td></tr>
                <tr><td class="col-name">指导教师</td><td><input class="input-style" type="text" /></td><td class="col-name">职称</td><td><input class="input-style" type="text" /></td></tr>
                <tr><td class="col-name">电子邮件</td><td><input class="input-style" type="text" /></td><td class="col-name">QQ</td><td><input class="input-style" type="text" /></td></tr>
                <tr><td class="col-name">专业</td><td><input class="input-style" type="text" /></td><td class="col-name">联系电话</td><td><input class="input-style" type="text" /></td></tr>
                <tr><td colspan="4" class="col-name">课题内容 ( 国内外现状,重点要解决的问题 )简介:</td></tr>
				<tr><td colspan="4"><textarea class="input-style td-height"></textarea></td></tr>
                <tr><td colspan="4"  class="col-name">课题的准备情况及对学生的要求（文献、仪器设备、材料、工作地点及学生须具备的技能）:</td></tr>
				<tr><td colspan="4"><textarea  class="input-style td-height"></textarea></td></tr>
                <tr><td class="col-name">课题内容性质</td><td colspan="3"><input class="input-style" type="text" /></td></tr>
                <tr><td class="col-name">课题来源性质</td><td><input class="input-style" type="text" /></td><td class="col-name">类型</td><td><input class="input-style" type="text" /></td></tr>
                <tr><td colspan="4" class="col-name">系主任审核意见： </td></tr>
				<tr><td colspan="4"><textarea  class="input-style td-height"></textarea></td></tr>
                <tr><td colspan="4" class="col-name">教学督导组审核意见： </td></tr>
				<tr><td colspan="4"><textarea  class="input-style td-height"></textarea></td></tr>
				<tr><td colspan="4"><button class="apply"></button></td></tr>
        </table>
		
    </div>
    </form>
</body>
</html>