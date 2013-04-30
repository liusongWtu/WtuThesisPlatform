<%@ Page Title="" Language="C#" MasterPageFile="~/StudentUI/StudentMasterPage.Master"
    AutoEventWireup="true" CodeBehind="StuTopicDetail.aspx.cs" Inherits="Web.StudentUI.StuTopicDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../css/student/stu_page.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <div class="wrap">
        <div class="teacher-info">
            <dl>
                <dt>
                    <h1>
                        导师基本信息</h1>
                </dt>
                <dd>
                    姓名：<span id="tName">何儒汉</span></dd>
                <dd>
                    职称：<span id="tPosition">学院副教授</span></dd>
                <dd>
                    电话：<span id="tPhone">16441471409</span></dd>
                <dd>
                    QQ：<span id="tQQ">594659037</span></dd>
                <dd>
                    邮箱：<span id="tEmail">594659037@qq.com</span></dd>
                <dd>
                    院系：<span id="tFaculty">数学与计算机学院</span></dd>
                <dd>
                    主讲课程：<span id="tProfession">数据库原理、软件基础、Delphi数据库应用、Unix操作系统</span></dd>
                <dd>
                    研究方向：<span id="tResearch">计算机视觉、多媒体处理、搜索引擎、信息检索、物流优化</span></dd>
            </dl>
            <!--<div id="tPhoto">
								待定
							</div>-->
        </div>
        <div class="topic-info">
            <dl>
                <dt>
                    <h1>
                        选题信息</h1>
                </dt>
            </dl>
            <table id="topic" class="topic-single  wid800" cellspacing="0" cellpadding="0">
                <tr class="detail">
                    <td class="fn-text-wrap" colspan="3">
                        选题名称<p id="topicname">
                            毕业设计选题系统</p>
                    </td>
                </tr>
                <tr class="detail">
                    <td class="fn-text-wrap" colspan="3">
                        开发平台<p id="developTool">
                            Visual C++</p>
                    </td>
                </tr>
                <tr class="detail">
                    <td class="fn-text-wrap">
                        剩余人数<p id="left">
                            3</p>
                    </td>
                    <td class="fn-text-wrap">
                        已选人数<p id="choosed">
                            4</p>
                    </td>
                    <td class="fn-text-wrap">
                        已选人数<p id="all">
                            7</p>
                    </td>
                </tr>
                <tr class="detail">
                    <td class="fn-text-wrap" colspan="3">
                        题目简介<p id="topicIntro">
                            视觉目标的自动跟踪是一个有趣的视频应用，实际应用十分广泛。但现实应用中常需要解决很多问题，比如光照、尺度、旋转等的变化，噪声的影响。通过在实践经典跟踪算法过程中，学习并改进算法，展现跟踪效果。视觉目标的自动跟踪是一个有趣的视频应用，实际应用十分广泛。但现实应用中常需要解决很多问题，比如光照、尺度、旋转等的变化，噪声的影响。通过在实践经典跟踪算法过程中，学习并改进算法，展现跟踪效果.</p>
                    </td>
                </tr>
                <tr class="detail">
                    <td class="fn-text-wrap" colspan="3">
                        设计功能与实现目标<p id="target">
                            视觉目标的自动跟踪是一个有趣的视频应用，实际应用十分广泛。但现实应用中常需要解决很多问题，比如光照、尺度、旋转等的变化，噪声的影响。通过在实践经典跟踪算法过程中，学习并改进算法，展现跟踪效果。</p>
                    </td>
                </tr>
            </table>
        </div>
        <div class="message-board">
            <dl>
                <dt>
                    <h1>
                        留言板</h1>
                </dt>
            </dl>
            <ul class="dis-comments">
                <li class="each-comment">
                    <div class="com-body">
                        <div class="com-name">
                            刘松</div>
                        <p>
                            这是一条留言</p>
                        <div class="com-action">
                            <span class="com-time">4月18日</span> <a href="javascript:void(0);" class="com-reply">
                                回复 </a>
                        </div>
                    </div>
                    <ul class="com-children">
                        <li class="each-comment">
                            <div class="com-body">
                                <div class="com-name">
                                    龙玉莲</div>
                                <p>
                                    这是我回复刘松的留言</p>
                                <div class="com-action">
                                    <span class="com-time">4月18日</span> <a href="javascript:void(0);" class="com-reply">
                                        回复 </a>
                                </div>
                            </div>
                        </li>
                    </ul>
                </li>
            </ul>
            <!--留言框-->
            <div class="reply-box">
                <div class="reply-textarea">
                    <textarea placeholder="说点什么吧..." name="message"></textarea>
                </div>
                <div class="reply-toolbar">
                    <button>
                    </button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
