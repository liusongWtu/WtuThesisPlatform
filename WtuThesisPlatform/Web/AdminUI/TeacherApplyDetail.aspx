<%@ Page Title="" Language="C#" MasterPageFile="~/AdminUI/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="TeacherApplyDetail.aspx.cs" Inherits="Web.AdminUI.TeacherApplyDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <div class="wrap">
        <div class="topic-info">
            <dl>
                <dt>
                    教师选题详细信息
                    <span class="check-wrap"><a href="#" class="check">通过</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href="#" class="check">不通过</a></span>
                </dt>
                
            </dl>
            <table id="topic" class="topic-single  wid1000" cellspacing="0" cellpadding="0">
                <tr>
                    <td class="fn-text-wrap colname">教师</td>
                    <td id="topicname">陈佳</td>
                    <td class="fn-text-wrap colname">选题名称</td>
                    <td colspan="4">毕业设计选题系统</td>
                </tr>
                <tr>
                    <td class="fn-text-wrap colname">电话</td>
                    <td>13419540412</td>
                    <td class="fn-text-wrap colname">QQ</td>
                    <td>594659037</td>
                    <td class="fn-text-wrap colname">邮箱</td>
                    <td>594659037@qq.com</td>
                </tr>
                <tr>
                    <td class="fn-text-wrap colname">职称</td>
                    <td>教师</td>
                    <td class="fn-text-wrap colname">主讲课程</td>
                    <td colspan="4"> 数据库原理、软件基础、数据库应用</td>
                </tr>
                <tr>
                    <td class="fn-text-wrap colname">研究方向</td>
                    <td colspan="5"> 数据库原理、软件基础、数据库应用</td>
                </tr>
                <tr>
                    <td class="fn-text-wrap colname" colspan="6">题目简介</td>
                </tr>
                <tr>
                    <td colspan="6"> <p>&nbsp;&nbsp;&nbsp;&nbsp;视觉目标的自动跟踪是一个有趣的视频应用，实际应用十分广泛。但现实应用中常需要解决很多问题，比如光照、尺度、旋转等的变化，噪声的影响。通过在实践经典跟踪算法过程中，学习并改进算法，展现跟踪效果。 达到的水平：依据学生自身条件，由浅入深。</p></td>
                </tr>
                <tr>
                    <td class="fn-text-wrap colname" colspan="6">设计功能与实现目标</td> 
                </tr>
                <tr >
                    <td colspan="6"> <p>&nbsp;&nbsp;&nbsp;&nbsp; 圈定视觉对象（比如人，车辆，人脸等），自动实时跟踪视频中视觉目标。可尝试一些著名跟踪算法比如Meanshift, Particle filter等算法，并进行一些改进，对比前后的效果。</p></td>
                </tr>
            </table>
        </div>
    </div>

</asp:Content>
