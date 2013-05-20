<%@ Page Title="" Language="C#" MasterPageFile="~/TeacherUI/TeacherMasterPage.Master"
    AutoEventWireup="true" CodeBehind="TeacherIndex.aspx.cs" Inherits="Web.TeacherUI.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../css/common_index.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <div class="fl workShow-wrap">
        <dl id="workShow" class="workShow">
            <dt class="fn-ellipsis">优秀毕业设计展示<span class="more"><a href="/TeacherUI/GoodWorkAll.aspx?nodeId=2001">>>更多</a></span></dt>
            <dd>
                <ul>
                    <asp:Repeater ID="rptGoodWork" runat="server">
                    <ItemTemplate>
                         <li><a href="/TeacherUI/SingleWork.aspx?nodeId=2001&gid=<%#Eval("GId") %>"><%#Eval("GTitle")%></a></li>
                    </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </dd>
        </dl>
    </div>
    <div class="fr rightpart">
        <div class="notice-wrap">
            <dl id="notice" class="notice">
                <dt class="fn-ellipsis">公告<span class="fr more"><a href="/TeacherUI/AllNotice.aspx?nodeId=2021">>>更多</a></span></dt>
                <dd>
                    <ul>
                        <asp:Repeater ID="rptNotice" runat="server">
                        <ItemTemplate>
                            <li><a href="/TeacherUI/NoticeDetail.aspx?nodeId=2021&nid=<%#Eval("NId") %>" class="readstatus"><%#Eval("NTitle") %></a></li>
                        </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </dd>
            </dl>
        </div>
        <%--<div class="download-wrap">
            <dl id="download" class="download">
                <dt class="fn-ellipsis">相关文档下载<span class="fr more"><a href="#">>>更多</a></span></dt>
                <dd>
                    <ul>
                        <li><a href="#">毕业设计各种作弊方法大全</a></li>
                        <li><a href="#">毕业设计各种作弊方法大全</a></li>
                        <li><a href="#">毕业设计各种作弊方法大全</a></li>
                    </ul>
                </dd>
            </dl>
        </div>--%>
    </div>
</asp:Content>
