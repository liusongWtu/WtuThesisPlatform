
$(function () {
    /*var apply = {
    tTittle: '',
    tName: '',
    tZhiCheng: '',
    tEmail: '',
    tQQ: '',
    tMajor: '',
    tPhone: '',
    tTopicSummary: '',
    tReqire: '',
    }*/
 

    $(".tea-apply").click(function () {//申请选题
        var myThis = $(this);
        if (!$(this).hasClass("applyed")) {
            $.post("../../ashx/teacher/TeacherApply.ashx", { "operate": "apply", "tid": $(this).parent().parent().attr("id") }, function (data) {
                var jsonArr = eval("(" + data + ")");
                if (jsonArr.result == "ok") {
                    $(myThis).text("取消").addClass("applyed");
                    //$(myThis).parent().prev().children("span").text("处理中...").css("color", "red");
                    $.omMessageTip.show({ content: '已申请，等待审批！', timeout: 1000, type: 'success' });
                } else {
                    $.omMessageTip.show({ content: '网络异常，请稍后操作！', timeout: 1000, type: 'error' });
                }
            });
        }
        else {
            $.post("../../ashx/teacher/TeacherApply.ashx", { "operate": "cancel", "tid": $(this).parent().parent().attr("id") }, function (data) {
                var jsonArr = eval("(" + data + ")");
                if (jsonArr.result == "ok") {
                    //取消申请
                    $(myThis).text("申请").removeClass("applyed");
                    $(myThis).parent().prev().children("span").text(jsonArr.state);
                    $.omMessageTip.show({ content: '取消成功！', timeout: 1000, type: 'success' });
                } else {
                    $.omMessageTip.show({ content: '取消失败！', timeout: 1000, type: 'error' });
                }
            });
        }
    });
    $(".tea-delete").click(function () {//删除申请
        var aid = $(this).parent().parent().attr("id");
        var myThis = $(this);
        $.omMessageBox.confirm({
            title: '确认删除？',
            content: '确定要将所选项删除？',
            onClose: function (value) {
                if (value) {
                    $.ajax({ type: "post", url: "../../ashx/teacher/TeacherApply.ashx", data: "operate=del&tid=" + aid, async: true, success: function (data) {
                        if (data == "ok") {
                            myThis.parent().parent().remove(); //这个就是删除标签，好像没起作用
                            $.omMessageTip.show({ content: '删除成功！', timeout: 1000, type: 'success' });
                        } else {
                            $.omMessageTip.show({ content: '删除失败！', timeout: 1000, type: 'error' });
                        }
                    }
                    });
                }
            }
        });

});

//修改选择、取消显示（注:显示取消的要加"applyed"样式）
    $(".selectStatus").click(function () {//选择学生
        var tid = $(".sTittle").attr("id");
        // var sid = $(".sStuName").atte("id");
        var myThis = $(this);
        if (!$(this).hasClass("selected")) {//如果还没有选择
            $.ajax({ type: "post", url: "../../ashx/teacher/TeacherSelect.ashx", data: "operate=select&tid=" + tid, success: function (data) {
                if (data == "ok") {
                    // $(myThis).text("选择").addClass("selected");
                    $(myThis).parent().parent().remove();
                    $.omMessageTip.show({ content: '选择成功！', timeout: 1000, type: 'success' });
                } else if (data == "ThesisFull") {
                    $.omMessageTip.show({ content: '该选题学生已满！', timeout: 1000, type: 'alert' });
                } else if (data == "SelectFull") {
                    $.omMessageTip.show({ content: '您可选学生数已满！', timeout: 1000, type: 'alert' });
                } else if (data == "StudentSelected") {
                    $.omMessageBox.alert({
                        title: '提示信息',
                        content: '学生已选题成功,请选择其他学生！',
                        onClose: function (value) {
                        }
                    });

                }
                else {
                    $.omMessageTip.show({ content: '选择失败！', timeout: 1000, type: 'error' });
                }

            }
            })
        }
        else {//取消选择
            $.ajax({ type: "post", url: "../../ashx/teacher/TeacherSelect.ashx", data: "operate=cancel&tid=" + tid, success: function (data) {
                if (data == "ok") {
                    // $(myThis).text("选择").removeClass("selected");
                    $(myThis).parent().parent().remove();
                    $.omMessageTip.show({ content: '退选成功！', timeout: 1000, type: 'success' });
                }
                else {
                    $.omMessageTip.show({ content: '退选失败！', timeout: 1000, type: 'error' });
                }
            }
            })
        }
    });
    /**********全选**********/
    $("#checkAll").click(function () {
        $("input[name='topiclist']").attr("checked", $(this).attr("checked"));
    });
    /**********批量删除***********/

    $("#deleteCount").click(function () {
        var $checked = $("input[name='topiclist']:checked");
        $.omMessageBox.confirm({
            title: '确认删除？',
            content: '确定要将所选项删除？',
            onClose: function (value) {
                if (value) {
                    $checked.each(function () {
                        var aid = $(this).parent().parent().attr("id");
                        var myThis = $(this);
                        $.ajax({ type: "post", url: "../../ashx/teacher/TeacherApply.ashx", async: false, data: "operate=del&tid=" + aid, success: function (data) {
                            if (data == "ok") {
                                myThis.parent().parent().remove();

                            } else {
                                $.omMessageTip.show({ content: '删除失败！', timeout: 1000, type: 'error' });
                            }
                        }

                        });

                        $.omMessageTip.show({ content: '删除成功！', timeout: 1000, type: 'success' });
                    });

                }
            }
        });
    });
});


