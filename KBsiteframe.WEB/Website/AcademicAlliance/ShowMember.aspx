<%@ Page Title="" Language="C#" MasterPageFile="~/Website/Master/KBSiteframe.Master" AutoEventWireup="true" CodeBehind="ShowMember.aspx.cs" Inherits="KBsiteframe.WEB.Website.AcademicAlliance.ShowMember" %>

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
            var type = 0;
            if ($("ContentPlaceHolder1_hftypeint").val() == "1") //代表联盟
                type = 3;
            else if ($("ContentPlaceHolder1_hftypeint").val() == "2") //代表团队
                type = 4;
            // 表明id 类型 type 1 = project ,2=expert,3=lmmember,4=tdmember
            window.location.href = pagename + ".aspx?ID=" + ID + "&type=" + type;

            return false;
        }


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--/当前位置开始-->
    <div id="address">
        <div class="address-zong">
            <div class="address-icon">
                <img src="../image/locate.png" />
            </div>
            <div class="list3_show-address-text">当前位置：<a href="../index.html">首页</a> / <a href="list3.html">研究联盟</a></div>
        </div>
    </div>
    <!--/当前位置结束-->
    <div id="list3_show-content-k">
        <div id="list3_show-content">
            <div class="list1_list_content1">
                <div class="list1_list_content1_first" style="margin-bottom: 50px">
                    <div class="list1_list_content1_first_left">
                        <%-- <asp:Image style="width: 341px;height: 210px" runat="server" ID="img"/>--%>
                        <div style="margin-left: 20px">
                            <img style="width: 341px; height: 210px" src="../image/notouxiang.gif" runat="server" id="htmlimg" /></div>
                    </div>
                    <div class="list1_list_content1_first_right">
                        <div class="list1_list_content1_first_right_shang">
                            <div class="member_style">成员名:<asp:Literal runat="server" ID="ltname"></asp:Literal></div>
                            <div class="member_style">所在机构:<asp:Literal runat="server" ID="ltorg"></asp:Literal></div>
                            <div class="member_style">学历:<asp:Literal runat="server" ID="ltqua"></asp:Literal></div>
                            <div class="member_style">联系方式:<asp:Literal runat="server" ID="ltphone"></asp:Literal></div>
                            <div class="member_style">邮箱:<asp:Literal runat="server" ID="ltemail"></asp:Literal></div>
                            <div class="member_style">
                                类别:<asp:Literal runat="server" ID="lttype">
                              
                                </asp:Literal>
                                <asp:HiddenField runat="server" ID="hftypeint" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="list3_show-content-xia">
                <div class="list3_show-xia-left">
                    <div class="list3_show-cglb">
                        <a href="javascript:GetID('../KbIntruoduce/ShowAllArticle');">文章成果</a></div>
                    <div class="list3_show-new1">
                            <ul>
                                <asp:Repeater runat="server" ID="rplist">
                                    <ItemTemplate>
                                        <%--       <li><a href="list3_show_show.html">•&nbsp;&nbsp;研究联盟成员成果列表一</a></li>--%>
                                        <li><a href='../KbIntruoduce/ShowArticle.aspx?ID=<%#Eval("ArticleID") %>' target="_blank">•••&nbsp;&nbsp;<%#Utils.CutString(Eval("ArticleTitle"),40) %></a></li>
                                    </ItemTemplate>
                                </asp:Repeater>

                            </ul>
                        </div>
                    </div>
                
                <div class="list3_show-xia-right">
                    <div class="list3_show-cglb"><a href="javascript:GetID('../KbIntruoduce/ShowAllTreatise');">专著成果</a></div>

                    <div class="list3_show-new2">
                        <ul>
                            <asp:Repeater runat="server" ID="rplist2">
                                <ItemTemplate>
                                    <%--  <li><a href="list3_show_show.html">•&nbsp;&nbsp;研究联盟成员成果列表十</a></li>--%>
                                    <li><a href='../KbIntruoduce/ShowTreatise.aspx?ID=<%#Eval("TreatiseID") %>' target="_blank">•••&nbsp;&nbsp;<%#Utils.CutString(Eval("TreatiseName"),40) %></a></li>
                                </ItemTemplate>
                            </asp:Repeater>


                        </ul>
                    </div>
                </div>
            </div>
            <!--//content-xia-->
        </div>
        <!--//content-->
    </div>
    <!--//content-k-->
</asp:Content>
