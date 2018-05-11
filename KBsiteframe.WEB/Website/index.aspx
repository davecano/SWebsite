<%@ Page Title="" Language="C#" MasterPageFile="~/Website/Master/KBSiteframe.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="KBsiteframe.WEB.Website.index" %>
<%@ Import Namespace="Z" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>index</title>
<link href="Css/style.css" rel="stylesheet" type="text/css" />  
  <link href="Css/bootstrap.min.css" rel="stylesheet"/>
    
  

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="home_content_all">
  <div class="home_content">
    <div class="home_content1">
      <div class="home_content1_left">
     <%--   <div class="home_content1_left_picture">
          <div class="home_content1_left_picture_shang"><img src="image/ball-da.png" /></div>
          <div class="home_content1_left_picture_xia_all">
            <div class="home_content1_left_picture_xia"><img src="image/ball-lun.png" /></div>
            <div class="home_content1_left_picture_xia"><img src="image/ball-lun.png" /></div>
            <div class="home_content1_left_picture_xia1"><img src="image/ball-lun.png" /></div>
          </div>
        </div>--%>
          
     <div id="myCarousel" class="carousel slide home_content1_left_picture">
    <!-- 轮播（Carousel）指标 -->
    <ol class="carousel-indicators home_content1_left_picture_xia" >
        <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
        <li data-target="#myCarousel" data-slide-to="1"></li>
        <li data-target="#myCarousel" data-slide-to="2"></li>
    </ol>   
    <!-- 轮播（Carousel）项目 -->
    <div class="carousel-inner home_content1_left_picture_shang">
        <div class="item active">
            <img src="<%=piclist?[0]?.NewsPicPath %>"   alt="<%=piclist?[0]?.Title %>">
            <div class="carousel-caption text-center"><%=Utils.CutString(piclist?[0]?.Title,6)%></div>
        </div>
        <div class="item">
             <img src="<%=piclist?[1]?.NewsPicPath %>"  alt="<%=piclist?[1]?.Title %>">
            <div class="carousel-caption text-center"><%=Utils.CutString(piclist?[1]?.Title,6) %></div>
        </div>
        <div class="item">
             <img src="<%=piclist?[2]?.NewsPicPath %>"  alt="<%=piclist?[2]?.Title %>">
            <div class="carousel-caption text-center"><%=Utils.CutString(piclist?[2]?.Title,6) %></div>
        </div>
    </div>
    <!-- 轮播（Carousel）导航 -->
 <%--   <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
        <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
        <span class="sr-only">Previous</span>
    </a>
    <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
        <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
        <span class="sr-only">Next</span>
    </a>--%>
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
                       <li><a href="#">•&nbsp;&nbsp;<%#Utils.CutString(Eval("Title"),37) %></a></li>
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
                       <li><a href="#">•&nbsp;&nbsp;<%#Utils.CutString(Eval("NoticeTitle"),37) %></a></li>
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
      <div class="home_content2_right">
        <form action="" method="get">
          <div class="home_content2_right_title">用户登录</div>
         
          <div class="home_content2_right_text">
            <div class="home_content2_right_text_one">
              <input type="text" value="" placeholder="请输入用户名"/>
            </div>
          </div>
          <div class="home_content2_right_text">
            <div class="home_content2_right_text_one">
              <input type="text" value="" placeholder="请输入密码"/>
            </div>
            <div class="home_content2_right_text">
              <div class="home_content2_right_text_one1">
                <input type="text" value="" placeholder="请输入验证码"/>
                <div class="home_content2_icon"><img src="image/yanzheng.png" /></div>
              </div>
              <div class="home_content2_right_text">
                <div class="home_content2_right_text_one2">
                  <div class="home_content2_right_text_one2_left">用户注册</div>
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
        </form>
      </div>
    </div>
  </div>
</div>
<div id="friend">
  <div class="friend_middle">
    <div class="freind_left">友情链接:</div>
    <div class="freind_right">
     
        <select name="教育信息网站"style="width:272px;height:25px;">
          <option>教育信息网站</option>
          <option selected="selected">教育信息网站</option>
        </select>
        <select name="教育咨询网站"  id="seclect"style="width:272px;height:25px;">
          <option>教育咨询网站</option>
          <option selected="selected">教育咨询网站</option>
        </select>
        <select name="教育协会网站" id="seclect"style="width:272px;height:25px;">
          <option>教育协会网站</option>
          <option selected="selected">教育协会网站</option>
        </select>
     
    </div>
  </div>
</div>
        <script type="text/javascript" src="Js/jquery.js"></script>
    <script type="text/javascript" src="Js/bootstrap.js"></script>

</asp:Content>
