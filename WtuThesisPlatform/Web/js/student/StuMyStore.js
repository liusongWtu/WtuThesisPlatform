﻿$(function () {
    //删除收藏
    $(".delete-icon").click(function () {
        var $myThis = $(this);
        $.omMessageBox.confirm({
            title: '确认删除？',
            content: '确定要删除该收藏？',
            onClose: function (v) {
                if (v) {
                    $.post("../../ashx/student/StoreManager.ashx", { "thesisId": $myThis.parent().parent().attr("id"), "operate": "del" }, function (data) {
                        if (data == "ok") {
                            $myThis.parent().parent().remove(); //移除节点
                            $.omMessageTip.show({ content: '已删除对该选题的收藏！', timeout: 1000, type: 'alert' });
                        } else {
                            return false;
                        }
                    });
                }
            }
        });
    });
    //选题
    $(".select-icon").click(function () {
        var $myThis = $(this);
        $.omMessageBox.confirm({
            title: '确认选题？',
            content: '确定要选择该题？',
            onClose: function (v) {
                if (v) {
                    $.post("../../ashx/student/SelectedManager.ashx", { "thesisId": $myThis.parent().parent().attr("id"), "operate": "add" }, function (data) {
                        if (data == "ok") {
                            $myThis.parent().parent().remove(); //移除节点
                            $.omMessageTip.show({ content: '已选择该题！', timeout: 1000, type: 'alert' });
                        } else {
                            return false;
                        }
                    });
                }
            }
        });

    })
});