<%@ Page Title="" Language="C#" MasterPageFile="~/Website/Master/KBSiteframe.Master" AutoEventWireup="true" CodeBehind="AboutIndex.aspx.cs" Inherits="KBsiteframe.WEB.Website.About.AboutIndex" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Css/style.css" rel="stylesheet" type="text/css" />
    <link href="../Css/bootstrap.min.css" rel="stylesheet" />
    <%--   javascript--%>
    <script type="text/javascript" src="../js/jquery-1.2.6.min.js"></script>
    <script type="text/javascript" src="../Js/jquery-easing-1.3.pack.js"></script>
    <script type="text/javascript" src="../Js/jquery-easing-compatibility.1.2.pack.js"></script>
    <script type="text/javascript" src="../Js/coda-slider.1.1.1.pack.js"></script>
    <script type="text/javascript" src="../Js/js.js"></script>

    <script type="text/javascript" src="../Js/bootstrap.js"></script>
    <script type="text/javascript" src="/js/layer/layer.min.js"></script>
    <script type="text/javascript" src="/js/Common.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--/当前位置开始-->
    <div id="address-list6">
        <div class="address-zong">
            <div class="address-icon">
                <img src="../image/locate.png" />
            </div>
            <div class="list6_list-show-address-text">当前位置：<a href="../index.html">首页</a> / <a href="list6.html">关于我们</a></div>
        </div>
    </div>
    <!--/当前位置结束-->
    <div id="list6_list-show-content-k">
        <div id="list6_list-show-content">

            <div class="list6_list-show-content-shang">
                <div class="list6_list-show-shang-1">
                    <div class="list6_list-show-shang-1-left">
                        <div class="list6_list-show-pic">
                            <div class="list6_list-show-picture">
                                <img src="../image/notouxiang.gif" runat="server" id="img1" width="240px" height="116px"/></div>
                            <div class="list6_list-show-text">
                                <a href=""><asp:Literal runat="server" ID="ltexpertname1"></asp:Literal><br />
                                    国籍：<asp:Literal runat="server" ID="ltcountry1"></asp:Literal><br />
                                    简介：<asp:Literal runat="server" ID="ltsummary1"></asp:Literal>
                                </a>
                            </div>
                        </div>
                        <div class="list6_list-show-new">
                            <ul>
                              <asp:Repeater runat="server" ID="rplist1">
                                  <ItemTemplate>
                                 <li><a href="">•&nbsp;&nbsp;<% %></a></li>        
                                  </ItemTemplate>
                              </asp:Repeater>
                            </ul>
                        </div>

                    </div>
                    <!--//shang-1-left-->

                    <div class="list6_list-show-shang-1-right">
                       <div class="list6_list-show-pic">
                            <div class="list6_list-show-picture">
                                <img src="../image/notouxiang.gif" runat="server" id="img2" width="240px" height="116px"/></div>
                            <div class="list6_list-show-text">
                                <a href=""><asp:Literal runat="server" ID="ltexpertname2"></asp:Literal><br />
                                    国籍：<asp:Literal runat="server" ID="ltcountry2"></asp:Literal><br />
                                    简介：<asp:Literal runat="server" ID="ltsummary2"></asp:Literal>
                                </a>
                            </div>
                        </div>
                        <div class="list6_list-show-new">
                            <ul>
                              <asp:Repeater runat="server" ID="rplist2">
                                  <ItemTemplate>
                                 <li><a href="">•&nbsp;&nbsp;<% %></a></li>        
                                  </ItemTemplate>
                              </asp:Repeater>
                            </ul>
                        </div>
                    </div>
                    <!--//shang-1-right-->

                </div>
                  <div class="list6_list-show-shang-1">
                    <div class="list6_list-show-shang-1-left">
                        <div class="list6_list-show-pic">
                            <div class="list6_list-show-picture">
                                <img src="../image/notouxiang.gif" runat="server" id="img3" width="240px" height="116px"/></div>
                            <div class="list6_list-show-text">
                                <a href=""><asp:Literal runat="server" ID="ltexpertname3"></asp:Literal><br />
                                    国籍：<asp:Literal runat="server" ID="ltcountry3"></asp:Literal><br />
                                    简介：<asp:Literal runat="server" ID="ltsummary3"></asp:Literal>
                                </a>
                            </div>
                        </div>
                        <div class="list6_list-show-new">
                            <ul>
                              <asp:Repeater runat="server" ID="rplist3">
                                  <ItemTemplate>
                                 <li><a href="">•&nbsp;&nbsp;<% %></a></li>        
                                  </ItemTemplate>
                              </asp:Repeater>
                            </ul>
                        </div>

                    </div>
                    <!--//shang-1-left-->

                    <div class="list6_list-show-shang-1-right">
                       <div class="list6_list-show-pic">
                            <div class="list6_list-show-picture">
                                <img src="../image/notouxiang.gif" runat="server" id="img4" width="240px" height="116px"/></div>
                            <div class="list6_list-show-text">
                                <a href=""><asp:Literal runat="server" ID="ltexpertname4"></asp:Literal><br />
                                    国籍：<asp:Literal runat="server" ID="ltcountry4"></asp:Literal><br />
                                    简介：<asp:Literal runat="server" ID="ltsummary4"></asp:Literal>
                                </a>
                            </div>
                        </div>
                        <div class="list6_list-show-new">
                            <ul>
                              <asp:Repeater runat="server" ID="rplist4">
                                  <ItemTemplate>
                                 <li><a href="">•&nbsp;&nbsp;<% %></a></li>        
                                  </ItemTemplate>
                              </asp:Repeater>
                            </ul>
                        </div>
                    </div>
                    <!--//shang-1-right-->

                </div>
                <!--//shang-1-->

            </div>

            <!--//content-shang-->

            <div class="list6_list-show-content-xia">
                <div class="border-1">
                    <div class="list6_list-show-shang-text">
                        <div class="list6_list-show-text-left">
                            <div class="list6_list-show-left1">年级</div>
                            <div class="list6_list-show-left2">硕士</div>
                        </div>
                        <div class="list6_list-show-text-right">
                            <div class="list6_list-show-left3">博士</div>
                        </div>
                        <!--//text-right-->
                    </div>
                    <!--//shang-text-->
                </div>
                <!--//border-1-->

                <div class="border-2">
                    <div class="list6_list-show-shang-text">
                        <div class="list6_list-show-text-left-2">
                            <div class="border-2-text1">2003</div>
                            <div class="border-2-text2"><a href="show3.html">硕士1，硕士2</a></div>
                            <div class="border-2-text3"><a href="show4.html">博士1，博士2</a></div>
                        </div>
                        <div class="border-2-chakan"><a href="list6_more.html">MORE</a></div>
                    </div>
                    <!--//shang-text-->
                </div>
                <!--//border-2-->

                <div class="border-3">
                    <div class="list6_list-show-shang-text">
                        <div class="list6_list-show-text-left-3">
                            <div class="border-2-text1">2003</div>
                            <div class="border-2-text2"><a href="show3.html">硕士1，硕士2</a></div>
                            <div class="border-2-text3"><a href="show4.html">博士1，博士2</a></div>
                        </div>
                        <div class="border-2-chakan"><a href="list6_more.html">MORE</a></div>

                    </div>
                    <!--//shang-text-->

                </div>
                <!--//border-3-->

                <div class="border-4">
                    <div class="list6_list-show-shang-text">
                        <div class="list6_list-show-text-left-2">
                            <div class="border-2-text1">2003</div>
                            <div class="border-2-text2"><a href="show3.html">硕士1，硕士2</a></div>
                            <div class="border-2-text3"><a href="show4.html">博士1，博士2</a></div>
                        </div>
                        <div class="border-2-chakan"><a href="list6_more.html">MORE</a></div>
                    </div>
                    <!--//shang-text-->

                </div>
                <!--//border-4-->

                <div class="border-5">
                    <div class="list6_list-show-shang-text">
                        <div class="list6_list-show-text-left-3">
                            <div class="border-2-text1">2003</div>
                            <div class="border-2-text2"><a href="show3.html">硕士1，硕士2</a></div>
                            <div class="border-2-text3"><a href="show4.html">博士1，博士2</a></div>
                        </div>
                        <div class="border-2-chakan"><a href="list6_more.html">MORE</a></div>
                    </div>
                    <!--//shang-text-->

                </div>
                <!--//border-5-->

            </div>
            <!--//content-xia-->

        </div>
        <!--//content-->
    </div>
    <!--//content-k-->
    <div class="fenye">
        <div class="fenye_middle">
            <div class="fenye_left"><a href="#">1/10</a></div>
            <div class="fenye_left1"><a href="#">1</a></div>
            <div class="fenye_left2"><a href="#">2</a></div>
            <div class="fenye_left3"><a href="#">3</a></div>
            <div class="fenye_left4"><a href="#">尾页</a></div>
        </div>
    </div>

</asp:Content>
