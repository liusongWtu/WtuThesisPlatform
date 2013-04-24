/**********点击展开选题详细信息效果**********/
var flag = false;
$("#mInfo").click(function () {
    console.log(flag);
    if (!flag) {
        $(".stu-info input:not('#ContentPlaceHolderBody_sName,#ContentPlaceHolderBody_sNo,#ContentPlaceHolderBody_sYear')").removeAttr("readonly")
			                                       .addClass("active")
												   .click(function () {
												       $(this).focus();
												   });
        var addDiv = $("<div id='button'><button id='modify-ok' class='modify-ok button dis-inline-block'></button><button id='modify-no' class='modify-no button dis-inline-block'></button></div>");
        flag = true;
        $(".stu-info").append(addDiv);
        $("#modify-ok").click(function () {
            alert("修改成功");
            $("#button").remove();
            $(".stu-info input").removeClass("active");
            flag = false;
        })
        $("#modify-no").click(function () {
            $("#button").remove();
            $(".stu-info input").removeClass("active");
            flag = false;
        })
    }

});