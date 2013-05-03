<%@ Page Title="" Language="C#" MasterPageFile="~/TeacherUI/TeacherMasterPage.Master"
    AutoEventWireup="true" CodeBehind="AllTopic.aspx.cs" Inherits="Web.TeacherUI.AllTopic" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../css/teacher/teacher_pages.css" />
    <script type="text/javascript" src="../js/teacher/AllTopic.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <div class="wrap">
        <div class="content-top">
            <div class="search fl fillet">
                <label class="ablt">
                    关键字...</label>
                <input type="text" class="search-input" />
                <button id="searchButton" class="search-button abrt">
                    <span>搜索</span></button>
            </div>
        </div>
        <div class="topic">
            <!--<dl>
								<dt>历年选题信息</dt>
							</dl>-->
            <table class="topic-list" cellspacing="0" cellpadding="0">
                <tr class="list-header">
                    <td class="td-wid0">
                        选题名称
                    </td>
                    <td class="last td-wid1" style="width: 50%">
                        出题时间
                    </td>
                </tr>
                <tr class="list-content">
                    <td class="td-wid0">
                        <a>毕业设计选题系统</a>
                    </td>
                    <td class="td-wid1">
                        2012-04-12
                    </td>
                </tr>
                <tr class="detail nohover hide">
                    <td colspan="2" class="tr-wid">
                        <table>
                            <tr class="nohover">
                                <td class="fn-text-wrap">
                                    开发平台<p>
                                        Visual C++</p>
                                </td>
                            </tr>
                            <tr class="nohover">
                                <td class="fn-text-wrap">
                                    题目简介<p>
                                        视觉目标的自动跟踪是一个有趣的视频应用，实际应用十分广泛。但现实应用中常需要解决很多问题，比如光照、尺度、旋转等的变化，噪声的影响。通过在实践经典跟踪算法过程中，学习并改进算法，展现跟踪效果。</p>
                                </td>
                            </tr>
                            <tr class="nohover">
                                <td class="fn-text-wrap">
                                    设计功能与实现目标<p>
                                        视觉目标的自动跟踪是一个有趣的视频应用，实际应用十分广泛。但现实应用中常需要解决很多问题，比如光照、尺度、旋转等的变化，噪声的影响。通过在实践经典跟踪算法过程中，学习并改进算法，展现跟踪效果。</p>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr class="list-content">
                    <td>
                        <a>毕业设计选题系统</a>
                    </td>
                    <td>
                        2012-04-12
                    </td>
                </tr>
                <tr class="detail nohover hide">
                    <td colspan="2" class="tr-wid">
                        <table align="left">
                            <tr class="nohover">
                                <td class="fn-text-wrap">
                                    开发平台<p id="developTool">
                                        Visual C++</p>
                                </td>
                            </tr>
                            <tr class="nohover">
                                <td class="fn-text-wrap">
                                    题目简介<p id="topicIntro">
                                        视觉目标的自动跟踪是一个有趣的视频应用，实际应用十分广泛。但现实应用中常需要解决很多问题，比如光照、尺度、旋转等的变化，噪声的影响。通过在实践经典跟踪算法过程中，学习并改进算法，展现跟踪效果。视觉目标的自动跟踪是一个有趣的视频应用，实际应用十分广泛。但现实应用中常需要解决很多问题，比如光照、尺度、旋转等的变化，噪声的影响。通过在实践经典跟踪算法过程中，学习并改进算法，展现跟踪效果。</p>
                                        视觉目标的自动跟踪是一个有趣的视频应用，实际应用十分广泛。但现实应用中常需要解决很多问题，比如光照、尺度、旋转等的变化，噪声的影响。通过在实践经典跟踪算法过程中，学习并改进算法，展现跟踪效果。视觉目标的自动跟踪是一个有趣的视频应用，实际应用十分广泛。但现实应用中常需要解决很多问题，比如光照、尺度、旋转等的变化，噪声的影响。通过在实践经典跟踪算法过程中，学习并改进算法，展现跟踪效果。
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
                </tr>
            </table>
        </div>
        <div class="content-bottom">
            <table class="pagechange">
                <tr>
                    <td class="page-up" title="上一页">
                        <span></span>
                    </td>
                    <td>
                        <a href="#">1</a>
                    </td>
                    <td>
                        <a href="#">2</a>
                    </td>
                    <td>
                        <a href="#">3</a>
                    </td>
                    <td>
                        <a href="#">4</a>
                    </td>
                    <td>
                        <a href="#">5</a>
                    </td>
                    <td>
                        <a href="#">6</a>
                    </td>
                    <td class="page-down" title="下一页">
                        <span></span>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
