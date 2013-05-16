<%@ Page Title="" Language="C#" MasterPageFile="~/TeacherUI/TeacherMasterPage.Master"
    AutoEventWireup="true" CodeBehind="AllTopic.aspx.cs" Inherits="Web.TeacherUI.AllTopic" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../css/teacher/teacher_pages.css" />
    <script type="text/javascript" src="../js/teacher/AllTopic.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <div class="select-list">
        <div class="content-top">
            <div class="search fl fillet">
                <label class="ablt">
                    关键字...</label>
                <input type="text" class="search-input" />
                <button id="searchButton" class="search-button abrt">
                    <span>搜索</span>
                </button>
            </div>
        </div>
        <div class="topic">
            <!--<dl>
								<dt>历年选题信息</dt>
							</dl>-->
            <table class="topic-list" cellspacing="0" cellpadding="0">
                <tr class="list-header">
                    <td class="td-wid0 left">
                        选题名称
                    </td>
                    <td style="width: 50%">
                        出题时间
                    </td>
                    <td class="last td-wid1">
                        审核结果
                    </td>
                </tr>
                <asp:Repeater ID="rptThesis" runat="server">
                <ItemTemplate>
                    <tr class="list-content">
                    <td class="bold left">
                        <a><%#Eval("TName") %></a>
                    </td>
                    <td>
                        <%#Eval("TYear") %>
                    </td>
                    <td>
                        <%#Eval("StateString")%>
                    </td>
                </tr>
                <tr class="detail nohover hide">
                    <td colspan="3" class="tr-wid fn-text-wrap">
                        <table>
                            <tr class="nohover">
                                <td>开发平台：
                                    <p id="developTool"><%#Eval("TPlatform") %></p>
                                </td>
                            </tr>
                            <tr class="nohover">
                                <td>题目简介：
                                    <p id="topicIntro" class="fn-text-wrap">
                                        <%#Eval("TIntroduct") %>
                                    </p>
                                </td>
                            </tr>
                            <tr class="nohover">
                                <td>设计功能与实现目标：
                                    <p id="target" class="fn-text-wrap">
                                    <%#Eval("TRequire") %>    
                                    </p>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                </ItemTemplate>
                </asp:Repeater>

            </table>
        </div>
       <%--<div class="content-bottom">
            <div class="pagechange">
                    <div id="pageBar"><%=pageBar%></div>
            </div>
        </div>--%>
    </div>
</asp:Content>
