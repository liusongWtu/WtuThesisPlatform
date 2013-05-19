var UUserName;
var UName;
var UPhone;
var UEmail;
var UQQ;
var DepartmentId;
var topicList;

$(function () {
    UUserName = $(".UUserName");
    UName = $(".UName");
    UPhone = $(".UPhone");
    UEmail = $(".UEmail");
    UQQ = $(".UQQ");
    topicList = $("#topicList");
    //初始化弹出框
    $("#AdmAddNew").omDialog({
        autoOpen: false,
        height: 400,
        width: 450,
        modal: true
    });

    //添加用户
    $("#add").click(function () {
        $(".errorImg,.errorMsg").hide();
        $("#AdmAddNew").omDialog({ title: "添加用户" });
        $("#AdmAddNew").omDialog({ buttons: [
            { text: "确定", click:
                function () {
                    var error = $("span.errorImg:visible").length;
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
        $("#AdmAddNew").omDialog('open');
        //验证
        UUserName.focus();
        UUserName.blur(function () {
            checkUserNameDB(UUserName.val());
        });
        Validata();
        $("#AdmAddNew").omDialog({ onClose: function () {
            $(".errorImg,.errorMsg").hide();
            UUserName.unbind("blur");
            clear();
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
        bindCheckEvent(this);
    });


    //修改用户信息
    $(".modifyInfo").click(function () {
        //初始化
        bindModifyEvent(this);
    });


    //重置密码
    $(".resetPwd").click(function () {
        bindResetEvent(this);
    });

    //删除用户信息
    $(".deleteOne").click(function () {
        bindDeleteEvent(this);
    });
   


});
function bindCheckEvent(myThis) {
    var admId = $(myThis).parent().parent().attr("id");
    $("#AdmAddNew").omDialog({ title: "用户信息" });
    $("#AdmAddNew").omDialog({ buttons: {} });
    $(".addTable input,.addTable textarea").attr("readonly", "readonly");
    $("#AdmAddNew").omDialog('open');
    $(".errorImg,.errorMsg").hide();
    setInfo(admId, "detail");
    $("#AdmAddNew").omDialog({ onClose: function () {
        $(".errorImg,.errorMsg").hide();
        UUserName.unbind("blur");
        clear();
    }
    });
}
function bindResetEvent(myThis) {
    var admId = $(myThis).parent().parent().attr("id");
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
}
function bindDeleteEvent(myThis) {
    var $myThis = $(myThis);
    var admId = $(myThis).parent().parent().attr("id");
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
}
function bindModifyEvent(myThis) {
    $(".errorImg,.errorMsg").hide();
    var admId = $(myThis).parent().parent().attr("id");
    $("#AdmAddNew").omDialog({ title: "修改信息" });
    $("#AdmAddNew").omDialog({ buttons: [
                { text: "确定", click:
                    function () {
                        var error = $("span.errorImg:visible").length;
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
    $(".addTable input,.addTable textarea").removeAttr("readonly");
    $("#AdmAddNew").omDialog('open');
    setInfo(admId, "modify");
    Validata();
    $("#AdmAddNew").omDialog({ onClose: function () {
        $(".errorImg,.errorMsg").hide();
        UUserName.unbind("blur");
        clear();
    }
    });
}
function setInfo(admId, operate) {
    $.ajax({ url: "../../ashx/admin/AdminManager.ashx", type: "get", data: "operate=getAInfo&adminId=" + admId, async: false, success: function (data) {
        info = eval("(" + data + ")");
        UUserName.val(info.UUserName);
        UName.val(info.UName);
        UPhone.val(info.UPhone);
        UEmail.val(info.UEmail);
        UQQ.val(info.UQQ);
        if (operate == "detail") {
            return;
        }
        //验证
        UUserName.blur(function () {
            var newUserName = UUserName.val();
            if (info.UUserName != newUserName) {
                checkUserNameDB(UUserName.val());
            }

        });
        Validata();
    }
    });
}

function addNewCount() {//添加新用户
    var result = false;
    $.ajax({ type: "post",
        url: "../../ashx/admin/AdminManager.ashx",
        data: "operate=addNew&uUserName=" + UUserName.val() + "&uName=" + UName.val() + "&uPhone=" + UPhone.val() +
                "&uEmail=" + UEmail.val() + "&uQQ=" + UQQ.val(),
        async: false,
        success: function (data) {
            var jsonArr = eval("(" + data + ")");
            if (jsonArr.result == "ok") {
                result = true;
                //页面添加相应变化
                topicList.append("<tr class='list-content' id=" + jsonArr.id +
                "><td><input type='checkbox' name='topiclist' /></td><td class='first'>" + UUserName.val() +
                "</td><td>" + UName.val() +
                "</td><td>" + UPhone.val() +
                "</td><td>" + UEmail.val() +
                "</td><td><a href='#' class='checkDetail' onclick='bindCheckEvent(this)'>查看详情</a></td><td><a href='#' class='resetPwd' onclick='bindResetEvent(this)'>重置</a></td><td><a href='#' class='modifyInfo' onclick='bindModifyEvent(this)'>修改</a></td><td><a href='#' class='deleteOne' onclick='bindDeleteEvent(this)'>删除</a></td></tr>");
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
    $.ajax({ type: "post",
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
    $.ajax({ type: "post",
        url: "../../ashx/admin/AdminManager.ashx",
        data: "operate=modify&aid=" + aid + "&uUserName=" + UUserName.val() + "&uName=" + UName.val() + "&uPhone=" +
             UPhone.val() + "&uEmail=" + UEmail.val() + "&uQQ=" + UQQ.val(),
        async: false,
        success: function (data) {
            if (data == "ok") {
                $("#" + aid).children().eq(1).text(UUserName.val());
                $("#" + aid).children().eq(2).text(UName.val());
                $("#" + aid).children().eq(3).text(UPhone.val());
                $("#" + aid).children().eq(4).text(UEmail.val());
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
//清空
function clear() {
    $("#AdmAddNew input").val("");
    $("#AdmAddNew textarea").val("");
    $("#AdmAddNew select").val("");
}
