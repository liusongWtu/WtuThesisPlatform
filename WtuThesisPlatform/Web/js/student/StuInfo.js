
/**********点击修改**********/
var flag = false;
var sFaculty;
var sProfession;
var sClass;
var sPhone;
var sEmail;
var sQQ;
var phoneValidate;
var emailValidate;
var qqValidate;

$(function () {
    sFaculty = $(".sFaculty");
    sProfession = $(".sProfession");
    sClass = $(".sClass");
    sPhone = $(".sPhone");
    sEmail = $(".sEmail");
    sQQ = $(".sQQ");
    oldInfo = getInfo(); //刚进入的时候获取各项值
    //console.log(oldInfo);
    $("#mInfo").click(function () {
        //console.log(flag);
        if (!flag) {
            $(".person-info input:not('#ContentPlaceHolderBody_sName,#ContentPlaceHolderBody_sSex,#ContentPlaceHolderBody_sNo,#ContentPlaceHolderBody_sYear')").removeAttr("readonly")
.addClass("active")
.click(function () {
    $(this).focus();
});
            $(".person-info select").removeAttr("disabled").addClass("active");
            var addDiv = $("<div id='button'><button id='modify-ok' class='modify-ok button dis-inline-block'></button><button id='modify-no' class='modify-no button dis-inline-block'></button></div>");

            //绑定院系选择变化事件
            $("#ContentPlaceHolderBody_sFaculty").change(function () { loadMajor(); });
            //绑定专业选择变化事件
            $("#ContentPlaceHolderBody_sProfession").change(function () { loadClass(); });
            //绑定邮箱验证事件
            sEmail.blur(function () {
                emailValidate = validateEmail(sEmail.get(0), $("#emailError").get(0));
            });
            //绑定电话验证事件
            sPhone.blur(function () {
                phoneValidate = validatePhone(sPhone.get(0), $("#phoneError").get(0));
            });

            //绑定QQ验证事件
            sQQ.blur(function () {
                qqValidate = validateQQ(sQQ[0], $("#qqError")[0]);
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
                console.log(newInfo);

                $.post("../../ashx/student/ModifyInfo.ashx",
                    { "did": sFaculty.val(), "mid": sProfession.val(), "cid": sClass.val(), "phone": sPhone.val(), "email": sEmail.val(), "qq": sQQ.val() },
                    function (data) {
                        if (data == "ok") {
                            setInfo(newInfo); //将各项值更新
                            sFaculty.find("option[value=" + newInfo.sFaculty + "]").attr("selected", "selected");
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
                //console.log(oldInfo);
                $("#emailError").hide();
                $("#phoneError").hide();
                sFaculty.find("option[value=" + oldInfo.sFaculty + "]").attr("selected", "selected");
                loadMajor();
                $(".button").remove();
                $(".person-info input").removeClass("active").attr("readonly", "readonly");
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
    sFaculty.val(info.aFaculty);
    sProfession.val(info.sProfession);
    sClass.val(info.sClass);
    sPhone.val(info.sPhone);
    sEmail.val(info.sEmail);
    sQQ.val(info.sQQ);
}
//取得各项的值
function getInfo() {
    var info = { 'sFaculty': sFaculty.val(), 'sProfession': sProfession.val(), 'sClass': sClass.val(), 'sPhone': sPhone.val(), 'sEmail': sEmail.val(), 'sQQ': sQQ.val() };
    return info;
}

//根据院系加载相应专业信息
function loadMajor() {
    $.get("../../ashx/common/LoadSelect.ashx", { "operate": "getDM", "did": $("#ContentPlaceHolderBody_sFaculty").val() }, function (data) {
        var dataJsonArr = eval("(" + data + ")");
        var curSelectMajor = $("#ContentPlaceHolderBody_sProfession");
        curSelectMajor.empty();
        curSelectMajor.append("<option selected=\"selected\" value=\"" + dataJsonArr.major[0].MId + "\">" + dataJsonArr.major[0].MName + "</option>");
        for (var i = 1; i < dataJsonArr.major.length; i++) {
            curSelectMajor.append("<option value=\"" + dataJsonArr.major[i].MId + "\">" + dataJsonArr.major[i].MName + "</option>");
        }
        var curSelectClass = $("#ContentPlaceHolderBody_sClass");
        curSelectClass.empty();
        curSelectClass.append("<option selected=\"selected\" value=\"" + dataJsonArr.class[0].CId + "\">" + dataJsonArr.class[0].CName + "</option>");
        for (var i = 1; i < dataJsonArr.class.length; i++) {
            curSelectClass.append("<option value=\"" + dataJsonArr.class[i].CId + "\">" + dataJsonArr.class[i].CName + "</option>");
        }
    });
}

//根据专业加载班级信息
function loadClass() {
    $.get("../../ashx/common/LoadSelect.ashx", { "operate": "getClass", "mid": $("#ContentPlaceHolderBody_sProfession").val() }, function (data) {
        var dataJsonArr = eval("(" + data + ")");
        var curSelect = $("#ContentPlaceHolderBody_sClass");
        curSelect.empty();
        curSelect.append("<option selected=\"selected\" value=\"" + dataJsonArr[0].CId + "\">" + dataJsonArr[0].CName + "</option>");
        for (var i = 1; i < dataJsonArr.length; i++) {
            curSelect.append("<option value=\"" + dataJsonArr[i].CId + "\">" + dataJsonArr[i].CName + "</option>");
        }
    });
}
