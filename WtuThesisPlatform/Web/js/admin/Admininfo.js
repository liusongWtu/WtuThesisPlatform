/**********点击修改**********/
var flag = false;
var aPhone;
var aEmail;
var aQQ;

$(function () {
    aPhone = $(".aPhone");
    aEmail = $(".aEmail");
    aQQ = $(".aQQ");
    oldInfo = getInfo(); //刚进入的时候获取各项值
    //console.log(oldInfo);
    $("#mInfo").click(function () {
        //console.log(flag);
        if (!flag) {
            $(".person-info input:not('.aName')").removeAttr("readonly")
.addClass("active")
.click(function () {
    $(this).focus();
});
            $(".person-info select").removeAttr("disabled").addClass("active");
            var addDiv = $("<div id='button'><button id='modify-ok' class='modify-ok button dis-inline-block'></button><button id='modify-no' class='modify-no button dis-inline-block'></button></div>");

            Validata();
            flag = true;
            $(".person-info").append(addDiv);
            $("#modify-ok").click(function () {
                //检查页面验证是否通过
                var errorNum = Validata();
                if (errorNum != 0) {
                    return;
                }
                else { 
                    var newInfo = getInfo(); //点击更新的时候获取新的各项值
                    //console.log(newInfo);
                    if (modifyInfo()) {//如果更新成功
                        setInfo(newInfo); //将各项值更新
                        $(".button").remove();
                        $(".person-info input").removeClass("active").attr("readonly", "readonly");
                        oldInfo = getInfo(); //更新成功之后表示数据已经进入数据库，此时要再次获得各项信息
                        //console.log(oldInfo);
                        flag = false;
                        $.omMessageTip.show({ content: '更新成功！', timeout: 1000, type: 'success' });
                    }
                    else {//更新失败
                        $.omMessageTip.show({ content: '更新失败！', timeout: 1000, type: 'error' });
                    }
                }
                //取得各项值
                
                return false;
            })
            $("#modify-no").click(function () {
                setInfo(oldInfo); //将各项值设置为原来的
                //console.log(oldInfo);
                //$("#emailError").hide();
                //$("#phoneError").hide();
                $(".error:not(input)").hide();
                //$("#qqError").hide();
                $(".button").remove();
                $(".person-info input").removeClass("active").attr("readonly", "readonly");
                flag = false;
                return false;
            })
            return false;
        }

    });


});
//给各项设置值
function setInfo(info) {
    aPhone.val(info.aPhone);
    aEmail.val(info.aEmail);
    aQQ.val(info.aQQ);
}
//取得各项的值
function getInfo() {
    var info = { 'aPhone': aPhone.val(), 'aEmail': aEmail.val(), 'aQQ': aQQ.val() };
    return info;
}

//修改操作
function modifyInfo() {

    //ajax更新操作
    var ope = $.post("../../ashx/admin/ModifyInfo.ashx",
        { "phone": aPhone.val(), "email": aEmail.val(), "qq": aQQ.val() },
        function (data) {
            if (data == "ok") {
                return true;
            } else {
                return false;
            }
        });
    return ope;
}