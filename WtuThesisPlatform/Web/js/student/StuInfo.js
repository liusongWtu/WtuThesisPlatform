/**********点击展开选题详细信息效果**********/
var flag = false;
$(function () {
    $("#mInfo").click(function () {
        //console.log(flag);
        var sFaculty = $("#sFaculty").val();
        if (!flag) {
            $(".stu-info input:not('#ContentPlaceHolderBody_sName,#ContentPlaceHolderBody_sNo,#ContentPlaceHolderBody_sYear')").removeAttr("readonly")
			                                                                                                                   .addClass("active")
												                                                                               .click(function () {
												                                                                                   $(this).focus();
												                                                                               });
            $(".stu-info select").removeAttr("disabled").addClass("active");
            var addDiv = $("<div id='button'><button id='modify-ok' class='modify-ok button dis-inline-block'></button><button id='modify-no' class='modify-no button dis-inline-block'></button></div>");
            //设置院系、专业、班级联动信息
            //loadData();

            flag = true;
            $(".stu-info").append(addDiv);
            $("#modify-ok").click(function () {
                if (modifyInfo()) {//如果更新成功
                    $.omMessageTip.show({ content: '更新成功！', timeout: 1000, type: 'success' });
                    $("#button").remove();
                    $(".stu-info input").removeClass("active").attr("readonly", "readonly");
                    $(".stu-info select").removeClass("active").attr("disabled", "disabled");
                    flag = false;
                }
                else {//更行失败
                    $.omMessageTip.show({ content: '更新失败！', timeout: 1000, type: 'error' });
                }
                return false;
            })
            $("#modify-no").click(function () {
                $("#button").remove();
                $(".stu-info input").removeClass("active").attr("readonly", "readonly");
                $(".stu-info select").removeClass("active").attr("disabled", "disabled");
                flag = false;
                return false;
            })
            return false;
        }
    });
});

//加载下拉框信息，并绑定相关事件
function loadData() {
    $.get();
}

//修改操作
function modifyInfo() {//这个函数你写成 : 如果更新成功就返回true，更新失败就返回false就行了
    //ajax更新操作
    $.post("../../ashx/student/ModifyInfo.ashx", {"":""}, function (data) { 
        
    });
}


