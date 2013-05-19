$(function () {
   

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
        var myThis = $(this);
        if (myThis.hasClass("select-icon-actived")) {//已经选择了该题，此时再点击表示取消选题
            if (deleteSelect(myThis.parent().attr("id"))) {//取消选题成功
                myThis.removeClass("select-icon-actived");
                $.omMessageTip.show({ content: '已取消选题！', timeout: 1000, type: 'success' });
            }
        }
        else {//还没选题，点击选题
            $.ajax({ data: "post", url: "../../ashx/student/SelectedManager.ashx", data: "thesisId=" + myThis.parent().attr("id") + "&operate=add&srcPage=stuSelect", async: false, success: function (data) {
                if (data == "ok") {
                    myThis.addClass("select-icon-actived");
                    e.stopPropagation();
                    $.omMessageTip.show({ content: '已选择该选题！', timeout: 1000, type: 'success' });

                } else if (data == "full") {
                    $.omMessageBox.alert({
                        title: '提示信息',
                        content: '您最多可以选择3个志愿！',
                        onClose: function (value) {
                        }
                    });
                } else {
                    $.omMessageBox.alert({
                        title: '提示信息',
                        content: '网络繁忙请稍后操作！',
                        onClose: function (value) {
                        }
                    });
                }
            }
            });

            //            if (selectTopic($(this).parent().attr("id"))) {//如果选题选择成功
            //                $(this).addClass("select-icon-actived");
            //                e.stopPropagation();
            //                $.omMessageTip.show({ content: '已选择该选题！', timeout: 1000, type: 'success' });
            //            }
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
    var result = false;
    $.ajax({ data: "post", url: "../../ashx/student/StoreManager.ashx", data: "thesisId=" + id + "&operate=add", async: false, success: function (data) {
        if (data == "ok") {
            result = true;
        } else {
            result = false;
        }
    }
    });
    return result;
}

function deldetStore(thesisId) {//取消收藏
    var result = false;
    $.ajax({ data: "post", url: "../../ashx/student/StoreManager.ashx", data: "thesisId=" + thesisId + "&operate=del", async: false, success: function (data) {
        if (data == "ok") {
            result = true;
        } else {
            result = false;
        }
    }
    });
    return result;
}

function deleteSelect(id) {//取消选题
    var result = false;
    $.post({ data: "post", url: "../../ashx/student/SelectedManager.ashx", data: "thesisId=" + id + "&operate=del&srcPage=mySelect", async: false, success: function (data) {
        if (data == "ok") {
            result = true;
        } else {
            result = false;
        }
    }
    });
    return result;
}