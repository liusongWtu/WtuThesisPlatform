﻿<%@ Page Title="" Language="C#" MasterPageFile="~/TeacherUI/TeacherMasterPage.Master" AutoEventWireup="true" CodeBehind="NoticeDetail.aspx.cs" Inherits="Web.TeacherUI.NoticeDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../css/teacher/teacher_pages.css" />
    <link rel="stylesheet" type="text/css" href="../css/common_notice.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <div class="links"><a href="TeacherIndex.aspx">首页</a>>><a href="AllNotice.aspx">所有公告</a></div>
    
    <div class="wrap-teavher">      
        <div class="singleBg">
            <div class="single">
                  <dl>
                    <dt class="top">
                        <h1 class="noticeTitle"><%=currNotice.NTitle %></h1>
                        <h3><span class="publishTime">发表时间：<span id="publishTime"><%=string.Format("{0:yyyy/MM/dd}",currNotice.NPublishTime) %></span></span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span  class="publishUnits">发表单位：<span id="publishUnits"><%=currNotice.NPublishUnits %></span></span></h3>
                    </dt>
                    <div class="line"></div>
                    <dd><div class="noticeContent"><%=currNotice.NContent %></div></dd>
                  </dl>
                 <div class="bottom">
                    <%--<table class="tab-down">
                        <tr><td>相关下载：</td></tr>
                        <tr class="download-list"><td><a>文档文档文档</a></td></tr>
                    </table>--%>
                    <div class="backLink"><a href="AllNotice.aspx">返回全部公告</a></div>
                 </div>
                 
            </div>
        </div>
    </div> 
        
</asp:Content>
