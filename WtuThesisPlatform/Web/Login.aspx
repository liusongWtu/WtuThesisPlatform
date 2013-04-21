<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="css/base.css" />
    <link rel="stylesheet" type="text/css" href="css/index.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="wrap">
        <div class="outer">
            <div class="mb30">
                <a href="#">
                    <img id="logo" alt="logo" src="images/index_logo.png" /></a></div>
            <div class="mainCl">
                <div class="bannerCl">
                </div>
                <div id="login" class="loginCl ml60">
                    <h1>
                        毕业设计选题系统</h1>
                    <fieldset>
                        <div class="item">
                            <div class="ui-input-wap">
                                <label for="username">
                                    用户名&nbsp;|</label><input type="text" id="username" value="123" class="ui-input  textInd70" />
                            </div>
                            <p>
                                <a>忘记密码?</a></p>
                            <div class="ui-input-wap">
                                <label for="password ">
                                    密&nbsp;&nbsp;码&nbsp;|</label><input type="password" id="password" value="liu" class="ui-input  textInd70" />
                            </div>
                            <p>
                                <input type="checkbox" id="isRemember" />记住我</p>
                            <div class="ui-input-wap">
                                <label for="verification">
                                    验证码&nbsp;|</label><input type="text" id="verification" class="ui-input  textInd70"
                                        onblur="checkCode()" />
                                <a>
                                    <img id="codeSpan" alt="点击刷新" title="点击刷新" src="/ashx/common/ValidateCode.ashx" /></a>
                            </div>
                            <div class="chooseid">
                                <input type="radio" name="ID" checked="checked" class="chooseidItem" value="1" />学生
                                <input type="radio" name="ID" class="chooseidItem" value="2" />教师
                                <input type="radio" name="ID" class="chooseidItem" value="3" />管理员
                            </div>
                        </div>
                        <div class="btn">
                            <span class="ui-btn-shadow btn-size">
                                <input type="button" id="btnLogin" value="登陆" class="btn-size ui-btn" />
                            </span><span class="ui-btn-shadow  ml100 btn-size">
                                <input type="button" value="重置" class="btn-size ui-btn " /></span>
                        </div>
                    </fieldset>
                </div>
            </div>
            <div class="footPos">
                <p>
                    武汉纺织大学版权所有 <font size="2" face="Verdana, Arial, Helvetica, sans-serif"><span></span>
                    </font>2010 Copyrights all reserved 鄂ICP备05003335号
                </p>
            </div>
        </div>
    </div>
    </form>
    <script src="js/Common.js" type="text/javascript"></script>
    <script src="js/msgBox.js" type="text/javascript"></script>
    <script src="js/ajaxHelper.js" type="text/javascript"></script>
    <script src="js/login.js" type="text/javascript"></script>
</body>
</html>
