$(function(){
    $.extend($,{omRules:{}});
    $.omRules.lang={
            notNum: "不是有效的数字",
            notInteger:"不是有效的整数",
            notChinese : "不是有效汉字",
            notEmail:"不是有效的邮箱",
            notMobilePhone:"不是有效的手机号码",
            notTelephone:"不是有效的固定电话号码",
            notQQ:"不是有效的QQ号码",
            notQuote:"含有特殊字符，不能输入",
            notDate:"非法日期格式",
            checkTime:"时间格式非法",
            notFullTime:"日期格式非法",
            notTeaNum:"限带人数不合法"
        };
    $.validator.addMethod("isTeaNum", function (value) {
        return checkTeaNum(value);
    }, $.omRules.lang.notTeaNum);
    /**
     * ruleName : isNum
     */
    $.validator.addMethod("isNum", function(value) {
         return checkNum(value);
     }, $.omRules.lang.notNum);
    /**
     * ruleName : isInteger
     */
    $.validator.addMethod("isInteger", function(value) {
        return checkInteger(value);
    }, $.omRules.lang.notInteger);
    /**
     * ruleName : isChinese
     */
    $.validator.addMethod("isChinese", function(value) {
        return checkChinese(value);
    }, $.omRules.lang.notChinese);

    /**
     * ruleName : isEmail
     */
    $.validator.addMethod("isEmail", function(value) {
        return checkEmail(value);
    }, $.omRules.lang.notEmail);

    /**
     * ruleName : isMobilePhone
     */
    $.validator.addMethod("isMobilePhone", function(value) {
        return checkMobilePhone(value);
    }, $.omRules.lang.notMobilePhone);

    /**
     * ruleName : isTelephone
     */
    $.validator.addMethod("isTelephone", function(value) {
        return checkTelephone(value);
    }, $.omRules.lang.notTelephone);

    /**
     * ruleName : isQQ
     */
    $.validator.addMethod("isQQ", function(value) {
        return checkQQ(value);
    }, $.omRules.lang.notQQ);
    /**
     * ruleName : isQuote
     */
    $.validator.addMethod("isQuote", function(value) {
        return checkQuote(value);
    }, $.omRules.lang.notQuote);
    /**
     * ruleName : isDate
     */
    $.validator.addMethod("isDate", function(value) {
        return checkDate(value);
    }, $.omRules.lang.notDate);
    /**
     * ruleName : isTime
     */
    $.validator.addMethod("isTime", function(value) {
        return checkTime(value);
    }, $.omRules.lang.notTime);
    /**
     * ruleName : isFullTime
     */
    $.validator.addMethod("isFullTime", function(value) {
        return checkFullTime(value);
    }, $.omRules.lang.notFullTime);

});
function checkTeaNum(str) {
    if (str.match(/^\d$|^1\d$|^20$/) == null) {
        return false;
    }
    else {
        return true;
    }
}
/**
 * 检查输入的一串字符是否全部是数字
 * 输入:str  字符串
 * 返回:true 或 flase; true表示为数字
 */
function checkNum(str){
    return str.match(/\D/) == null;
}


/**
 * 检查输入的一串字符是否为整型数据
 * 输入:str  字符串
 * 返回:true 或 flase; true表示为小数
 */
function checkInteger(str){
    if (str.match(/^[-+]?\d*$/) == null) {
        return false;
    }
    else {
        return true;
    }
}


/**
 * 检查输入的一串字符是否包含汉字
 * 输入:str  字符串
 * 返回:true 或 flase; true表示包含汉字
 */
function checkChinese(str){
    if (escape(str).indexOf("%u") != -1) {
        return true;
    }
    else {
        return false;
    }
}

/**
 * 检查输入的邮箱格式是否正确
 * 输入:str  字符串
 * 返回:true 或 flase; true表示格式正确
 */
function checkEmail(str){
    if (str.match(/[A-Za-z0-9_-]+[@](\S*)(net|com|cn|org|cc|tv|[0-9]{1,3})(\S*)/g) == null) {
        return false;
    }
    else {
        return true;
    }
}

/**
 * 检查输入的手机号码格式是否正确
 * 输入:str  字符串
 * 返回:true 或 flase; true表示格式正确
 */
function checkMobilePhone(str){
    if (str.match(/^(?:13\d|15[89])-?\d{5}(\d{3}|\*{3})$/) == null) {
        return false;
    }
    else {
        return true;
    }
}
/**
 * 检查输入的固定电话号码是否正确
 * 输入:str  字符串
 * 返回:true 或 flase; true表示格式正确
 */
