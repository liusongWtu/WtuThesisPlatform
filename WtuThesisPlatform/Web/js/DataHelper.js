//加载院系下拉框,参数均为jquery对象
function loadDepartment(sltDepartment) {
    $.ajax({ data: "get", url: "../ashx/common/LoadSelect.ashx", data: "operate=getDepartment", async: false, success: function (data) {
        var dataJsonArr = eval("(" + data + ")");
        sltDepartment.empty();
        sltDepartment.append("<option selected=\"selected\">----请选择----</option>");
        for (var i = 0; i < dataJsonArr.length; i++) {
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
        sltMajor.append("<option selected=\"selected\">----请选择----</option>");
        for (var i = 0; i < dataJsonArr.length; i++) {
            sltMajor.append("<option value=\"" + dataJsonArr[i].MId + "\">" + dataJsonArr[i].MName + "</option>");
        }
    }
    });
}
