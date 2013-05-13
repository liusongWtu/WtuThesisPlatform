<%@ Page Title="" Language="C#" MasterPageFile="~/TeacherUI/TeacherMasterPage.Master" AutoEventWireup="true" CodeBehind="TeacherInfo.aspx.cs" Inherits="Web.TeacherUI.TeacherInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="../js/teacher/Teacherinfo.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <div class="wrap">
        <div class="person-info">
            <dl>
                <dt>个人基本信息
                    <span class="modify"><a href="TeacherModifyPwd.aspx" id="mPassword" class="dis-inline-block">
                        修改密码</a><a   href="#" id="mInfo" class="dis-inline-block">修改个人信息</a></span></dt>
            </dl>
            <table>  
                <tr>
                    <td>教工号：</td><td><input type="text" id="tNo" class="tNo" runat="server" value="111" readonly="readonly" /></td></tr>
                <tr>
                    <td>姓名：</td><td><input type="text" id="tName" class="tName" runat="server" value="何儒汉" readonly="readonly" /></td></tr>
                <tr>
                    <td>性别：</td><td><input type="text" id="tSex" class="tSex" runat="server" value="男" readonly="readonly" /></td></tr>
                <tr>
                    <td>职称：</td><td><input type="text" id="tZhiCheng" class="tZhiCheng" runat="server" value="博士" readonly="readonly" /></td></tr>
                <tr>
                    <td>电话：</td><td><input type="text" id="tPhone" class="tPhone" runat="server" value="13419540412"
                        readonly="readonly" /></td>
                </tr>
                <tr>
                    <td>邮箱：</td><td><input type="text" id="tEmail" class="tEmail" runat="server" value="594659037@qq.com"
                        readonly="readonly" /></td>
                </tr>
                <tr><td>Q Q：</td><td>
                    <input type="text" id="tQQ" class="tQQ" runat="server" value="594659037" readonly="readonly" /></td>
                </tr>
                <tr>
                    <td>院系：</td><td><select id="tFaculty" class="tFaculty" runat="server" disabled="disabled">
                    </select></td></tr>
                <tr>
                    <td>专业：</td><td><select id="tProfession" class="tProfession" runat="server" disabled="disabled">
                    </select></td></tr>
                <tr>
                    <td>主讲课程：</td><td><textarea cols="50" rows="3" id="tTeachCourse" class="tTeachCourse"></textarea></td>
                </tr>
                <tr><td>
                    研究方向：</td><td><textarea cols="50" rows="3" id="tResearchFields" class="tResearchFields"></textarea></td>
                </tr>
                
            </table>
        </div>
    </div>
</asp:Content>
