$(function () {
    $(".deadline").omCalendar();
    $(".btnSubmit").click(function () {
        var flag = false;
        if ($(".txtName").val() == "") {
            $(".txtName").parent().parent().prev().children("span").css("display", "block");
            flag = true;
        }
        if ($(".txtUnits").val() == "") {
            $(".txtUnits").parent().parent().prev().children("span").css("display", "block");
            flag = true;
        }
        if ($(".deadline").val() == "") {
            $(".deadline").parent().parent().prev().children("span").css("display", "block");
            flag = true;
        }
        if ($(".txtContent").val() == "") {
            $(".txtContent").parent().parent().prev().children("span").css("display", "block");
            flag = true;
        }
        if (!flag) {
            if ($(".btnSubmit").attr("isSaved") == "saved") {
                $.omMessageTip.show({ content: '保存成功！', timeout: 1000, type: 'success' });
                $(".txtName").val("");
                $(".txtContent").val("");
            }
            else {
                $.omMessageTip.show({ content: '保存失败！', timeout: 1000, type: 'error' });
            }
        }
    })

    $(".cancel").click(function () {
        $(".txtName").val("");
        $(".txtUnits").val("");
        $(".deadline").val("");
        $(".txtContent").val("");
    });
    
})
