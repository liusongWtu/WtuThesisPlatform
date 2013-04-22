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
	/**********登出效果**********/
	$("#logout").click(function(){
		$.confirm({
			'title'		: '确定退出？',
			'message'	: '确定要退出系统？',
			'buttons'	: {
				'Yes'	: {
					'class'	: 'blue',
					'action': function(){
						self.location='index.html';
					}
				},
				'No'	: {
					'class'	: 'gray',
					'action': function(){}	// Nothing to do in this case. You can as well omit the action property.
				}
			}
		});
	})
	/**********收藏以及选题效果**********/
	$(".store-icon").click(function(e){
		$(this).toggleClass("store-icon-actived");
		e.stopPropagation();
	})
	$(".select-icon").click(function(e){
		$(this).toggleClass("select-icon-actived");
		e.stopPropagation();
	});
	/**********�ղ��Լ�ѡ��Ч��**********/
	
	
	/**********ȫѡЧ��**********/
	$("#checkAll").click(function(){
		$("input[name='topiclist']").attr("checked",$(this).attr("checked"));
	});
	
	/**********全选效果**********/
	$("#clickToStore").click(function(){
		$.confirm({
			'title'		: '确定收藏',
			'message'	: '确定要将所选项收藏？',
			'buttons'	: {
				'Yes'	: {
					'class'	: 'blue',
					'action': function(){
						var flag = false;
						$("input[name='topiclist']:checked").each(function(){
							var $span = $(this)	.parent().siblings("td").children(".store-icon");
							if(!($span.hasClass("store-icon-actived"))){
								$span.addClass("store-icon-actived");
								flag = true;
							}
						});
						if(!flag){
							alert("您已经收藏了这些选题，无需重复收藏！");
						}
					}
				},
				'No'	: {
					'class'	: 'gray',
					'action': function(){}	// Nothing to do in this case. You can as well omit the action property.
				}
			}
		});
		
	});
	/**********һ���ղ�Ч��**********/
	
	/**********���չ��ѡ����ϸ��ϢЧ��**********/
	$(".topic-list tr:not('.nohover'):not(:first)").hover(function(){
		$(this).toggleClass("hover");
	}).click(function(){
		$(this).toggleClass("actived");
		$(this).next().toggleClass("show");
	});
	
	/**********点击展开选题详细信息效果**********/
	var flag = false;
	$("#mInfo").click(function(){
		console.log(flag);
		if(!flag){
			$(".stu-info input:not('#sName,#sNo')").removeAttr("readonly")
			                                       .addClass("active")
												   .click(function(){
														$(this).focus();
														});	
			var addDiv = $("<div id='button'><button id='modify-ok' class='modify-ok button dis-inline-block'></button><button id='modify-no' class='modify-no button dis-inline-block'></button></div>");
			flag = true;
			$(".stu-info").append(addDiv);
			$("#modify-ok").click(function(){
				alert("修改成功");
				$("#button").remove();
				$(".stu-info input").removeClass("active");
				flag = false;
			})
			$("#modify-no").click(function(){
				$("#button").remove();
				$(".stu-info input").removeClass("active");
				flag = false;
			})
		}
		
	});
	
	/**********修改密码**********/
	$("#psd-modify-ok").click(function(){
		//修改密码
		alert("修改密码");
	});
	/**********�޸�����**********/
	/**********����hasreaded**********/
	$(".notice li a").click(function(){
		$(this).removeClass("readstatus");
		$(this).parent().css("background","none");
	})
	/**********����hasreaded**********/
});