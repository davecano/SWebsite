<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="KBsiteframe.Web.Share.Index" %>

<%@ Register Assembly="Zlib" Namespace="Z" TagPrefix="cc1" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=9" />
    <meta charset="utf-8" />
    <title>kbsiteframe后台管理</title>
    
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <!-- basic styles -->
    <link href="../assets/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="../assets/css/font-awesome.min.css" />

    <!--[if IE 7]>
		  <link rel="stylesheet" href="../assets/css/font-awesome-ie7.min.css" />
		<![endif]-->
    <link rel="stylesheet" href="../assets/css/ace.min.css" />
    <link rel="stylesheet" href="../assets/css/ace-rtl.min.css" />
    <link rel="stylesheet" href="../assets/css/ace-skins.min.css" />

    <!--[if lte IE 8]>
		  <link rel="stylesheet" href="../assets/css/ace-ie.min.css" />
		<![endif]-->
    <!-- ace settings handler -->

    <script src="../assets/js/ace-extra.min.js"></script>

    <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->

    <!--[if lt IE 9]>
		<script src="../assets/js/html5shiv.js"></script>
		<script src="../assets/js/respond.min.js"></script>
		<![endif]-->
    <style>
        html {
        overflow:hidden;}
    </style>
</head>
<body>
    <form id="form1" runat="server" onKeyDown="return KeyDown()">
        <div class="navbar navbar-default" id="navbar">
            <script type="text/javascript">
                try { ace.settings.check('navbar', 'fixed') } catch (e) { }
            </script>

            <div class="navbar-container" id="navbar-container">
                <div class="navbar-header pull-left">
                    <a href="#" class="navbar-brand">
                        <small>
                            <%--<i class="icon-legal"></i>--%>
                            <b>kbsiteframe后台管理</b>
                        </small>
                    </a>
                    <!-- /.brand -->
                </div>
                <!-- /.navbar-header -->

                <div class="navbar-header pull-right" role="navigation">
                    <ul class="nav ace-nav">
                        <li class="purple" title="网站首页">
                            <a href="right.aspx" target="frmright">
                                <i class="icon-home"></i>
                            </a>
                        </li>
                        
                        <li class="light-blue">
                            <a data-toggle="dropdown" href="#" class="dropdown-toggle">
                                <img class="nav-user-photo" src="/assets/avatars/avatar2.png"/>
                                <span class="user-info">
                                    <small>欢迎您,</small>
                                    <asp:Label ID="lblUser" runat="server"></asp:Label>
                                </span>

                                <i class="icon-caret-down"></i>
                            </a>

                            <ul class="user-menu pull-right dropdown-menu dropdown-yellow dropdown-caret dropdown-close">
                                <li>
                                    <asp:HyperLink runat="server" ID="HpUserMsg" Target="frmright">
                                 
                                        <i class="icon-user"></i>
                                        个人资料
                                   </asp:HyperLink>
                                </li>
                                <li class="">
                                    <script type="text/javascript">
                                       
                                    </script>
                                    <asp:HiddenField ID="HfPsw" runat="server" />
                                    <a  href="javascript:getUrl();" >
                                        <i class="icon-cog"></i>
                                        修改密码
                                    </a>
                                </li>
                                <li class="divider"></li>
                                <li>
                                    
                                    <cc1:ZLinkButton ID="zlbquit" runat="server" OnClick="zlbquit_Click" OnClientClick="return confirm('确定要退出系统吗？')">
                                        <i class="icon-off"></i>
                                        退出
                                    </cc1:ZLinkButton>
                                </li>
                            </ul>
                        </li>
                    </ul>
                    <!-- /.ace-nav -->
                </div>
                <!-- /.navbar-header -->
            </div>
            <!-- /.container -->
        </div>

        <div class="main-container" id="main-container">
            <script type="text/javascript">
                try { ace.settings.check('main-container', 'fixed') } catch (e) { }
            </script>

            <div class="main-container-inner">
                <a class="menu-toggler" id="menu-toggler" href="#">
                    <span class="menu-text"></span>
                </a>

                <!--左侧-->
                <div class="sidebar" id="sidebar">
                    <script type="text/javascript">
                        try { ace.settings.check('sidebar', 'fixed') } catch (e) { }
                    </script>

                    
                    <!-- #左侧菜单 -->
                    <asp:Literal ID="litmenu" runat="server"></asp:Literal>

                    <!-- 菜单结束 -->

                    <div class="sidebar-collapse" id="sidebar-collapse">
                        <i class="icon-angle-double-left" data-icon1="icon-angle-double-left" data-icon2="icon-angle-double-right"></i>
                    </div>

                    <script type="text/javascript">
                        try { ace.settings.check('sidebar', 'collapsed') } catch (e) { }
                    </script>
                </div>
                <!--左侧结束-->
                <!--内容开始-->
                <div class="main-content" style="padding-right:0px;margin-right:-15px">
                    <div class="breadcrumbs" id="breadcrumbs">
                        <script type="text/javascript">
                            try { ace.settings.check('breadcrumbs', 'fixed') } catch (e) { }
                        </script>

                        <ul class="breadcrumb">
                            <li>
                                <i class="icon-home home-icon"></i>
                                <a href="Index.aspx">首页</a>
                            </li>
                            <li class="active">
                                <span id="barName"></span>
                            </li>
                        </ul>
                        <!-- .breadcrumb -->
                    </div>

                    <div class="page-content" id="divContent"  >
                        <!--主体内容开始-->
                      <iframe id="frmright" name="frmright"  style="border:none;margin:0;padding:0px;width:100%"  src="right.aspx"></iframe>
                        <!--主体内容结束-->
                    </div>
                </div>

            </div>
            <!--定位到头部 -->
            <a href="#" id="btn-scroll-up" class="btn-scroll-up btn btn-sm btn-inverse">
                <i class="icon-double-angle-up icon-only bigger-110"></i>
            </a>
        </div>
        <!-- 内容结束 -->

    </form>
    <!-- basic scripts -->

    <!--[if !IE]> -->

    <script src="/assets/js/jquery-2.0.3.min.js"></script>

    <!-- <![endif]-->

    <!--[if IE]>
