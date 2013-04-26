/**********点击修改**********/
var flag = false;
var sFaculty= $(".sFaculty");
var sProfession=$(".sProfession");
var sClass= $(".sClass");
var sPhone= $(".sPhone");
var sEmail= $(".sEmail");
var sQQ= $(".sQQ");

$(function () {
    var oldInfo = getInfo(); //刚进入的时候获取各项值
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

            //绑定院系选择变化事件
            $("#ContentPlaceHolderBody_sFaculty").change(function () { loadMajor(); });
            //绑定专业选择变化事件
            $("#ContentPlaceHolderBody_sProfession").change(function () { loadClass(); });

            flag = true;
            $(".stu-info").append(addDiv);
            $("#modify-ok").click(function () {
                //取得各项值
                var newInfo = getInfo(); //点击更新的时候获取新的各项值
                if (modifyInfo()) {//如果更新成功
                    setInfo(newInfo); //将各项值更新
                    $.omMessageTip.show({ content: '更新成功！', timeout: 1000, type: 'success' });
                    $("#button").remove();
                    $(".stu-info input").removeClass("active").attr("readonly", "readonly");
                    $(".stu-info select").removeClass("active").attr("disabled", "disabled");
                    oldInfo = getInfo(); //更新成功之后表示数据已经进入数据库，此时要再次获得各项信息
                    flag = false;
                }
                else {//更新失败
                    $.omMessageTip.show({ content: '更新失败！', timeout: 1000, type: 'error' });
                }
                return false;
            })
            $("#modify-no").click(function () {
                setInfo(oldInfo); //将各项值设置为原来的
                $(".button").remove();
                $(".stu-info input").removeClass("active").attr("readonly", "readonly");
                $(".stu-info select").removeClass("active").attr("disabled", "disabled");
                flag = false;
                return false;
            })
            return false;
        }

    });


});
//给各项设置值
function setInfo(info) {
   sFaculty.val(info.aFaculty);
   sProfession.val(info.sProfession);
   sClass.val(info.sClass);
   sPhone.val(info.sPhone);
   sEmail.val(info.sEmail);
   sQQ.val(info.sQQ);
}
//取得各项的值
function getInfo() {
    var info = { 'sFaculty':sFaculty.val() , 'sProfession': sProfession.val(), 'sClass': sClass.val(), 'sPhone': sPhone.value, 'sEmail':sEmail.value, 'sQQ':sQQ.value };
    return info;
}

//根据院系加载相应专业信息
function loadMajor() {
    $.get("../../ashx/common/LoadSelect.ashx", { "did": $("#ContentPlaceHolderBody_sFaculty").val() }, function (data) {
        var dataJsonArr = eval("(" + data + ")");
        var curSelect = $("#ContentPlaceHolderBody_sProfession");
        curSelect.empty();
        for (var i = 0; i < dataJsonArr.length; i++) {
            curSelect.append("<option value=\"" + dataJsonArr[i].MId + "\">" + dataJsonArr[i].MName + "</option>");
        }
    });
}

//根据专业加载班级信息
function loadClass() {
    $.get("../../ashx/common/LoadSelect.ashx", { "mid": $("#ContentPlaceHolderBody_sProfession").val() }, function (data) {
        var dataJsonArr = eval("(" + data + ")");
        var curSelect = $("#ContentPlaceHolderBody_sClass");
        curSelect.empty();
        for (var i = 0; i < dataJsonArr.length; i++) {
            curSelect.append("<option value=\"" + dataJsonArr[i].CId + "\">" + dataJsonArr[i].CName + "</option>");
        }
    });
}


//修改操作
function modifyInfo() {//这个函数你写成 : 如果更新成功就返回true，更新失败就返回false就行了
    //ajax更新操作
//    $.post("../../ashx/student/ModifyInfo.ashx", { $(""): "" }, function (data) {

  //  });
}


