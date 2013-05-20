<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="error.aspx.cs" Inherits="Web.error" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="css/error.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="outer">
       <img src="images/wrong.gif" alt="wrong" /> 
       <p class="para">您访问的页面可能已经删除、更名或暂时不可用</p>
       <a class="alink" href="Login.aspx">返回首页</a>
    </div>
    </form>
</body>
</html>
