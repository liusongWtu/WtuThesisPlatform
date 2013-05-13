
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
        if (!$(this).hasClass("applyed")) {
            $(this).text("取消").addClass("applyed");
            $(this).parent().prev().children("span").text("处理中...").css("color", "red");
            $.post("", {}, function (data) {

            });
            $.omMessageTip.show({ content: '已申请，等待审批！', timeout: 1000, type: 'success' });
        }
        else {
            if (cansoleApply()) {//取消申请
                $(this).text("申请").removeClass("applyed");
                $(".tea-status").text("状态").css("color", "black");
                $.omMessageTip.show({ content: '取消成功！', timeout: 1000, type: 'success' });
            }
            else {
                $.omMessageTip.show({ content: '取消失败！', timeout: 1000, type: 'error' });
            }
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
                    $.ajax({ type: "post", url: "", data: "operate=del&tid=" + aid, async: true, success: function (data) {
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
    $(".selectStatus").click(function () {//选择学生
        var tid = $(".sTittle").attr("id");
        var sid = $(".sStuName").atte("id");
        if (!$(this).hasClass("selected")) {//如果还没有选择
            $.ajax({ type: "post", url: "", data: "operate=select&tid=" + tid + "&sid" + sid ,success: function(data){
                    if(data == "ok"){
                        $(this).text("取消").addClass("selected");
                        $.omMessageTip.show({ content: '选择成功！', timeout: 1000, type: 'success' });
                    }
                    else{
                        $.omMessageTip.show({ content: '选择失败！', timeout: 1000, type: 'error' });
                    }
            
                }
            })
        }
        else {//取消选择
            $.ajax({ type: "post", url: "", data: "operate=consoleSel&tid=" + tid + "&sid" + sid, success: function (data) {
                    if (data == "ok") {
                        $(this).text("选择").removeClass("selected");
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
        var tag = false;
        var $checked = $("input[name='topiclist']:checked");
        $.omMessageBox.confirm({
            title: '确认删除？',
            content: '确定要将所选项删除？',
            onClose: function (value) {
                if (value) {
                    $checked.each(function () {
                        var aid = $(this).parent().parent().attr("id");
                        $.ajax({ type: "post", url: "", data: "operate=del&tid=" + aid, success: function (data) {
                            if (data == "ok") {
                                $(this).parent().parent().remove();
                                tag = true;
                            } else {
                                tag = false;
                                return false;
                            }
                        }
                        });
                    });
                    if (tag) {
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

function cansoleApply() { //取消申请
    return true;
}


