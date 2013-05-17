$(function () {
    $(".deleteOne").click(function () {
        var noticeId = $(this).parent().parent().attr("id");
        $myThis = $(this);
        $.omMessageBox.confirm({
            title: '确认删除？',
            content: '确定要删除该用户信息？',
            onClose: function (value) {
                if (value) {
                    $.post("", { "operate": "del", "nid": noticeId }, function (data) {
                        if (data == "ok") {
                            $myThis.parent().parent().remove();
                            $.omMessageTip.show({ content: '删除成功！', timeout: 1000, type: 'success' });
                        }
                        else {
                            $.omMessageTip.show({ content: '删除失败！', timeout: 1000, type: 'error' });
                        }
                    })

                }
            }
        });
    })
})