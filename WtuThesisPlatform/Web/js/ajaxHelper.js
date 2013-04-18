function AjaxHelper() {//timeout()超时方法,outtime超时毫秒,type[post/get],loading(),complete(),data,success(),error(),url,err(),vf()
    var xhobj, timer, s;
    var vfsec = 5000;
    function getBU(url) {
        return url; //"/web"+
    }
    this.validBackValue = function (jM) {
        return validBackValueIn(jM);
    }
    function  validBackValueIn(jM) {
        if (jM.toString().indexOf("{res:") > -1) {
            jM = eval("(" + jM + ")");
            if (jM.res == "vf") { setTimeout("window.location ='" + getBU(jM.loginUrl) + "'", vfsec); } //如果身份验证失败
            return jM;
        } else return { res: 'f' };
    }
    this.doAjaxJuge = function (jM) {
        jM.msgBox.showWait();
        this.doAjax({ url: jM.url, data: jM.data, type: jM.type, success: function (m) {
            m = validBackValueIn(m);
            if (m.res == "f") {
                jM.msgBox.showReqErr();
                if (jM.err) jM.err();
            } else if (m.res == "vf") {
                jM.msgBox.showSysMsgWTime("会话过期,5秒后自动返回登录界面 -o-!", 1, vfsec);
                if (jM.vf) jM.vf();
            } else {
                jM.msgBox.showReqOk();
                jM.success(m);
            }
        }
        });
    }
    this.doAjax = function (jsonParas) {
        s = jsonParas;
        if (null != xhobj) { clearTimeout(timer); xhobj.abort(); xhobj = null; }
        xhobj = createXmlHttp(); // xmlHttp();
        if (!s.type) s.type = "POST"; //默认为post
        else s.type = s.type.toUpperCase();

        xhobj.open(s.type, (s.type == "GET" ? s.url + "?" + s.data : s.url), true);
        if (s.type == "POST") xhobj.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
        xhobj.onreadystatechange = watching; //为onreadystatechange事件设置回调函数
        xhobj.setRequestHeader("If-Modified-Since", "0");
        if (s.type == "POST") xhobj.send(s.data); else xhobj.send(null);
        timer = setTimeout(requestTimeout, s.outtime ? s.outtime : 9500);
    }
    this.doPost = function (jsonParas) {jsonParas.type = "POST";this.doAjax(jsonParas);}
    this.doGet= function (jsonParas) {jsonParas.type = "GET";this.doAjax(jsonParas);}
    function requestTimeout() {
        xhobj.abort();
        xhobj = null;
        if (s.timeout) s.timeout();
        else { s.success("服务器繁忙~ : ("); }
    }

    //onreadystatechange事件的回调函数
    function watching() {
        if (xhobj.readyState < 4) {
            if (s.loading) {s.loading(); }
        } else if (xhobj.readyState >= 4) {
            if (s.complete) s.complete(xhobj.responseText);
            if (xhobj.status == 200) {//如果服务器返回的状态码200，则服务器运行正常
                if (s.success)s.success(xhobj.responseText, xhobj.status);
            } else {
                if (s.error)s.error(xhobj.status);
                else s.success("服务器错误!"+xhobj.status);
            }
            clearTimeout(timer);
        }
    }
    function createXmlHttp() {
        xhobj = false;
        try {
            xhobj = new ActiveXObject("Msxml2.XMLHTTP"); // iemsxml3.0+
        } catch (e) {
            try {
                xhobj = new ActiveXObject("Microsoft.XMLHTTP"); //iemsxml2.6
            } catch (e2) {
                xhobj = false;
            }
        }
        if (!xhobj && typeof XMLHttpRequest != 'undefined') {// Firefox, Opera 8.0+, Safari
            xhobj = new XMLHttpRequest();
        }
        return xhobj;
    }
    function xmlHttp() {
        xmlHttp = false;
        xmlHttpObj = ["MSXML2.XMLHttp.5.0", "MSXML2.XMLHttp.4.0", "MSXML2.XMLHttp.3.0", "MSXML2.XMLHttp", "MSXML.XMLHttp"];
        if (window.XMLHttpRequest) {
            xmlHttp = new XMLHttpRequest();
        } else if (window.ActiveXObject) {
            for (i = 0; i < xmlHttpObj.length; i++) {
                xmlHttp = new ActiveXObject(xmlHttpObj[i]);
                if (xmlHttp) {
                    break; 
                }
            }
        }
        return xmlHttp ? xmlHttp : false;
    }
}