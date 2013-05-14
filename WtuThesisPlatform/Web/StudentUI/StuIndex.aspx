<%@ Page Title="" Language="C#" MasterPageFile="~/StudentUI/StudentMasterPage.Master" AutoEventWireup="true" CodeBehind="StuIndex.aspx.cs" Inherits="Web.StudentUI.StuIndex" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" type="text/css" href="../css/common_index.css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
 <div class="fl workShow-wrap">
        <dl id="workShow" class="workShow">
            <dt class="fn-ellipsis">优秀毕业设计展示<span class="more"><a href="#">>>更多</a></span></dt>
            <dd>
                <ul>
                    <li class="fn-ellipsis"><a href="#">毕业设计选题系统作品欣赏</a></li>
        
                </ul>
            </dd>
        </dl>
    </div>
    <div class="fr rightpart">
        <div class="notice-wrap">
            <dl id="notice" class="notice">
                <dt class="fn-ellipsis">公告<span class="fr more"><a href="#">>>更多</a></span></dt>
                <dd>
                    <ul>
                        <li class="fn-ellipsis"><a href="#">马上要交毕业设计了，你们赶紧的啊~~</a></li>
                    </ul>
                </dd>
            </dl>
        </div>
        <div class="download-wrap">
            <dl id="download" class="download">
                <dt class="fn-ellipsis">相关文档下载<span class="fr more"><a href="#">>>更多</a></span></dt>
                <dd>
                    <ul>
                        <li class="fn-ellipsis"><a href="#">毕业设计各种作弊方法大全</a></li>
                    </ul>
                </dd>
            </dl>
        </div>
    </div>
</asp:Content>
