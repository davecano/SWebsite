<%@ Page Title="" Language="C#" MasterPageFile="~/Website/Master/KBSiteframe.Master" AutoEventWireup="true" CodeBehind="ShowArticle.aspx.cs" Inherits="KBsiteframe.WEB.Website.KbIntruoduce.ShowArticle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--/当前位置开始-->
<div id="address">
	<div class="address-zong">
		<div class="address-icon"><img src="../image/locate.png" /></div>
		<div class="list5_show_gj-address-text">当前位置：<a href="../index.html">首页</a> / <a href="../KbIntruoduce/knowledgeIndex.aspx">知识建构</a> / <a href="#">关于观点</a></div>
	</div>
</div>
<!--/当前位置结束-->
<div id="list5_show_gj-content-k">
	<div id="list5_show_gj-content">
		<div class="list5_show_gj-shang-title"><asp:Literal runat="server" ID="lttitle" ></asp:Literal></div>
	
		<!--//biaozhu-->
        <div class="list5_show_gj-biaozhu"> 关键词：<asp:Literal runat="server" ID="ltkeyword"></asp:Literal></div>
        <div class="list5_show_gj-biaozhu"> 作者：<asp:Literal runat="server" ID="ltauthor"></asp:Literal>  </div>
            <div class="list5_show_gj-biaozhu"> 日期：<asp:Literal runat="server" ID="ltdate"></asp:Literal>  </div>
            <div class="list5_show_gj-text" style="width:885px ">摘要： <asp:Literal runat="server" ID="ltsummary"></asp:Literal> </div>
	  <div class="Article_pic"><asp:Image runat="server" ID="aimg"/> </div>
		<!--//text-->
		<%--<div class="last-title"><asp:Button runat="server" ID="btndownload" Text="下载" CssClass="last-title-btn btn btn-link" OnClick="btndownload_OnClick"/>    
         <asp:Literal runat="server" ID="ltmsg" Text="需要权限才能下载" Visible="False"></asp:Literal> </div>--%>
<!--//text-->
		<!--//text-->
		
        	<div class="last-title"><i><span><asp:LinkButton runat="server" Text="下载" ID="lbdownload" OnClick="lbdownload_OnClick"></asp:LinkButton></span> &nbsp;&nbsp;&nbsp; <asp:Literal runat="server" ID="ltmsg" Text="需要权限才能下载" Visible="False"></asp:Literal></i> </div>
	</div>
	<!--//content-->
</div>
<!--//content-k-->
</asp:Content>
