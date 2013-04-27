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
    /**********登出效果**********/
    $("#logout").click(function () {
        $.omMessageBox.confirm({

           title: '确认退出？',
            content: '确定要退出系统吗？',
            onClose: function (value) {
                if (value) {
                    self.location = "index.html";
                }
            }
        });
    })
    /**********收藏以及选题效果**********/
    $(".store-icon").click(function (e) {
        $(this).toggleClass("store-icon-actived");
        e.stopPropagation();
    })
    $(".select-icon").click(function (e) {
        $(this).toggleClass("select-icon-actived");
        e.stopPropagation();
    });



    /**********全选**********/
    $("#checkAll").click(function () {
        $("input[name='topiclist']").attr("checked", $(this).attr("checked"));
    });

    /**********一键收藏**********/
    $("#clickToStore").click(function () {
        $.confirm({
            'title': '确定收藏',
            'message': '确定要将所选项收藏？',
            'buttons': {
                'Yes': {
                    'class': 'blue',
                    'action': function () {
                        var flag = false;
                        $("input[name='topiclist']:checked").each(function () {
                            var $span = $(this).parent().siblings("td").children(".store-icon");
                            if (!($span.hasClass("store-icon-actived"))) {
                                $span.addClass("store-icon-actived");
                                flag = true;
                            }
                        });
                        if (!flag) {
                            alert("您已经收藏了这些选题，无需重复收藏！");
                        }
                    }
                },
                'No': {
                    'class': 'gray',
                    'action': function () { } // Nothing to do in this case. You can as well omit the action property.
                }
            }
        });

    });

    $(".topic-list tr:not('.nohover'):not(:first)").hover(function () {
        $(this).toggleClass("hover");
    }).click(function () {
        $(this).toggleClass("actived");
        $(this).next().toggleClass("show");
    });

    /**********点击展开选题详细信息效果**********/
    var flag = false;
    $("#mInfo").click(function () {
        console.log(flag);
        if (!flag) {
            $(".stu-info input:not('#ContentPlaceHolderBody_sName,#ContentPlaceHolderBody_sNo,#ContentPlaceHolderBody_sYear')").removeAttr("readonly")
			                                       .addClass("active")
												   .click(function () {
												       $(this).focus();
												   });
            var addDiv = $("<div id='button'><button id='modify-ok' class='modify-ok button dis-inline-block'></button><button id='modify-no' class='modify-no button dis-inline-block'></button></div>");
            flag = true;
            $(".stu-info").append(addDiv);
            $("#modify-ok").click(function () {
                
                $("#button").remove();
                $(".stu-info input").removeClass("active");
                flag = false;
                $.omMessageTip.show({ content: '修改成功！', timeout: 1000, type: 'success' });
            })
            $("#modify-no").click(function () {
                $("#button").remove();
                $(".stu-info input").removeClass("active");
                flag = false;
            })
        }

    });

   

    /**********公告点击之后**********/
    $(".notice li a").click(function () {

        $(this).removeClass("readstatus");

        $(this).parent().css("background", "none");

    });

    

    /**********删除收藏**********/
    $(".delete-icon").click(function () {
        var $myThis = $(this);
        $.omMessageBox.confirm({
            title: '确认删除？',
            content: '确定要删除该收藏？',
            onClose: function () {
                if ($myThis.parent().parent().remove()) {
                    //删除成功
                    $.omMessageTip.show({ content: '已删除对该选题的收藏！', timeout: 1000, type: 'alert' });
                }
            }
        });
    })
});
