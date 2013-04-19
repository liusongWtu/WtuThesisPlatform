<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="css/base.css" />
    <link rel="stylesheet" type="text/css" href="css/index.css" />
    <script src="js/Common.js" type="text/javascript"></script>
    <script src="js/msgBox.js" type="text/javascript"></script>
    <script src="js/ajaxHelper.js" type="text/javascript"></script>
    <script type="text/javascript">
        var xhr = false; //异步对象
        var msgBox = false; //消息提示框对象
        var ajaxHelper = false; //ajax帮助对象
        var code = false; //验证码输入框
        var username = false; //用户名输入框
        var password = false;//密码框

        //当浏览器加载数据后
        window.onload = function () {
            code = gel("verification");
            username = gel("username");
            password = gel("password");

            xhr = createXhr();
            msgBox = new MsgBox();
            ajaxHelper = new AjaxHelper();
            gel("btnLogin").focus();
        };

       


        //换一张验证码
        function changeCode() {
            var code = document.getElementById("codeSpan").src = "/ashx/ValidateCode.ashx?date=" + new Date().getMilliseconds();
        }

        //检测验证码
        function checkCode() {
            //调用 ajax帮助对象，向服务器发送一个 post 请求
            //url是指的要请求的路径
            //success是服务器返回数据成功执行的方法
            ajaxHelper.doPost({ url: "/ashx/CheckValidateCode.ashx", data: "code=" + code.value, success: function (result) {
                if (result == "ok") {
                    
                } else {
                    msgBox.showMsgInfo("验证码错误");
                }
            }
            });
        }

        //登录后验证
        function CheckLogin() {
            if (trim(username.value) == "") {
                msgBox.showMsgErr("用户名不能为空！");
                return false;
            }
            if (trim(password.value) == "") {
                msgBox.showMsgErr("密码不能为空！");
                return false;
            }
            if (trim(code.value) == "") {
                msgBox.showMsgErr("验证码不能为空！");
                return false;
            }

            ajaxHelper.doPost({ url: "/ashx/LoginAjax.ashx", data: "code=" + code.value + "&username=" + username.value + "&pwd" });
        }

        
    </script>
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
                                    用户名&nbsp;|</label><input type="text" id="username" class="ui-input  textInd70" />
                            </div>
                            <p>
                                <a>忘记密码?</a></p>
                            <div class="ui-input-wap">
                                <label for="password ">
                                    密&nbsp;&nbsp;码&nbsp;|</label><input type="password" id="password" class="ui-input  textInd70" />
                            </div>
                            <p>
                                <input type="checkbox" />是否记住密码?</p>
                            <div class="ui-input-wap">
                                <label for="verification">
                                    验证码&nbsp;|</label><input type="text" id="verification" class="ui-input  textInd70"
                                        onblur="checkCode()" />
                                <img id="codeSpan" alt="验证码" title="点击换一张" onclick="changeCode()" src="ashx/ValidateCode.ashx" />
                            </div>
                            <div class="chooseid">
                                <input type="radio" name="ID" checked="checked" class="chooseidItem" value="1" />学生
                                <input type="radio" name="ID" class="chooseidItem" value="2" />教师
                                <input type="radio" name="ID" class="chooseidItem" value="3" />管理员
                            </div>
                        </div>
                        <div class="btn">
                            <span class="ui-btn-shadow btn-size">
                                <input type="button" id="btnLogin" value="登陆" onclick="CheckLogin()" class="btn-size ui-btn" />
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
</body>
</html>
