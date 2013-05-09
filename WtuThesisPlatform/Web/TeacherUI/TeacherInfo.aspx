<%@ Page Title="" Language="C#" MasterPageFile="~/TeacherUI/TeacherMasterPage.Master" AutoEventWireup="true" CodeBehind="TeacherInfo.aspx.cs" Inherits="Web.TeacherUI.TeacherInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <div class="wrap">
        <div class="person-info">
            <dl>
                <dt>
                    <h1>
                        个人基本信息</h1>
                    <span class="modify"><a href="StuModifyPwd.aspx" id="mPassword" class="dis-inline-block">
                        修改密码</a><a   href="#" id="mInfo" class="dis-inline-block">修改个人信息</a></span></dt>
                <dd>
                    教工号：<input type="text" id="tNo" class="tNo" runat="server" value="111" readonly="readonly" /></dd>
                <dd>
                    姓名：<input type="text" id="tName" class="tName" runat="server" value="何儒汉" readonly="readonly" /></dd>
                <dd>
                    性别：<input type="text" id="tSex" class="tSex" runat="server" value="男" readonly="readonly" /></dd>
                <dd>
                    职称：<input type="text" id="tZhiCheng" class="tZhiCheng" runat="server" value="博士" readonly="readonly" /></dd>
                <dd>
                    院系：<select id="tFaculty" class="tFaculty" runat="server" disabled="disabled">
                    </select></dd>
                <dd>
                    专业：<select id="tProfession" class="tProfession" runat="server" disabled="disabled">
                    </select></dd>
                <dd>
                    电话：<input type="text" id="tPhone" class="tPhone" runat="server" value="13419540412"
                        readonly="readonly" /><span id="phoneError" style="color: red; display: none">*</span>
                </dd>
                <dd>
                    邮箱：<input type="text" id="tEmail" class="tEmail" runat="server" value="594659037@qq.com"
                        readonly="readonly" /><span id="emailError" style="color: red; display: none">*</span>
                </dd>
                <dd>
                    Q Q：
                    <input type="text" id="tQQ" class="tQQ" runat="server" value="594659037" readonly="readonly" />
                    <span id="qqError" style="color: red; display: none">*</span></dd>
                <dd>
                    主讲课程：<input type="text" id="tTeachCourse" class="tTeachCourse" runat="server" value="软件工程" readonly="readonly" /></dd>
            </dl>
        </div>
    </div>
</asp:Content>
