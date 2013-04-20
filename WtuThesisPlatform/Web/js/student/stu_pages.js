// JavaScript Document
$(function(){
	/**********�����Ч��**********/
	$(".search-input").click(function(){
		$(this).parent().children("label").hide();
	}).blur(function(){
		if($(this).val()==""){
			$(this).parent().children("label").show();
		}
	});
	/**********�����Ч��**********/
	
	/**********�ղ��Լ�ѡ��Ч��**********/
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
	/**********ȫѡЧ��**********/
	
	/**********һ���ղ�Ч��**********/
	$("#clickToStore").click(function(){
		$.confirm({
			'title'		: 'ȷ���ղ�',
			'message'	: 'ȷ��Ҫ����ѡ���ղأ�',
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
	/**********һ���ղ�Ч��**********/
	
	/**********���չ��ѡ����ϸ��ϢЧ��**********/
	$(".topic-list tr:not('.nohover'):not(:first)").hover(function(){
		$(this).toggleClass("hover");
	}).click(function(){
		$(this).toggleClass("actived");
		$(this).next().toggleClass("show");
	})
	/**********���չ��ѡ����ϸ��ϢЧ��**********/
	
	
	/**********�޸ĸ�����ϢЧ��**********/
	$("#mInfo").click(function(){
		$(".stu-info input").addClass("active")
		                    .click(function(){
								$(this).focus();
								$(this).select();
							});	
		var addDiv = $("<div id='button'><button id='modify-ok' class='modify-ok button dis-inline-block'></button><button id='modify-no' class='modify-no button dis-inline-block'></button></div>");
		$(".stu-info").append(addDiv);
		$("#modify-ok").click(function(){
			alert("�޸ĳɹ�");
		})
		$("#modify-no").click(function(){
			$("#button").remove();
			$(".stu-info input").removeClass("active")
		})
	})
	/**********�޸ĸ�����ϢЧ��**********/
	/**********�޸�����**********/
	$("#psd-modify-ok").click(function(){
		//�޸�����
		alert("�޸�����");
	});
	/**********�޸�����**********/
	
});