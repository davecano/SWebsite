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
                                        <li><a target="_blank" href="/Website/ShowNews.aspx?ID=<%#Eval("NewsID")%>">•&nbsp;&nbsp;<%#Utils.CutString(Eval("Title"),45) %></a><span style="float: right"><%#Eval("SubmitTime","{0:yyyy-MM-dd}") %></span></li>

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
                         <%--    <div class="list5_content_wh_right_neirong_one">
                            <div class="list5_mulu">
                              <div class="list5_tool">
                                          <a href="#">
                                   <video width="320" height="240" controls="controls">
                                  
                                            <source src="/文档及其他/login & logout in asp net sql database with session - Web Development.mp4" type="video/mp4"/>
                                            Your browser does not support the video tag.
                                        </video>
                                      <object id="player" height="64" width="275" classid="CLSID:6BF52A52-394A-11d3-B153-00C04F79FAA6">
                                            <param name="AutoStart" value="-1" />
                                            <!--是否自动播放-->
                                            <param name="Balance" value="0" />
                                            <!--调整左右声道平衡-->
                                            <param name="enabled" value="-1" />
                                            <!--播放器是否可人为控制-->
                                            <param name="EnableContextMenu" value="-1" />
                                            <!--是否启用上下文菜单-->
                                            <param name="url" value="文件路径/文件名" />
                                            <!--播放的文件地址-->
                                            <param name="PlayCount" value="1" />
                                            <!--播放次数控制,为整数-->
                                            <param name="rate" value="1" />
                                            <!--播放速率控制,1为正常,允许小数,1.0-2.0-->
                                            <param name="currentPosition" value="0" />
                                            <!--控件设置:当前位置-->
                                            <param name="currentMarker" value="0" />
                                            <!--控件设置:当前标记-->
                                            <param name="defaultFrame" value="" />
                                            <!--显示默认框架-->
                                            <param name="invokeURLs" value="0" />
                                            <!--脚本命令设置:是否调用URL-->
                                            <param name="baseURL" value="" />
                                            <!--脚本命令设置:被调用的URL-->
                                            <param name="stretchToFit" value="0" />
                                            <!--是否按比例伸展-->
                                            <param name="volume" value="50" />
                                            <!--默认声音大小0%-100%,50则为50%-->
                                            <param name="mute" value="0" />
                                            <!--是否静音-->
                                            <param name="uiMode" value="mini" />
                                            <!--播放器显示模式:Full显示全部;mini最简化;None不显示播放控制,只显示视频窗口;invisible全部不显示-->
                                            <param name="windowlessVideo" value="0" />
                                            <!--如果是0可以允许全屏,否则只能在窗口中查看-->
                                            <param name="fullScreen" value="0" />
                                            <!--开始播放是否自动全屏-->
                                            <param name="enableErrorDialogs" value="-1" />
                                            <!--是否启用错误提示报告-->
                                            <param name="SAMIStyle" value="value" />
                                            <!--SAMI样式-->
                                            <param name="SAMILang" value="value" />
                                            <!--SAMI语言-->
                                            <param name="SAMIFilename" value="value" />
                                            <!--字幕ID-->
                                        </object>
                                    </a>

                                </div>
                                <div class="list5_icon1"></div>
                            </div>
                        </div>--%>
                        <div class="list5_content_wh_right_neirong_one">
                            <div class="list5_mulu">
                                <div class="list5_tool"><a href="ShowAllTool.aspx?type=1">视频类</a></div>
                                <div class="list5_icon1"></div>
                            </div>
                        </div>
                        <div class="list5_content_wh_right_neirong_one">
                            <div class="list5_mulu">
                                <div class="list5_tool"><a href="ShowAllTool.aspx?type=2">文本类</a></div>
                                <div class="list5_icon1"></div>
                            </div>
                        </div>
                        <div class="list5_content_wh_right_neirong_one">
                            <div class="list5_mulu">
                                <div class="list5_tool"><a href="ShowAllTool.aspx?type=3">压缩类</a></div>
                                <div class="list5_icon1"></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
