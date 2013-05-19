<%@ Page Title="" Language="C#" MasterPageFile="~/TeacherUI/TeacherMasterPage.Master" AutoEventWireup="true" CodeBehind="AllNotice.aspx.cs" Inherits="Web.TeacherUI.AllNotice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="Stylesheet" type="text/css" href="../css/teacher/teacher_pages.css" />
    <script  type="text/javascript">
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
    <div class="links"><a href="TeacherIndex.aspx">首页</a></div>
    
    <div class="select-list">
        <div class="topic">
            <dl>
                <dt>
                     全部公告
                </dt>
            </dl>
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
                            <a class="NTitle <%#Eval("IsNew") %>" href="/TeacherUI/NoticeDetail.aspx?nid=<%#Eval("NId") %>&nodeId=2021"><%#Eval("NTitle") %>></a>
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
            <div class="content-bottom">
            <div class="pagechange">
                    <div id="pageBar"><%=pageBar%></div>
            </div>
        </div>
        </div>
</asp:Content>
