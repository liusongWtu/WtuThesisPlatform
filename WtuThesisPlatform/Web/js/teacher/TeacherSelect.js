
$(function () {
    $(".tea-apply").click(function () {//申请选题
        if (!$(this).hasClass("applyed")) {
            $(this).text("取消").addClass("applyed");
            $(".tea-status").text("处理中...").css("color", "red");
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
        $(this).parent().parent().remove();
    });
    $(".selectStatus").click(function () {//选择学生
        if (!$(this).hasClass("selected")) {//如果还没有选择
            if (selectStu()) {
                $(this).text("取消").addClass("selected");
                $.omMessageTip.show({ content: '选择成功！', timeout: 1000, type: 'success' });
            }
            else {
                $.omMessageTip.show({ content: '选择失败！', timeout: 1000, type: 'error' });
            }

        }
        else {//取消选择
            if (cansoleSelect()) {
                $(this).text("选择").removeClass("selected");
                $.omMessageTip.show({ content: '退选成功！', timeout: 1000, type: 'success' });
            }
            else {
                $.omMessageTip.show({ content: '退选失败！', timeout: 1000, type: 'error' });
            }
        }
    })
});

function cansoleApply() { //取消申请
    return true;
}

function selectStu() {//选择学生
    return true;
}

function cansoleSelect() { //取消选择
    return true;
}

