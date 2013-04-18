(function($){
	
	$.confirm = function(params){
		
		if($('#confirmOverlay').length){
			// A confirm is already shown on the page:
			return false;
		}
		
		var buttonHTML = '';
		$.each(params.buttons,function(name,obj){
			
			// Generating the markup for the buttons:
			
			buttonHTML += '<a href="#" class="button '+obj['class']+'">'+name+'<span></span></a>';
			
			if(!obj.action){
				obj.action = function(){};
			}
		});
		
		var markup = [
			'<div id="confirmOverlay">',
			'<div id="confirmBox">',
			'<h1>',params.title,'</h1>',
			'<p>',params.message,'</p>',
			'<div id="confirmButtons">',
			buttonHTML,
			'</div></div></div>'
		].join('');
		
		$(markup).hide().appendTo('body').fadeIn();
		
		var _move=false;//移动标记
		var _x,_y;//鼠标离控件左上角的相对位置
		$("#confirmBox h1").click(function(){
		}).mousedown(function(e){
		   		_move=true;
				_x=e.pageX-parseInt($("#confirmBox").css("left"));
				_y=e.pageY-parseInt($("#confirmBox").css("top"));
				$("#confirmBox").fadeTo(20, 0.9);//点击后开始拖动并透明显示
	       });
		$(document).mousemove(function(e){
			if(_move){
				var x=e.pageX-_x;//移动时根据鼠标位置计算控件左上角的绝对位置
				var y=e.pageY-_y;
				$("#confirmBox").css({top:y,left:x});//控件新位置
			}
		}).mouseup(function(){
		  		_move=false;
				$("#confirmBox").fadeTo("fast", 1);//松开鼠标后停止移动并恢复成不透明
		  });
		
		var buttons = $('#confirmBox .button'),
			i = 0;

		$.each(params.buttons,function(name,obj){
			buttons.eq(i++).click(function(){
				
				// Calling the action attribute when a
				// click occurs, and hiding the confirm.
				
				obj.action();
				$.confirm.hide();
				return false;
			});
		});
	}

	$.confirm.hide = function(){
		$('#confirmOverlay').fadeOut(function(){
			$(this).remove();
		});
	}
	
})(jQuery);