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

    $("#addNew").omDialog({
        autoOpen: false,
        height: 400,
        width: 550,
        modal: true
    });


    $("#add").click(function () {//添加
        loadDepartment(DepartmentId, MajorId); //加载下拉列表
        DepartmentId.change(function () { loadMajor(MajorId,DepartmentId.val()); });
        $("#addNew").omDialog({ title: "添加用户" });
        $("#addNew").omDialog({ buttons: [
            { text: "确定", click:
                function () {

                    if (addNewCount()) { //添加新用户成功
                        //关闭窗口
                        $("#addNew").omDialog('close');
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
                        $("#addNew input").val("");
                        $("#addNew textarea").val("");
                    }
                }
            },
            { text: "取消", click:
                function () {
                    $("#addNew").omDialog('close');
                }
            }
         ]
        });
        $("#addNew").omDialog('open');
        $(".addTable input,.addTable textarea").removeAttr("readonly");       

    });
    $("#delete").click(function () {//批量删除
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
                            if (deleteCount($(this))) {//数据库删除成功
                                $(this).parent().parent().remove();
                            }
                        })
                    }
                }
            });
        }
    });

    $(".checkDetail").click(function () { //查看详情
        var teaId = $(this).parent().parent().attr("id");
        $("#addNew").omDialog({ title: "用户信息" });
        $("#addNew").omDialog({ buttons: {} });
        $("#addNew").omDialog('open');
        setInfo(teaId);
        $(".addTable input,.addTable textarea").attr("readonly", "readonly");
        $("#addNew").omDialog({onClose : function() {clear()}});
    });

    $(".modifyInfo").click(function () { //修改信息
        var teaId = $(this).parent().parent().attr("id");
        $("#addNew").omDialog({ title: "修改信息" });
        $("#addNew").omDialog({ buttons: [
            { text: "确定", click:
                function () {
                    if (modifyCount()) { //修改成功
                        //关闭窗口
                        $("#addNew").omDialog('close');
                        $.omMessageTip.show({ content: '修改成功！', timeout: 1000, type: 'success' });
                    }
                    else {
                        $.omMessageTip.show({ content: '修改失败！', timeout: 1000, type: 'error' });
                    }
                }
            },

            { text: "取消", click:
                function () {
                    $("#addNew").omDialog('close');
                }
            }
         ]

        });
        $("#addNew").omDialog('open');
        setInfo(teaId);
        $(".addTable input,.addTable textarea").removeAttr("readonly");

    })
    $(".deleteOne").click(function () {//删除信息
        var $myThis = $(this);
        $.omMessageBox.confirm({
            title: '确认删除？',
            content: '确定要删除该用户信息？',
            onClose: function (value) {
                if (value) {
                    if (deleteCount()) {//删除信息成功
                        $myThis.parent().parent().remove();
                        $.omMessageTip.show({ content: '删除成功！', timeout: 1000, type: 'success' });
                    }
                    else {
                        $.omMessageTip.show({ content: '删除失败！', timeout: 1000, type: 'error' });
                    }
                }
            }
        });
    })
});

function getInfo() {
    var info = { 'TNo': TNo.val(), 'TSex': TSex.val(), 'TName': TName.val(), 'TPhone': TPhone.val(), 'TEmail': TEmail.val(), 'TQQ': TQQ.val(), 'TZhiCheng': TZhiCheng.val(), 'TTeachNum': TTeachNum.val(),'DepartmentId': DepartmentId.val(),'MajorId': MajorId.val(), 'TTeachCourse': TTeachCourse.val(), 'TResearchFields': TResearchFields.val() };
    return info;
}

function setInfo(teaId){
    $.get("../../ashx/admin/TeacherManager.ashx", { "operate": "getAInfo", "teacherId": teaId }, function (data) {
        //将返回的json数组字符串，转成 javascript的 数组对象
        info = eval("(" + data + ")");
        TNo.val(info.TNo);
        TName.val(info.TName);
        TSex.val(info.TSex);
        TPhone.val(info.TPhone);
        TEmail.val(info.TEmail);
        TQQ.val(info.TQQ);
        TZhiCheng.val(info.TZhiCheng);
        TTeachNum.val(info.TTeachNum);
        DepartmentId.append("<option selected='selected'>"+info.Department.DName+"</option>");
        MajorId.append("<option selected='selected'>"+info.Major.MName+"</option>");
        TTeachCourse.text(info.TTeachCourse);
        TResearchFields.text(info.TResearchFields);
    });
}
function addNewCount() {//添加新用户
    var result = false;
    $.post("../../ashx/admin/TeacherManager.ashx",
            { "operate": "addNew", "tUserName": TUserName.val(), "tName": TName.val(), "tPhone": TPhone.val(),
               "tEmail":TEmail.val(),"tQQ":TQQ.val(),"tZhiCheng":TZhiCheng.val(),"tTeachNum":TTeachNum
                 },
            function (data) { });
    return result;
}
function deleteCount() {//删除用户
    return true;
}
function modifyCount() {//修改用户
    return true;
}
function clear() {
    TNo.val("");
    TName.val("");
    TSex.val("");
    TPhone.val("");
    TEmail.val("");
    TQQ.val("");
    TZhiCheng.val("");
    TTeachNum.val("");
    DepartmentId.empty();
    MajorId.empty();
    TTeachCourse.text("");
    TResearchFields.text("");
}