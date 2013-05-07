var xhr = false; //异步对象
var msgBox = false; //消息提示框对象
var ajaxHelper = false; //ajax帮助对象
var code = false; //验证码输入框
var username = false; //用户名输入框
var password = false; //密码框
var vp = false;

//当浏览器加载数据后
window.onload = function () {
    code = gel("txtCode");
    username = gel("username");
    password = gel("password");

    xhr = createXhr();
    msgBox = new MsgBox();
    ajaxHelper = new AjaxHelper();
    gel("btnLogin").focus();
    bindEvent("codeSpan", "onclick", "changeCode()");
    bindEvent("btnLogin", "onclick", "checkLogin()");
};

//换一张验证码
function changeCode() {
    var codeV = document.getElementById("codeSpan").src = "/ashx/common/ValidateCode.ashx?date=" + new Date().getMilliseconds();
}

//检测验证码
function checkCode() {
    if (trim(code.value) == "") {
        return;
    }
    //调用 ajax帮助对象，向服务器发送一个 post 请求
    //url是指的要请求的路径
    //success是服务器返回数据成功执行的方法
    ajaxHelper.doPost({ url: "/ashx/common/CheckValidateCode.ashx", data: "code=" + code.value, success: function (result) {
        if (result == "ok") {
            $(".verification-msg").css("background", "url(../images/right.gif)");
        } else {
            $(".verification-msg").css("background", "url(../images/wrong.png)");
            changeCode();
            code.select();
        }
    }
    });
}

//登录后验证
function checkLogin() {
    if (trim(username.value) == "") {
        msgBox.showMsgErr("用户名不能为空！");
        username.select();
    }
    else if (trim(password.value) == "") {
        msgBox.showMsgErr("密码不能为空！");
        password.select();
    }
    else if (trim(code.value) == "") {
        msgBox.showMsgErr("验证码不能为空！");
        code.select();
    } else {
        ajaxHelper.doPost({ url: "/ashx/common/LoginAjax.ashx",
            data: "code=" + code.value + "&type=" + getRadioValue("ID") + "&username=" + username.value + "&pwd=" + password.value + "&isremember=" + (gel("isRemember").checked ? "1" : "0"),
            success: function (result) {
                requestBack(result);
            }
        });
    }
}

//回传消息响应
function requestBack(result) {
    if (result == "codeEmpty") {
        msgBox.showMsgErr("验证码不能为空！");
        changeCode();
        code.select();
    } else if (result == "codeError") {
        msgBox.showMsgErr("验证码错误！");
        changeCode();
        code.value = "";
        code.select();
    } else if (result == "userError") {
        msgBox.showMsgErr("用户名错误！");
        changeCode();
        username.select();
    } else if (result == "pwdError") {
        msgBox.showMsgErr("密码错误！");
        changeCode();
        password.select();
    } else if (result == "del") {
        msgBox.showMsgErr("此用户已被冻结！");
        changeCode();
        username.select();
    } else if (result == "typeError") {
        msgBox.showMsgErr("非法用户！");
        changeCode();
        username.select();
    } else {
        msgBox.showMsgOk("登录成功!正在跳转...");
        var currType = getRadioValue("ID");
        if (currType == "1") {
            window.location.assign("/StudentUI/StuIndex.aspx?nodeId=1000");
        } else if (currType == "2") {
            window.location.assign("/TeacherUI/TeacherIndex.aspx?nodeId=2000");
        } else if (currType == "3") {
            window.location.assign("/AdminUI/AdminInfo.aspx?nodeId=3001");
        } else {
            msgBox.showMsgErr("用户类型错误");
        }
    }
}
