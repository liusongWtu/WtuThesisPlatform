// JavaScript Document
$(function(){
	/**********输入框效果**********/
	$(".search-input").click(function(){
		$(this).parent().children("label").hide();
	}).blur(function(){
		if($(this).val()==""){
			$(this).parent().children("label").show();
		}
	});
	/**********输入框效果**********/
	
	/**********收藏以及选题效果**********/
	$(".store-icon").click(function(e){
		$(this).toggleClass("store-icon-actived");
		e.stopPropagation();
	})
	$(".select-icon").click(function(e){
		$(this).toggleClass("select-icon-actived");
		e.stopPropagation();
	});
	/**********收藏以及选题效果**********/
	
	
	/**********全选效果**********/
	$("#checkAll").click(function(){
		$("input[name='topiclist']").attr("checked",$(this).attr("checked"));
	});
	/**********全选效果**********/
	
	/**********一键收藏效果**********/
	$("#clickToStore").click(function(){
		$.confirm({
			'title'		: '确定收藏',
			'message'	: '确定要将所选项收藏？',
			'buttons'	: {
				'Yes'	: {
					'class'	: 'blue',
					'action': function(){
						$("input[name='topiclist']:checked").each(function(){
							$(this)	.parent().siblings("td").children(".store-icon").addClass("store-icon-actived");	
						});
					}
				},
				'No'	: {
					'class'	: 'gray',
					'action': function(){}	// Nothing to do in this case. You can as well omit the action property.
				}
			}
		});
		
	});
	/**********一键收藏效果**********/
	
	/**********点击展开选题详细信息效果**********/
	$(".topic-list tr:not('.nohover'):not(:first)").hover(function(){
		$(this).toggleClass("hover");
	}).click(function(){
		$(this).toggleClass("actived");
		$(this).next().toggleClass("show");
	})
	/**********点击展开选题详细信息效果**********/
	
	
	/**********修改个人信息效果**********/
	$("#mInfo").click(function(){
		$(".stu-info input").addClass("active")
		                    .click(function(){
								$(this).focus();
								$(this).select();
							});	
		var addDiv = $("<div id='button'><button id='modify-ok' class='modify-ok button dis-inline-block'></button><button id='modify-no' class='modify-no button dis-inline-block'></button></div>");
		$(".stu-info").append(addDiv);
		$("#modify-ok").click(function(){
			alert("修改成功");
		})
		$("#modify-no").click(function(){
			$("#button").remove();
			$(".stu-info input").removeClass("active")
		})
	})
	/**********修改个人信息效果**********/
	/**********修改密码**********/
	$("#psd-modify-ok").click(function(){
		//修改密码
		alert("修改密码");
	});
	/**********修改密码**********/
	
});