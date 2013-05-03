// JavaScript Document
$(function () {
    


    /**********公告点击之后**********/
    $(".notice li a").click(function () {

        $(this).removeClass("readstatus");

        $(this).parent().css("background", "none");

    });

    

});
