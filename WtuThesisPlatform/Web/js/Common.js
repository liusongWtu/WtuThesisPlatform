﻿//使用浏览器兼容的方式创建 异步对象
function createXhr() {
    var xhobj = false;
    try {
        xhobj = new ActiveXObject("Msxml2.XMLHTTP"); // ie msxml3.0+
    } catch (e) {
        try {
            xhobj = new ActiveXObject("Microsoft.XMLHTTP"); //ie msxml2.6
        } catch (e2) {
            xhobj = false;
        }
    }
    if (!xhobj && typeof XMLHttpRequest != 'undefined') {// Firefox, Opera 8.0+, Safari
        xhobj = new XMLHttpRequest();
    }
    return xhobj;
}

//根据id获取标签
function gel(id) { return document.getElementById ? document.getElementById(id) : null; }
//根据name获取标签
function gelsBn(name) { return document.getElementsByName ? document.getElementsByName(name) : null; }
//根据Tag获取标签
function gelsBtn(tag) { return document.getElementsByTagName ? document.getElementsByTagName(tag) : null; }
//获取标签Value属性，参数标签id
function txt(id) { return gel(id).value; }
//设置标签Value属性,参数1：标签id；参数2：新值
function txtSet(id, value) { gel(id).value = value; }
//获取标签的innerHTML，参数标签id
function htm(id) { return gel(id).innerHTML; }
//设置标签的innerHTML
function htmSet(id, value) { gel(id).innerHTML = value; }  
//给指定标签innerHTML属性后面追加内容
function htmAppend(id, value) { gel(id).innerHTML += value; }
//在指定标签innerHTML属性前插入内容
function htmInsertFirst(id, value) { var now = gel(id).innerHTML; gel(id).innerHTML = value + now; }
//根据标签id设置焦点
function setFocus(id) { gel(id).focus(); }
//根据标签id移除标签
function removeNode(nid) { var t = gel(nid); t.parentNode.removeChild(t); }
//为控件绑定方法
function bindEvent(cid, ename, func) {//为控件a，事件名e，绑定方法f gel(a).onclick = f;
    eval("document.getElementById('" + cid + "')." + ename + " = function(){" + func + "};");
}

//删除字符两端的空白
function trim(s) {
    var count = s.length;
    var st = 0; // start 
    var end = count - 1; // end 
    if (s == "")
        return s;
    while (st < count) {
        if (s.charAt(st) == " ")
            st++;
        else
            break;
    }
    while (end > st) {
        if (s.charAt(end) == " ")
            end--;
        else break;
    }
    return s.substring(st, end + 1);
} 

//将序列化成json格式后日期(毫秒数)转成日期格式
function changeDateFormat(cellval) {
    var date = new Date(parseInt(cellval.replace("/Date(", "").replace(")/", ""), 10));
    var month = date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;
    var currentDate = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
    return date.getFullYear() + "-" + month + "-" + currentDate;
}

