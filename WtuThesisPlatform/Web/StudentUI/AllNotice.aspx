<%@ Page Title="" Language="C#" MasterPageFile="~/StudentUI/StudentMasterPage.Master" AutoEventWireup="true" CodeBehind="AllNotice.aspx.cs" Inherits="Web.StudentUI.AllNotice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../css/common_notice.css" />
    <script type="text/javascript">
        $(function () {
            var allName = $(".NTitle");
            allName.each(function () {
                if ($(this).hasClass("True")) {
                    $(this).addClass("bold");
                }
                else {
                    $(this).removeClass("bold");
                }
            })

        })
    
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <div class="links"><a href="StuIndex.aspx">首页</a></div>
    
    <div class="wrap">
        <dl>
			<dt>所有公告</dt>
		</dl>
        <div class="notice">
                
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
                        <td class="left tr30">
                            <a class="NTitle <%#Eval("IsNew") %>" href="/StudentUI/NoticeDetail.aspx?nid=<%#Eval("NId") %>&nodeId=1021"><%#Eval("NTitle") %></a>
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
             <div class="pagechange">
                
                    <div id="pageBar"><%=pageBar%></div>
                
            </div>
        </div>
</asp:Content>
