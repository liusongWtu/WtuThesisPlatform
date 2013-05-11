var SNo;
var SName;
var SSex;
var SPhone;
var SQQ;
var SEmail;
var SClass;
var SYear;
var DepartmentId;
var MajorId;

$(function () {
    SNo = $(".SNo");
    SName = $(".SName");
    SSex = $(".SSex");
    SPhone = $(".SPhone");
    SQQ = $(".SQQ");
    SEmail = $(".SEmail");
    SClass = $(".CId");
    SYear = $(".SYear");
    DepartmentId = $(".DId");
    MajorId = $(".MId");
    //初始化弹出框
    $("#StuAddNew").omDialog({
        autoOpen: false,
        height: 400,
        width: 550,
        modal: true
    });

    //添加用户
    $("#add").click(function () {
        //加载下拉列表
        loadDepartment(DepartmentId); //加载下拉列表
        DepartmentId.change(function () { loadMajor(MajorId, DepartmentId.val()); });
        $("#StuAddNew").omDialog({ title: "添加用户" });
        $("#StuAddNew").omDialog('open');
        $("#StuAddNew").omDialog({ buttons: [
            { text: "确定", click:
                function () {

                    if (addNewCount()) { //添加新用户成功
                        //关闭窗口
                        $("#StuAddNew").omDialog('close');
                        $.omMessageTip.show({ content: '添加成功！', timeout: 1000, type: 'success' });
                    }
                    else {
                        $.omMessageTip.show({ content: '添加失败！', timeout: 1000, type: 'error' });
                    }
                }
            },
            { text: "继续添加", click:
                function () {
                    if (addNewCount()) {//添加成功
                        $.omMessageTip.show({ content: '添加成功！', timeout: 1000, type: 'success' });
                        $("#StuAddNew input").val("");
                        $("#StuAddNew textarea").val("");
                    }
                }
            },
            { text: "取消", click:
                function () {
                    $("#StuAddNew").omDialog('close');
                }
            }
         ]
        });
        $(".addTable input,.addTable textarea").removeAttr("readonly");
        //验证
        $("#StuAddNew").attr("tabindex", 0);
        $("#StuAddNew").focus(); //不让输入框一开始就获得焦点
        //管理员登录名是否需要验证？？？？
        SPhone.blur(function () {//电话号码验证
            checkPhone();
        })
        SEmail.blur(function () {//email验证
            checkEmail();
        })
        SQQ.blur(function () {//QQ验证
            checkQQ();
        })
        SYear.blur(function () { //毕业届验证
            checkYear();
        })

    });

    //批量删除用户信息
    $("#delete").click(function () {
        var $checked = $("input[name='topiclist']:checked");
        if ($checked.length == 0) {
            $.omMessageTip.show({ content: '您还没有选择要删除的信息！', timeout: 1000, type: 'warning' });
        }
        else {
            $.omMessageBox.confirm({
                title: '确认删除？',
                content: '确定要将所选项删除？',
                onClose: function (value) {
                    if (value) {
                        $checked.each(function () {
                            if (deleteCount($(this).parent().parent().attr("id"))) {//数据库删除成功
                                $(this).parent().parent().remove();
                            }
                        })
                        $.omMessageTip.show({ content: '删除成功！', timeout: 1000, type: 'success' });
                    }
                }
            });
        }
    });


    //查看用户详情
    $(".checkDetail").click(function () {
        var stuId = $(this).parent().parent().attr("id");
        $("#StuAddNew").omDialog({ title: "用户信息" });
        $("#StuAddNew").omDialog({ buttons: {} });
        $("#StuAddNew").omDialog('open');
        setInfo(stuId, "detail");
        $(".addTable input,.addTable textarea").attr("readonly", "readonly");
        $("#StuAddNew").omDialog({ onClose: function () { clear(); } });
    });


    //修改用户信息
    $(".modifyInfo").click(function () {
        //初始化
        var stuId = $(this).parent().parent().attr("id");
        $("#StuAddNew").omDialog({ title: "修改信息" });
        $("#StuAddNew").omDialog({ buttons: [
                { text: "确定", click:
                    function () {
                        if (modifyCount(teaId)) { //修改成功
                            //关闭窗口
                            $("#StuAddNew").omDialog('close');
                            $.omMessageTip.show({ content: '修改成功！', timeout: 1000, type: 'success' });
                        }
                        else {
                            $.omMessageTip.show({ content: '修改失败！', timeout: 1000, type: 'error' });
                        }
                    }
                },

                { text: "取消", click:
                    function () {
                        $("#StuAddNew").omDialog('close');
                    }
                }
            ]
        });
        $("#StuAddNew").omDialog('open');
        setInfo(stuId, "modify");
        $(".addTable input,.addTable textarea").removeAttr("readonly");

    });


    //删除用户信息
    $(".deleteOne").click(function () {
        var $myThis = $(this);
        var stuId = $(this).parent().parent().attr("id");
        $.omMessageBox.confirm({
            title: '确认删除？',
            content: '确定要删除该用户信息？',
            onClose: function (value) {
                if (value) {
                    if (deleteCount(stuId)) {//删除信息成功
                        $myThis.parent().parent().remove();
                        $.omMessageTip.show({ content: '删除成功！', timeout: 1000, type: 'success' });
                    }
                    else {
                        $.omMessageTip.show({ content: '删除失败！', timeout: 1000, type: 'error' });
                    }
                }
            }
        });
    });

});

//function getInfo() {
//var info = { 'TNo': TNo.val(), 'TSex': TSex.val(), 'TName': TName.val(), 'TPhone': TPhone.val(), 'TEmail': TEmail.val(), 'TQQ': TQQ.val(), 'TZhiCheng': TZhiCheng.val(), 'TTeachNum': TTeachNum.val(), 'DepartmentId': DepartmentId.val(), 'MajorId': MajorId.val(), 'TTeachCourse': TTeachCourse.val(), 'TResearchFields': TResearchFields.val() };
//return info;
//}


