<%@ Page Title="" Language="C#" MasterPageFile="~/TeacherUI/TeacherMasterPage.Master" AutoEventWireup="true" CodeBehind="AllNotice.aspx.cs" Inherits="Web.TeacherUI.AllNotice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="Stylesheet" type="text/css" href="../css/teacher/teacher_pages.css" />
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
                    <tr class="list-content">
                        <td class="left bold tr30">
                            <a class="NTitle">公告标题</a>
                        </td>
                        <td  class="tr10">
                            <span class="NPublishTime">2013-05-12</span>
                        </td>
                        <td class="tr10">
                            <span class="NPublishUnits">发布单位</span>
                        </td>
                        <td class="tr10">
                            <span class="NDeadTime">2013-12-12</span>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
</asp:Content>
