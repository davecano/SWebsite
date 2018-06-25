<%@ Page Title="" Language="C#" MasterPageFile="~/Website/Master/KBSiteframe.Master" AutoEventWireup="true" CodeBehind="ShowProject.aspx.cs" Inherits="KBsiteframe.WEB.Website.KbIntruoduce.ShowProject" %>

<%@ Import Namespace="Z" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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


        function GetID(pagename) {
            var ID = getQueryString("ID");
           // 表明id 类型 type 1 = project ,2=expert,3=lmmember,4=tdmember
            window.location.href=pagename + ".aspx?ID=" + ID+"&type=1";

            return false;
        }


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--/当前位置开始-->
    <div id="address">
        <div class="address-zong">
            <div class="address-icon">
                <img src="../image/locate.png" /></div>
            <div class="list2_show-address-text">当前位置：<a href="../index.html">首页</a> / <a href="list2.html">研究项目 </a></div>
        </div>
    </div>
    <!--/当前位置结束-->
    <div id="list2_show-content-k">
        <div id="list2_show-content">
            <div class="list2_show-content-shang">
                <div class="list2_show-shang-title">
                    <asp:Literal runat="server" ID="ltProjectTitle"></asp:Literal></div>
                <div class="list2_show-shang-text">
                    起止时间：<asp:Literal runat="server" ID="lttime"></asp:Literal><br />
                    所属阶段：<asp:Literal runat="server" ID="ltPeriod"></asp:Literal><br />
                    所属机构：<asp:Literal runat="server" ID="ltorg"></asp:Literal><br />
                    具体内容：<asp:Literal runat="server" ID="ltcontent"></asp:Literal>
                </div>
                <!--//shang-text-->
            </div>
            <!--//content-shang-->
            <div class="list2_show-content-xia">
                <div class="list2_show-content-left">
                    <div class="jd-text-1">
                        <asp:Literal runat="server" ID="ltstage"></asp:Literal>

                    </div>
                </div>
                <!--//content-left-->
                <div class="list2_show-content-right">
                  
                <div class="cg" runat="server" id="v1">
                    <a href="javascript:GetID('ShowAllArticle');">项目文章</a>
                </div>
                    <div class="list2_show-Article home_content1_right_text_all">
                        <ul>
                            <asp:Repeater runat="server" ID="rplist1">
                                <ItemTemplate>
                                    <li><a href='ShowArticle.aspx?ID=<%#Eval("ArticleID") %>' target="_blank" >•••&nbsp;&nbsp;<%#Utils.CutString(Eval("ArticleTitle"),20) %></a></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                   
                   <div class="cg" runat="server" id="v2">
                        <a href="javascript:GetID('ShowAllTreatise');">项目专著</a>
                   </div>
                    <div class="list2_show-Article home_content1_right_text_all">
                        <ul>
                            <asp:Repeater runat="server" ID="rplist2">
                                <ItemTemplate>
                                    <li><a href='ShowTreatise.aspx?ID=<%#Eval("TreatiseID") %>' target="_blank" >•••&nbsp;&nbsp;<%#Utils.CutString(Eval("TreatiseName"),20) %></a></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>

                </div>
                <!--//content-right-->
            </div>
            <!--//content-xia-->
        </div>
        <!--//content-->
    </div>
    <!--//content-k-->
        </a>
</asp:Content>
