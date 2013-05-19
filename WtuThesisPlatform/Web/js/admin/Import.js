$(function () {
    $(".fielUpExcel").val("");
    String.prototype.compare = function (str) {
        //不区分大小写
        if (this.toLowerCase() == str.toLowerCase()) {
            return "1"; // 正确
        }
        else {
            return "0"; // 错误
        }
    }
    $(".fielUpExcel").change(function () {
        var excurl = $(this).val().split(".");
        excurl = excurl[excurl.length - 1];
        console.log(excurl);
        if (excurl.compare("xls") == "1") {
        }
        else {
            $.omMessageTip.show({ content: '请选择excel文件', timeout: 1000, type: 'error' });
            $(this).val("");
        }

    });
    $(".opeImport").click(function () {
        $(".importDiv").toggle();

    })

})
function clientClick() {
    if ($(".fielUpExcel").val() == "") {
        $.omMessageTip.show({ content: '请选择要导入的文件', timeout: 1000, type: 'error' });
        return false;
    }

}