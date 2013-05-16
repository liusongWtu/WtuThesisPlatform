//加载院系下拉框,参数均为jquery对象
function loadDepartment(sltDepartment) {
    $.ajax({ data: "get", url: "../ashx/common/LoadSelect.ashx", data: "operate=getDepartment", async: false, success: function (data) {
        var dataJsonArr = eval("(" + data + ")");
        sltDepartment.empty();
        sltDepartment.append("<option selected=\"selected\" value=\"" + dataJsonArr[0].DId + "\">" + dataJsonArr[0].DName + "</option>");
        for (var i = 1; i < dataJsonArr.length; i++) {
            sltDepartment.append("<option value=\"" + dataJsonArr[i].DId + "\">" + dataJsonArr[i].DName + "</option>");
        }
    }
    });
}

//加载专业下拉框
function loadMajor(sltMajor, departmentId) {
    $.ajax({ data: "get", url: "../ashx/common/LoadSelect.ashx", data: "operate=getMajor&did=" + departmentId, async: false, success: function (data) {
        var dataJsonArr = eval("(" + data + ")");
        sltMajor.empty();
        sltMajor.append("<option  selected=\"selected\" value=\"" + dataJsonArr[0].MId + "\">" + dataJsonArr[0].MName + "</option>");
        for (var i = 1; i < dataJsonArr.length; i++) {
            sltMajor.append("<option value=\"" + dataJsonArr[i].MId + "\">" + dataJsonArr[i].MName + "</option>");
        }
    }
    });
}

//加载班级下拉框
function loadClass(sltClass, majorId) {
    $.ajax({ data: "get", url: "../ashx/common/LoadSelect.ashx", data: "operate=getClass&mid=" + majorId, async: false, success: function (data) {
        var dataJsonArr = eval("(" + data + ")");
        sltClass.empty();
        sltClass.append("<option selected=\"selected\" value=\"" + dataJsonArr[0].CId + "\">" + dataJsonArr[0].CName + "</option>");
        for (var i = 1; i < dataJsonArr.length; i++) {
            sltClass.append("<option value=\"" + dataJsonArr[i].CId + "\">" + dataJsonArr[i].CName + "</option>");
        }
    }
    });
}
