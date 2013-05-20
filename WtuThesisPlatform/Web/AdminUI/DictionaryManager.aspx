<%@ Page Title="" Language="C#" MasterPageFile="~/AdminUI/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="DictionaryManager.aspx.cs" Inherits="Web.AdminUI.DictionaryManager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="Stylesheet" type="text/css" href="../css/admin/adm_page.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <div class="select-list"> 
        <div class="topic"> 
        <dl>
            <dt>
                    系统参数设置
            </dt>
            <br />
        </dl>
        <div class="content-center">
        <table class="dictionary">
            <tr><td class="col-name">当前届：</td><td>
                <select id="currYear">
                    <option></option>
                </select>
            </td></tr>
            <tr><td class="col-name">是否向学生开放：</td><td>
                <input name="open" type="radio" checked="checked" />是
                <input name="open" type="radio" />否
            </td></tr>
            <tr><td class="col-name">学生志愿数：</td><td>
                <select id="wish">
                    <option selected="selected">1</option>
                    <option>2</option>
                    <option>3</option>
                    <option>4</option>
                    <option>5</option>
                </select>
            </td></tr>
        </table>
        </div>
        <div class="content-bottom">
            <button>保存</button>
        </div>
        </div>
    </div>
</asp:Content>
