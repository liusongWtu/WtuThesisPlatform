$(function () {
    //设置志愿序列号
    setTopicIndex();
    /**********退选**********/
    $(".refuse-select-icon").click(function () {
        var $myThis = $(this);

        $.omMessageBox.confirm({

            title: '确认删除？',

            content: '确定要退选该选题吗？',

            onClose: function (value) {

                if (value) {
                    if (deleteSelectedTopic($myThis.parent().parent().attr("id"))) {
                        //删除成功

                        $myThis.parent().parent().remove();//删除节点

                        $.omMessageTip.show({ content: '已退选该题！', timeout: 1000, type: 'alert' });

                        //每次退选之后重新设置志愿序列号
                        setTopicIndex();

                    }
                }

            }

        })
    });
});

//设置志愿序列号
function setTopicIndex() {
    $(".order").each(function () {
        index = $(this).parent().parent().prevAll().length + 1;
        $(this).text(index);
    })
}


function deleteSelectedTopic(id) {
    //删除已选选题
    var result = $.post("../../ashx/student/SelectedManager.ashx", { "thesisId": id, "operate": "del" }, function (data) {
        if (data == "ok") {
            return true;
        } else {
            return false;
        }
    });
    return result;
}