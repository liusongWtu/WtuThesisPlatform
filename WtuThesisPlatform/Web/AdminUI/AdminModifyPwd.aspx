<%@ Page Title="" Language="C#" MasterPageFile="~/AdminUI/AdminMasterPage.Master"
    AutoEventWireup="true" CodeBehind="AdminModifyPwd.aspx.cs" Inherits="Web.AdminUI.AdminModifyPwd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../js/popup/jquery.confirm.css" />
    <script type="text/javascript" src="../js/ModifyPwd.js"></script>
    <script src="../js/MD5.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <div class="wrap">
        <div class="modify_password">
            <dl>
                <dt>
                        密码修改
                </dt>
                <br />
            </dl>
            <div class="content-center">
            <table>
                <tr>
                    <td>
                        输入原密码：
                    </td>
                    <td>
                        <input type="password" id="oldPassword" class="dis-inline-block" />
                    </td>
                    <td style="color: red">
                    </td>
                </tr>
                <tr>
                    <td>
                        输入新密码：
                    </td>
                    <td>
                        <input type="password" id="newPassword" class="dis-inline-block" />
                    </td>
                    <td style="color: red">
                    </td>
                </tr>
                <tr>
                    <td>
                        新密码确认：
                    </td>
                    <td>
                        <input type="password" id="repeatNewPsw" class="dis-inline-block" />
                    </td>
                    <td style="color: red">
                    </td>
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
            </div>
            <!--<div id="tPhoto">
				待定
			</div>-->
        </div>
    </div>
</asp:Content>