<script src="/assets/js/jquery-1.10.2.min.js"></script>
<![endif]-->

    <!--[if !IE]> -->

    <script type="text/javascript">
        window.jQuery || document.write("<script src='/assets/js/jquery-2.0.3.min.js'>" + "<" + "script>");
    </script>

    <!-- <![endif]-->

    <!--[if IE]>
    <script type="text/javascript">
        window.jQuery || document.write("<script src='/assets/js/jquery-1.10.2.min.js'>"+"<"+"script>");
    </script>
    <![endif]-->

    <script type="text/javascript">
        if ("ontouchend" in document) document.write("<script src='/assets/js/jquery.mobile.custom.min.js'>" + "<" + "script>");
    </script>
    <script src="../assets/js/bootstrap.min.js"></script>
    <script src="../assets/js/typeahead-bs2.min.js"></script>

    <!-- page specific plugin scripts -->

    <!--[if lte IE 8]>
		  <script src="/assets/js/excanvas.min.js"></script>
		<![endif]-->

    <script src="../assets/js/jquery-ui-1.10.3.custom.min.js"></script>
    <script src="../assets/js/jquery.ui.touch-punch.min.js"></script>
    <script src="../assets/js/jquery.slimscroll.min.js"></script>
    <script src="../assets/js/jquery.easy-pie-chart.min.js"></script>
    <script src="../assets/js/jquery.sparkline.min.js"></script>
    <script src="../assets/js/flot/jquery.flot.min.js"></script>
    <script src="../assets/js/flot/jquery.flot.pie.min.js"></script>
    <script src="../assets/js/flot/jquery.flot.resize.min.js"></script>

    <!-- ace scripts -->

    <script src="../assets/js/ace-elements.min.js"></script>
    <script src="../assets/js/ace.min.js"></script>
	<script src="../js/layer/layer.min.js"></script>
     <script type="text/javascript" src="../js/Common.js"></script>
        <script type="text/javascript">
            function getUrl() {

                var key = $("#HfPsw").val();
              
                ShowIframe("用户修改密码", "/Share/UpdatePassword.aspx?ID=" + key, '780px', '400px');
             
                return false;

            }
            //加载时适应浏览器高度
            $(document).ready(function () {
             
                //模块尺寸
                $('#frmright').css('height', $(window).height() - 100);
                //菜单点击事件
                $("ul.nav-list a").bind("click", function () {
                    var href=$(this).attr("href");
                    if (href == "" || href == "#") {
                    }
                    else {
                        //子节点
                        $("ul.nav-list li").removeClass("active");
                        $(this).closest('li').addClass("active");
                        $(this).closest('li').closest('ul').closest('li').addClass("active");
                    }
               
                });
            })
            //改变窗体大小时适应浏览器高度
            $(window).resize(function () {
                //模块尺寸
                $('#frmright').css('height', $(window).height() - 100);
            });

            function changeBarName(menuName)
            {
                $("#barName").text(menuName);
            }

            function changesrc() {
                if (getRequestQueryString("Dicurl") != null) {
                    document.getElementById("frmright").src = getRequestQueryString("Dicurl")
                    $("#frmright").attr("src", getRequestQueryString("Dicurl"));

                }
                else {
                    $("#frmright").attr("src", "right.aspx");
                }
            }

            function getRequestQueryString(key) {
                var QueryString = location.search;
                if (QueryString.indexOf("?") != -1) {
                    var str = QueryString.substr(1);
                    str = str.replace(key + "=", "");
                    if ("returnUrl=%2flogin.aspx".toLowerCase() == str.toLowerCase() || "returnUrl=%2findex.aspx".toLowerCase() == str.toLowerCase() || "returnUrl=%2fShare%2fRegister.aspx".toLowerCase() == str.toLowerCase()) {
                        return null;
                    }
                    return str;
                }
                return null;
            }
            window.onload = changesrc;


            //function showMessage() {
            
            //    var pageurl = 'Index.aspx/GetMessage';
            //    $.ajax({
            //        type: 'POST',//使用get方法访问后台
            //        dataType: 'json',//返回json格式的数据
            //        contentType: "application/json;charset=utf-8",
            //        url: pageurl,//要访问的后台地址
            //        data: '',//要发送的数据
            //        error: function (errorThrown) {//请求错误时执行的方法 
            //            //alert("error!" + errorThrown.error);
            //        },
            //        success: function (data) {
            //            $.each(eval(data.d), function (i, n) {

            //                if (n.html != "") {
            //                    $.layer({
            //                        type: 1, // 层的类型。0：信息框（默认），1：页面层，2：iframe层，3：加载层，4：tips层。
            //                        shade: [0], // 控制遮罩。
            //                        time: 20, // 1分钟关闭
            //                        title: ['消息提醒', 'border:none; background:#438eb9; color:#fff;height:30px;font-size:12px;font-weight:bold;'], //自定义标题风格，如果不需要，直接title: '标题' 即可
            //                        area: ['300px', '340px'], //控制层宽高。 area值分别为：[宽度, 高度]
            //                        border: [2, 0.3, '#000'], // 控制层的边框,border的值分别为：[边框大小, 透明度, 颜色]
            //                        shift: 'right-bottom',  // 用于控制动画弹出 有七种选择：左上(left-top),上(top), 右上(right-top),右下(right-bottom),下(bottom),左下(left-bottom),左('left')。
            //                        page: {
            //                            html: n.html // 页面层模式私有参数。 dom: 页面已存在的选择器 html: 直接传入的html字符串。url: ajax请求地址。 ok: ajax请求完毕后执行的回调，datas是异步传递过来的值。 
            //                        }
            //                    });
            //                }
            //            })

                    
            //        }
            //    });


            
            //}


            // 每隔2分钟刷新一次提示消息
            var int = window.setInterval(function () {
                showMessage();
            }, 30000);


            function KeyDown(){   
                if(event.keyCode==13) {    //在页面form中，按回车不触发事件   
                    return false;
                }
            }

        </script>

</body>
</html>
