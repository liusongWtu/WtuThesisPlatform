<%@ Page Title="" Language="C#" MasterPageFile="~/StudentUI/StudentMasterPage.Master" AutoEventWireup="true" CodeBehind="SingleWork.aspx.cs" Inherits="Web.StudentUI.SingleWork" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../css/common_goodwork.css" />
    <link rel="stylesheet" type="text/css" href="../css/common_notice.css" />
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
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
                    <div class="backLink"><a href="/StudentUI/GoodWorkAll.aspx?nodeId=1001">返回全部作品</a></div>
                 </div>
                 
            </div>
        </div>
    </div>
</asp:Content>
