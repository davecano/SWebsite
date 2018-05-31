<%@ Page Title="" Language="C#" MasterPageFile="~/Website/Master/KBSiteframe.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="KBsiteframe.WEB.Website.index" %>

<%@ Import Namespace="Z" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>index</title>
    <link href="Css/style.css" rel="stylesheet" type="text/css" />

    <link rel="stylesheet" type="text/css" href="Css/lrtk.css" />
    <link href="Css/bootstrap.min.css" rel="stylesheet" />
    <%--   javascript--%>
        <script type="text/javascript" src="js/jquery-1.2.6.min.js"></script>
    <script type="text/javascript" src="Js/jquery-easing-1.3.pack.js"></script>
    <script type="text/javascript" src="Js/jquery-easing-compatibility.1.2.pack.js"></script>
    <script type="text/javascript" src="Js/coda-slider.1.1.1.pack.js"></script>
    <script type="text/javascript" src="Js/js.js"></script>

    <script type="text/javascript" src="Js/bootstrap.js"></script>
    <script type="text/javascript" src="/js/layer/layer.min.js"></script>
    <script type="text/javascript" src="/js/Common.js"></script>
    <script>
        $(document).ready(function () {
            //$("#ZButton2").click(function () {
            //    ShowIframe("添加字典信息", "CodeAdd.aspx", '780px', '500px');
            //    return false;
            //});

        });


        function GetID(pagename,id) {
            ShowIframeNotClose(pagename+".aspx?ID=" + id);

            return false;
        }

        function Register() {
            ShowIframe("用户注册", "UserRegister.aspx", '780px', '500px');
            return false;
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="home_content_all">
        <div class="home_content">
            <div class="home_content1">
                <div class="home_content1_left">
                    <div class="home_content1_left_picture">
                        <!-- 代码 开始 -->
                        <div id="page-wrap">
                            <div class="slider-wrap">
                                <div id="main-photo-slider" class="csw">
                                    <div class="panelContainer">
                                        <div class="panel" title="Panel 1">
                                            <div class="wrapper">
                                                <a href="ShowNews.aspx?ID=<%=piclist?[0].NewsID %>">
                                                    <img src="<%=piclist[0].NewsPicPath %>" alt="<%=piclist[0].Title %>"  ></a>
                                            </div>
                                        </div>
                                        <div class="panel" title="Panel 2">
                                            <div class="wrapper">
                                                <a href="ShowNews.aspx?ID=<%=piclist?[1].NewsID %>" target="_blank">
                                                    <img src="<%=piclist[1].NewsPicPath %>" alt="<%=piclist[1].Title %>"></a>
                                            </div>
                                        </div>
                                        <div class="panel" title="Panel 3">
                                            <div class="wrapper">
                                                <a href="ShowNews.aspx?ID=<%=piclist?[2].NewsID %>">
                                                    <img src="<%=piclist[2].NewsPicPath %>" alt="<%=piclist[2].Title %>" class="floatLeft"></a>
                                            </div>
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
                            </div>
                            <!-- 代码 结束 -->
                        </div>
                    </div>

                    <div class="home_content1_right">
                        <div class="home_content1_right_title">
                            <div class="home_news"><a href="#">新闻动态</a></div>
                            <div class="home_more"><a href="#">MORE</a></div>
                        </div>
                        <div class="home_content1_right_text_all">
                            <ul>
                                <asp:Repeater runat="server" ID="rpNewList">
                                    <ItemTemplate>
                                        <li><a href="javascript:GetID('ShowNews',<%#Eval("NewsID")%>);">•&nbsp;&nbsp;<%#Utils.CutString(Eval("Title"),37) %></a></li>
                                    </ItemTemplate>
                                </asp:Repeater>

                            </ul>
                        </div>
                    </div>
                </div>
                <div class="home_content1_right_all">
                    <div class="home_content1_right_title">
                        <div class="home_news"><a href="#">通知公告</a></div>
                        <div class="home_more"><a href="#">MORE</a></div>
                    </div>
                    <div class="home_content1_right_text_all">
                        <ul>
                            <asp:Repeater runat="server" ID="rpNoticeList">
                                <ItemTemplate>
                                    <li><a href="javascript:GetID('ShowNotice',<%#Eval("NoticeID")%>);">•&nbsp;&nbsp;<%#Utils.CutString(Eval("NoticeTitle"),37) %></a></li>
                                </ItemTemplate>
                            </asp:Repeater>

                        </ul>
                    </div>
                </div>
            </div>
            <div class="home_content2">
                <div class="home_content2_left">
                    <div class="home_content1_right_title">
                        <div class="home_news"><a href="#">联盟动态</a></div>
                        <div class="home_more"><a href="#">MORE</a></div>
                    </div>
                    <div class="home_content1_right_text_all">
                        <ul>
                            <asp:Repeater runat="server" ID="rpLMlist">
                                <ItemTemplate>
                                    <li><a href="#">•&nbsp;&nbsp;<%#Utils.CutString(Eval("Title"),37) %></a></li>
                                </ItemTemplate>
                            </asp:Repeater>

                        </ul>
                    </div>
                    <%--    <div class="home_content2_left_xia">
          <div class="home_content2_left_xia_one">
            <div class="home_content2_left_xia_one_left"><img src="image/bal-text.jpg" /></div>
            <div class="home_content2_left_xia_one_right">
              <div class="home_content2_left_xia_one_right_shang"><a href="#">全省高校武装部部长培训班</a></div>
              <div class="home_content2_left_xia_one_right_xia"><a href="#">4月23日至25日，省教育厅、省军区战备建设局、省军区动员局...</a></div>
            </div>
          </div>
          <div class="home_content2_left_xia_one">
            <div class="home_content2_left_xia_one_left"><img src="image/bal-text.jpg" /></div>
            <div class="home_content2_left_xia_one_right">
              <div class="home_content2_left_xia_one_right_shang"><a href="#">全省高校武装部部长培训班</a></div>
              <div class="home_content2_left_xia_one_right_xia"><a href="#">4月23日至25日，省教育厅、省军区战备建设局、省军区动员局...</a></div>
            </div>
          </div>
          <div class="home_content2_left_xia_one">
            <div class="home_content2_left_xia_one_left"><img src="image/bal-text.jpg" /></div>
            <div class="home_content2_left_xia_one_right">
              <div class="home_content2_left_xia_one_right_shang"><a href="#">全省高校武装部部长培训班</a></div>
              <div class="home_content2_left_xia_one_right_xia"><a href="#">4月23日至25日，省教育厅、省军区战备建设局、省军区动员局...</a></div>
            </div>
          </div>
        </div>--%>
                </div>
                <div class="home_content2_middle">
                    <div class="home_content1_right_title">
                        <div class="home_news"><a href="#">团队动态</a></div>
                        <div class="home_more"><a href="#">MORE</a></div>
                    </div>
                    <div class="home_content1_right_text_all">
                        <ul>
                            <asp:Repeater runat="server" ID="rpTDlist">
                                <ItemTemplate>
                                    <li><a href="#">•&nbsp;&nbsp;<%#Utils.CutString(Eval("Title"),37) %></a></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </div>
                <asp:Panel runat="server" ID="plLogin">
                      <div class="home_content2_right">
                    <div>
                        <div class="home_content2_right_title">用户登录</div>

                        <div class="home_content2_right_text">
                            <div class="home_content2_right_text_one">
                                <input type="text" value="" placeholder="请输入用户名" />
                            </div>
                        </div>
                        <div class="home_content2_right_text">
                            <div class="home_content2_right_text_one">
                                <input type="text" value="" placeholder="请输入密码" />
                            </div>
                            <div class="home_content2_right_text">
                                <div class="home_content2_right_text_one1">
                                    <input type="text" value="" placeholder="请输入验证码" />
                                    <div class="home_content2_icon">
                                        <img src="image/yanzheng.png" />
                                    </div>
                                </div>
                                <div class="home_content2_right_text">
                                    <div class="home_content2_right_text_one2">
                                        <div class="home_content2_right_text_one2_left"><a href="javascript:Register();">用户注册</a></div>
                                        <div class="home_content2_right_text_one2_right"><a href="../Login.aspx" target="_blank">管理员登录</a></div>
                                    </div>
                                </div>
                                <div class="home_content2_right_text">
                                    <div class="home_content2_right_text_one2">
                                        <div class="home_login"><a href="#">登录</a></div>
                                        <div class="home_clear"><a href="#">清除</a></div>
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
            <div class="freind_left">友情链接:</div>
            <div class="freind_right">

                <select name="教育信息网站" style="width: 272px; height: 25px;">
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
                </select>

            </div>
        </div>
    </div>


</asp:Content>
