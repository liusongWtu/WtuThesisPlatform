<%@ Page Title="" Language="C#" MasterPageFile="~/StudentUI/StudentMasterPage.Master"
    AutoEventWireup="true" CodeBehind="StuModifyPwd.aspx.cs" Inherits="Web.StudentUI.StuModifyPwd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../css/student/stu_page.css" />
    <link rel="stylesheet" type="text/css" href="../js/popup/jquery.confirm.css" />
    <script type="text/javascript" src="../js/student/StuModifyPwd.js"></script>
    <script type="text/javascript" src="../js/popup/jquery.confirm.js"></script>
    <script src="../js/MD5.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <div class="wrap">
        <div class="stu-modify_password">
            <dl>
                <dt>
                    <h1>
                        密码修改</h1>
                </dt>
                <br />
            </dl>
            <table>
                <tr>
                    <td>
                        输入原密码：
                    </td>
                    <td>
                        <input type="password" id="oldPassword" class="dis-inline-block" />
                    </td>
                    <td style="color:red"></td>
                </tr>
                <tr>
                    <td>
                        输入新密码：
                    </td>
                    <td>
                        <input type="password" id="newPassword" class="dis-inline-block" />
                    </td>
                    <td style="color:red"></td>
                </tr>
                <tr>
                    <td>
                        新密码确认：
                    </td>
                    <td>
                        <input type="password" id="repeatNewPsw" class="dis-inline-block" />
                    </td>
                    <td style="color:red"></td>
                </tr>
                <tr>
                    <td>
                        <button id='psd-modify-ok' class='psd-modify-ok button dis-inline-block'>
                        </button>
                    </td>
                    <td>
                        <button id='psd-modify-no' class='psd-modify-no button dis-inline-block'>
                        </button>
                    </td>
                </tr>
            </table>
            <!--<div id="tPhoto">
				待定
			</div>-->
        </div>
    </div>
</asp:Content>
