// JavaScript Document
$(function(){
		/*********左侧折叠菜单*********/
		var $menudts = $("#subNav dl dt");
		var $menudds = $("#subNav dl dd");
		$("#subNav dl:not(:first) dd").hide();
		$("#subNav dl:first dt").addClass("menu-header-actived");
		$("#subNav dl:first span").addClass("menu-header-icon-actived");
		
		$menudts.click(function(){
			$(this).toggleClass("menu-header-actived");
			$(this).children("span").toggleClass("menu-header-icon-actived");
			$(this).siblings("dd").toggle();
		});
		$menudds.click(function(){
			$(this).addClass("menu-list-actived").siblings("dd").removeClass("menu-list-actived");
			$(this).parent().siblings().children("dd").removeClass("menu-list-actived")
		});
		/*********左侧折叠菜单*********/
		
		/*********头部一级菜单*********/
		var $headerlis = $(".nav-ul li");
		$(".nav-ul li:first").addClass("nav-ul-li-actived");
		$headerlis.click(function(){
			$(this).addClass("nav-ul-li-actived").siblings("li").removeClass("nav-ul-li-actived");
		});
		/*********头部一级菜单*********/
		
	})