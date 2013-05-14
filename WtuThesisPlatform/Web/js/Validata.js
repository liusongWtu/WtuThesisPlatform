function Validata() {
    var test = $("#form1").validate({
        rules: {
            isMobilePhone: {
                required: true,
                isMobilePhone: true
            },
            isEmail: {
                required: true,
                isEmail: true
            },
            isQQ: {
                required: true,
                isQQ: true
            },
            isPasssword: {
                required: true,
                isPassword: true
            },
            isNameEmpty: {
                required: true
            },
            isUserNameEmpty: {
                required: true
            },
            isTeaNum: {
                required: true,
                isTeaNum: true
            }
        },
        messages: {
            isMobilePhone: {
                required: "请输入电话号码",
                isMobilePhone: "您输入的电话号码格式不对"
            },
            isEmail: {
                required: "请输入邮箱",
                isEmail: "您输入的邮箱格式不对"
            },
            isQQ: {
                required: "请输入QQ",
                isQQ: "您输入的QQ号码格式不对"
            },
            isNameEmpty: {
                required: "该项不能为空"
            },
            isUserNameEmpty: {
                required: "该项不能为空"
            },
            isTeaNum: {
                required: "该项不能为空",
                isTeaNum: "教师限带人数范围是0~20"
            }
        },
        validateOnEmpty: true,
        errorPlacement: function (error, element) {
            if (error.html()) {
                $(element).parents().map(function () {
                    if (this.tagName.toLowerCase() == 'td') {
                        var attentionElement = $(this).next().children().eq(0);
                        attentionElement.css('display', 'block');
                        attentionElement.next().html(error);
                    }
                });
            }
        },
        showErrors: function (errorMap, errorList) {
            if (errorList && errorList.length > 0) {
                $.each(errorList, function (index, obj) {
                    var msg = this.message;
                    $(obj.element).parents().map(function () {
                        if (this.tagName.toLowerCase() == 'td') {
                            var attentionElement = $(this).next().children().eq(0);
                            attentionElement.show();
                            attentionElement.next().html(msg);
                        }
                    });
                });
            } else {
                $(this.currentElements).parents().map(function () {
                    if (this.tagName.toLowerCase() == 'td') {
                        $(this).next().children().eq(0).hide();
                    }
                });
            }
            this.defaultShowErrors();
        }
    });
    $('.errorImg').bind('mouseover', function () {
        $(this).next().css('display', 'block');
    }).bind('mouseout', function () {
        $(this).next().css('display', 'none');
    });
    return test.numberOfInvalids();
}; 
    