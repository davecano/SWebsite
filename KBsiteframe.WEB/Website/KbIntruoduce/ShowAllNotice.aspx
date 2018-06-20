<%@ Page Title="" Language="C#" MasterPageFile="~/Website/Master/KBSiteframe.Master" AutoEventWireup="true" CodeBehind="ShowAllNotice.aspx.cs" Inherits="KBsiteframe.WEB.Website.KbIntruoduce.ShowAllNotice" %>

<%@ Register TagPrefix="webdiyer" Namespace="Z" Assembly="AspNetPager" %>
<%@ Import Namespace="Z" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--   javascript--%>
    <script type="text/javascript" src="../Js/jquery-1.2.6.min.js"></script>
    <script type="text/javascript" src="../Js/jquery-easing-1.3.pack.js"></script>
    <script type="text/javascript" src="../Js/jquery-easing-compatibility.1.2.pack.js"></script>
    <script type="text/javascript" src="../Js/coda-slider.1.1.1.pack.js"></script>
    <script type="text/javascript" src="../Js/js.js"></script>

    <script type="text/javascript" src="../Js/bootstrap.js"></script>
    <script type="text/javascript" src="/js/layer/layer.min.js"></script>
    <script type="text/javascript" src="/js/Common.js"></script>
    <script>
        $(document).ready(function () {


        });


        function GetID(pagename, id) {
            window.open(pagename + ".aspx?ID=" + id);

            return false;
        }


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="list_text_content">
        <div class="list_text_content_middle">
            <div class="list_text_daohang">
                <div class="list_text_icon">
                    <img src="image/locate.png" /></div>
                <div class="list_text_text"><a href="#">当前位置：首页 / 栏目名称</a></div>
            </div>
            <div class="list_text_content2">
                <asp:Repeater runat="server" ID="rplist">
                    <ItemTemplate>
                        <div class="list_text_content2_right_text_all">
                            <ul>

                                <li><a target="_blank" href="javascript:GetID('../ShowNotice',<%#Eval("NoticeID")%>);">•&nbsp;&nbsp;<%#Utils.CutString(Eval("NoticeTitle"),37) %></a></li>
                            </ul>
                        </div>
                        <div class="list_text_content2_right_text_all_right">
                            <ul>
                                <li><%#Eval("CreateDate","{0:yyyy-MM-dd}") %></li>

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
