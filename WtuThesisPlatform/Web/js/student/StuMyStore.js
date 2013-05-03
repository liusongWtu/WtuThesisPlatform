$(function () {
    //删除收藏
    $(".delete-icon").click(function () {
        var $myThis = $(this);
        $.omMessageBox.confirm({
            title: '确认删除？',
            content: '确定要删除该收藏？',
            onClose: function () {
                if (deleteStore($myThis.parent().parent().attr("id"))) { //删除成功
                    $myThis.parent().parent().remove(); //移除节点
                    $.omMessageTip.show({ content: '已删除对该选题的收藏！', timeout: 1000, type: 'alert' });
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
            onClose: function () {
                if (selectStore($myThis.parent().parent().attr("id"))) { //删除成功
                    $myThis.parent().parent().remove();//移除节点
                    $.omMessageTip.show({ content: '已选择该题！', timeout: 1000, type: 'alert' });
                }
            }
        });

    })
});


function deleteStore(id) {
    //删除收藏

    return true;
}


function selectStore() {
    //选题
    return true;
}