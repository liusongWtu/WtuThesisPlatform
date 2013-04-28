﻿
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
    newPwd.change(function () {
        newPwd.parent().next().text("");
    })
    /**********修改密码**********/
    $("#psd-modify-ok").click(function () {
        //修改密码
        if (newPwd.val() == repeatPwd.val()) {
            if (modifyPwd()) {//修改密码成功
                $.omMessageTip.show({ content: '密码修改成功！', timeout: 1000, type: 'success' });
            }
        }

        else{
            repeatPwd.parent().next().text("您输入的密码与新密码不一致！");
        }
        repeatPwd.change(function () {
            repeatPwd.parent().next().text("");
        })

        return false;
    });
    //点击取消，返回到个人基本信息页面
    $("#psd-modify-no").click(function () {
        self.location = "StuInfo.aspx";
        return false;
    })
})

function modifyPwd(){//修改数据库密码
    return true;
}