var UUserName;
var UName;
var UPhone;
var UEmail;
var UQQ;
var DepartmentId;


$(function () {
    UUserName = $(".UUserName");
    UName = $(".UName");
    UPhone = $(".UPhone");
    UEmail = $(".UEmail");
    UQQ = $(".UQQ");
    //初始化弹出框
    $("#AdmAddNew").omDialog({
        autoOpen: false,
        height: 400,
        width: 450,
        modal: true
    });

    //添加用户
    $("#add").click(function () {
        $("#AdmAddNew").omDialog({ title: "添加用户" });
        $("#AdmAddNew").omDialog('open');
        $("#AdmAddNew").omDialog({ buttons: [
            { text: "确定", click:
                function () {
                    var error = $("span.errorImg:visible").length;
                    //alert(error);
                    if (error != 0) {
                        return;
                    } else {
                        if (addNewCount()) { //添加新用户成功

                            $("#AdmAddNew").omDialog('close');
                            $.omMessageTip.show({ content: '添加成功！', timeout: 1000, type: 'success' });
                        }
                        else {
                            $.omMessageTip.show({ content: '添加失败！', timeout: 1000, type: 'error' });
                        }
                    }

                }
            },
            { text: "继续添加", click:
                function () {
                    var error = $("span.errorImg:visible").length;
                    //alert(error);
                    if (error != 0) {
                        return;
                    } else {
                        if (addNewCount()) {//添加成功
                            $.omMessageTip.show({ content: '添加成功！', timeout: 1000, type: 'success' });
                            $("#AdmAddNew input").val("");
                            $("#AdmAddNew textarea").val("");
                        }
                    }
                }
            },
            { text: "取消", click:
                function () {
                    $("#AdmAddNew").omDialog('close');
                }
            }
         ]
        });
        $(".addTable input,.addTable textarea").removeAttr("readonly");
        //验证
        //$("#AdmAddNew").attr("tabindex", 0);
        //$("#AdmAddNew").focus(); //不让输入框一开始就获得焦点
        UUserName.blur(function () {
            checkUserNameDB(UUserName.val());
        });
        Validata();
        //管理员登录名是否需要验证？？？？
        /*UPhone.blur(function () {//电话号码验证
        checkPhone();
        })
        UEmail.blur(function () {//email验证
        checkEmail();
        })
        UQQ.blur(function () {//QQ验证
        checkQQ();
        })*/
        $("#AdmAddNew").omDialog({ onClose: function () {
            clear();
            UUserName.unbind("blur");
            $(".errorImg,.errorMsg").hide();
        }
        });

    });

    //批量删除用户信息
    $("#delete").click(function () {
        var $checked = $("input[name='topiclist']:checked");
        if ($checked.length == 0) {
            $.omMessageTip.show({ content: '您还没有选择要删除的信息！', timeout: 1000, type: 'warning' });
        }
        else {
            $.omMessageBox.confirm({
                title: '确认删除？',
                content: '确定要将所选项删除？',
                onClose: function (value) {
                    if (value) {
                        $checked.each(function () {
                            if (deleteCount($(this).parent().parent().attr("id"))) {//数据库删除成功
                                $(this).parent().parent().remove();
                            }
                        })
                        $.omMessageTip.show({ content: '删除成功！', timeout: 1000, type: 'success' });
                    }
                }
            });
        }
    });


    //查看用户详情
    $(".checkDetail").click(function () {
        var admId = $(this).parent().parent().attr("id");
        $("#AdmAddNew").omDialog({ title: "用户信息" });
        $("#AdmAddNew").omDialog({ buttons: {} });
        $("#AdmAddNew").omDialog('open');
        setInfo(admId, "detail");
        $(".addTable input,.addTable textarea").attr("readonly", "readonly");
        $("#AdmAddNew").omDialog({ onBeforeClose: function () {
            clear();
            UUserName.unbind("blur");
            $(".errorImg,.errorMsg").hide();
        } 
        });
    });


    //修改用户信息
    $(".modifyInfo").click(function () {
        //初始化
        var admId = $(this).parent().parent().attr("id");
        $("#AdmAddNew").omDialog({ title: "修改信息" });
        $("#AdmAddNew").omDialog({ buttons: [
                { text: "确定", click:
                    function () {
                        var error = $("span.errorImg:visible").length;
                        //alert(error);
                        if (error != 0) {
                            return;
                        } else {
                            if (modifyCount(admId)) { //修改成功
                                //关闭窗口
                                $("#AdmAddNew").omDialog('close');
                                $.omMessageTip.show({ content: '修改成功！', timeout: 1000, type: 'success' });
                            }
                            else {
                                $.omMessageTip.show({ content: '修改失败！', timeout: 1000, type: 'error' });
                            }
                        }

                    }
                },

                { text: "取消", click:
                    function () {
                        $("#AdmAddNew").omDialog('close');
                    }
                }
            ]
        });
        $("#AdmAddNew").omDialog('open');
        setInfo(admId, "modify");
        $(".addTable input,.addTable textarea").removeAttr("readonly");
        $("#AdmAddNew").omDialog({ onBeforeClose: function () {
            clear();
            UUserName.unbind("blur");
            $(".errorImg,.errorMsg").hide();
        }
        });
    });


    //重置密码
    $(".resetPwd").click(function () {
        var admId = $(this).parent().parent().attr("id");
        $.omMessageBox.confirm({
            title: '密码重置？',
            content: '确定要重置该用户密码？',
            onClose: function (value) {
                if (value) {
                    $.post("../../ashx/admin/AdminManager.ashx", { "operate": "resetPwd", "aid": admId }, function (data) {
                        if (data == "ok") {
                            $.omMessageTip.show({ content: '重置成功！', timeout: 1000, type: 'success' });
                        } else {
                            $.omMessageTip.show({ content: '重置失败！', timeout: 1000, type: 'error' });
                        }
                    });
                }
            }
        });
    });

    //删除用户信息
    $(".deleteOne").click(function () {
        var $myThis = $(this);
        var admId = $(this).parent().parent().attr("id");
        $.omMessageBox.confirm({
            title: '确认删除？',
            content: '确定要删除该用户信息？',
            onClose: function (value) {
                if (value) {
                    if (deleteCount(admId)) {//删除信息成功
                        $myThis.parent().parent().remove();
                        $.omMessageTip.show({ content: '删除成功！', timeout: 1000, type: 'success' });
                    }
                    else {
                        $.omMessageTip.show({ content: '删除失败！', timeout: 1000, type: 'error' });
                    }
                }
            }
        });
    });

});

