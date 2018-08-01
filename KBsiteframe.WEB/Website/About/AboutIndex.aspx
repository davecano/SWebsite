<%@ Page Title="" Language="C#" MasterPageFile="~/Website/Master/KBSiteframe.Master" AutoEventWireup="true" CodeBehind="AboutIndex.aspx.cs" Inherits="KBsiteframe.WEB.Website.About.AboutIndex" %>

<%@ Register TagPrefix="webdiyer" Namespace="Z" Assembly="AspNetPager" %>
<%@ Register Assembly="ZLib" Namespace="Z" TagPrefix="cc1" %>
<%@ Import Namespace="Z" %>

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
    <script>
        $(document).ready(function () {
            ;

        });


        function GetID(pagename, type) {
            var id;
            if (type == 1)
                id = $("hfeid1").val();
            else if (type == 2) {
                id = $("hfeid2").val();
            }
            else if (type == 3) {
                id = $("hfeid3").val();
            }
            else if (type == 4) {
                id = $("hfeid4").val();
            } else alert("error");
            window.open(pagename + ".aspx?ID=" + id);
            return false;
        }


    </script>
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
                                <img src="../image/notouxiang.gif" runat="server" id="img1" width="240" height="116" />
                            </div>
                            <div class="list6_list-show-text">
                                <a href="javascript:GetID('../KbIntruoduce/ShowExpert',1);">
                                    <asp:Literal runat="server" ID="ltexpertname1"></asp:Literal><br />
                                    国籍：<asp:Literal runat="server" ID="ltcountry1"></asp:Literal><br />
                                    简介：<asp:Literal runat="server" ID="ltsummary1"></asp:Literal>
                                    <asp:HiddenField runat="server" ID="hfeid1" />
                                </a>
                            </div>
                        </div>
                        <div class="list6_list-show-new">
                            <ul>
                                <asp:Repeater runat="server" ID="rplist1">
                                    <HeaderTemplate>
                                        <div style="text-align: center; font-size: 16px; background: #008080; color: #fff; font-weight: bold">所著文章</div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <li><a href="../KbIntruoduce/ShowArticle.aspx?ID=<%#Eval("ArticleID") %>">•&nbsp;&nbsp;<%#Utils.CutString(Eval("ArticleTitle"),15) %></a></li>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <div style="margin: 10px; font-weight: bold">
                                            <asp:Literal ID="ltmsg" runat="server" Visible='<%#bool.Parse((rplist1.Items.Count==0).ToString())%>'>无文章！</asp:Literal>
                                        </div>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>

                    </div>
                    <!--//shang-1-left-->

                    <div class="list6_list-show-shang-1-right">
                        <div class="list6_list-show-pic">
                            <div class="list6_list-show-picture">
                                <img src="../image/notouxiang.gif" runat="server" id="img2" width="240" height="116" />
                            </div>
                            <div class="list6_list-show-text">
                                <a href="javascript:GetID('../KbIntruoduce/ShowExpert',2);">
                                    <asp:Literal runat="server" ID="ltexpertname2"></asp:Literal><br />
                                    国籍：<asp:Literal runat="server" ID="ltcountry2"></asp:Literal><br />
                                    简介：<asp:Literal runat="server" ID="ltsummary2"></asp:Literal>
                                    <asp:HiddenField runat="server" ID="hfeid2" />
                                </a>
                            </div>
                        </div>
                        <div class="list6_list-show-new">
                            <ul>
                                <asp:Repeater runat="server" ID="rplist2">
                                    <HeaderTemplate>
                                        <div style="text-align: center; font-size: 16px; background: #008080; color: #fff; font-weight: bold">所著文章</div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <li><a href="../KbIntruoduce/ShowArticle.aspx?ID=<%#Eval("ArticleID") %>">•&nbsp;&nbsp;<%#Utils.CutString(Eval("ArticleTitle"),15) %></a></li>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <div style="margin: 10px; font-weight: bold">
                                            <asp:Literal ID="ltmsg" runat="server" Visible='<%#bool.Parse((rplist2.Items.Count==0).ToString())%>'>无文章！</asp:Literal>
                                        </div>
                                    </FooterTemplate>
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
                                <img src="../image/notouxiang.gif" runat="server" id="img3" width="240" height="116" />
                            </div>
                            <div class="list6_list-show-text">
                                <a href="javascript:GetID('../KbIntruoduce/ShowExpert',3);">
                                    <asp:Literal runat="server" ID="ltexpertname3"></asp:Literal><br />
                                    国籍：<asp:Literal runat="server" ID="ltcountry3"></asp:Literal><br />
                                    简介：<asp:Literal runat="server" ID="ltsummary3"></asp:Literal>
                                    <asp:HiddenField runat="server" ID="hfeid3" />
                                </a>
                            </div>
                        </div>
                        <div class="list6_list-show-new">
                            <ul>
                                <headertemplate> <div style="text-align: center; font-size: 16px; background: #008080; color: #fff;font-weight: bold">所著文章</div></headertemplate>
                                <asp:Repeater runat="server" ID="rplist3">
                                    <ItemTemplate>
                                        <li><a href="../KbIntruoduce/ShowArticle.aspx?ID=<%#Eval("ArticleID") %>">•&nbsp;&nbsp;<%#Utils.CutString(Eval("ArticleTitle"),15) %></a></li>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <div style="margin: 10px; font-weight: bold">
                                            <asp:Literal ID="ltmsg" runat="server" Visible='<%#bool.Parse((rplist3.Items.Count==0).ToString())%>'>无文章！</asp:Literal>
                                        </div>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>

                    </div>
                    <!--//shang-1-left-->

                    <div class="list6_list-show-shang-1-right">
                        <div class="list6_list-show-pic">
                            <div class="list6_list-show-picture">
                                <img src="../image/notouxiang.gif" runat="server" id="img4" width="240" height="116" />
                            </div>
                            <div class="list6_list-show-text">
                                <a href="javascript:GetID('../KbIntruoduce/ShowExpert',4);">
                                    <asp:Literal runat="server" ID="ltexpertname4"></asp:Literal><br />
                                    国籍：<asp:Literal runat="server" ID="ltcountry4"></asp:Literal><br />
                                    简介：<asp:Literal runat="server" ID="ltsummary4"></asp:Literal>
                                    <asp:HiddenField runat="server" ID="hfeid4" />
                                </a>
                            </div>
                        </div>
                        <div class="list6_list-show-new">
                            <ul>
                                <asp:Repeater runat="server" ID="rplist4">
                                    <HeaderTemplate>
                                        <div style="text-align: center; font-size: 16px; background: #008080; color: #fff; font-weight: bold">所著文章</div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <li><a href="../KbIntruoduce/ShowArticle.aspx?ID=<%#Eval("ArticleID") %>">•&nbsp;&nbsp;<%#Utils.CutString(Eval("ArticleTitle"),15) %></a></li>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <div style="margin: 10px; font-weight: bold">
                                            <asp:Literal ID="ltmsg" runat="server" Visible='<%#bool.Parse((rplist4.Items.Count==0).ToString())%>'>无文章！</asp:Literal>
                                        </div>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                        <div class="list6_ck"><a href="ShowAllExperts.aspx">MORE</a></div>
                    </div>
                    <!--//shang-1-right-->

                </div>
                <!--//shang-1-->

            </div>

            <!--//content-shang-->

            <div class="list6_list-show-content-xia">
                <div style="font-size: 20px; font-weight: bold">校内学生</div>
                <%--  <div class="border-1">
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
                <!--//border-5-->--%>

                <%--   listening Sgt. Pepper's Lonely Hearts Club Band--%>

                <table class="table table-striped">
                    <thead>
                        <tr>
                            <th>年级</th>
                            <th>硕士</th>
                            <th>博士</th>
                            <th>查看</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="rpstulist">
                            <ItemTemplate>
                                <tr>
                                <td><%#Eval("Grade") %></td>
                                <td><%#Eval("Graduate") %></td>
                                <td><%#Eval("PHD") %></td>

                                <td>
                                   <a href='StuMemberIndex.aspx?Grade=<%#Eval("Grade") %>'>MORE</a>
                                </td>
                                    </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
            <!--//content-xia-->

        </div>
        <!--//content-->
    </div>
    <!--//content-k-->
    <div class="fenye">
        <div class="fenye_middle fenye_middle_special">
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_OnPageChanged" CssClass="pagination" CurrentPageButtonClass="active" PagingButtonLayoutType="UnorderedList" PagingButtonSpacing="0" LayoutType="Ul" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" NumericButtonCount="5" PrevPageText="上一页" PageSize="6" EnableTheming="False">
            </webdiyer:AspNetPager>

        </div>
    </div>

</asp:Content>
