<%@ Page Title="" Language="C#" MasterPageFile="~/TeacherUI/TeacherMasterPage.Master" AutoEventWireup="true" CodeBehind="SingleWork.aspx.cs" Inherits="Web.TeacherUI.SingleWork" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../css/common_goodwork.css" />
    <link rel="stylesheet" type="text/css" href="../css/common_notice.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <div class="links"><a href="TeacherIndex.aspx">首页</a>>><a href="GoodWorkAll.aspx">所有作品</a></div>
    
    <div class="wrap-teavher">      
        <div class="singleBg">
            <div class="single">
                  <dl>
                    <dt class="top">
                        <h1 class="workTitle"><%=currGoodWork.GTitle %></h1>
                        <h3><span class="publishTime">发表时间：<span id="publishTime"><%=string.Format("{0:yyyy/MM/dd}",currGoodWork.GTime) %></span></span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span  class="publishUnits">作者：<span id="publisher">啊啊啊啊</span></span></h3>
                    </dt>
                    <div class="line"></div>
                    <dd><p class="workContent"><%=currGoodWork.GContent %></p></dd>
                  </dl>
                 <div class="bottom">
                    <div class="backLink"><a href="/TeacherUI/GoodWorkAll.aspx?nodeId=2001">返回全部作品</a></div>
                 </div>
                 
            </div>
        </div>
    </div>
</asp:Content>
