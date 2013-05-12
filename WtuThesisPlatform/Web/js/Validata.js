function Validata() {
    var errorNum = 0;
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
            }
        },
        //submitHandler: function () {
        //alert('提交成功！');
        //$(this)[0].currentForm.reset()
        //return false;
        //},
        showErrors: function (errorMap, errorList) {
            errorNum = errorList.length;
            if (errorList && errorList.length > 0) {
                $.each(errorList, function (index, obj) {
                    $(obj.element).next().show();
                });
                this.defaultShowErrors();
            } else {
                var hideEmpError = $(this.currentElements).next();
                if (hideEmpError.length > 0 && hideEmpError[0].tagName == 'LABEL' && hideEmpError.hasClass('error'))
                    hideEmpError.hide();
            }
            $(this.currentElements).each(function (index, item) {
                if ($(item).hasClass("valid")) {
                    $(item).next(".error").hide();
                }
            });
        }
    });
    console.log(errorNum);
    return errorNum;
}; 
    