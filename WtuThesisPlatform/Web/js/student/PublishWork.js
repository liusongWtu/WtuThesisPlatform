$(function () {
    $("#picURL").change(function () {

        var picurl = $(this).val().split(".");
        picurl = picurl[picurl.length - 1];
        if (picurl == "jpg" || picurl == "png" || picurl == "gif" || picurl == "bmp") {
            $("#pic").attr("src", this.document.selection.createRange().text);
        }
        else {
            $.omMessageTip.show({ content: '请选择图片类型', timeout: 1000, type: 'error' });
            var ie = (navigator.appVersion.indexOf("MSIE") != -1); //IE        
            if (ie) {
                $("#picURL").select();
                document.execCommand("delete");
            } else {
                $("#picURL").val("");
            }

        }
    });
    $("#upload").click(function () {
        if ($("#picURL").val() == "") {
            $.omMessageTip.show({ content: '您还没有选择图片', timeout: 1000, type: 'error' });
            return false;
        }
    })
})