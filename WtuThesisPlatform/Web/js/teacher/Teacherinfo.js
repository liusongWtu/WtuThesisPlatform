
/**********点击修改**********/
var flag = false;
var tFaculty;
var tProfession;
var tPhone;
var tEmail;
var tQQ;
var tTeachCourse;
var tResearchFields;
var phoneValidate;
var emailValidate;
var qqValidate;

$(function () {
    tFaculty = $(".tFaculty");
    tProfession = $(".tProfession");
    tPhone = $(".tPhone");
    tEmail = $(".tEmail");
    tQQ = $(".tQQ");
    tTeachCourse = $(".tTeachCourse");
    tResearchFields = $(".tResearchFields");
    oldInfo = getInfo(); //刚进入的时候获取各项值
    $("#mInfo").click(function () {
        if (!flag) {
            $(".person-info input:not('.tName,.tSex,.tNo,.tZhiCheng'),.person-info textarea").removeAttr("readonly")
.addClass("active")
.click(function () {
    $(this).focus();
});
            $(".person-info select").removeAttr("disabled").addClass("active");
            var addDiv = $("<div id='button'><button id='modify-ok' class='modify-ok button dis-inline-block'></button><button id='modify-no' class='modify-no button dis-inline-block'></button></div>");

            //绑定院系选择变化事件
            tFaculty.change(function () { loadMajor(); });
            //绑定专业选择变化事件
            tProfession.change(function () { loadClass(); });
            //绑定邮箱验证事件
            tEmail.blur(function () {
                emailValidate = validateEmail(tEmail.get(0), $("#emailError").get(0));
            });
            //绑定电话验证事件
            tPhone.blur(function () {
                phoneValidate = validatePhone(tPhone.get(0), $("#phoneError").get(0));
            });

            //绑定QQ验证事件
            tQQ.blur(function () {
                qqValidate = validateQQ(tQQ[0], $("#qqError")[0]);
            });

            flag = true;
            $(".person-info").append(addDiv);
            $("#modify-ok").click(function () {
                //检查页面验证是否通过
                if (phoneValidate == false || emailValidate == false || qqValidate == false) {
                    return;
                }
                //取得各项值
                var newInfo = getInfo(); //点击更新的时候获取新的各项值
                $.post("../../ashx/student/ModifyInfo.ashx",
                    { "did": tFaculty.val(), "mid": tProfession.val(), "phone": tPhone.val(), "email": tEmail.val(), "qq": tQQ.val(), "teachCourse": tTeachCourse.val(), "tResearchFields": tResearchFields.val() },
                    function (data) {
                        if (data == "ok") {
                            setInfo(newInfo); //将各项值更新
                            tFaculty.find("option[value=" + newInfo.tFaculty + "]").attr("selected", "selected");
                            $(".button").remove();
                            $(".person-info input").removeClass("active").attr("readonly", "readonly");
                            $(".person-info select").removeClass("active").attr("disabled", "disabled");
                            oldInfo = getInfo(); //更新成功之后表示数据已经进入数据库，此时要再次获得各项信息
                            //console.log(oldInfo);
                            flag = false;
                            $.omMessageTip.show({ content: '更新成功！', timeout: 1000, type: 'success' });
                        } else {
                            $.omMessageTip.show({ content: '更新失败！', timeout: 1000, type: 'error' });
                        }
                    });
                return false;
            })
            $("#modify-no").click(function () {
                setInfo(oldInfo); //将各项值设置为原来的
                $("#emailError").hide();
                $("#phoneError").hide();
                tFaculty.find("option[value=" + oldInfo.tFaculty + "]").attr("selected", "selected");
                loadMajor();
                $(".button").remove();
                $(".person-info input").removeClass("active").attr("readonly", "readonly");
                $(".person-info textarea").removeClass("active").attr("readonly", "readonly");
                $(".person-info select").removeClass("active").attr("disabled", "disabled");
                flag = false;
                return false;
            })
            return false;
        }

    });


});
//给各项设置值
function setInfo(info) {
    tFaculty.val(info.tFaculty);
    tProfession.val(info.tProfession);
    tPhone.val(info.tPhone);
    tEmail.val(info.tEmail);
    tQQ.val(info.tQQ);
    tTeachCourse.val(info.tTeachCourse);
    tResearchFields.val(info.tResearchFields);
}
//取得各项的值
function getInfo() {
    var info = { 'tFaculty': tFaculty.val(), 'tProfession': tProfession.val(), 'tPhone': tPhone.val(), 'tEmail': tEmail.val(), 'tQQ': tQQ.val(), "teachCourse": tTeachCourse.val(), "tResearchFields": tResearchFields.val() };
    return info;
}

//根据院系加载相应专业信息
function loadMajor() {
    $.get("../../ashx/common/LoadSelect.ashx", { "operate": "getDM", "did": $(".tFaculty").val() }, function (data) {
        var dataJsonArr = eval("(" + data + ")");
        var curSelectMajor = $(".tProfession");
        curSelectMajor.empty();
        curSelectMajor.append("<option selected=\"selected\" value=\"" + dataJsonArr.major[0].MId + "\">" + dataJsonArr.major[0].MName + "</option>");
        for (var i = 1; i < dataJsonArr.major.length; i++) {
            curSelectMajor.append("<option value=\"" + dataJsonArr.major[i].MId + "\">" + dataJsonArr.major[i].MName + "</option>");
        }
    });
}

//根据专业加载班级信息
/*function loadClass() {
    $.get("../../ashx/common/LoadSelect.ashx", { "operate": "getClass", "mid": $("#ContentPlaceHolderBody_sProfession").val() }, function (data) {
        var dataJsonArr = eval("(" + data + ")");
        var curSelect = $("#ContentPlaceHolderBody_sClass");
        curSelect.empty();
        curSelect.append("<option selected=\"selected\" value=\"" + dataJsonArr[0].CId + "\">" + dataJsonArr[0].CName + "</option>");
        for (var i = 1; i < dataJsonArr.length; i++) {
            curSelect.append("<option value=\"" + dataJsonArr[i].CId + "\">" + dataJsonArr[i].CName + "</option>");
        }
    });
}*/
