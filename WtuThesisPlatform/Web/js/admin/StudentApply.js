﻿$(function () {
    $(".checkYes").click(function () {
        var myThis = $(this);
        var tid = $(".checkId").attr("id");
        $.omMessageBox.confirm({
            title: '确认审核？',
            content: '您确定通过审核？',
            onClose: function (value) {
                if (value) {
                    $.post("", { "operate": "pass", "tid": tid }, function (data) {
                        if (data == "ok") {
                            myThis.text("取消");
                            if ($(".tea-status")) {
                                $(".tea-status").text("审核通过");
                            }
                            if ($(".backLink")) {
                                $(".backLink").html("审核不通过");
                            }
                            // myThis.parent().parent().prev().text("通过");
                            $.omMessageTip.show({ content: '操作成功！', timeout: 1000, type: 'success' });
                        }
                        else {
                            $.omMessageTip.show({ content: '操作失败！', timeout: 1000, type: 'error' });
                        }
                    })
                }

            }
        });
    });

    $(".checkNo").click(function () {
        var myThis = $(this);
        var tid = $(".checkId").attr("id");
        $.omMessageBox.confirm({
            title: '确认审核？',
            content: '您确定不通过审核？',
            onClose: function (value) {
                if (value) {
                    $.post("", { "operate": "nopass", "tid": tid }, function (data) {
                        if (data == "ok") {
                            myThis.text("取消");
                            if ($(".tea-status")) {
                                $(".tea-status").text("审核不通过");
                            }
                            if ($(".backLink")) {
                                $(".backLink").html("审核不通过");
                            }
                            //myThis.parent().parent().prev().text("不通过");
                            $.omMessageTip.show({ content: '操作成功！', timeout: 1000, type: 'success' });
                        }
                        else {
                            $.omMessageTip.show({ content: '操作失败！', timeout: 1000, type: 'error' });
                        }

                    })
                }
            }
        });
    })
})