<%@ Page Title="" Language="C#" MasterPageFile="~/AdminUI/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="TeacherApplyDetail.aspx.cs" Inherits="Web.AdminUI.TeacherApplyDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="../js/admin/TeacherApply.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <div class="wrap">
        <div class="topic-info">
            <dl>
                <dt>
                    教师选题详细信息
                    <span class="check-wrap" id="<%=currThesisTitle.TId %>"><a href="#" class="check checkYes">通过</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href="#" class="check checkNo">不通过</a></span>
                </dt>
                
            </dl>
            <table id="topic" class="topic-single  wid1000" cellspacing="0" cellpadding="0">
                <tr>
                    <td class="fn-text-wrap colname">教师</td>
                    <td id="topicname"><%=currThesisTitle.Teacher.TName%></td>
                    <td class="fn-text-wrap colname">选题名称</td>
                    <td colspan="4"><%=currThesisTitle.TName %></td>
                </tr>
                <tr>
                    <td class="fn-text-wrap colname">电话</td>
                    <td><%=currThesisTitle.Teacher.TPhone %></td>
                    <td class="fn-text-wrap colname">QQ</td>
                    <td><%=currThesisTitle.Teacher.TQQ %></td>
                    <td class="fn-text-wrap colname">邮箱</td>
                    <td><%=currThesisTitle.Teacher.TEmail %></td>
                </tr>
                <tr>
                    <td class="fn-text-wrap colname">职称</td>
                    <td><%=currThesisTitle.Teacher.TZhiCheng %></td>
                    <td class="fn-text-wrap colname">主讲课程</td>
                    <td colspan="4"> <%=currThesisTitle.Teacher.TTeachCourse %></td>
                </tr>
                <tr>
                    <td class="fn-text-wrap colname">研究方向</td>
                    <td colspan="5"> <%=currThesisTitle.Teacher.TResearchFields %></td>
                </tr>
                <tr>
                    <td class="fn-text-wrap colname" colspan="6">题目简介</td>
                </tr>
                <tr>
                    <td colspan="6"> <p>&nbsp;&nbsp;&nbsp;&nbsp;<%=currThesisTitle.TIntroduct %></p></td>
                </tr>
                <tr>
                    <td class="fn-text-wrap colname" colspan="6">设计功能与实现目标</td> 
                </tr>
                <tr >
                    <td colspan="6"> <p>&nbsp;&nbsp;&nbsp;&nbsp; <%=currThesisTitle.TRequire %></p></td>
                </tr>
            </table>
        </div>
    </div>

</asp:Content>
