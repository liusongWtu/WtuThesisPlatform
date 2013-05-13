<%@ Page Title="" Language="C#" MasterPageFile="~/TeacherUI/TeacherMasterPage.Master" AutoEventWireup="true" CodeBehind="TeacherInfo.aspx.cs" Inherits="Web.TeacherUI.TeacherInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="../js/om/ui/rules.js"></script>
    <script type="text/javascript" src="../js/om/ui/om-validate.js"></script>
    <script type="text/javascript" src="../js/Validata.js"></script>
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
                    <td>教工号：</td><td><input type="text" id="tNo" class="tNo"  value="<%=currTeacher.TNo %>" readonly="readonly" /></td></tr>
                <tr>
                    <td>姓名：</td><td><input type="text" id="tName" class="tName"  value="<%=currTeacher.TName %>" readonly="readonly" /></td></tr>
                <tr> 
                    <td>性别：</td><td><input type="text" id="tSex" class="tSex"  value="<%=currTeacher.TSex %>" readonly="readonly" /></td></tr>
                <tr>
                    <td>职称：</td><td><input type="text" id="tZhiCheng" class="tZhiCheng"  value="<%=currTeacher.TZhiCheng %>" readonly="readonly" /></td></tr>
                <tr>
                    <td>电话：</td><td><input name="isMobilePhone" type="text" id="tPhone" class="tPhone"  value="<%=currTeacher.TPhone %>"
                        readonly="readonly" /></td>
                </tr>
                <tr>
                    <td>邮箱：</td><td><input  name ="isEmail" type="text" id="tEmail" class="tEmail"  value="<%=currTeacher.TEmail %>"
                        readonly="readonly" /></td>
                </tr>
                <tr><td>Q Q：</td><td>
                    <input  name="isQQ" type="text" id="tQQ" class="tQQ"  value="<%=currTeacher.TQQ %>" readonly="readonly" /></td>
                </tr>
                <tr>
                    <td>院系：</td><td><select id="tFaculty" class="tFaculty" runat="server" disabled="disabled">
                    </select></td></tr>
                <tr>
                    <td>专业：</td><td><select id="tProfession" class="tProfession" runat="server" disabled="disabled">
                    </select></td></tr>
                <tr>
                    <td>主讲课程：</td><td><textarea cols="50" rows="3" id="tTeachCourse" class="tTeachCourse"><%=currTeacher.TTeachCourse %></textarea></td>
                </tr>
                <tr><td>
                    研究方向：</td><td><textarea cols="50" rows="3" id="tResearchFields" class="tResearchFields"><%=currTeacher.TResearchFields %></textarea></td>
                </tr>
                
            </table>
        </div>
    </div>
</asp:Content>
