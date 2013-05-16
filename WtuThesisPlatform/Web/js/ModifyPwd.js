
$(function () {
    var oldPwd = $("#oldPassword"); //原始密码
    var newPwd = $("#newPassword"); //新密码
    var repeatPwd = $("#repeatNewPsw"); //重复输入的新密码
    newPwd.focus(function () {
        // console.log(oldPwd.val());
        if ("" == oldPwd.val()) {
            oldPwd.parent().next().text("您还没有输入原始密码!");
        }

    });
    oldPwd.change(function () {
        oldPwd.parent().next().text("");
    })
    repeatPwd.focus(function () {
        //console.log(oldPwd.val());
        if ("" == oldPwd.val() && oldPwd.next() == null) {
            oldPwd.parent().next().text("您还没有输入原始密码!");
        }
        if ("" == newPwd.val()) {
            newPwd.parent().next().text("您还没有输入新密码!");
        }
    });
    repeatPwd.blur(function () {
        if (newPwd.val() != repeatPwd.val()) {
            repeatPwd.parent().next().text("您输入的密码与新密码不一致！");
        }
    })
    oldPwd.keydown(function () {
        oldPwd.parent().next().text("");
    })
    repeatPwd.keydown(function () {
        repeatPwd.parent().next().text("");
    })
    newPwd.keydown(function () {
        newPwd.parent().next().text("");
    })
    /**********修改密码**********/
    $("#psd-modify-ok").click(function () {
        //修改密码
        if ("" == oldPwd.val()) {
            oldPwd.parent().next().text("您还没有输入原始密码!");
        }
        else if ("" == newPwd.val()) {
            newPwd.parent().next().text("您还没有输入新密码!");
        }
        else if ("" == repeatPwd.val()) {
            repeatPwd.parent().next().text("您还重复输入新密码!");
        }
        else if (newPwd.val() != repeatPwd.val()) {
            repeatPwd.parent().next().text("您输入的密码与新密码不一致！");
        }
        else {
            var type = $("#userType").val();
            var md5PwdNew = $.md5($("#newPassword").val());
            var md5PwdOld = $.md5($("#oldPassword").val());
            $.post("../../ashx/common/ChangePwd.ashx", { "type": type, "oldPwd": md5PwdOld, "newPwd": md5PwdNew }, function (data) {
                if (data == "ok") {
                    $.omMessageTip.show({ content: '密码修改成功！', timeout: 1000, type: 'success' });
                } else {
                    $.omMessageTip.show({ content: '密码修改失败！', timeout: 1000, type: 'error' });
                }
            });
        }
        repeatPwd.change(function () {
            repeatPwd.parent().next().text("");
        })

        return false;
    });
    //点击取消，返回到个人基本信息页面
    $("#psd-modify-no").click(function () {
        oldPwd.val("");
        newPwd.val("");
        repeatPwd.val("");
        return false;
    })

    //验证密码
    oldPwd.blur(function () {
        var type = $("#userType").val();
        var md5Pwd = $.md5(oldPwd.val()); //计算密码的md5值
        if (oldPwd.val() != "") {
            $.post("../../ashx/common/checkPwd.ashx", { "type": type, "oldPwd": md5Pwd }, function (data) {
                if (data == "ok") {
                    oldPwd.parent().next().text("");
                } else {
                    oldPwd.parent().next().text("密码错误");
                }
            });
        }

    });
})
