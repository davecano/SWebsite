<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="right.aspx.cs" Inherits="KBsiteframe.Web.Share.right" %>

<%@ Register Assembly="ZLib" Namespace="Z" TagPrefix="cc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Z" TagPrefix="webdiyer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>管理中心首页</title>
    <link type="text/css" rel="stylesheet" href="../../css/bootstrap.min.css" />
    <!--[if lte IE 7]
	<link rel="stylesheet" type="text/css" href="../../css/bootstrap-ie6.min.css">
	<link rel="stylesheet" type="text/css" href="../../css/ie.css">
	<![endif]-->
	<link type="text/css" rel="stylesheet" href="../../css/custom.css" />
	<link type="text/css" rel="stylesheet" href="../../css/main.css" />
    <script type="text/javascript" src="../../js/jquery-1.11.3.min.js"></script>
    <script type="text/javascript" src="../../js/bootstrap.min.js"></script>
	<script type="text/javascript" src="../../js/layer/layer.min.js"></script>
    <script src="../../js/Common.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {

        });

        function changeBarName(menuName)
        {
            $("#barName", window.parent.document).text(menuName);
        }
    </script>
</head>
<body>
    <div class="mainindex">
        <div class="welinfo">
            <b><asp:Label ID="lblLoginUser" runat="server"></asp:Label>，欢迎使用kbsiteframe后台管理系统</b>
        </div>
        <div class="xline"></div>
        <ul class="iconlist">
            <li><a href="/Manager/ContentManage/ArticleManage.aspx" onclick="changeBarName('文章管理');"><img src="../images/Main/ico03.png" width="32" height="32"/><p>文章管理<br/>Article Management</p></a></li>
            <li><a href="/Manager/ContentManage/TreatiseManage.aspx" onclick="changeBarName('专著管理');"><img src="../images/Main/ico02.png" width="32" height="32"/><p>专著管理<br/>Treatise Management</p></a></li>
            <li><a href="/Manager/ContentManage/ProjectManage.aspx" onclick="changeBarName('项目管理');"><img src="../images/Main/ico04.png" width="32" height="32"/><p>项目管理<br/>Project Management</p></a></li>
            <li><a href="/Manager/ContentManage/ExpertManage.aspx" onclick="changeBarName('专家管理');"><img src="../images/Main/i09.png" width="32" height="32"/> <p>专家管理<br/>Expert Management</p></a></li>
            <li><a href="/Manager/ContentManage/TDDynamicManage.aspx" onclick="changeBarName('团队动态');"><img src="../images/Main/i06.png" width="32" height="32"/><p>团队动态<br/>TeamDynamic Management </p></a></li> 
     
            <li><a href="/Manager/ContentManage/LMDynamicManage.aspx" onclick="changeBarName('联盟动态');"><img src="../images/Main/icon03.png" width="32" height="32"/><p>联盟动态<br/>LeagueDynamic Management </p></a></li>
              </ul>
    
    </div>
</body>
</html>