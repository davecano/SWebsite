<%@ Page Title="" Language="C#" MasterPageFile="~/Website/Master/KBSiteframe.Master" AutoEventWireup="true" CodeBehind="ShowExpert.aspx.cs" Inherits="KBsiteframe.WEB.Website.KbIntruoduce.ShowExpert" %>
<%@ Register Assembly="AspNetPager" Namespace="Z" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="list1_list_content">
        <div class="list1_list_content_middle">
            <div class="list1_list_daohang">
                <div class="list1_list_icon">
                    <img src="../image/locate.png" /></div>
                <div class="list1_list_text">当前位置：<a href="../index.html">首页</a> / <a href="list1.html">知识建构</a> / <a href="list1.html">知识建构专家</a></div>
            </div>
            <div class="list1_list_content1">
                <div class="list1_list_content1_first">
                    <div class="list1_list_content1_first_left">
                   <%-- <asp:Image style="width: 341px;height: 210px" runat="server" ID="img"/>--%>
                        <img style="width: 341px;height: 210px" src="../image/notouxiang.gif"  runat="server" id="htmlimg"/></div>
                    <div class="list1_list_content1_first_right">
                        <div class="list1_list_content1_first_right_shang">
                            专家名:<asp:Literal runat="server" ID="ltexpertname"></asp:Literal>
                            <asp:HiddenField runat="server" ID="hfEID"/>
                            <div class="list1_list_content1_first_right_xia">简介：<asp:Literal runat="server" ID="ltsummary"></asp:Literal></div>
                         <%--   <div class="list1_list_more"><a href="#">查看更多</a></div>--%>
                        </div>
                    </div>
                </div>
            </div>
            <div class="list1_list_content2">
                <asp:Repeater runat="server" ID="rplist">
                    <ItemTemplate>
                        <div class="list1_list_content2_right_text_all">
                            <ul>

                                <li><a href='ShowArticle.aspx?ID=<%#Eval("ArticleID") %>'>•&nbsp;&nbsp;<%#Eval("ArticleTitle") %></a></li>

                            </ul>
                        </div>
                        <div class="list1_list_content2_right_text_all_right">
                            <ul>
                                <li><%#Eval("SubmitTime") %></li>

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
