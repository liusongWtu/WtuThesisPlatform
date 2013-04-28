﻿<%@ Page Title="" Language="C#" MasterPageFile="~/StudentUI/StudentMasterPage.Master"
    AutoEventWireup="true" CodeBehind="StuSelect.aspx.cs" Inherits="Web.StudentUI.StuSelect" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../css/student/stu_select.css" />
    <link rel="stylesheet" type="text/css" href="../css/student/stu_page.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <div class="select-list">
        <div class="content-top">
            <div class="search fl fillet">
                <label class="ablt">
                    关键字...</label>
                <input type="text" class="search-input" />
                <button id="searchButton" class="search-button abrt">
                    <span>搜索</span></button>
            </div>
            <!--<div class="top-change-page fr">
								<span id="topPageUp" class="top-page-up top-page"></span>
								<strong><span id="currentPage" class="current-page">123</span>\<span id="totalPage" class="total-page">1000</span></strong>
								<span id="topPageDown" class="top-page-down top-page"></span>
							</div>-->
            <!--<table>
								<tr>
									<td id="topPageUp"></td>
									<td></td>
									<td id="topPageDown"></td>
								</tr>
							</table>-->
        </div>
        <div class="content-center">
            <!-- <table id="grid"></table>-->
            <table id="topicList" class="topic-list" cellspacing="0" cellpadding="0">
                <tr class="list-header">
                    <td class="td0">
                        &nbsp;
                    </td>
                    <td class="td1">
                        选题名称
                    </td>
                    <td class="td2">
                        允许人数
                    </td>
                    <td class="td3">
                        已选人数
                    </td>
                    <td class="td4">
                        剩余人数
                    </td>
                    <td class="td5">
                        教师
                    </td>
                    <td class="td6">
                        收藏
                    </td>
                    <td class="td7">
                        选题
                    </td>
                </tr>
                <tr class="list-content">
                    <td class="td0">
                        <input type="checkbox" name="topiclist" />
                    </td>
                    <td class="td1">
                        <a href="#">毕业设计选题系统</a>
                    </td>
                    <td class="td2">
                        6
                    </td>
                    <td class="td3">
                        4
                    </td>
                    <td class="td4">
                        3
                    </td>
                    <td class="td5 teacher">
                        <a href="#">何儒汉</a>
                    </td>
                    <td class="td6">
                        <span class="store-icon list-icon"></span>
                    </td>
                    <td class="td7">
                        <span class="select-icon list-icon"></span>
                    </td>
                </tr>
                <tr class="list-content">
                    <td class="td0">
                        <input type="checkbox" name="topiclist" />
                    </td>
                    <td class="td1">
                        <a href="#">毕业设计选题系统</a>
                    </td>
                    <td class="td2">
                        6
                    </td>
                    <td class="td3">
                        4
                    </td>
                    <td class="td4">
                        3
                    </td>
                    <td class="td5 teacher">
                        <a href="#">何儒汉</a>
                    </td>
                    <td class="td6">
                        <span class="store-icon list-icon"></span>
                    </td>
                    <td class="td7">
                        <span class="select-icon list-icon"></span>
                    </td>
                </tr>
                <tr class="list-content">
                    <td class="td0">
                        <input type="checkbox" name="topiclist" />
                    </td>
                    <td class="td1">
                        <a href="#">毕业设计选题系统</a>
                    </td>
                    <td class="td2">
                        6
                    </td>
                    <td class="td3">
                        4
                    </td>
                    <td class="td4 ">
                        3
                    </td>
                    <td class="td5 teacher">
                        <a href="#">何儒汉</a>
                    </td>
                    <td class="td6">
                        <span class="store-icon list-icon"></span>
                    </td>
                    <td class="td7">
                        <span class="select-icon list-icon"></span>
                    </td>
                </tr>
                <tr class="list-content">
                    <td class="td0">
                        <input type="checkbox" name="topiclist" />
                    </td>
                    <td class="td1">
                        <a href="#">毕业设计选题系统</a>
                    </td>
                    <td class="td2">
                        6
                    </td>
                    <td class="td3">
                        4
                    </td>
                    <td class="td4">
                        3
                    </td>
                    <td class="td5 teacher">
                        <a href="#">何儒汉</a>
                    </td>
                    <td class="td6">
                        <span class="store-icon list-icon"></span>
                    </td>
                    <td class="td7">
                        <span class="select-icon list-icon"></span>
                    </td>
                </tr>
                <tr class="list-content">
                    <td class="td0">
                        <input type="checkbox" name="topiclist" />
                    </td>
                    <td class="td1">
                        <a href="#">毕业设计选题系统</a>
                    </td>
                    <td class="td2">
                        6
                    </td>
                    <td class="td3">
                        4
                    </td>
                    <td class="td4">
                        3
                    </td>
                    <td class="td5 teacher">
                        <a href="#">何儒汉</a>
                    </td>
                    <td class="td6">
                        <span class="store-icon list-icon"></span>
                    </td>
                    <td class="td7">
                        <span class="select-icon list-icon"></span>
                    </td>
                </tr>
                <tr class="list-content">
                    <td class="td0">
                        <input type="checkbox" name="topiclist" />
                    </td>
                    <td class="td1">
                        <a href="#">毕业设计选题系统</a>
                    </td>
                    <td class="td2">
                        6
                    </td>
                    <td class="td3">
                        4
                    </td>
                    <td class="td4">
                        3
                    </td>
                    <td class="td5 teacher">
                        <a href="#">何儒汉</a>
                    </td>
                    <td class="td6">
                        <span class="store-icon list-icon"></span>
                    </td>
                    <td class="td7">
                        <span class="select-icon list-icon"></span>
                    </td>
                </tr>
                <tr class="list-content">
                    <td class="td0">
                        <input type="checkbox" name="topiclist" />
                    </td>
                    <td class="td1">
                        <a href="#">毕业设计选题系统</a>
                    </td>
                    <td class="td2">
                        6
                    </td>
                    <td class="td3">
                        4
                    </td>
                    <td class="td4">
                        3
                    </td>
                    <td class="td5 teacher">
                        <a href="#">何儒汉</a>
                    </td>
                    <td class="td6">
                        <span class="store-icon list-icon"></span>
                    </td>
                    <td class="td7">
                        <span class="select-icon list-icon"></span>
                    </td>
                </tr>
                <tr class="list-content">
                    <td class="td0">
                        <input type="checkbox" name="topiclist" />
                    </td>
                    <td class="td1">
                        <a href="#">毕业设计选题系统</a>
                    </td>
                    <td class="td2">
                        6
                    </td>
                    <td class="td3">
                        4
                    </td>
                    <td class="td4">
                        3
                    </td>
                    <td class="td5 teacher">
                        <a href="#">何儒汉</a>
                    </td>
                    <td class="td6">
                        <span class="store-icon list-icon"></span>
                    </td>
                    <td class="td7">
                        <span class="select-icon list-icon"></span>
                    </td>
                </tr>
                <tr class="list-content">
                    <td class="td0">
                        <input type="checkbox" name="topiclist" />
                    </td>
                    <td class="td1">
                        <a href="#">毕业设计选题系统</a>
                    </td>
                    <td class="td2">
                        6
                    </td>
                    <td class="td3">
                        4
                    </td>
                    <td class="td4">
                        3
                    </td>
                    <td class="td5 teacher">
                        <a href="#">何儒汉</a>
                    </td>
                    <td class="td6">
                        <span class="store-icon list-icon"></span>
                    </td>
                    <td class="td7">
                        <span class="select-icon list-icon"></span>
                    </td>
                </tr>
                <tr class="list-content">
                    <td class="td0">
                        <input type="checkbox" name="topiclist" />
                    </td>
                    <td class="td1">
                        <a href="#">毕业设计选题系统</a>
                    </td>
                    <td class="td2">
                        6
                    </td>
                    <td class="td3">
                        4
                    </td>
                    <td class="td4">
                        3
                    </td>
                    <td class="td5 teacher">
                        <a href="#">何儒汉</a>
                    </td>
                    <td class="td6">
                        <span class="store-icon list-icon"></span>
                    </td>
                    <td class="td7">
                        <span class="select-icon list-icon"></span>
                    </td>
                </tr>
                <tr class="list-content">
                    <td class="td0">
                        <input type="checkbox" name="topiclist" />
                    </td>
                    <td class="td1">
                        <a href="#">毕业设计选题系统</a>
                    </td>
                    <td class="td2">
                        6
                    </td>
                    <td class="td3">
                        4
                    </td>
                    <td class="td4">
                        3
                    </td>
                    <td class="td5 teacher">
                        <a href="#">何儒汉</a>
                    </td>
                    <td class="td6">
                        <span class="store-icon list-icon"></span>
                    </td>
                    <td class="td7">
                        <span class="select-icon list-icon"></span>
                    </td>
                </tr>
                <tr class="list-content">
                    <td class="td0">
                        <input type="checkbox" name="topiclist" />
                    </td>
                    <td class="td1">
                        <a href="#">毕业设计选题系统</a>
                    </td>
                    <td class="td2">
                        6
                    </td>
                    <td class="td3">
                        4
                    </td>
                    <td class="td4">
                        3
                    </td>
                    <td class="td5 teacher">
                        <a href="#">何儒汉</a>
                    </td>
                    <td class="td6">
                        <span class="store-icon list-icon"></span>
                    </td>
                    <td class="td7">
                        <span class="select-icon list-icon"></span>
                    </td>
                </tr>
                <tr class="list-content">
                    <td class="td0">
                        <input type="checkbox" name="topiclist" />
                    </td>
                    <td class="td1">
                        <a href="#">毕业设计选题系统</a>
                    </td>
                    <td class="td2">
                        6
                    </td>
                    <td class="td3">
                        4
                    </td>
                    <td class="td4">
                        3
                    </td>
                    <td class="td5 teacher">
                        <a href="#">何儒汉</a>
                    </td>
                    <td class="td6">
                        <span class="store-icon list-icon"></span>
                    </td>
                    <td class="td7">
                        <span class="select-icon list-icon"></span>
                    </td>
                </tr>
            </table>
        </div>
        <div class="content-bottom">
            <ul class="operate">
                <li>
                    <input type="checkbox" name="checkall" id="checkAll" />&nbsp;全选</li>
                <li>|</li>
                <li><a href="#" id="clickToStore">一键收藏</a></li>
            </ul>
            <table class="pagechange">
                <tr>
                    <td class="page-up" title="上一页">
                        <span></span>
                    </td>
                    <td>
                        <a href="#">1</a>
                    </td>
                    <td>
                        <a href="#">2</a>
                    </td>
                    <td>
                        <a href="#">3</a>
                    </td>
                    <td>
                        <a href="#">4</a>
                    </td>
                    <td>
                        <a href="#">5</a>
                    </td>
                    <td>
                        <a href="#">6</a>
                    </td>
                    <td class="page-down" title="下一页">
                        <span></span>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
