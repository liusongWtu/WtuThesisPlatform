// JavaScript Document
$(function () {
    /**********输入框效果**********/
    $(".search-input").click(function () {
        $(this).parent().children("label").hide();
    }).blur(function () {
        if ($(this).val() == "") {
            $(this).parent().children("label").show();
        }
    });
     /**********点击展开选题详细信息效果**********/
    $(".topic-list tr:not('.nohover'):not(:first)").hover(function () {
        $(this).toggleClass("hover");
    }).click(function () {
        $(this).toggleClass("actived");
        $(this).next().toggleClass("show");
    });


    /**********公告点击之后**********/
    $(".notice li a").click(function () {

        $(this).removeClass("readstatus");

        $(this).parent().css("background", "none");

    });

    

});
