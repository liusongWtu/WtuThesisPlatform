//加载院系下拉框,参数均为jquery对象
function loadDepartment(sltDepartment, sltMajor) {
    $.get("../ashx/common/LoadSelect.ashx", { "getDM": "getDM" }, function (data) {
        var dataJsonArr = eval("(" + data + ")");
        sltDepartment.empty();
        sltDepartment.append("<option selected=\"selected\" value=\"" + dataJsonArr.department[0].DId + "\">" + dataJsonArr.department[0].DName + "</option>");
        for (var i = 1; i < dataJsonArr.major.length; i++) {
            sltDepartment.append("<option value=\"" + dataJsonArr.department[i].DId + "\">" + dataJsonArr.department[i].DName + "</option>");
        }
        sltMajor.empty();
        sltMajor.append("<option selected=\"selected\" value=\"" + dataJsonArr.major[0].MId + "\">" + dataJsonArr.major[0].MName + "</option>");
        for (var i = 1; i < dataJsonArr.major.length; i++) {
            sltMajor.append("<option value=\"" + dataJsonArr.major[i].MId + "\">" + dataJsonArr.major[i].MName + "</option>");
        }
    });
}