function setInfo(stuId, operate) {
    $.get("../../ashx/admin/STudentManager.ashx", { "operate": "getAInfo", "studentId": stuId }, function (data) {
        //将返回的json数组字符串，转成 javascript的 数组对象
        info = eval("(" + data + ")");
        SNo.val(info.SNo);
        SName.val(info.SName);
        SSex.val(info.SSex);
        SPhone.val(info.SPhone);
        SEmail.val(info.SEmail);
        SQQ.val(info.SQQ);
        SYear.val(info.SYear);
        if (operate == "detail") {
            SClass.append("<option selected='selected'>" + info.ClassInfo.CName + "</option>")
            DepartmentId.append("<option selected='selected'>" + info.Department.DName + "</option>");
            MajorId.append("<option selected='selected'>" + info.Major.MName + "</option>");
        } else if (operate == "modify") {
            loadDepartment(DepartmentId); //加载院系下拉列表
            DepartmentId.find("option[value=" + info.Department.DId + "]").attr("selected", "selected");
            DepartmentId.change(function () { loadMajor(MajorId, DepartmentId.val()); });
            loadMajor(MajorId, info.Department.DId); //加载专业下拉列表
            MajorId.val(info.Major.MId);
            MajorId.change(function () { loadClass(SClass, MajorId.val()); });
            loadClass(SClass, MajorId.val()); //加载班级下拉列表
            SClass.val(info.ClassInfo.CId);
        }
        //验证
        //var oldInfo = getInfo();
        $("#addNew").attr("tabindex", 0);
        $("#addNew").focus();
        SNo.blur(function () {
            var newNo = SNo.val();
            if (info.SNo != newNo) {
                checkTNo();
            }
        });
        SPhone.blur(function () {
            var newPhone = SPhone.val();
            if (info.SPhone != newPhone) {
                checkPhone();
            }
        });
        SEmail.blur(function () {
            var newEmail = SEmail.val();
            if (info.SEmail != newEmail) {
                checkEmail();
            }
        });
        SQQ.blur(function () {
            var newQQ = SQQ.val();
            if (info.SQQ != newQQ) {
                checkQQ();
            }

        });
        SYear.blur(function () {
            var newYear = SYear.val();
            if (info.SYear != newYear) {
                checkYear();
            }
        })
    });
}

function addNewCount() {//添加新用户
    var result = $.post("../../ashx/admin/STudentManager.ashx",
            { "operate": "addNew", "sNo": SNo.val(), "sName": SName.val(), "sPhone": SPhone.val(),
                "sSex": SSex.val(), "sEmail": SEmail.val(), "sQQ": SQQ.val(),"sClass": SClass.val(),"sYear": SYear.val(),
                "did": DepartmentId.val(), "mid": MajorId.val()
            },
             function (data) {
                 if (data == "ok") {
                     return true;
                 } else {
                     return false;
                 }
             });
    return result;
}
function deleteCount(sid) {//删除用户
    var result = $.post("../../ashx/admin/STudentManager.ashx", { "operate": "del", "sid": sid }, function (data) {
        if (data == "ok") {
            return true;
        } else {
            return false;
        }
    });
    return result;
}
function modifyCount(sid) {//修改用户
    var ope = $.post("../../ashx/admin/STudentManager.ashx", { "operate": "modify", "sid": sid, "sNo": SNo.val(), "sName": SName.val(), "sPhone": SPhone.val(),
        "sSex": SSex.val(), "sEmail": SEmail.val(), "sQQ": SQQ.val(), "sClass": SClass.val(), "sYear": SYear.val(),
        "did": DepartmentId.val(), "mid": MajorId.val()
    },
                    function (data) {
                        if (data == "ok") {
                            return true;
                        } else {
                            return false;
                        }
                    });

    return ope;
}

//验证学号是否存在
function checkSNoDB(sno) {
    $.get("../../ashx/admin/STudentManager.ashx", { "operate": "checkTNo", "SNo": sno }, function (data) {
        if (data == "ok") {

        } else {
            $.omMessageBox.confirm({
                title: '提示',
                content: '您输入的教工号已存在！',
                onClose: function (v) { }
            });
        }
    });
}

function checkPhone() {
    var phoneValidata = validatePhone(SPhone.get(0), $("#SPhoneError").get(0));
    if (!phoneValidata) {
        $.omMessageBox.confirm({
            title: '提示',
            content: '请输入正确的电话号码！',
            onClose: function (v) {

            }
        });
    }
}

function checkEmail() {//email验证
    var emailValidata = validateEmail(SEmail.get(0), $("#SEmailError").get(0));
    if (!emailValidata) {
        $.omMessageBox.confirm({
            title: '提示',
            content: '请输入正确的邮箱格式！',
            onClose: function (v) {

            }
        });
    }
}

function checkQQ() {
    var qqValidata = validateQQ(SQQ.get(0), $("#SQQError").get(0));
    if (!qqValidata) {
        $.omMessageBox.confirm({
            title: '提示',
            content: '请输入正确的QQ格式！',
            onClose: function (v) {

            }
        });
    }
}


function checkTNo() {
    var numFieldValidata = validataNumField(SNo.get(0), $("#SNoError").get(0));
    if (!numFieldValidata) {
        $.omMessageBox.confirm({
            title: '提示',
            content: '请输入1~20位数字串！',
            onClose: function (v) {

            }
        });
    }
    checkSNoDB(SNo.val());
}

//清空
function clear() {
    $("#addNew input").val("");
    $("#addNew textarea").val("");
    $("#addNew select").val("");
}
