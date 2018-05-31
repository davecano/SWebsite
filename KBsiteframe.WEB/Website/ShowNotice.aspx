<%@ Page Title="" Language="C#" MasterPageFile="~/Website/Master/KBSiteframe.Master" AutoEventWireup="true" CodeBehind="ShowNotice.aspx.cs" Inherits="KBsiteframe.WEB.Website.ShowNotice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<!--/当前位置开始-->
<div id="address">
  <div class="address-zong">
    <div class="address-icon"><img src="image/locate.png" /></div>
    <div class="list5_show_gj-address-text">当前位置：首页 / 栏目名称</div>
  </div>
</div>
<!--/当前位置结束-->
<div id="list5_show_gj-content-k">

  <div id="list5_show_gj-content">
    <div class="list5_show_gj-shang-title"><asp:Literal runat="server" ID="ltTitle"></asp:Literal></div>
    <div class="list5_show_gj-biaozhu">
      <div class="list5_show_gj-biaozhu-left">
        <div class="list5_show_gj-biaozhu1">浏览量：<asp:Literal runat="server" ID="ltViews"></asp:Literal> </div>
        <div class="list5_show_gj-biaozhu2">作者：<asp:Literal runat="server" ID="ltauthor"></asp:Literal></div>
      </div>
      <!--//biaozhu-left-->
      <div class="list5_show_gj-biaozhu-right">
        <div class="list5_show_gj-biaozhu3">[日期：<asp:Literal runat="server" ID="ltdate"></asp:Literal>]</div>
      </div>
      <!--//biaozhu-right--> 
    </div>
    <!--//biaozhu-->
    
    <div class="list5_show_gj-text">
        <asp:Literal runat="server" ID="ltContent"></asp:Literal>
    </div>
    <!--//text-->
  </div>
  <!--//content--> 
</div>
<!--//content-k-->
</asp:Content>
