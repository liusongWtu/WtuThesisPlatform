var TNo;
var TSex;
var TName;
var TPhone;
var TEmail;
var TQQ;
var TZhiCheng;
var TTeachNum;
var DepartmentId;
var MajorId;
var TTeachCourse;
var TResearchFields;
$(function () {
    TNo = $(".TNo");
    TSex = $(".TSex");
    TName = $(".TName");
    TPhone = $(".TPhone");
    TEmail = $(".TEmail");
    TQQ = $(".TQQ");
    TZhiCheng = $(".TZhiCheng");
    TTeachNum = $(".TTeachNum");
    DepartmentId = $(".DepartmentId");
    MajorId = $(".MajorId");
    TTeachCourse = $(".TTeachCourse");
    TResearchFields = $(".TResearchFields");
    //初始化弹出框
    $("#teaAddNew").omDialog({
        autoOpen: false,
        height: 400,
        width: 550,
        modal: true
    });
    //添加用户
    $("#add").click(function () {
        //初始化
        $(".errorImg,.errorMsg").hide();
        TSex.empty();
        TSex.append("<option>男</option><option>女</option>");
        loadDepartment(DepartmentId);
        loadMajor(MajorId, DepartmentId.val());
        DepartmentId.change(function () { loadMajor(MajorId, DepartmentId.val()); });
        $("#teaAddNew").omDialog({ title: "添加用户" });

        $("#teaAddNew").omDialog({ buttons: [
            { text: "确定", click:
                function () {
                    var error = $("span.errorImg:visible").length;
                    if (error != 0) {
                        return;
                    }
                    else {
                        if (addNewCount()) { //添加新用户成功
                            //关闭窗口
                            $("#teaAddNew").omDialog('close');
                            $.omMessageTip.show({ content: '添加成功！', timeout: 1000, type: 'success' });
                        }
                        else {
                            $.omMessageTip.show({ content: '添加失败！', timeout: 1000, type: 'error' });
                        }
                    }
                    window.location.reload();

                }
            },
            { text: "继续添加", click:
                function () {
                    var error = $("span.errorImg:visible").length;
                    if (error != 0) {
                        return;
                    }
                    else {
                        if (addNewCount()) {//添加成功
                            $.omMessageTip.show({ content: '添加成功！', timeout: 1000, type: 'success' });
                            $("#teaAddNew input").val("");
                            $("#teaAddNew textarea").val("");

                        }
                    }
                }
            },
            { text: "取消", click:
                function () {
                    $("#teaAddNew").omDialog('close');
                }
            }
         ]
        });
        $(".addTable input,.addTable textarea").removeAttr("readonly");
        $("#teaAddNew").omDialog('open');
        //验证
        TNo.blur(function () {
            checkTNoDB(TNo.val());
        })
        Validata();
        $("#teaAddNew").omDialog({ onClose: function () {
            clear();
            $(".errorImg,.errorMsg").hide();
            TNo.unbind("blur");

        }
        });

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
        $(".errorImg,.errorMsg").hide();
        var teaId = $(this).parent().parent().attr("id");
        $("#teaAddNew").omDialog({ title: "用户信息" });
        $("#teaAddNew").omDialog({ buttons: {} });
        $(".addTable input,.addTable textarea").attr("readonly", "readonly");
        $("#teaAddNew").omDialog('open');
        setInfo(teaId, "detail");
        $("#teaAddNew").omDialog({ onClose: function () {
            clear();
            $(".errorImg,.errorMsg").hide();
        }
        });
    });


    //修改用户信息
    $(".modifyInfo").click(function () {
        //初始化
        $(".errorImg,.errorMsg").hide();
        var teaId = $(this).parent().parent().attr("id");
        $("#teaAddNew").omDialog({ title: "修改信息" });
        $("#teaAddNew").omDialog({ buttons: [
                { text: "确定", click:
                    function () {
                        var error = $("span.errorImg:visible").length;
                        if (error != 0) {
                            return;
                        } else {
                            if (modifyCount(teaId)) { //修改成功
                                //关闭窗口
                                $("#teaAddNew").omDialog('close');
                                $.omMessageTip.show({ content: '修改成功！', timeout: 1000, type: 'success' });

                            }
                            else {
                                $.omMessageTip.show({ content: '修改失败！', timeout: 1000, type: 'error' });
                            }
                        }
                        window.location.reload();
                    }
                },

                { text: "取消", click:
                    function () {
                        $("#teaAddNew").omDialog('close');
                    }
                }
            ]
        });
        $("#teaAddNew").omDialog('open');
        setInfo(teaId, "modify");
        $(".addTable input,.addTable textarea").removeAttr("readonly");
        $("#teaAddNew").omDialog({ onClose: function () {
            TNo.unbind("blur");
            $(".errorImg,.errorMsg").hide();
            clear();
        }
        });
    });

    //重置密码
    $(".resetPwd").click(function () {
        var teaId = $(this).parent().parent().attr("id");
        $.omMessageBox.confirm({
            title: '密码重置？',
            content: '确定要重置该用户密码？',
            onClose: function (value) {
                if (value) {
                    $.post("../../ashx/admin/TeacherManager.ashx", { "operate": "resetPwd", "tid": teaId }, function (data) {
                        if (data == "ok") {
                            $.omMessageTip.show({ content: '重置成功！', timeout: 1000, type: 'success' });
                        } else {
                            $.omMessageTip.show({ content: '重置失败！', timeout: 1000, type: 'error' });
                        }
                    });
                }
            }
        });
    });

    //删除用户信息
    $(".deleteOne").click(function () {
        var $myThis = $(this);
        var teaId = $(this).parent().parent().attr("id");
        $.omMessageBox.confirm({
            title: '确认删除？',
            content: '确定要删除该用户信息？',
            onClose: function (value) {
                if (value) {
                    if (deleteCount(teaId)) {//删除信息成功
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
    
function getInfo() {
    var info = { 'TNo': TNo.val(), 'TSex': TSex.val(), 'TName': TName.val(), 'TPhone': TPhone.val(), 'TEmail': TEmail.val(), 'TQQ': TQQ.val(), 'TZhiCheng': TZhiCheng.val(), 'TTeachNum': TTeachNum.val(), 'DepartmentId': DepartmentId.val(), 'MajorId': MajorId.val(), 'TTeachCourse': TTeachCourse.val(), 'TResearchFields': TResearchFields.val() };
    return info;
}


function setInfo(teaId, operate) {
    $.get("../../ashx/admin/TeacherManager.ashx", { "operate": "getAInfo", "teacherId": teaId }, function (data) {
        info = eval("(" + data + ")");
        TNo.val(info.TNo);
        TName.val(info.TName);
        TPhone.val(info.TPhone);
        TEmail.val(info.TEmail);
        TQQ.val(info.TQQ);
        TZhiCheng.val(info.TZhiCheng);
        TTeachNum.val(info.TTeachNum);
        TTeachCourse.val(info.TTeachCourse);
        TResearchFields.val(info.TResearchFields);
        if (operate == "detail") {
            TSex.empty();
            TSex.append("<option selected='selected'>" + info.TSex + "</option>");
            DepartmentId.append("<option selected='selected'>" + info.Department.DName + "</option>");
            MajorId.append("<option selected='selected'>" + info.Major.MName + "</option>");
        } else if (operate == "modify") {
            TSex.empty();
            TSex.append("<option>男</option><option>女</option>");
            loadDepartment(DepartmentId); //加载下拉列表
            DepartmentId.find("option[value=" + info.Department.DId + "]").attr("selected", "selected");
            DepartmentId.change(function () { loadMajor(MajorId, DepartmentId.val()); });
            loadMajor(MajorId, info.Department.DId);
            MajorId.val(info.Major.MId);

            //验证
            var oldInfo = getInfo();
            
            TNo.blur(function () {
                var newNo = TNo.val();
                if (info.TNo != newNo) {
                    checkTNoDB(TNo.val());
                }
            });
            Validata();
        }

    });

}

function addNewCount() {//添加新用户
    var result = false;
    $.ajax({ data: "post",
        url: "../../ashx/admin/TeacherManager.ashx",
        data: "operate=addNew&tNo=" + TNo.val() + "&tName=" + TName.val() + "&tPhone=" + TPhone.val() + "&tSex=" + TSex.val() +
             "&tEmail=" + TEmail.val() + "&tQQ=" + TQQ.val() + "&tZhiCheng=" + TZhiCheng.val() + "&tTeachNum=" + TTeachNum.val() + "&tTeachCourse=" +
            TTeachCourse.val() + "&tResearchFields=" + TResearchFields.val() + "&did=" + DepartmentId.val() + "&mid=" + MajorId.val(),
        async: false,
        success: function (data) {
            var jsonArr = eval("(" + data + ")");
            if (jsonArr.result == "ok") {
                result = true;
            } else {
                result = false;
            }
        }
    });
    return result;
}

//删除用户
function deleteCount(tid) {
    var result = false;
    $.ajax({ data: "post", url: "../../ashx/admin/TeacherManager.ashx", data: "operate=del&tid=" + tid, async: false, success: function (data) {
        if (data == "ok") {
            result = true;
        } else {
            result = false;
        }
    }
    });
    return result;
}

//修改用户
function modifyCount(tid) {
    var ope = false;
    $.ajax({ type: "post",
        url: "../../ashx/admin/TeacherManager.ashx",
        data: "operate=modify&tid=" + tid + "&tNo=" + TNo.val() + "&tName=" + TName.val() + "&tPhone=" + TPhone.val() + "&tSex=" + TSex.val() +
             "&tEmail=" + TEmail.val() + "&tQQ=" + TQQ.val() + "&tZhiCheng=" + TZhiCheng.val() + "&tTeachNum=" + TTeachNum.val() + "&tTeachCourse=" +
            TTeachCourse.val() + "&tResearchFields=" + TResearchFields.val() + "&did=" + DepartmentId.val() + "&mid=" + MajorId.val(),
        async: false,
        success: function (data) {
            if (data == "ok") {
                ope = true;
            } else {
                ope = false;
            }
        }
    });

    return ope;
}

//验证工号是否存在
function checkTNoDB(tno) {
    $.get("../../ashx/admin/TeacherManager.ashx", { "operate": "checkTNo", "TNo": tno }, function (data) {
        if (data == "ok") {

        } else {
            TNo.parent().next().children("span.errorImg").css("display", "block");
            TNo.parent().next().children("span.errorMsg").text("您输入的教工号已存在");
            return;
        }
    });
}
//清空
function clear() {
    $("#teaAddNew input").val("");
    $("#teaAddNew textarea").val("");
    $("#teaAddNew select").val("");
}
