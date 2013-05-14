//验证控件是否为空

//提交
$(function () {
    $(".btnSave").click(function () {
        //验证
        $.post("../../ashx/teacher/ApplyExcel.ashx",
                { "title": $("#txtTitle").val(), "introduct": $("#txtIntroduct").val(),
                    "require": $("#txtRequire").val(), "platform": $("#platform").val(),
                    "number": $("#number").val()
                },
                 function (data) {
                     if (data == "ok") {
                         $.omMessageTip.show({ content: '保存成功！', timeout: 1000, type: 'success' });
                         $("#txtTitle").val("");
                         $("#txtIntroduct").val("");
                         $("#txtRequire").val("");
                         $("#platform").val("");
                         $("#number").val("");
                     } else if (data == "exist") {
                         $.omMessageTip.show({ content: '当前选题已存在！', timeout: 1000, type: 'error' });
                     }else {
                         $.omMessageTip.show({ content: '保存失败！', timeout: 1000, type: 'error' });
                     }
                     
                 });
    });
});