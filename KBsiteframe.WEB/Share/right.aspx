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
            <b><asp:Label ID="lblLoginUser" runat="server"></asp:Label>，欢迎使用智采市场准入资源管理系统</b>
        </div>
        <div class="xline"></div>
        <ul class="iconlist">
            <li><a href="/Manager/QualificationsManage/EQualityManage.aspx" onclick="changeBarName('企业资质管理');"><img src="../images/Main/ico03.png" width="32" height="32"/><p>企业资质管理<br/>Enterprise Qualification</p></a></li>
            <li><a href="/Manager/QualificationsManage/PQualityManage.aspx" onclick="changeBarName('产品资质管理');"><img src="../images/Main/ico02.png" width="32" height="32"/><p>产品资质管理<br/>Product Qualification</p></a></li>
            <li><a href="/Manager/ProductManage/ProductManage.aspx" onclick="changeBarName('基础产品管理');"><img src="../images/Main/ico04.png" width="32" height="32"/>
                <p>基础产品管理<br/>Product Management</p></a></li>
            <li><a href="/Enterprises/PricesManage/DeliveryPricesManage.aspx" onclick="changeBarName('终端价格管理');"><img src="../images/Main/i09.png" width="32" height="32"/>
                <p>终端价格管理<br/>End Users Price</p></a></li>
            <li><a href="/Enterprises/AttributeManage/PricesManage.aspx" onclick="changeBarName('物价收费管理');"><img src="../images/Main/i06.png" width="32" height="32"/>
                <p>物价收费管理<br/>Reimbursement </p></a></li> 
    <%--        <li><a href="/Enterprises/AttributeManage/HealthCareManage.aspx" onclick="changeBarName('产品医保管理');"><img src="../images/Main/ico05.png" width="32" height="32"/><p>产品医保管理</p></a></li>--%>
           <%-- <li><a href="/Enterprises/PricesManage/BidResultManage.aspx" onclick="changeBarName('中标结果管理');"><img src="../images/Main/ico06.png" width="32" height="32"/><p>中标结果管理</p></a></li>--%>
            <li><a href="/Enterprises/ProjectsManage/ProjectManage.aspx" onclick="changeBarName('项目信息管理');"><img src="../images/Main/icon03.png" width="32" height="32"/>
                <p>项目信息管理<br/>Tender Project</p></a></li>
               <li><a href="/Enterprises/ReportManage/DeliveryPricesAnalysis.aspx" onclick="changeBarName('数据分析');"><img src="../images/Main/ico06.png" width="32" height="32"/>
                <p>数据分析<br/>Data Analysis</p></a></li>
        </ul>
     <%--   <div class="xline"></div>
        <div class="box"></div>
        <div class="welinfo">--%>
      <%--      <b>待办事项</b>
        </div>
        <ul class="infolist">
            <li><span>您有<a href="/Manager/QualificationsManage/EQualityManage.aspx" style="display:inline-block;font-size:16px; font-weight:bold; color:red;">&nbsp;<asp:Literal ID="ltrEQuality" runat="server"></asp:Literal>&nbsp;</a>条企业资质信息未审核</span></li>
            <li><span>您有<a href="/Manager/QualificationsManage/PQualityManage.aspx" style="display:inline-block;font-size:16px; font-weight:bold; color:red;">&nbsp;<asp:Literal ID="ltrPQuality" runat="server"></asp:Literal>&nbsp;</a>条产品资质信息未审核</span></li>
            <li><span>您有<a href="/Manager/ProductManage/ProductManage.aspx" style="display:inline-block;font-size:16px; font-weight:bold; color:red;">&nbsp;<asp:Literal ID="ltrProduct" runat="server"></asp:Literal>&nbsp;</a>条产品信息未审核</span></li>
        </ul>--%>
        <div class="xline"></div>
        <div class="welinfo">
            <span><img src="../images/Main/dp.png" alt="提醒" /></span>
            <b>资质到期提醒</b>
        </div>
        <ul class="infolist">
            <li><span>共有<a href="/Manager/QualificationsManage/PQualityManage.aspx" style="display:inline-block;font-size:16px; font-weight:bold; color:red;">&nbsp;<asp:Literal ID="ltrRegQuality" runat="server"></asp:Literal>&nbsp;</a>条注册证信息即将到期</span></li>
            <li><span>共有<a href="/Manager/QualificationsManage/EQualityManage.aspx" style="display:inline-block;font-size:16px; font-weight:bold; color:red;">&nbsp;<asp:Literal ID="ltrEOQuality" runat="server"></asp:Literal>&nbsp;</a>条企业资质信息即将到期</span></li>
            <li><span>共有<a href="/Manager/QualificationsManage/PQualityManage.aspx" style="display:inline-block;font-size:16px; font-weight:bold; color:red;">&nbsp;<asp:Literal ID="ltrPOQuality" runat="server"></asp:Literal>&nbsp;</a>条产品资质信息即将到期</span></li>
            <li><span>共有<a href="/Manager/QualificationsManage/PQualityManage.aspx" style="display:inline-block;font-size:16px; font-weight:bold; color:red;">&nbsp;<asp:Literal ID="ltrRegEnd" runat="server"></asp:Literal>&nbsp;</a>条注册证信息已到期</span></li>
            <li><span>共有<a href="/Manager/QualificationsManage/EQualityManage.aspx" style="display:inline-block;font-size:16px; font-weight:bold; color:red;">&nbsp;<asp:Literal ID="ltrEOEnd" runat="server"></asp:Literal>&nbsp;</a>条企业资质信息已到期</span></li>
            <li><span>共有<a href="/Manager/QualificationsManage/PQualityManage.aspx" style="display:inline-block;font-size:16px; font-weight:bold; color:red;">&nbsp;<asp:Literal ID="ltrPOEnd" runat="server"></asp:Literal>&nbsp;</a>条产品资质信息已到期</span></li>
        </ul>
    </div>
</body>
</html>