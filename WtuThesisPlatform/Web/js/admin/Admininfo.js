/**********点击修改**********/
var flag = false;
var sPhone;
var sEmail;
var sQQ;
var phoneValidate;
var emailValidate;
var qqValidate;

$(function () {
    sPhone = $(".sPhone");
    sEmail = $(".sEmail");
    sQQ = $(".sQQ");
    oldInfo = getInfo(); //刚进入的时候获取各项值
    //console.log(oldInfo);
    $("#mInfo").click(function () {
        //console.log(flag);
        if (!flag) {
            $(".stu-info input:not('#ContentPlaceHolderBody_sName')").removeAttr("readonly")
.addClass("active")
.click(function () {
    $(this).focus();
});
            $(".stu-info select").removeAttr("disabled").addClass("active");
            var addDiv = $("<div id='button'><button id='modify-ok' class='modify-ok button dis-inline-block'></button><button id='modify-no' class='modify-no button dis-inline-block'></button></div>");

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
            $(".stu-info").append(addDiv);
            $("#modify-ok").click(function () {
                //检查页面验证是否通过
                if (phoneValidate == false || emailValidate == false || qqValidate == false) {
                    return;
                }
                //取得各项值
                var newInfo = getInfo(); //点击更新的时候获取新的各项值
                console.log(newInfo);
                if (modifyInfo()) {//如果更新成功
                    setInfo(newInfo); //将各项值更新
                    $(".button").remove();
                    $(".stu-info input").removeClass("active").attr("readonly", "readonly");
                    $(".stu-info select").removeClass("active").attr("disabled", "disabled");
                    oldInfo = getInfo(); //更新成功之后表示数据已经进入数据库，此时要再次获得各项信息
                    //console.log(oldInfo);
                    flag = false;
                    $.omMessageTip.show({ content: '更新成功！', timeout: 1000, type: 'success' });
                }
                else {//更新失败
                    $.omMessageTip.show({ content: '更新失败！', timeout: 1000, type: 'error' });
                }
                return false;
            })
            $("#modify-no").click(function () {
                setInfo(oldInfo); //将各项值设置为原来的
                //console.log(oldInfo);
                $("#emailError").hide();
                $("#phoneError").hide();
                $("#qqError").hide();
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
    sPhone.val(info.sPhone);
    sEmail.val(info.sEmail);
    sQQ.val(info.sQQ);
}
//取得各项的值
function getInfo() {
    var info = { 'sPhone': sPhone.val(), 'sEmail': sEmail.val(), 'sQQ': sQQ.val() };
    return info;
}

//修改操作
function modifyInfo() {

    //ajax更新操作
    var ope = $.post("../../ashx/admin/ModifyInfo.ashx",
        { "phone": sPhone.val(), "email": sEmail.val(), "qq": sQQ.val() },
        function (data) {
            if (data == "ok") {
                return true;
            } else {
                return false;
            }
        });
    return ope;
}