//使控件在屏幕中间显示
function beScreenCenter(pi) { gel(pi).style.left = window.screen.width / 2 - 150; gel(pi).style.top = window.screen.height / 2 - 150; }
//隐藏标签
function hideEle(eleId) { gel(eleId).style.display = "none"; }
//显示标签
function showEle(eleId) { gel(eleId).style.display = "block"; }
//返回鼠标位置（json格式）
function mousePosition(ev) {
    if (ev.pageX || ev.pageY) { return { x: ev.pageX, y: ev.pageY }; }
    return { x: ev.clientX + document.body.scrollLeft - document.body.clientLeft, y: ev.clientY + document.body.scrollTop - document.body.clientTop };
}
//
function getPositionPx(tid) { var t = gel(tid); var p = getObjPosition(t); return { top: p.top + "px", left: p.left + "px" }; }
function getPosition(tid) { var t = gel(tid); return getObjPosition(t); }
function getObjPosition(t) {
    var left = 0, top = 0;
    do { left += t.offsetLeft || 0; top += t.offsetTop || 0; t = t.offsetParent; } while (t);
    return { left: left, top: top }
}
//
function setPosition(tid, pos) { gel(tid).style.top = pos.top; gel(tid).style.left = pos.left; }
function getPageHeight() {
    var windowHeight
    if (self.innerHeight) {//all except Explorer
        windowHeight = self.innerHeight;
    } else if (document.documentElement && document.documentElement.clientHeight) { // Explorer 6 Strict Mode
        windowHeight = document.documentElement.clientHeight;
    } else if (document.body) {//other Explorers
        windowHeight = document.body.clientHeight;
    }
    return windowHeight
}
// getPageScroll() by quirksmode.com  : getPageScroll()[1]
function getPageScroll() {
    var xScroll, yScroll;
    if (self.pageYOffset) {
        yScroll = self.pageYOffset; xScroll = self.pageXOffset;
    } else if (document.documentElement && document.documentElement.scrollTop) {//Explorer6Strict
        yScroll = document.documentElement.scrollTop; xScroll = document.documentElement.scrollLeft;
    } else if (document.body) {// all other Explorers
        yScroll = document.body.scrollTop; xScroll = document.body.scrollLeft;
    }
    return { xScroll: xScroll, yScorll: yScroll };
}
function getObjectLeft(e) { var l = e.offsetLeft; while (e = e.offsetParent) l += e.offsetLeft; return l; }
function getObjectTop(e) { var t = e.offsetTop; while (e = e.offsetParent) t += e.offsetTop; return t; }
function HTMLEncode(html) {
    var temp = document.createElement("div");
    if (temp.textContent != null) temp.textContent = html;
    else temp.innerText = html;
    var output = temp.innerHTML;
    temp = null;
    return output;
}
function HTMLDecode(text) {
    var temp = document.createElement("div");
    temp.innerHTML = text;
    var output = temp.innerText || temp.textContent;
    temp = null;
    return output;
}
function escapeHTML(j) { return j.replace(/</g, '&lt;').replace(/>/g, '&gt;').replace(/ /g, '&nbsp;').replace(/"/g, '&quot;').replace(/'/g, '&dan;'); } //.replace(/&/g, '&amp;')
function unescapeHTML(h) { return h.replace(/&lt;/g, '<').replace(/&gt;/g, '>').replace(/&nbsp;/g, ' ').replace(/&quot;/g, '"').replace(/&dan;/g, '\''); } //.replace(/&amp;/g, '&')
function addEvent(obj, evType, fn) {
    if (obj.addEventListener) { obj.addEventListener(evType, fn, false); } else if (obj.attachEvent) { obj.attachEvent("on" + evType, fn); }
}
function removeEvent(obj, evType, fn) {
    if (obj.removeEventListener) { obj.removeEventListener(evType, fn, false); } else if (obj.detachEvent) { obj.detachEvent("on" + evType, fn); } else { alert("Handler could not be removed"); }
}
function getHttpParams(name) { var r = new RegExp("(\\?|#|&)" + name + "=([^&#]*)(&|#|$)"); var m = location.href.match(r); return (!m ? "" : m[2]); }
/**
* Code below taken from - http://www.evolt.org/article/document_body_doctype_switching_and_more/17/30655/
*
* Modified 4/22/04 to work with Opera/Moz (by webmaster at subimage dot com)
*
* Gets the full width/height because it's different for most browsers.
*/
function getViewportHeight() {
    if (window.innerHeight != window.undefined) return window.innerHeight;
    if (document.compatMode == 'CSS1Compat') return document.documentElement.clientHeight;
    if (document.body) return document.body.clientHeight;
    return window.undefined;
}
function getViewportWidth() {
    if (window.innerWidth != window.undefined) return window.innerWidth;
    if (document.compatMode == 'CSS1Compat') return document.documentElement.clientWidth;
    if (document.body) return document.body.clientWidth;
    return window.undefined;
}
//function doEventThing(eventTag) {
//    var event = eventTag || window.event;
//    var currentKey = event.charCode || event.keyCode; //ff||ie
//    var eventSource = window.event ? window.event.srcElement : eventTag.target; //ie||ff
//    //alert(event + ":" + currentKey + ":" + eventSource);
//}