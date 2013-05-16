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
var topicList;

$(function () {
    topicList = $("#topicList");
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
        $(".errorImg,.errorMsg").hide();
        SSex.empty();
        SSex.append("<option>男</option><option>女</option>");
        loadDepartment(DepartmentId);
        loadMajor(MajorId, DepartmentId.val());
        loadClass(SClass, MajorId.val());
        DepartmentId.change(function () { loadMajor(MajorId, DepartmentId.val()); });
        MajorId.change(function () { loadClass(SClass, MajorId.val()); });
        $("#StuAddNew").omDialog({ title: "添加用户" });
        $("#StuAddNew").omDialog('open');
        $("#StuAddNew").omDialog({ buttons: [
            { text: "确定", click:
                function () {
                    var error = $("span.errorImg:visible").length;
                    if (error != 0) {
                        return;
                    } else {
                        if (addNewCount()) { //添加新用户成功
                            //关闭窗口
                            $("#StuAddNew").omDialog('close');
                            $.omMessageTip.show({ content: '添加成功！', timeout: 1000, type: 'success' });
                        }
                        else {
                            $.omMessageTip.show({ content: '添加失败！', timeout: 1000, type: 'error' });
                        }
                    }

                }
            },
            { text: "继续添加", click:
                function () {
                    var error = $("span.errorImg:visible").length;
                    if (error != 0) {
                        return;
                    } else {
                        if (addNewCount()) {//添加成功
                            $.omMessageTip.show({ content: '添加成功！', timeout: 1000, type: 'success' });
                            $("#StuAddNew input").val("");
                            $("#StuAddNew textarea").val("");
                        }
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
        SNo.blur(function () {
            checkSNoDB(SNo.val());
        });
        Validata();
        $("#StuAddNew").omDialog({ onClose: function () {
            clear();
            $(".errorImg,.errorMsg").hide();
            SNo.unbind("blur");
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
        bindCheckEvent(this);
    });


    //修改用户信息
    $(".modifyInfo").click(function () {
        bindModifyEvent(this);
    });

    //重置密码
    $(".resetPwd").click(function () {
        bindResetEvent(this);
    });

    //删除用户信息
    $(".deleteOne").click(function () {
        bindDeleteEvent(this);
    });

});

function bindCheckEvent(myThis) {
    $(".errorImg,.errorMsg").hide();
    var stuId = $(myThis).parent().parent().attr("id");
    $("#StuAddNew").omDialog({ title: "用户信息" });
    $("#StuAddNew").omDialog({ buttons: {} });
    $("#StuAddNew").omDialog('open');
    setInfo(stuId, "detail");
    $(".addTable input,.addTable textarea").attr("readonly", "readonly");
    $("#StuAddNew").omDialog({ onClose: function () { clear(); } });
}


function bindModifyEvent(myThis) {
    $(".errorImg,.errorMsg").hide();
    var stuId = $(myThis).parent().parent().attr("id");
    $("#StuAddNew").omDialog({ title: "修改信息" });
    $("#StuAddNew").omDialog({ buttons: [
                { text: "确定", click:
                    function () {
                        var error = $("span.errorImg:visible").length;
                        if (error != 0) {
                            return;
                        } else {
                            if (modifyCount(stuId)) { //修改成功
                                //关闭窗口
                                $("#StuAddNew").omDialog('close');
                                $.omMessageTip.show({ content: '修改成功！', timeout: 1000, type: 'success' });
                            }
                            else {
                                $.omMessageTip.show({ content: '修改失败！', timeout: 1000, type: 'error' });
                            }
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
    $("#StuAddNew").omDialog({ onClose: function () {
        SNo.unbind("blur");
        $(".errorImg,.errorMsg").hide();
        clear();
    }
    });

}



function bindDeleteEvent(myThis) {
    var $myThis = $(myThis);
    var stuId = $(myThis).parent().parent().attr("id");
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
}

function bindResetEvent(myThis) {
    var stuId = $(myThis).parent().parent().attr("id");
    $.omMessageBox.confirm({
        title: '密码重置？',
        content: '确定要重置该用户密码？',
        onClose: function (value) {
            if (value) {
                $.post("../../ashx/admin/StudentManager.ashx", { "operate": "resetPwd", "sid": stuId }, function (data) {
                    if (data == "ok") {
                        $.omMessageTip.show({ content: '重置成功！', timeout: 1000, type: 'success' });
                    } else {
                        $.omMessageTip.show({ content: '重置失败！', timeout: 1000, type: 'error' });
                    }
                });
            }
        }
    });
    
}

function setInfo(stuId, operate) {
    $.get("../../ashx/admin/StudentManager.ashx", { "operate": "getAInfo", "studentId": stuId }, function (data) {
        //将返回的json数组字符串，转成 javascript的 数组对象
        info = eval("(" + data + ")");
        SNo.val(info.SNo);
        SName.val(info.SName);
        SPhone.val(info.SPhone);
        SEmail.val(info.SEmail);
        SQQ.val(info.SQQ);
        SYear.val(info.SYear);
        if (operate == "detail") {
            SSex.empty();
            SSex.append("<option selected='selected'>" + info.SSex + "</option>");
            SClass.empty();
            SClass.append("<option selected='selected'>" + info.ClassInfo.CName + "</option>");
            DepartmentId.empty();
            DepartmentId.append("<option selected='selected'>" + info.Department.DName + "</option>");
            MajorId.empty();
            MajorId.append("<option selected='selected'>" + info.Major.MName + "</option>");
        } else if (operate == "modify") {
            SSex.empty();
            SSex.append("<option>男</option><option>女</option>");
            loadDepartment(DepartmentId); //加载院系下拉列表
            DepartmentId.find("option[value=" + info.Department.DId + "]").attr("selected", "selected");
            DepartmentId.change(function () { loadMajor(MajorId, DepartmentId.val()); loadClass(SClass, MajorId.val()); });
            loadMajor(MajorId, info.Department.DId); //加载专业下拉列表
            MajorId.val(info.Major.MId);
            MajorId.change(function () { loadClass(SClass, MajorId.val()); });
            loadClass(SClass, MajorId.val()); //加载班级下拉列表
            SClass.val(info.ClassInfo.CId);
            SNo.blur(function () {
                var newNo = SNo.val();
                if (info.SNo != newNo) {
                    checkSNoDB(SNo.val());
                }
            });
            Validata();
        }
    });
}

//添加新用户
function addNewCount() {
    var result = false;
    $.ajax({ data: "post",
        url: "../../ashx/admin/STudentManager.ashx",
        data: "operate=addNew&sNo=" + SNo.val() + "&sName=" + SName.val() + "&sPhone=" + SPhone.val() +
                "&sSex=" + SSex.val() + "&sEmail=" + SEmail.val() + "&sQQ=" + SQQ.val() + "&cid=" + SClass.val() +
                "&sYear=" + SYear.val() + "&did=" + DepartmentId.val() + "&mid=" + MajorId.val(),
        async: false,
        success: function (data) {
            var jsonArr = eval("(" + data + ")");
            if (jsonArr.result == "ok") {
                result = true;
                topicList.append("<tr class='list-content' id=" + jsonArr.id +
                "><td><input type='checkbox' name='topiclist' /></td><td class='first'>" + SNo.val() +
                "</td><td>" + SName.val() +
                "</td><td>" + DepartmentId.find("option:selected").text() +
                "</td><td>" + MajorId.find("option:selected").text() +
                "</td><td>" + SClass.find("option:selected").text() +
                "</td><td>否</td><td><a href='#' class='checkDetail' onclick='bindCheckEvent(this)'>查看详情</a></td><td><a href='#' class='resetPwd'>重置</a></td><td><a href='#' class='modifyInfo' onclick='bindModifyEvent(this)'>修改</a></td><td><a href='#' class='deleteOne' onclick='bindDeleteEvent(this)'>删除</a></td></tr>");
            } else {
                result = false;
            }
        }
    });
    return result;
}

//删除用户
function deleteCount(sid) {
    var result = false;
    $.ajax({ data: "post",
        url: "../../ashx/admin/STudentManager.ashx",
        data: "operate=del&sid=" + sid,
        async: false,
        success: function (data) {
            if (data == "ok") {
                result = true;
            } else {
                result = false;
            }
        }
    });
    return result;
}
function modifyCount(sid) {//修改用户
    var result = false;
    $.ajax({ data: "get",
        url: "../../ashx/admin/StudentManager.ashx",
        data: "operate=modify&sid=" + sid + "&sNo=" + SNo.val() + "&sName=" + SName.val() + "&sPhone=" + SPhone.val() +
                "&sSex=" + SSex.val() + "&sEmail=" + SEmail.val() + "&sQQ=" + SQQ.val() + "&cid=" + SClass.val() + "&sYear=" + SYear.val() +
                "&did=" + DepartmentId.val() + "&mid=" + MajorId.val(),
        async: false,
        success: function (data) {
            if (data == "ok") {
                $("#" + sid).children().eq(1).text(SNo.val());
                $("#" + sid).children().eq(2).text(SName.val());
                $("#" + sid).children().eq(3).text(DepartmentId.find("option:selected").text());
                $("#" + sid).children().eq(4).text(MajorId.find("option:selected").text());
                $("#" + sid).children().eq(5).text(SClass.find("option:selected").text());
                result = true;
            } else {
                result = false;
            }
        }
    });
    return result;
}

//验证学号是否存在
function checkSNoDB(sno) {
    $.get("../../ashx/admin/STudentManager.ashx", { "operate": "checkTNo", "SNo": sno }, function (data) {
        if (data == "ok") {

        } else {
            SNo.parent().next().children("span.errorImg").css("display", "block");
            SNo.parent().next().children("span.errorMsg").text("您输入的学号已存在");
            return;
        }
    });
}
//清空
function clear() {
    $("#StuAddNew input").val("");
    $("#StuAddNew textarea").val("");
    $("#StuAddNew select").val("");
}
