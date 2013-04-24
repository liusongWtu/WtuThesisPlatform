// JavaScript Document
$(function () {
    /*********左侧折叠菜单*********/
    var $menudts = $("#subNav dl dt");
    var $menudds = $("#subNav dl dd");
    // $("#subNav dl: dd").hide();
    // $("#subNav dl:not(:first) dd").hide();
    // $("#subNav dl:first dt").addClass("menu-header-actived");
    //$("#subNav dl:first span").addClass("menu-header-icon-actived");
    $menudts.each(function () {
        if ($(this).hasClass("close")) {//有close样式，则折叠样式
            $(this).removeClass("menu-header-actived");
            $(this).children("span").removeClass("menu-header-icon-actived");
            $(this).siblings("dd").hide();
        }
    });

    $menudts.click(function () {
        $(this).toggleClass("menu-header-actived");
        $(this).children("span").toggleClass("menu-header-icon-actived");
        $(this).siblings("dd").toggle();
        //记录导航状态
        setState();
    });
    $menudds.click(function () {
        $(this).addClass("menu-list-actived").siblings("dd").removeClass("menu-list-actived");
        $(this).parent().siblings().children("dd").removeClass("menu-list-actived");
    });

    /*
    $("#201").addClass("menu-list-actived").siblings("dd").removeClass("menu-list-actived");
    $("#201").parent().siblings().children("dd").removeClass("menu-list-actived");
    */


    /*********左侧折叠菜单*********/

    /*********头部一级菜单*********/
    var $headerlis = $(".nav-ul li");
    $(".nav-ul li:first").addClass("nav-ul-li-actived");
    $headerlis.click(function () {
        $(this).addClass("nav-ul-li-actived").siblings("li").removeClass("nav-ul-li-actived");
    });
    /*********头部一级菜单*********/

})

//记录导航状态
function setState() {
    var operate = false;

    alert($(this).attr("id"));
    operate = $(this).hasClass("open");
    if (operate) {//若展开状态
        $.post("../ashx/SaveTreeState.ashx", { "id": $(this).attr("id"), "operate": "0" }, showResult(data, status));
    } else {
        $.post("../ashx/SaveTreeState.ashx", { "id": $(this).attr("id"), "operate": "1" }, showResult(data, status));
    }
}

//操作结果显示（异常才显示）
function showResult(data, status) {
    if (status == "success") {//服务器运行正常
        if (data != "ok") {
            $.omMessageTip.show({ content: '操作失败！', timeout: 1000, type: 'error' });
        }
    } else {
        $.omMessageTip.show({ content: '系统繁忙！', timeout: 1000, type: 'error' });
    }
}