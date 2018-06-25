<%@ Page Title="" Language="C#" MasterPageFile="~/Website/Master/KBSiteframe.Master" AutoEventWireup="true" CodeBehind="AcademicCommunicationIndex.aspx.cs" Inherits="KBsiteframe.WEB.Website.AcademicCommunication.AcademicCommunicationIndex" %>
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

        function GetTopID(pagename,isinternal) {
            if (isinternal==1)
                var ID = $("#ContentPlaceHolder1_hfaid").val();
            else if (isinternal == 0)
                var ID = $("#ContentPlaceHolder1_hfaid2").val();
            window.location.href = pagename + ".aspx?ID=" + ID ;

            return false;
        }
        function GetID(pagename, isinternal) {
            var type;
            // 表明id 类型 type 1 = project ,2=expert,3=lmmember,4=tdmember,5代表国内,6代表国外
            if (isinternal == 1)
                type = 5;
            else if (isinternal == 0)
                type = 6;
            window.location.href = pagename + ".aspx?ID?type=" + type;

            return false;
        }


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="list4_content">
        <div class="list4_content_middle">
            <div class="list4_daohang">
                <div class="list4_icon">
                    <img src="../image/locate.png" /></div>
                <div class="list4_text">当前位置：<a href="../index.html">首页</a> / <a href="#">学术交流</a></div>
            </div>
            <div class="list4_content1">
                <div class="list4_content1_first">
                    <div class="list4_content1_first_left">
                        <div class="list4_content1_first_left_title">
                            <div class="list4_content1_first_left_title_line"></div>
                            <div class="list4_content1_first_left_title_text">国内学术交流　　　　　　　　　　　　　　　　
                                <a href="javascript:GetID('../KbIntruoduce/ShowAllArticle',1);">MORE</a></div>  <%--待会要修改的地方--%>
                        </div>
                        <div class="list4_content1_first_left_neirong">
                            <div class="list4_content1_first_left_neirong_one">
                                <div class="list4_content1_first_shang"><asp:Literal runat="server" ID="lttitle"></asp:Literal>
                                    <asp:HiddenField runat="server" ID="hfaid"/>
                                </div>
                                <div class="list4_content1_first_xia"><asp:Literal runat="server" ID="ltsummary"></asp:Literal></div>
                                <div class="list4_chakan"><a href="javascript:GetTopID('../KbIntruoduce/ShowArticle',1);">【查看更多】</a> </div>    <%--待会要修改的地方--%>
                            </div>
                            <div class="list4_content1_first_left_neirong_two">
                                <ul>
                                    <asp:Repeater runat="server" ID="rplist1">
                                        <ItemTemplate>
                                    <%--   <li><a href="list4_show.html">•&nbsp;&nbsp;全国学校美育工作会议暨第三批学校美育改革发展备忘录签署仪式举行</a></li>--%>
                                         <li><a href='../KbIntruoduce/ShowArticle.aspx?ID=<%#Eval("ArticleID") %>' target="_blank">•&nbsp;&nbsp;<%#Utils.CutString(Eval("ArticleTitle"),50) %></a></li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                 
                                  
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="list4_content1_first_right">
                        <div class="list4_content1_first_left_title">
                            <div class="list4_content1_first_left_title_line"></div>
                            <div class="list4_content1_first_left_title_text">国外学术交流　　　　　　　　　　　　　
                                <a href="javascript:GetID('../KbIntruoduce/ShowAllArticle',0);">MORE</a></div>   <%--待会要修改的地方--%>
                        </div>
                        <div class="list4_content1_first_left_neirong">
                            <div class="list4_content1_first_left_neirong_one">
                                <div class="list4_content1_first_shang"><asp:Literal runat="server" ID="lttitle2"></asp:Literal>
                                      <asp:HiddenField runat="server" ID="hfaid2"/>
                                </div>
                                <div class="list4_content1_first_xia"><asp:Literal runat="server" ID="ltsummary2"></asp:Literal></div>
                                <div class="list4_chakan"><a href="javascript:GetTopID('../KbIntruoduce/ShowArticle',0);">【查看更多】</a> </div>   <%--待会要修改的地方--%>
                            </div>
                            <div class="list4_content1_first_left_neirong_two">
                                <ul>
                                      <asp:Repeater runat="server" ID="rplist2">
                                        <ItemTemplate>
                                    <%--   <li><a href="list4_show.html">•&nbsp;&nbsp;全国学校美育工作会议暨第三批学校美育改革发展备忘录签署仪式举行</a></li>--%>
                                         <li><a href='../KbIntruoduce/ShowArticle.aspx?ID=<%#Eval("ArticleID") %>' target="_blank">•&nbsp;&nbsp;<%#Utils.CutString(Eval("ArticleTitle"),50) %></a></li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                 
                                 
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
