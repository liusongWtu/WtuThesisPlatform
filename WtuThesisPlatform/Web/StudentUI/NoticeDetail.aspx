<%@ Page Title="" Language="C#" MasterPageFile="~/StudentUI/StudentMasterPage.Master" AutoEventWireup="true" CodeBehind="NoticeDetail.aspx.cs" Inherits="Web.StudentUI.NoticeDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" type="text/css" href="../css/common_notice.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <div class="wrap-teavher">      
        <div class="singleBg">
            <div class="single">
                  <dl>
                    <dt class="top">
                        <h1 class="noticeTitle"><%=currNotice.NTitle %></h1>
                        <h3><span class="publishTime">发表时间：<span id="publishTime"><%=string.Format("{0:yyyy/MM/dd}",currNotice.NPublishTime) %></span></span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span  class="publishUnits">发表单位：<span id="publishUnits"><%=currNotice.NPublishUnits %></span></span></h3>
                    </dt>
                    <div class="line"></div>
                    <dd><p class="noticeContent"><%=currNotice.NContent %></p></dd>
                  </dl>
                 <div class="bottom">
                   <%-- <table class="tab-down">
                        <tr><td>相关下载：</td></tr>
                        <tr class="download-list"><td><a>文档文档文档</a></td></tr>
                    </table>--%>
                    <div class="backLink"><a href="AllNotice.aspx?nodeId=1021">返回全部公告</a></div>
                 </div>
                 
            </div>
        </div>
    </div>
</asp:Content>
