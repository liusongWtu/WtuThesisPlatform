/**********点击展开选题详细信息效果**********/
var flag = false;
$(function () {
    $("#mInfo").click(function () {
        //console.log(flag);
        if (!flag) {
            $(".stu-info input:not('#ContentPlaceHolderBody_sName,#ContentPlaceHolderBody_sNo,#ContentPlaceHolderBody_sYear')").removeAttr("readonly")
			                                                                                                                   .addClass("active")
												                                                                               .click(function () {
												                                                                                   $(this).focus();
												                                                                               });
            $(".stu-info select").removeAttr("disabled").addClass("active");
            var addDiv = $("<div id='button'><button id='modify-ok' class='modify-ok button dis-inline-block'></button><button id='modify-no' class='modify-no button dis-inline-block'></button></div>");
            flag = true;
            $(".stu-info").append(addDiv);
            $("#modify-ok").click(function () {
                if (modifyInfo()) {//如果更新成功
                    $.omMessageTip.show({ content: '更新成功！', timeout: 1000, type: 'success' });
                    $(".stu-info input").removeClass("active").attr("readonly", "readonly");
                    $(".stu-info select").removeClass("active").attr("disabled", "disabled");
                }
                else {//更行失败
                    $.omMessageTip.show({ content: '更新失败！', timeout: 1000, type: 'error' });
                }
            })
            $("#modify-no").click(function () {
                $("#button").remove();
                $(".stu-info input").removeClass("active").attr("readonly", "readonly");
                $(".stu-info select").removeClass("active").attr("disabled", "disabled");
                flag = false;
            })
        }
    });
});

//修改操作
function modifyInfo() {//这个函数你写成 : 如果更新成功就返回true，更新失败就返回false就行了
    //ajax更新操作

    //更新成功时提示
    return true;
    //失败时提示
    //return false;
}


