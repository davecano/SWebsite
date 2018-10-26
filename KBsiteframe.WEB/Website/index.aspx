<%@ Page Title="" Language="C#" MasterPageFile="~/Website/Master/KBSiteframe.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="KBsiteframe.WEB.Website.index" %>

<%@ Import Namespace="Z" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>首页</title>

    <link rel="stylesheet" type="text/css" href="Css/lrtk.css" />
    <link href="Css/bootstrap.min.css" rel="stylesheet" />
    <%--   javascript--%>
    <script type="text/javascript" src="/js/jquery-1.11.3.min.js"></script>
    <script type="text/javascript" src="Js/jquery-easing-1.3.pack.js"></script>
    <script type="text/javascript" src="Js/jquery-easing-compatibility.1.2.pack.js"></script>
    <script type="text/javascript" src="Js/coda-slider.1.1.1.pack.js"></script>
    <script type="text/javascript" src="Js/js.js"></script>
    <script type="text/javascript" src="/js/bootstrap.min.js"></script>

    <script type="text/javascript" src="/js/layer/layer.min.js"></script>
    <script type="text/javascript" src="/js/Common.js"></script>
    <script>
        $(document).ready(function () {
            //$("#ZButton2").click(function () {
            //    ShowIframe("添加字典信息", "CodeAdd.aspx", '780px', '500px');
            //    return false;
            //});
            $("#lb1").find("li").first().addClass("active");
            $("#lb2").find("div").first().addClass("active");

        });


        function GetID(pagename, id) {
            //ShowIframeNotClose(pagename+".aspx?ID=" + id);
            window.open(pagename + ".aspx?ID=" + id);
            return false;
        }

        function Register() {
            //ShowIframe("用户注册", "UserRegister.aspx", '780px', '600px');
            ShowIframeNew("用户注册", "/Website/UserRegister.aspx", '780px', '600px');
            return false;
        }
    </script>
    <style type="text/css">
        #ContentPlaceHolder1_ckisrember {
            height: 15px;
        }

        .carousel-indicators li {
            border: 1px solid #2BB2E3;
        }

        .carousel-indicators {
            margin-bottom: -75px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="home_content_all">
        <div class="home_content">
            <div class="home_content1">
                <div class="home_content1_left">
                    <div class="home_content1_left_picture">
                        <!-- 代码 开始 -->
                        <div id="page-wrap">
                            <%--    <div class="slider-wrap">
                            <div id="main-photo-slider" class="csw">
                                    <div class="panelContainer">
                                        <div class="panel" title="Panel 1">
                                            <div class="wrapper">
                                                <a target="_blank" href="ShowNews.aspx?ID=<%=piclist?[0].NewsID %>">
                                                    <img src="<%=piclist[0].NewsPicPath %>" alt="<%=piclist[0].Title %>"></a>
                                            </div>
                                        </div>
                                        <div class="panel" title="Panel 2">
                                            <div class="wrapper">
                                                <a  target="_blank" href="ShowNews.aspx?ID=<%=piclist?[1].NewsID %>" target="_blank">
                                                    <img src="<%=piclist[1].NewsPicPath %>" alt="<%=piclist[1].Title %>"></a>
                                            </div>
                                        </div>
                                        <div class="panel" title="Panel 3">
                                            <div class="wrapper">
                                                <a  target="_blank" href="ShowNews.aspx?ID=<%=piclist?[2].NewsID %>">
                                               <img src="<%=piclist[2].NewsPicPath %>" alt="<%=piclist[2].Title %>"  class="floatLeft"/></a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            <div id="main-photo-slider" class="csw">
								<div class="panelContainer">
									<div class="panel" title="Panel 1">
										<div class="wrapper"><a href="show.html"><img src="Image/small-1.jpg"  alt="temp" /></a></div>
									</div>
									<div class="panel" title="Panel 2">
										<div class="wrapper"><a href="show.html"><img src="Image/small-2.jpg"  alt="temp" /></a></div>
									</div>
									<div class="panel" title="Panel 3">
										<div class="wrapper"><a href="show.html"><img src="Image/small-3.jpg"  alt="scotch egg" class="floatLeft"/></a></div>
									</div>
								</div>
							</div>
                                <a href="#1" class="cross-link active-thumb">
                                    <img src="<%=piclist[0].NewsPicPath %>" alt="<%=piclist[0].Title %>" class="nav-thumb" /></a>
                                <div id="movers-row">
                                    <div>
                                        <a href="#2" class="cross-link">
                                            <img src="<%=piclist[1].NewsPicPath %>" alt="<%=piclist[1].Title %>" class="nav-thumb" /></a>
                                    </div>
                                    <div>
                                        <a href="#3" class="cross-link">
                                            <img src="<%=piclist[2].NewsPicPath %>" alt="<%=piclist[2].Title %>" class="nav-thumb" /></a>
                                    </div>
                                </div>
                            </div>--%>

                            <%--        		<div class="slider-wrap">
							<div id="main-photo-slider" class="csw">
								<div class="panelContainer">
									<div class="panel" title="Panel 1">
										<div class="wrapper"><a href="show.html"><img src="Image/big-1.jpg"  alt="temp" /></a></div>
									</div>
									<div class="panel" title="Panel 2">
										<div class="wrapper"><a href="show.html"><img src="Image/big-2.jpg"  alt="temp" /></a></div>
									</div>
									<div class="panel" title="Panel 3">
										<div class="wrapper"><a href="show.html"><img src="Image/big-3.jpg"  alt="scotch egg" class="floatLeft"/></a></div>
									</div>
								</div>
							</div>
							<a href="#1" class="cross-link active-thumb"><img src="Image/small-1.jpg" class="nav-thumb" alt="temp-thumb" /></a>
							<div id="movers-row">
								<div><a href="#2" class="cross-link"><img src="Image/small-2.jpg" class="nav-thumb" alt="temp-thumb" /></a></div>
								<div><a href="#3" class="cross-link"><img src="Image/small-3.jpg" class="nav-thumb" alt="temp-thumb" /></a></div>
							</div>
						</div>--%>

                            <div id="myCarousel" class="carousel slide slider-wrap " style="background: #2f4f4f">


                                <ol class="carousel-indicators" id="lb1">
                                    <%--    <li data-target="#myCarousel" data-slide-to='<%#Container.ItemIndex%>' class="active"></li>--%>
                                    <li data-target="#myCarousel" data-slide-to="0" <%--class="active"--%>></li>
                                    <li data-target="#myCarousel" data-slide-to="1" <%--class="active"--%>></li>
                                    <li data-target="#myCarousel" data-slide-to="2" <%--class="active"--%>></li>
                                </ol>




                                <!-- 轮播（Carousel）项目 -->
                                <div class="carousel-inner" id="lb2" style="height: 300px">
                                    <asp:Repeater runat="server" ID="rppiclist">
                                        <ItemTemplate>
                                            <div class="item<%-- active--%>">
                                                <a target="_blank" href="/Website/ShowNews.aspx?ID=<%#Eval("NewsID")%>">
                                                    <img src="<%#PicFilePathV+Eval("NewsPicPath")%>" alt="<%#Eval("Title")%>" /></a>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>


                                <!-- 轮播（Carousel）指标 -->


                            </div>
                            <!-- 代码 结束 -->
                        </div>
                    </div>

                    <div class="home_content1_right">
                        <div class="home_content1_right_title">
                            <div class="home_news"><a href="#">新闻动态</a></div>
                            <div class="home_more"><a href="KbIntruoduce/ShowAll.aspx">MORE</a></div>
                        </div>
                        <div class="home_content1_right_text_all">
                            <ul>
                                <asp:Repeater runat="server" ID="rpNewList">
                                    <ItemTemplate>
                                        <li><a target="_blank" href="javascript:GetID('/Website/ShowNews',<%#Eval("NewsID")%>);">•&nbsp;&nbsp;<%#Utils.CutString(Eval("Title"),37) %></a></li>
                                    </ItemTemplate>
                                </asp:Repeater>

                            </ul>
                        </div>
                    </div>
                </div>
                <div class="home_content1_right_all">
                    <div class="home_content1_right_title">
                        <div class="home_news"><a href="#">通知公告</a></div>
                        <div class="home_more"><a href="KbIntruoduce/ShowAllNotice.aspx">MORE</a></div>
                    </div>
                    <div class="home_content1_right_text_all">
                        <ul>
                            <asp:Repeater runat="server" ID="rpNoticeList">
                                <ItemTemplate>
                                    <li><a target="_blank" href="javascript:GetID('/Website/ShowNotice',<%#Eval("NoticeID")%>);">•&nbsp;&nbsp;<%#Utils.CutString(Eval("NoticeTitle"),37) %></a></li>
                                </ItemTemplate>
                            </asp:Repeater>

                        </ul>
                    </div>
                </div>
            </div>
            <div class="home_content2">
          <%--      <div class="home_content2_left">
                    <div class="home_content1_right_title">
                        <div class="home_news"><a href="#">联盟动态</a></div>
                        <div class="home_more"><a href="KbIntruoduce/ShowAllDynamic.aspx?type=1">MORE</a></div>
                    </div>
                    <div class="home_content1_right_text_all">
                        <ul>
                            <asp:Repeater runat="server" ID="rpLMlist">
                                <ItemTemplate>
                                    <li><a target="_blank" href="javascript:GetID('/Website/ShowDynamic',<%#Eval("DynamicID")%>);">•&nbsp;&nbsp;<%#Utils.CutString(Eval("Title"),37) %></a></li>
                                </ItemTemplate>
                            </asp:Repeater>

                        </ul>
                    </div>
         
                </div>--%>
                      <div class="home_content2_left">
                    <div class="home_content1_right_title">
                        <div class="home_news"><a href="#">联盟动态</a></div>
                        <div class="home_more"><a href="KbIntruoduce/ShowAllDynamic.aspx?type=1">MORE</a></div>
                    </div>
                    <div class="home_content1_right_text_all">
                        <ul>
                            <asp:Repeater runat="server" ID="rpLMlist">
                                <ItemTemplate>
                                    <li><a target="_blank" href="javascript:GetID('/Website/ShowDynamic',<%#Eval("DynamicID")%>);">•&nbsp;&nbsp;<%#Utils.CutString(Eval("Title"),37) %></a></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </div>
                <div class="home_content2_middle">
                    <div class="home_content1_right_title">
                        <div class="home_news"><a href="#">团队动态</a></div>
                        <div class="home_more"><a href="KbIntruoduce/ShowAllDynamic.aspx?type=2">MORE</a></div>
                    </div>
                    <div class="home_content1_right_text_all">
                        <ul>
                            <asp:Repeater runat="server" ID="rpTDlist">
                                <ItemTemplate>
                                    <li><a target="_blank" href="javascript:GetID('/Website/ShowDynamic',<%#Eval("DynamicID")%>);">•&nbsp;&nbsp;<%#Utils.CutString(Eval("Title"),37) %></a></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </div>
                <asp:Panel runat="server" ID="plLogin" Visible="False">
                    <div class="home_content2_right">
                        <div>
                            <div class="home_content2_right_title">用户登录</div>

                            <div class="home_content2_right_text">
                                <div class="home_content2_right_text_one">
                                    <%--     <input type="text" value="" placeholder="请输入用户名" />--%>
                                    <asp:TextBox ID="txtUserName" runat="server" placeholder="请输入用户名"></asp:TextBox>
                                </div>
                            </div>
                            <div class="home_content2_right_text">
                                <div class="home_content2_right_text_one">
                                    <%--   <input type="text" value="" placeholder="请输入密码" />--%>
                                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="请输入密码"></asp:TextBox>
                                </div>
                                <div class="home_content2_right_text">
                                    <div class="home_content2_right_text_one1">
                                        <%--  <input type="text" value="" placeholder="请输入验证码" />--%>
                                        <asp:TextBox ID="txtImg" runat="server" CssClass="form-control" placeholder="请输入验证码"></asp:TextBox>
                                        <div class="home_content2_icon">
                                            <%--    <img src="image/yanzheng.png" />--%>
                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/share/ImgCreator.aspx?id=1" onclick="this.src = '../share/ImgCreator.aspx?id=1&amp;flag=' + Math.random() " title="看不清楚，双击图片换一张。不区分大小写。" Width="71px" Height="32px" />
                                        </div>
                                    </div>
                                    <div class="home_content2_right_text">
                                        <div class="home_content2_right_text_one2">
                                            <div class="home_content2_right_text_one2_left"><a href="javascript:Register();">用户注册</a></div>

                                            <div class="home_content2_right_text_one2_right">
                                                <asp:CheckBox runat="server" ID="ckisrember" Style="display: inline-block; width: 15px; height: 15px" Checked="True" />记住密码
                                            </div>
                                        </div>
                                    </div>
                                    <div class="home_content2_right_text">
                                        <div class="home_content2_right_text_one2">
                                            <div class="home_login">
                                                <asp:Button runat="server" ID="btnlogin" Text="登&nbsp;录" OnClick="btnlogin_OnClick" />
                                            </div>
                                            <div class="home_clear">
                                                <input id="Reset1" class="btn btn-mini btn-primary" type="reset" value="清&nbsp;除" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:Panel>

            </div>
        </div>
    </div>
    <div id="friend">
        <div class="friend_middle">
            <div class="freind_left"><a href="../Login.aspx" target="_blank">管理员登录</a></div>
            <div class="freind_right">

           <%--     <select name="教育信息网站" style="width: 272px; height: 25px;">
                    <option>教育信息网站</option>
                    <option selected="selected">教育信息网站</option>
                </select>
                <select name="教育咨询网站" id="seclect" style="width: 272px; height: 25px;">
                    <option>教育咨询网站</option>
                    <option selected="selected">教育咨询网站</option>
                </select>
                <select name="教育协会网站" id="seclect" style="width: 272px; height: 25px;">
                    <option>教育协会网站</option>
                    <option selected="selected">教育协会网站</option>
                </select>--%>

            </div>
        </div>
    </div>


</asp:Content>
