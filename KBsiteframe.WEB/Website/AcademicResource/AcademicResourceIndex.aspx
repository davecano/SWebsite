<%@ Page Title="" Language="C#" MasterPageFile="~/Website/Master/KBSiteframe.Master" AutoEventWireup="true" CodeBehind="AcademicResourceIndex.aspx.cs" Inherits="KBsiteframe.WEB.Website.AcademicResource.AcademicResourceIndex" %>

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

        function GetTopID(pagename, isinternal) {
            if (isinternal == 1)
                var ID = $("#ContentPlaceHolder1_hfaid").val();
            else if (isinternal == 0)
                var ID = $("#ContentPlaceHolder1_hfaid2").val();
            window.location.href = pagename + ".aspx?ID=" + ID;

            return false;
        }
        function GetID(pagename, isinternal) {
            var type;
            // 表明id 类型 type 1 = project ,2=expert,3=lmmember,4=tdmember,5代表国内,6代表国外
            if (isinternal == 1)
                type = 5;
            else if (isinternal == 0)
                type = 6;
            window.location.href = pagename + ".aspx?type=" + type;

            return false;
        }


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="list5_content">
        <div class="list5_content_middle">
            <div class="list5_daohang">
                <div class="list5_icon">
                    <img src="../image/locate.png" />
                </div>
                <div class="list5_text">当前位置：<a href="../index.aspx">首页</a> / <a href="#">学术资源</a></div>
            </div>
            <div class="list5_content_wh">
                <div class="list5_content_wh_left">
                    <div class="list5_content_wh_left_one">
                        <div class="list5_content_wh_left_one_shang">
                            <div class="list5_content1_first_left_title_line"></div>
                            <div class="list5_content1_first_left_title_text">国外文章</div>
                            <div class="list5_more"><a href="javascript:GetID('../KbIntruoduce/ShowAllArticle',0);">MORE</a></div>
                        </div>

                        <div class="list5_content1_first_left_neirong_two">
                            <ul>
                                <asp:Repeater runat="server" ID="rplist2">
                                    <ItemTemplate>
                                        <li><a href='../KbIntruoduce/ShowArticle.aspx?ID=<%#Eval("ArticleID") %>' target="_blank">•&nbsp;&nbsp;<%#Utils.CutString(Eval("ArticleTitle"),45) %></a><span style="float: right"><%#Eval("SubmitTime","{0:yyyy-MM-dd}") %></span></li>

                                    </ItemTemplate>
                                </asp:Repeater>

                            </ul>
                        </div>

                    </div>
                    <div class="list5_content_wh_left_one">
                        <div class="list5_content_wh_left_one_shang">
                            <div class="list5_content1_first_left_title_line"></div>
                            <div class="list5_content1_first_left_title_text">国内文章</div>
                            <div class="list5_more"><a href="javascript:GetID('../KbIntruoduce/ShowAllArticle',1);">MORE</a></div>
                        </div>

                        <div class="list5_content1_first_left_neirong_two">
                            <ul>
                                <asp:Repeater runat="server" ID="rplist1">
                                    <ItemTemplate>
                                        <%--        <li><a href="list5_show_wz.html">•&nbsp;&nbsp;全国学校美育工作会议暨第三批学校美育批学校改革发展备批学校美育改...</a></li>--%>
                                        <li><a href='../KbIntruoduce/ShowArticle.aspx?ID=<%#Eval("ArticleID") %>' target="_blank">•&nbsp;&nbsp;<%#Utils.CutString(Eval("ArticleTitle"),45) %></a><span style="float: right"><%#Eval("SubmitTime","{0:yyyy-MM-dd}") %></span></li>



                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>

                    </div>

                    <div class="list5_content_wh_left_one">
                        <div class="list5_content_wh_left_one_shang">
                            <div class="list5_content1_first_left_title_line"></div>
                            <div class="list5_content1_first_left_title_text">国际会议</div>
                            <div class="list5_more"><a href="javascript:GetID('../KbIntruoduce/ShowAll',3);">MORE</a></div>
                        </div>

                        <div class="list5_content1_first_left_neirong_two">
                            <ul>
                                <asp:Repeater runat="server" ID="rplist3">
                                    <ItemTemplate>
                                        <%--  <li><a href="list5_show_wz.html">•&nbsp;&nbsp;全国学校美育工作会议暨第三批学校美育批学校改革发展备批学校美育改...</a></li>--%>
                                        <li><a target="_blank" href="javascript:GetID('../ShowNews',<%#Eval("NewsID")%>);">•&nbsp;&nbsp;<%#Utils.CutString(Eval("Title"),45) %></a><span style="float: right"><%#Eval("SubmitTime","{0:yyyy-MM-dd}") %></span></li>

                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="list5_content_wh_right">
                    <div class="list5_content_wh_right_title">
                        <div class="list5_all">
                            <div class="list5_content_wh_right_title_icon">
                                <img src="../image/icon_03.png" />
                            </div>
                            <div class="list5_content_wh_right_title_text"><a href="#">知识建构工具</a></div>
                        </div>
                    </div>
                    <div class="list5_content_wh_right_neirong">
                        <div class="list5_content_wh_right_neirong_one">
                            <div class="list5_mulu">
                                <div class="list5_tool"><a href="list5_show_gj.html">工具一</a></div>
                                <div class="list5_icon1"></div>
                            </div>
                        </div>
                        <div class="list5_content_wh_right_neirong_one">
                            <div class="list5_mulu">
                                <div class="list5_tool"><a href="list5_show_gj.html">工具二</a></div>
                                <div class="list5_icon1"></div>
                            </div>
                        </div>
                        <div class="list5_content_wh_right_neirong_one">
                            <div class="list5_mulu">
                                <div class="list5_tool"><a href="list5_show_gj.html">工具三</a></div>
                                <div class="list5_icon1"></div>
                            </div>
                        </div>
                        <div class="list5_content_wh_right_neirong_one">
                            <div class="list5_mulu">
                                <div class="list5_tool"><a href="list5_show_gj.html">工具四</a></div>
                                <div class="list5_icon1"></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
