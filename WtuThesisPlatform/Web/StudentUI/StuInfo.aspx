<%@ Page Title="" Language="C#" MasterPageFile="~/StudentUI/StudentMasterPage.Master"
    AutoEventWireup="true" CodeBehind="StuInfo.aspx.cs" Inherits="Web.StudentUI.StuInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../css/student/stu_page.css" />
    <style type="text/css">
       
    </style>
    <script src="../js/student/StuInfo.js" type="text/javascript"></script>
    <script src="../js/Common.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/om/ui/rules.js"></script>
    <script type="text/javascript" src="../js/om/ui/om-validate.js"></script>
    <script type="text/javascript" src="../js/Validata.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <div class="wrap">
        <div class="person-info">
            <dl>
                <dt>个人基本信息
                    <span class="modify"><a href="StuModifyPwd.aspx?nodeId=1032" id="mPassword" class="dis-inline-block">
                        修改密码</a><a   href="#" id="mInfo" class="dis-inline-block">修改个人信息</a></span></dt>
             </dl>
             <table>
                <tr><td>学号：</td>
                    <td><input type="text" name="isNumber" id="sNo" class="sNo"  value="<%=currStudent.SNo %>" readonly="readonly" /></td>
                </tr>
                <tr><td>姓名：</td>
                    <td><input type="text" id="sName" class="sName"  value="<%=currStudent.SName %>" readonly="readonly" /></td>
                </tr>
                <tr><td>性别：</td>
                    <td><input type="text" id="sSex" class="sSex"  value="<%=currStudent.SSex %>" readonly="readonly" /></td>
                </tr>
                <tr><td>届数：</td>
                    <td><input type="text" id="sYear" class="sYear"  value="<%=currStudent.SYear %>" readonly="readonly" /></td>
                </tr>
                <tr><td>电话：</td>
                    <td><input type="text" name="isMobilePhone"  id="sPhone" class="sPhone"  value="<%=currStudent.SPhone %>" readonly="readonly" /></td>
                </tr>
                <tr><td>邮箱：</td>
                    <td><input type="text" name ="isEmail" id="sEmail" class="sEmail"  value="<%=currStudent.SEmail %>" readonly="readonly" /></td>
                </tr>
                <tr><td>QQ：</td>
                    <td><input type="text" name="isQQ" id="sQQ" class="sQQ"  value="<%=currStudent.SQQ %>" readonly="readonly" /></td>
                </tr>
                <tr><td>院系：</td>
                    <td><select id="sFaculty" class="sFaculty" runat="server" disabled="disabled"></select></td>
                </tr>                                                                            
                <tr><td>专业：</td>
                    <td><select id="sProfession" class="sProfession" runat="server" disabled="disabled"></select></td>
                </tr>
                <tr><td>班级：</td>
                    <td><select id="sClass" class="sClass" runat="server" disabled="disabled"></select></td>
                </tr>
             </table>
                
        </div>
    </div>
</asp:Content>
