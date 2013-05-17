<%@ Page Title="" Language="C#" MasterPageFile="~/TeacherUI/TeacherMasterPage.Master" AutoEventWireup="true" CodeBehind="GoodWorkAll.aspx.cs" Inherits="Web.TeacherUI.GoodWorkAll" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../css/common_goodwork.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <div class="wrap">
        <div class="good-work">
            <dl>
                <dt>毕业作品</dt>
                <dd>
                    <table cellspacing="0" cellpadding="0">
                        <asp:Repeater ID="rptGoodWork" runat="server">
                        <ItemTemplate>
                            <tr>
                            <td rowspan="2" class="image"><a href="/TeacherUI/SingleWork.aspx?gid=<%#Eval("GId") %>&nodeId=2001"><img src="/images/goodwork/<%#Eval("GCoverPic") %>" alt="封面图片" /></a></td>
                            <td class="work-data"><%#string.Format("{0:yyyy/MM/dd}",Eval("GTime") )%></td>
                            <td class="title"><a href="/TeacherUI/SingleWork.aspx?gid=<%#Eval("GId") %>&nodeId=2001"><%#Eval("GTitle") %></a></td>
                        </tr>
                        <tr>
                            <td class="work-summary fn-ellipsis fn-text-wrap" colspan="2"><%# Eval("GContent").ToString().Substring(0,100) %>
                                <a href="/TeacherUI/SingleWork.aspx?gid=<%#Eval("GId") %>&nodeId=2001">【查看全文】</a>
                            </td>
                        </tr> 
                        </ItemTemplate>
                        </asp:Repeater>
                           
                    </table>
                </dd>
            </dl>
        </div>
    </div>

</asp:Content>
