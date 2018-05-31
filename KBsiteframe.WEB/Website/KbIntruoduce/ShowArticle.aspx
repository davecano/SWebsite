<%@ Page Title="" Language="C#" MasterPageFile="~/Website/Master/KBSiteframe.Master" AutoEventWireup="true" CodeBehind="ShowArticle.aspx.cs" Inherits="KBsiteframe.WEB.Website.KbIntruoduce.ShowArticle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--/当前位置开始-->
<div id="address">
	<div class="address-zong">
		<div class="address-icon"><img src="../image/locate.png" /></div>
		<div class="list5_show_gj-address-text">当前位置：<a href="../index.html">首页</a> / <a href="list1.html">知识建构</a> / <a href="list1_show_guandian.html">关于观点</a></div>
	</div>
</div>
<!--/当前位置结束-->
<div id="list5_show_gj-content-k">
	<div id="list5_show_gj-content">
		<div class="list5_show_gj-shang-title"><asp:Literal runat="server" ID="lttitle" ></asp:Literal></div>
		<div class="list5_show_gj-biaozhu">
			<div class="list5_show_gj-biaozhu-left">
				<div class="list5_show_gj-biaozhu1">关键词：<asp:Literal runat="server" ID="ltkeyword"></asp:Literal> </div>
				<div class="list5_show_gj-biaozhu2">作者：<asp:Literal runat="server" ID="ltauthor"></asp:Literal> </div>
			</div>
			<!--//biaozhu-left-->
			<div class="list5_show_gj-biaozhu-right">
				<div class="list5_show_gj-biaozhu3">[日期：<asp:Literal runat="server" ID="ltdate"></asp:Literal>]</div>
			</div>
			<!--//biaozhu-right-->
		</div>
		<!--//biaozhu-->
		<div class="list5_show_gj-text"> <asp:Literal runat="server" ID="ltsummary"></asp:Literal> </div>
		<!--//text-->
		<div class="last-title"><i><span><asp:Button runat="server" ID="btndownload" Text="下载" OnClick="btndownload_OnClick"/></span><asp:HiddenField runat="server" ID="hfpath"/>　<asp:Literal runat="server" ID="ltmsg" Text="需要权限才能下载" Visible="False"></asp:Literal></i> </div>
	</div>
	<!--//content-->
</div>
<!--//content-k-->
</asp:Content>
