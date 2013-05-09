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
                <dt id="<%=currThesisTitle.TId %>">
                    <h1>选题信息</h1>
                    <span class="store-icon list-icon ope"></span>
                    <span class="select-icon list-icon ope"></span>
                </dt>
                
            </dl>
            <table id="topic" class="topic-single  wid1000" cellspacing="0" cellpadding="0">
                <tr>
                    <td class="fn-text-wrap colname">选题名称</td>
                    <td id="topicname"><%=currThesisTitle.TName%></td>
                    <td class="fn-text-wrap colname">导师</td>
                    <td id="topicTeacher"><a href="#"><%=currThesisTitle.Teacher.TName %></a></td>
                    <td class="fn-text-wrap colname">开发平台</td>
                    <td id="developTool"><%=currThesisTitle.TPlatform %></td>
                    
                </tr>
                <tr>
                    <td class="fn-text-wrap colname">允许选择人数</td>
                    <td id="all"><%=currThesisTitle.TNumber %></td>
                    <td class="fn-text-wrap colname">新选人数</td>
                    <td id="choosed"><%=currThesisTitle.TNewNum %></td>
                    <td class="fn-text-wrap colname">确定人数</td>
                    <td id="left"><%=currThesisTitle.TAcceptNum %></td>
                </tr>
                <tr>
                    <td class="fn-text-wrap colname" colspan="6">题目简介</td>
                </tr>
                <tr>
                    <td id="topicIntro" colspan="6"> <p>&nbsp;&nbsp;&nbsp;&nbsp;<%=currThesisTitle.TIntroduct %></p></td>
                </tr>
                <tr>
                    <td class="fn-text-wrap colname" colspan="6">设计功能与实现目标</td> 
                </tr>
                <tr >
                    <td id="target" colspan="6"> <p>&nbsp;&nbsp;&nbsp;&nbsp;<%=currThesisTitle.TRequire %></p></td>
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