//function getInfo() {
    //var info = { 'UUserName': UUserName.val(), 'UName': UName.val(), 'UPhone': UPhone.val(), 'UEmail': UEmail.val(), 'UQQ': UQQ.val()};
    //return info;
//}


function setInfo(admId, operate) {
    $.ajax({url:"../../ashx/admin/AdminManager.ashx",type:"get",data: "operate=getAInfo&adminId="+ admId ,async:false,success: function (data) {
        info = eval("(" + data + ")");
        UUserName.val(info.UUserName);
        UName.val(info.UName);
        UPhone.val(info.UPhone);
        UEmail.val(info.UEmail);
        UQQ.val(info.UQQ);
        console.log(info.UQQ);
        if (operate == "detail") {
            return;
        }
        //验证
        //var oldInfo = getInfo();
        //$("#AdmAddNew").attr("tabindex", 0);
        //$("#AdmAddNew").focus();
        UUserName.blur(function () {
            var newUserName = UUserName.val();
            if (info.UUserName != newUserName) {
                checkUserNameDB(UUserName.val());
            }

        });
        Validata();
        /*UPhone.blur(function () {
        var newPhone = UPhone.val();
        if (info.UPhone != newPhone) {
        checkPhone();
        }
        });
        UEmail.blur(function () {
        var newEmail = UEmail.val();
        if (info.UEmail != newEmail) {
        checkEmail();
        }
        });
        UQQ.blur(function () {
        var newQQ = UQQ.val();
        if (info.UQQ != newQQ) {
        checkQQ();
        }

        });*/
    }
    });
}

function addNewCount() {//添加新用户
    var result = false;
    $.ajax({ data: "post",
        url: "../../ashx/admin/AdminManager.ashx",
        data: "operate=addNew&uUserName=" + UUserName.val() + "&uName=" + UName.val() + "&uPhone=" + UPhone.val() +
                "&uEmail=" + UEmail.val() + "&uQQ=" + UQQ.val(),
        async: false,
        success: function (data) {
            if (data == "ok") {
                result = true;
            } else {
                result = false;
            }
        }
    });
    return result;
}

//删除用户
function deleteCount(aid) {
    var result = false;
    $.ajax({ data: "post",
        url: "../../ashx/admin/AdminManager.ashx",
        data: "operate=del&aid=" + aid,
        async: false,
        success: function (data) {
            if (data == "ok") {
                result = true;
            } else {
                result = false;
            }
        }
    });
    return result;
}


//修改用户
function modifyCount(aid) {
    var result = false;
    $.ajax({ data: "post",
        url: "../../ashx/admin/AdminManager.ashx",
        data: "operate=modify&aid=" + aid + "&uUserName=" + UUserName.val() + "&uName=" + UName.val() + "&uPhone=" +
             UPhone.val() + "&uEmail=" + UEmail.val() + "&uQQ=" + UQQ.val(),
        async: false,
        success: function (data) {
            if (data == "ok") {
                result = true;
            } else {
                result = false;
            }
        }
    });

    return result;
}

//验证登录名是否存在
function checkUserNameDB(username) {
    $.get("../../ashx/admin/AdminManager.ashx", { "operate": "checkUUserName", "UUserName": username }, function (data) {
        if (data == "ok") {

        } else {
            UUserName.parent().next().children("span.errorImg").css("display", "block");
            UUserName.parent().next().children("span.errorMsg").text("您输入的登录名已存在");
            return;
        }
    });
}
/*function checkPhone() {
    var phoneValidata = validatePhone(UPhone.get(0), $("#UPhoneError").get(0));
    if (!phoneValidata) {
        $.omMessageBox.confirm({
            title: '提示',
            content: '请输入正确的电话号码！',
            onClose: function (v) {

            }
        });
    }
}

function checkEmail() {//email验证
    var emailValidata = validateEmail(UEmail.get(0), $("#UEmailError").get(0));
    if (!emailValidata) {
        $.omMessageBox.confirm({
            title: '提示',
            content: '请输入正确的邮箱格式！',
            onClose: function (v) {

            }
        });
    }
}

function checkQQ() {
    var qqValidata = validateQQ(UQQ.get(0), $("#UQQError").get(0));
    if (!qqValidata) {
        $.omMessageBox.confirm({
            title: '提示',
            content: '请输入正确的QQ格式！',
            onClose: function (v) {

            }
        });
    }
}

//留着给管理员的登录名备用
/*function checkTNo() {
var numFieldValidata = validataNumField(TNo.get(0), $("#TNoError").get(0));
if (!numFieldValidata) {
$.omMessageBox.confirm({
title: '提示',
content: '请输入1~20位数字串！',
onClose: function (v) {

}
});
}
checkTNoDB(TNo.val());
}
*/
//清空
function clear() {
    $("#AdmAddNew input").val("");
    $("#AdmAddNew textarea").val("");
    $("#AdmAddNew select").val("");
}
