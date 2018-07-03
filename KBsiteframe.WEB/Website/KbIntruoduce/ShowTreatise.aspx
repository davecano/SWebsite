<%@ Page Title="" Language="C#" MasterPageFile="~/Website/Master/KBSiteframe.Master" AutoEventWireup="true" CodeBehind="ShowTreatise.aspx.cs" Inherits="KBsiteframe.WEB.Website.KbIntruoduce.ShowTreatise" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--/当前位置开始-->
<div id="address">
	<div class="address-zong">
		<div class="address-icon"><img src="../image/locate.png" /></div>
		<div class="list5_show_gj-address-text">当前位置：<a href="../index.aspx">首页</a> / <a href="../KbIntruoduce/knowledgeIndex.aspx">知识建构</a> / <a href="#">专著</a></div>
	</div>
</div>
<!--/当前位置结束-->
<div id="list5_show_gj-content-k">
	<div id="list5_show_gj-content">
		<div class="list5_show_gj-shang-title">《<asp:Literal runat="server" ID="lttitle" ></asp:Literal>》</div>
	  <div class="list5_show_gj-biaozhu"> 作者：<asp:Literal runat="server" ID="ltauthor"></asp:Literal>  </div>
        
		<!--//biaozhu-->
  <div class="list5_show_gj-biaozhu">
      <div class="pic_left">
          <asp:Image runat="server" ID="aimg"/>
      </div>
      <div class="content_right">
           <div class="">出版社：<asp:Literal runat="server" ID="ltpublish"></asp:Literal></div>
             <div class="">出版时间：<asp:Literal runat="server" ID="ltdate"></asp:Literal></div>
           <div class="">专家：<asp:Literal runat="server" ID="ltexpert"></asp:Literal></div>
            <div class="">联盟成员：<asp:Literal runat="server" ID="ltlm"></asp:Literal></div>
            <div class="">团队成员：<asp:Literal runat="server" ID="lttd"></asp:Literal></div>
           <div class="">所属项目：<asp:Literal runat="server" ID="ltproject"></asp:Literal></div>
      </div>
  </div>
        <div class="list5_show_gj-text" style="clear: both;margin-top: 20px">图书简介：<br/>
        <asp:Literal runat="server" ID="ltsum"></asp:Literal>
    </div>
	    <div class="list5_show_gj-text" style="clear: both; margin-top: 20px">图书目录：<br/>
      <code> <asp:Literal runat="server" ID="ltcatalog"></asp:Literal></code> 
    </div>
        
	</div>
	<!--//content-->
</div>
<!--//content-k-->
</asp:Content>
