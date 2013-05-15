//验证控件是否为空

//提交
$(function () {
    $(".input-style").keydown(function () {
        $(this).removeClass("error");
    })
    $(".number").blur(function () {
        if ($(this).val() != "") {
            if ($(this).val().match(/^\d$|^1\d$|^20$/) == null) {
                $(this).addClass("error");
                $.omMessageTip.show({ content: '请输入1~20之间的数值！', timeout: 1000, type: 'alert' });
            }
        }

    })
    $(".btnSave").click(function () {
        //验证
        var flag = false;
        if ($(".txtTitle").val() == "") {
            $(".txtTitle").addClass("error");
            flag = true;
        }
        if ($(".txtIntroduct").val() == "") {
            $(".txtIntroduct").addClass("error");
            flag = true;
        }
        if ($(".txtRequire").val() == "") {
            $(".txtRequire").addClass("error");
            flag = true;
        }
        if ($(".platform").val() == "") {
            $(".platform").addClass("error");
            flag = true;
        }
        if ($(".number").val() == "") {
            $(".number").addClass("error");
            flag = true;
        }

        if ($(".number").val().match(/^\d$|^1\d$|^20$/) == null) {
            $(".number").addClass("error");
            flag = true;
        }
        if (!flag) {
            if ($(".btnSave").attr("operate") == "modify") {
                PostApply("modify", $(".btnSave").attr("thesisId"));
            } else {
                PostApply("add","");
            }
        }
    });
});

function PostApply(operate,thesisId) {
    $.post("../../ashx/teacher/ApplyExcel.ashx",
                    { "operate": operate, "title": $(".txtTitle").val(), "introduct": $(".txtIntroduct").val(),
                        "require": $(".txtRequire").val(), "platform": $(".platform").val(), "tid": thesisId,
                        "number": $(".number").val()
                    },
                     function (data) {
                         if (data == "ok") {
                             $.omMessageTip.show({ content: '保存成功！', timeout: 1000, type: 'success' });
                             if (operate == "add") {
                                 $(".txtTitle").val("");
                                 $(".txtIntroduct").val("");
                                 $(".txtRequire").val("");
                                 $(".platform").val("");
                                 $(".number").val("");
                             }
                         } else if (data == "exist") {
                             $.omMessageTip.show({ content: '当前选题已存在！', timeout: 1000, type: 'error' });
                         } else {
                             $.omMessageTip.show({ content: '保存失败！', timeout: 1000, type: 'error' });
                         }
                     });
}
