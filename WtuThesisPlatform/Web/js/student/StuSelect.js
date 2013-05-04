﻿$(function () {
    /**********输入框效果**********/
    $(".search-input").click(function () {
        $(this).parent().children("label").hide();
    }).blur(function () {
        if ($(this).val() == "") {
            $(this).parent().children("label").show();
        }
    });

    /**********收藏以及选题效果**********/
    $(".store-icon").click(function (e) {
        if ($(this).hasClass("store-icon-actived")) {//已经收藏了选题，此时再点击表示取消收藏
            if (deldetStore($(this).parent().attr("id"))) {//取消收藏成功
                $(this).removeClass("store-icon-actived");
                $.omMessageTip.show({ content: '已取消收藏！', timeout: 1000, type: 'success' });
            }
        }
        else {//还没有收藏，点击收藏
            if (storeTopic($(this).parent().attr("id"))) {//如果选题收藏成功
                $(this).addClass("store-icon-actived");
                e.stopPropagation();
                $.omMessageTip.show({ content: '已收藏该选题！', timeout: 1000, type: 'success' });
            }
        }

    })
    $(".select-icon").click(function (e) {
        if ($(this).hasClass("select-icon-actived")) {//已经选择了该题，此时再点击表示取消选题
            if (deleteSelect($(this).parent().attr("id"))) {//取消选题成功
                $(this).removeClass("select-icon-actived");
                $.omMessageTip.show({ content: '已取消选题！', timeout: 1000, type: 'success' });
            }
        }
        else {//还没选题，点击选题
            if (selectTopic($(this).parent().attr("id"))) {//如果选题选择成功
                $(this).addClass("select-icon-actived");
                e.stopPropagation();
                $.omMessageTip.show({ content: '已选择该选题！', timeout: 1000, type: 'success' });
            }
        }
        

    });
    /**********全选**********/
    $("#checkAll").click(function () {
        $("input[name='topiclist']").attr("checked", $(this).attr("checked"));
    });

    /**********一键收藏**********/
    $("#clickToStore").click(function () {
        var $checked = $("input[name='topiclist']:checked");
        if ($checked.length == 0) {
            $.omMessageTip.show({ content: '您还没有选择选题！', timeout: 1000, type: 'warning' });
        }
        else {
            $.omMessageBox.confirm({
                title: '确认收藏？',
                content: '确定要将所选项收藏？',
                onClose: function (value) {
                    if (value) {
                        var flag = false;
                        $checked.each(function () {
                            var $span = $(this).parent().siblings("td").children(".store-icon");
                            storeTopic($(this).attr("id"));
                            if (!($span.hasClass("store-icon-actived"))) {
                                $span.addClass("store-icon-actived");
                                flag = true;
                            }
                        });
                        if (!flag) {
                            $.omMessageTip.show({ content: '您已经收藏了这些选题，无需重复收藏！', timeout: 1000, type: 'warning' });
                        }
                    }
                }
            });
        }
    })

});

function storeTopic(id) {//收藏选题
    var result = $.post("../../ashx/student/StoreManager.ashx", { "thesisId": id, "operate": "add" }, function (data) {
        if (data == "ok") {
            return true;
        } else {
            return false;
        }
    });
    return result;
}

function deldetStore(thesisId) {//取消收藏
    var result = $.post("../../ashx/student/StoreManager.ashx", { "thesisId": thesisId, "operate": "del" }, function (data) {
        if (data == "ok") {
            return true;
        } else {
            return false;
        }
    });
    return result;
}
function selectTopic(id) {//选择选题
    var result = $.post("../../ashx/student/SelectedManager.ashx", { "thesisId": id, "operate": "add" }, function (data) {
        if (data == "ok") {
            return true;
        } else {
            return false;
        }
    });
    return result;
}
function deleteSelect(id) {//取消选题
    var result = $.post("../../ashx/student/SelectedManager.ashx", { "thesisId": id, "operate": "del" }, function (data) {
        if (data == "ok") {
            return true;
        } else {
            return false;
        }
    });
    return result;
}