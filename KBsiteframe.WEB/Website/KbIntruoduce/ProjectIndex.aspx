<%@ Page Title="" Language="C#" MasterPageFile="~/Website/Master/KBSiteframe.Master" AutoEventWireup="true" CodeBehind="ProjectIndex.aspx.cs" Inherits="KBsiteframe.WEB.Website.KbIntruoduce.ProjectIndex" %>
<%@ Register TagPrefix="webdiyer" Namespace="Z" Assembly="AspNetPager" %>
<%@ Import Namespace="Z" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="list2_content">
<div class="list2_content_middle">
<div class="list2_daohang">
  <div class="list2_icon"><img src="../image/locate.png" /></div>
  <div class="list2_text">当前位置：<a href="../index.html">首页</a> / <a href="list2.html">研究项目</a></div>
</div> 
<div class="list2_content1">
  <div class="list2_content1_first">
   <div class="list2_content1_first_shang"><a href="list2_show.html">•&nbsp;&nbsp;项目名称标题</a></div>
  
    </div>
  </div>
  <div class="list2_content2">
      <asp:Repeater runat="server" ID="rplist">
          <ItemTemplate>
                <div class="list2_content2_right_text_all">
    <ul>
      <li><a href='ShowProject.aspx?ID=<%#Eval("ProjectID") %>'>•&nbsp;&nbsp;<%#Utils.CutString(Eval("ProjectName"),40) %></a></li>
      
    </ul>
  </div>
  <div class="list2_content2_right_text_all_right">
    <ul>
      <li><%#Eval("StartTime","{0:yyyy-MM-dd}") %></li>

    </ul>
  </div>
          </ItemTemplate>
      </asp:Repeater>

</div>
 <div class="fenye">
                <div class="fenye_middle">
                 <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_OnPageChanged">
            </webdiyer:AspNetPager>
                </div>
            </div>
</div>
</div>
</asp:Content>