function checkTelephone(str){
    if (str.match(/^(([0\+]\d{2,3}-)?(0\d{2,3})-)(\d{7,8})(-(\d{3,}))?$/) == null) {
        return false;
    }
    else {
        return true;
    }
}

/**
 * 检查QQ的格式是否正确
 * 输入:str  字符串
 *  返回:true 或 flase; true表示格式正确
 */
function checkQQ(str){
    if (str.match(/^\d{5,10}$/) == null) {
        return false;
    }
    else {
        return true;
    }
}




/**
 * 检查输入的字符是否具有特殊字符
 * 输入:str  字符串
 * 返回:true 或 flase; true表示包含特殊字符
 * 主要用于注册信息的时候验证
 */
function checkQuote(str){
    var items = new Array("~", "`", "!", "@", "#", "$", "%", "^", "&", "*", "{", "}", "[", "]", "(", ")");
    items.push(":", ";", "'", "|", "\\", "<", ">", "?", "/", "<<", ">>", "||", "//");
    items.push("admin", "administrators", "administrator", "管理员", "系统管理员");
    items.push("select", "delete", "update", "insert", "create", "drop", "alter", "trancate");
    str = str.toLowerCase();
    for (var i = 0; i < items.length; i++) {
        if (str.indexOf(items[i]) >= 0) {
            return false;
        }
    }
    return true;
}

/**
 * 检查日期格式是否正确
 * 输入:str  字符串
 * 返回:true 或 flase; true表示格式正确
 * 注意：此处不能验证中文日期格式
 * 验证短日期（2007-06-05）
 */
function checkDate(str){
    //var value=str.match(/((^((1[8-9]\d{2})|([2-9]\d{3}))(-)(10|12|0?[13578])(-)(3[01]|[12][0-9]|0?[1-9])$)|(^((1[8-9]\d{2})|([2-9]\d{3}))(-)(11|0?[469])(-)(30|[12][0-9]|0?[1-9])$)|(^((1[8-9]\d{2})|([2-9]\d{3}))(-)(0?2)(-)(2[0-8]|1[0-9]|0?[1-9])$)|(^([2468][048]00)(-)(0?2)(-)(29)$)|(^([3579][26]00)(-)(0?2)(-)(29)$)|(^([1][89][0][48])(-)(0?2)(-)(29)$)|(^([2-9][0-9][0][48])(-)(0?2)(-)(29)$)|(^([1][89][2468][048])(-)(0?2)(-)(29)$)|(^([2-9][0-9][2468][048])(-)(0?2)(-)(29)$)|(^([1][89][13579][26])(-)(0?2)(-)(29)$)|(^([2-9][0-9][13579][26])(-)(0?2)(-)(29)$))/);
    var value = str.match(/^(\d{1,4})(-|\/)(\d{1,2})\2(\d{1,2})$/);
    if (value == null) {
        return false;
    }
    else {
        var date = new Date(value[1], value[3] - 1, value[4]);
        return (date.getFullYear() == value[1] && (date.getMonth() + 1) == value[3] && date.getDate() == value[4]);
    }
}

/**
 * 检查时间格式是否正确
 * 输入:str  字符串
 * 返回:true 或 flase; true表示格式正确
 * 验证时间(10:57:10)
 */
function checkTime(str){
    var value = str.match(/^(\d{1,2})(:)?(\d{1,2})\2(\d{1,2})$/)
    if (value == null) {
        return false;
    }
    else {
        if (value[1] > 24 || value[3] > 60 || value[4] > 60) {
            return false
        }
        else {
            return true;
        }
    }
}

/**
 * 检查全日期时间格式是否正确
 * 输入:str  字符串
 * 返回:true 或 flase; true表示格式正确
 * (2007-06-05 10:57:10)
 */
function checkFullTime(str){
    var value = str.match(/^(?:19|20)[0-9][0-9]-(?:(?:0[1-9])|(?:1[0-2]))-(?:(?:[0-2][1-9])|(?:[1-3][0-1])) (?:(?:[0-2][0-3])|(?:[0-1][0-9])):[0-5][0-9]:[0-5][0-9]$/);
    if (value == null) {
        return false;
    }
    else {
        return true;
    }
}
//去掉字符串头尾空格   
function trim(str){
    return str.replace(/(^\s*)|(\s*$)/g, "");
}
