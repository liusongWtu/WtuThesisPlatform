<%@ Page Title="" Language="C#" MasterPageFile="~/StudentUI/StudentMasterPage.Master"
    AutoEventWireup="true" CodeBehind="StuTopicInfo.aspx.cs" Inherits="Web.StudentUI.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../css/student/stu_page.css" />
    <script type="text/javascript" src="../js/student/StuSelect.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <div class="links"><a href="StuIndex.aspx">首页</a></div>
   
    <div class="wrap">
        <div class="teacher-info">
            <dl>
                <dt>
                    <h1>
                        导师基本信息</h1>
                </dt>
                <dd>
                    姓名：<span id="tName"><%=currTeacher.TName %></span></dd>
                <dd>
                    职称：<span id="tPosition"><%=currTeacher.TZhiCheng %></span></dd>
                <dd>
                    电话：<span id="tPhone"><%=currTeacher.TPhone %></span></dd>
                <dd>
                    QQ：<span id="tQQ"><%=currTeacher.TQQ %></span></dd>
                <dd>
                    邮箱：<span id="tEmail"><%=currTeacher.TEmail %></span></dd>
                <dd>
                    院系：<span id="tFaculty"><%=currTeacher.Department.DName %></span></dd>
                <dd>
                    主讲课程：<span id="tProfession"><%=currTeacher.TTeachCourse %></span></dd>
                <dd>
                    研究方向：<span id="tResearch"><%=currTeacher.TResearchFields %></span></dd>
            </dl>
            <!--<div id="tPhoto">
								待定
							</div>-->
        </div>
        <div class="topic-info">
            <dl>
                <dt>
                    <h1>
                        导师各选题信息</h1>
                </dt>
            </dl>
            <table id="topicList" class="topic-list" cellspacing="0" cellpadding="0">
                <tr class="list-header">
                    <td class="td0">
                        &nbsp;
                    </td>
                    <td class="td1">
                        选题名称
                    </td>
                    <td class="td2">
                        允许人数
                    </td>
                    <td class="td3">
                        新选人数
                    </td>
                    <td class="td4">
                        确定人数
                    </td>
                    <td class="td5">
                        教师
                    </td>
                    <td class="td6">
                        收藏
                    </td>
                    <td class="td7">
                        选题
                    </td>
                </tr>
                <asp:Repeater ID="rptThesises" runat="server">
                    <ItemTemplate>
                        <tr class="list-content">
                            <td class="td0">
                                <input type="checkbox" name="topiclist" />
                            </td>
                            <td class="td1">
                                <a href="/StudentUI/StuTopicDetail.aspx?thesisId=<%#Eval("TId") %>"><%#Eval("TName") %></a>
                            </td>
                            <td class="td2">
                                <%#Eval("TNumber") %>
                            </td>
                            <td class="td3">
                                <%#Eval("TNewNum") %>
                            </td>
                            <td class="td4">
                                <%#Eval("TAcceptNum") %>
                            </td>
                            <td class="td5teacher">
                                <a href="/StudentUI/StuTopicInfo.aspx?teacherId=<%#Eval("Teacher.TId") %>"><%#Eval("Teacher.TName") %></a>
                            </td>
                            <td class="td6" id="<%#Eval("TId") %>">
                                <span class="store-icon list-icon"></span>
                            </td>
                            <td class="td7" id="<%#Eval("TId") %>" >
                                <span class="select-icon list-icon"></span>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <!--<tr class="detail nohover hide">
                    <td colspan="8">
                        <table>
                            <tr class="nohover">
                                <td class="fn-text-wrap">
                                    开发平台<p id="developTool">
                                        Visual C++</p>
                                </td>
                            </tr>
                            <tr class="nohover">
                                <td class="fn-text-wrap">
                                    题目简介<p id="topicIntro">
                                        视觉目标的自动跟踪是一个有趣的视频应用，实际应用十分广泛。但现实应用中常需要解决很多问题，比如光照、尺度、旋转等的变化，噪声的影响。通过在实践经典跟踪算法过程中，学习并改进算法，展现跟踪效果。</p>
                                </td>
                            </tr>
                            <tr class="nohover">
                                <td class="fn-text-wrap">
                                    设计功能与实现目标<p id="target">
                                        视觉目标的自动跟踪是一个有趣的视频应用，实际应用十分广泛。但现实应用中常需要解决很多问题，比如光照、尺度、旋转等的变化，噪声的影响。通过在实践经典跟踪算法过程中，学习并改进算法，展现跟踪效果。</p>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>-->
            </table>
        </div>
    </div>
</asp:Content>
