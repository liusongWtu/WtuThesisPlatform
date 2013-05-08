﻿var TUserName;
var TPassword;
var TName;
var TPhone;
var TEmail;
var TQQ;
var TZhiCheng;
var TTeachNum;
var TTeachCourse;
var TResearchFields;

$(function () {
    $("#addNew").omDialog({
        autoOpen: false,
        height: 400,
        width: 550,
        modal: true
    });


    $("#add").click(function () {//添加
        $("#addNew").omDialog({ buttons: [
        { text: "确定", click:
            function () {
                if (addNewCount()) { //添加新用户成功
                    //关闭窗口
                    $("#addNew").omDialog('close');
                    $.omMessageTip.show({ content: '添加成功！', timeout: 1000, type: 'success' });
                }
                else {
                    $.omMessageTip.show({ content: '添加失败！', timeout: 1000, type: 'error' });
                }
            }
        },
        { text: "继续添加", click:
            function () {
                if (addNewCount()) {//添加成功
                    $.omMessageTip.show({ content: '添加成功！', timeout: 1000, type: 'success' });
                    $("#addNew input").val("");
                    $("#addNew textarea").val("");
                }
            }
        },
        { text: "取消", click:
            function () {
                $("#addNew").omDialog('close');
            }
        },
         ]
        });

        $("#addNew").omDialog('open');
    });
    $("#delete").click(function () {//批量删除
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
                            if (deleteCount($(this))) {//数据库删除成功
                                $(this).parent().parent().remove();
                            }
                        })
                    }
                }
            });
        }
    })
    $(".checkDetail").click(function () { //查看详情
        $("#addNew").omDialog({ title: "用户信息" });
        $("#addNew").omDialog({ buttons: {} });
        $("#addNew").omDialog('open');
        $(".addTable input,.addTable textarea").attr("readonly", "readonly").addClass("borderNone");
        $('.addTable select').attr("disabled", "disabled");
        //给各项赋值

    })
    $(".modifyInfo").click(function () { //修改信息
        $("#addNew").omDialog({ title: "修改信息" });
        $("#addNew").omDialog({ buttons: {} });
        $("#addNew").omDialog('open');
        $(".addTable input,.addTable textarea").removeAttr("readonly").removeClass("borderNone");
        $('.addTable select').removeAttr("disabled");
        //显示原信息
        //更新信息
    })
    $(".deleteOne").click(function () {//删除信息
        var $myThis = $(this);
        $.omMessageBox.confirm({
            title: '确认删除？',
            content: '确定要删除该用户信息？',
            onClose: function (value) {
                if (value) {
                    if (deleteCount()) {//删除信息成功
                        $myThis.parent().parent().remove();
                        $.omMessageTip.show({ content: '删除成功！', timeout: 1000, type: 'success' });
                    }
                    else {
                        $.omMessageTip.show({ content: '删除失败！', timeout: 1000, type: 'error' });
                    }
                }
            }
        });
    })
});

function getInfo() {
    var info = { 'TUserName': TUserName.val(), 'TPassword': TPassword.val(), 'TName': TName.val(), 'TPhone': TPhone.val(), 'TEmail': TEmail.val(), 'TQQ': TQQ.val(), 'TZhiCheng': TZhiCheng.val(), 'TTeachNum': TTeachNum.val(), 'TTeachCourse': TTeachCourse.val(), 'TResearchFields': TResearchFields.val() };
    return info;
}

function addNewCount() {//添加新用户
    return true;
}
function deleteCount() {//删除用户
    return true;
}