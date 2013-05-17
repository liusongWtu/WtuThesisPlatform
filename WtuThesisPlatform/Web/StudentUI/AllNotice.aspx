<%@ Page Title="" Language="C#" MasterPageFile="~/StudentUI/StudentMasterPage.Master" AutoEventWireup="true" CodeBehind="AllNotice.aspx.cs" Inherits="Web.StudentUI.AllNotice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../css/common_notice.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <div class="wrap">
        <div class="notice">
                <!--<dl>
								    <dt>历年选题信息</dt>
							    </dl>-->
                <table class="topic-list" cellspacing="0" cellpadding="0">
                    <tr class="list-header">
                        <td class="left tr30">
                            公告标题
                        </td>
                        <td class="tr10">
                            发布时间
                        </td>
                        <td class="tr10">
                            发布单位
                        </td>
                        <td class="tr10 last">
                            有效期限
                        </td>
                    </tr>
                     <asp:Repeater ID="rptNotice" runat="server">
                   <ItemTemplate>
                    <tr class="list-content">
                        <td class="left bold tr30">
                            <a class="NTitle <%#Eval("IsNew") %>" href="/StudentUI/NoticeDetail.aspx?nid=<%#Eval("NId") %>&nodeId=2021"><%#Eval("NTitle") %>></a>
                        </td>
                        <td  class="tr10">
                            <span class="NPublishTime"><%#string.Format ("{0:yyyy/MM/dd}",Eval("NPublishTime")) %></span>
                        </td>
                        <td class="tr10">
                            <span class="NPublishUnits"><%#Eval("NPublishUnits")%></span>
                        </td>
                        <td class="tr10">
                            <span class="NDeadTime"><%#string.Format ("{0:yyyy/MM/dd}",Eval("NDeadTime")) %></span>
                        </td>
                    </tr>
                   </ItemTemplate>
                   </asp:Repeater>
                </table>
            </div>
        </div>
</asp:Content>
