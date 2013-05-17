var DepartmentId;
var MajorId;
var CName;
var topicList;

$(function () {
    topicList = $("#topicList");
    DepartmentId = $(".DepartmentId");
    MajorId = $(".MajorId");
    CName = $(".MajorId");

    //初始化弹出框
    $("#AddNew").omDialog({
        autoOpen: false,
        height: 400,
        width: 550,
        modal: true
    });

    //添加用户
    $("#add").click(function () {
        //加载下拉列表
        loadDepartment(DepartmentId);
        loadMajor(MajorId, DepartmentId.val());
        DepartmentId.change(function () { loadMajor(MajorId, DepartmentId.val()); });
        $(".errorImg,.errorMsg").hide();
        $("#AddNew").omDialog({ title: "添加用户" });
        $("#AddNew").omDialog('open');
        $("#AddNew").omDialog({ buttons: [
            { text: "确定", click:
                function () {
                    var error = $("span.errorImg:visible").length;
                    if (error != 0) {
                        return;
                    } else {
                        if (addNewCount()) { //添加新用户成功
                            //关闭窗口
                            $("#AddNew").omDialog('close');
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
                            $("#AddNew input").val("");
                            $("#AddNew textarea").val("");
                        }
                    }
                }
            },
            { text: "取消", click:
                function () {
                    $("#AddNew").omDialog('close');
                }
            }
         ]
        });
        $(".addTable input,.addTable textarea").removeAttr("readonly");
        CName.blur(function () {
            checkCNameDB(CName.val());
        });
        Validata();
        $("#AddNew").omDialog({ onClose: function () {
            clear();
            $(".errorImg,.errorMsg").hide();
            CName.unbind("blur");
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


    //修改用户信息
    $(".modifyInfo").click(function () {
        bindModifyEvent(this);
    });
    //删除用户信息
    $(".deleteOne").click(function () {
        bindDeleteEvent(this);
    });

});


function bindModifyEvent(myThis) {
    $(".errorImg,.errorMsg").hide();
    var cId = $(myThis).parent().parent().attr("id");
    $("#AddNew").omDialog({ title: "修改信息" });
    $("#AddNew").omDialog({ buttons: [
                { text: "确定", click:
                    function () {
                        var error = $("span.errorImg:visible").length;
                        if (error != 0) {
                            return;
                        } else {
                            if (modifyCount(cId)) { //修改成功
                                //关闭窗口
                                $("#AddNew").omDialog('close');
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
                        $("#AddNew").omDialog('close');
                    }
                }
            ]
    });
    $("#AddNew").omDialog('open');
    setInfo(cId, "modify");
    $(".addTable input,.addTable textarea").removeAttr("readonly");
    $("#AddNew").omDialog({ onClose: function () {
        CName.unbind("blur");
        $(".errorImg,.errorMsg").hide();
        clear();
    }
    });

}



function bindDeleteEvent(myThis) {
    var $myThis = $(myThis);
    var cId = $(myThis).parent().parent().attr("id");
    $.omMessageBox.confirm({
        title: '确认删除？',
        content: '确定要删除该用户信息？',
        onClose: function (value) {
            if (value) {
                if (deleteCount(cId)) {//删除信息成功
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


function setInfo(cId, operate) {
    $.get("../../ashx/admin/ClassManager.ashx", { "operate": "getAInfo", "classId": cId }, function (data) {
        //将返回的json数组字符串，转成 javascript的 数组对象
        info = eval("(" + data + ")");
        CName.val(info.CName);
        if (operate == "modify") {
            loadDepartment(DepartmentId);
            DepartmentId.val(info.Department.DId);
            DepartmentId.change(function () { loadMajor(MajorId, DepartmentId.val()); });
            loadMajor(MajorId, info.Department.DId);
            MajorId.val(info.Major.MId);
            CName.blur(function () {
                var newName = CName.val();
                if (info.CName != newName) {
                    checkCNameDB(newName);
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
        url: "../../ashx/admin/ClassManager.ashx",
        data: "operate=addNew&CName=" + CName.val() + "&MajorId=" + MajorId.val(),
        async: false,
        success: function (data) {
            var jsonArr = eval("(" + data + ")");
            if (jsonArr.result == "ok") {
                result = true;
                topicList.append("<tr class='list-content' id=" + jsonArr.id +
                "><td><input type='checkbox' name='topiclist' /></td><td class='first'>" + CName.val() +
                "</td><td>" + MajorId.find("option:selected").text() +
                "</td>+<td>0</td><td><a href='#' class='modifyInfo' onclick='bindModifyEvent(this)'>修改</a></td><td><a href='#' class='deleteOne' onclick='bindDeleteEvent(this)'>删除</a></td></tr>");
            } else {
                result = false;
            }
        }
    });
    return result;
}

//删除用户
function deleteCount(cid) {
    var result = false;
    $.ajax({ data: "post",
        url: "../../ashx/admin/ClassManager.ashx",
        data: "operate=del&cid=" + cid,
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
function modifyCount(cid) {//修改用户
    var result = false;
    $.ajax({ data: "get",
        url: "../../ashx/admin/ClassManager.ashx",
        data: "operate=modify&cid=" + cid + "&CName=" + CName.val() + "&MajorId=" + MajorId.val(),
        async: false,
        success: function (data) {
            if (data == "ok") {
                $("#" + did).children().eq(1).text(CName.val());
                $("#" + did).children().eq(2).text(MajorId.find("option:selected").text());
                result = true;
            } else {
                result = false;
            }
        }
    });
    return result;
}

//验证学号是否存在
function checkCNameDB(cname) {
    $.get("../../ashx/admin/ClassManager.ashx", { "operate": "checkName", "CName": cname }, function (data) {
        if (data == "ok") {

        } else {
            CName.parent().next().children("span.errorImg").css("display", "block");
            CName.parent().next().children("span.errorMsg").text("您输入的班级已存在");
            return;
        }
    });
}
//清空
function clear() {
    $("#AddNew input").val("");
    $("#AddNew textarea").val("");
    $("#AddNew select").val("");
}
