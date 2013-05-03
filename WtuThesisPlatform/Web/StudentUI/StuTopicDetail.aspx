<%@ Page Title="" Language="C#" MasterPageFile="~/StudentUI/StudentMasterPage.Master"
    AutoEventWireup="true" CodeBehind="StuTopicDetail.aspx.cs" Inherits="Web.StudentUI.StuTopicDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../css/student/stu_page.css" />
    <script type="text/javascript" src="../js/student/StuSelect.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <div class="wrap">
        <div class="topic-info">
            <dl>
                <dt>
                    <h1>选题信息</h1>
                    <span class="store-icon list-icon ope"></span>
                    <span class="select-icon list-icon ope"></span>
                </dt>
                
            </dl>
            <table id="topic" class="topic-single  wid1000" cellspacing="0" cellpadding="0">
                <tr>
                    <td class="fn-text-wrap colname">选题名称</td>
                    <td id="topicname">毕业设计选题系统</td>
                    <td class="fn-text-wrap colname">导师</td>
                    <td id="topicTeacher"><a href="#">何何何</a></td>
                    <td class="fn-text-wrap colname">开发平台</td>
                    <td id="developTool">Visual C++</td>
                    
                </tr>
                <tr>
                    <td class="fn-text-wrap colname">允许选择人数</td>
                    <td id="all">3</td>
                    <td class="fn-text-wrap colname">已选人数</td>
                    <td id="choosed">4</td>
                    <td class="fn-text-wrap colname">剩余人数</td>
                    <td id="left">7</td>
                </tr>
                <tr>
                    <td class="fn-text-wrap colname" colspan="6">题目简介</td>
                </tr>
                <tr>
                    <td id="topicIntro" colspan="6"> <p>&nbsp;&nbsp;&nbsp;&nbsp;视觉目标的自动跟踪是一个有趣的视频应用，实际应用十分广泛。但现实应用中常需要解决很多问题，比如光照、尺度、旋转等的变化，噪声的影响。通过在实践经典跟踪算法过程中，学习并改进算法，展现跟踪效果。视觉目标的自动跟踪是一个有趣的视频应用，实际应用十分广泛。但现实应用中常需要解决很多问题，比如光照、尺度、旋转等的变化，噪声的影响。通过在实践经典跟踪算法过程中，学习并改进算法，展现跟踪效果.</p></td>
                </tr>
                <tr>
                    <td class="fn-text-wrap colname" colspan="6">设计功能与实现目标</td> 
                </tr>
                <tr >
                    <td id="target" colspan="6"> <p>&nbsp;&nbsp;&nbsp;&nbsp;视觉目标的自动跟踪是一个有趣的视频应用，实际应用十分广泛。但现实应用中常需要解决很多问题，比如光照、尺度、旋转等的变化，噪声的影响。通过在实践经典跟踪算法过程中，学习并改进算法，展现跟踪效果。</p></td>
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
